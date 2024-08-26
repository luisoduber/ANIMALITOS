using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ventas_loteria
{
    public partial class frm_ventas : Form
    {
        public frm_ventas()
        {
            InitializeComponent();
        }

        clsMet objVentas = new clsMet();
        DataTable dtDgvLot = new DataTable();
        DataTable dtDgvJug = new DataTable();
        DataTable dtNombProd = new DataTable();
        crear_ticket ticket = new crear_ticket();

        string idTck = "";
        int idLot = 0, idSort = 0;
        int idUsu= 0, codMaxProd=0;
        string nombLot = "", nombSort = "";
        double mTotalJug = 0;
        double mJug=0;
        int id_proceso = 0;
        
        int nroFila = 0;
        int rsVerfSort;
        string fechaHoraServ = "";
        string rsJug = "";

        string abrevLot = "", msjInfo = "";
        DateTime horaServ,horaSort,horaSortJug;
        Boolean validBorraJug = false;

        string fechaHora = "", FechaAct = "";
        string[] rsDat = null;
        string HoraAct = "";
private void frm_ventas_Load(object sender, EventArgs e)
{
    this.Text="Ventas Taquilla.";
    tmpReloj.Enabled = true;
    tmpReloj.Interval = 1000;

    tmpProceso.Enabled = true;
    tmpProceso.Interval = 60000;

    this.dgvLot.AllowUserToAddRows = false;
    this.dgvLot.RowHeadersVisible = false;

    this.dgvJug.AllowUserToAddRows = false;
    this.dgvJug.RowHeadersVisible = false;
    this.dgvJug.ColumnHeadersVisible = false;

    dtDgvJug.Columns.Add("abrev_loteria", typeof(string));
    dtDgvJug.Columns.Add("hora_sorteo", typeof(string));
    dtDgvJug.Columns.Add("codigo_jugada", typeof(string));
    dtDgvJug.Columns.Add("nomb_product", typeof(string));
    dtDgvJug.Columns.Add("monto", typeof(string));
    dtDgvJug.Columns.Add("id_loteria", typeof(string));
    dtDgvJug.Columns.Add("id_sorteo", typeof(string));
    dtDgvJug.Columns.Add("nomb_loteria", typeof(string));

    idUsu = Convert.ToInt32(clsMet.idUsu);
    this.KeyPreview=true;

    LblNombDivisa.Text = clsMet.NombDivisa.ToUpper();
    lblTotVenta.Text ="0,00";
    lblTotPag.Text = "0,00";
    lblTotAnul.Text = "0,00";
    lblTotCaja.Text = "0,00";
    lblUltTick.Text = "0,00";

    this.work_inicia_frm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.work_inicia_frm_DoWork);
    this.work_inicia_frm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.work_inicia_frm_OnProgressChanged);
    this.work_inicia_frm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.work_inicia_frm_OnRunWorkerCompleted);
    this.work_inicia_frm.RunWorkerAsync();

    this.work_proc_sorteos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.work_proc_sorteos_DoWork);
    this.work_proc_sorteos.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.work_proc_sorteos_ProgressChanged);
    this.work_proc_sorteos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.work_proc_sorteos_OnRunWorkerCompleted);

    lblMontJug.Text = "0.00";
    txt_monto_jug.Text = "0";  
}
private void work_inicia_frm_DoWork(object sender, DoWorkEventArgs e)
{
    try
    {
        dtDgvLot= objVentas.busLot(idUsu);
        dtNombProd= objVentas.busNombProd();
        fechaHoraServ = objVentas.verfHoraServ(idUsu);
        rsDat = objVentas.busFechHoraServ();
       
        id_proceso = 1;
        work_inicia_frm.CancelAsync();
    }
    catch (Exception ex)
    {
      id_proceso = 0;
      MessageBox.Show(ex.Message, "Verifique.");
    }
}
private void work_inicia_frm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
{
}
private void work_inicia_frm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
{
    if (id_proceso == 1)
    {
        clsMet.FechaActual = Convert.ToDateTime(rsDat[0].ToString()).ToString("yyyy/MM/dd");
        FechaAct = Convert.ToDateTime(rsDat[0].ToString()).ToString("dd/MM/yyyy");
        HoraAct = Convert.ToDateTime(rsDat[1].ToString()).ToString("hh:mm:ss");

        this.Text = "Usuario:";
        this.Text += clsMet.nombUsu.ToUpper();
        this.Text += " - Fecha: ";
        this.Text += FechaAct;

        dgvLot.DataSource = dtDgvLot;
        horaServ = Convert.ToDateTime(fechaHoraServ);
        msjInfo = "Hora Cierre: ";
        msjInfo += Convert.ToDateTime(fechaHoraServ).ToString("hh:mm:ss");
        lblHoraCierre.Text = msjInfo;
        busCuadDiario();
    }
}
delegate void delProcSort(int prmIdSort);
private void procSort(int prmIdSort)
{
    int i = 0, idSort = 0;
    while (i < dgvLot.RowCount)
    {
        idSort = Convert.ToInt32(dgvLot.Rows[i].Cells[2].Value.ToString());
        if (idSort == prmIdSort) { dgvLot.Rows.RemoveAt(i); }
        else { i++; }
    }
}
delegate void delProcJug(int prmIdSort);
private void procJug(int prmIdSort)
{
    int i = 0, idSort = 0;
    while (i < dgvJug.RowCount)
    {
        idSort = Convert.ToInt32(dgvJug.Rows[i].Cells[6].Value.ToString());
        if (idSort == prmIdSort)
        {
            //MessageBox.Show("jugadas: " + prm_id_sorteo + "  i:" + i);
             dgvJug.Rows.RemoveAt(i);
        }
        else { i++; }
    }
 }
private void tmpReloj_Tick(object sender, EventArgs e)
{
    horaServ= horaServ.AddSeconds(1);
    msjInfo = "Hora Cierre: " + horaServ.ToString("hh:mm:ss");
    lblHoraCierre.Text = msjInfo;
}
private void tmpProceso_Tick(object sender, EventArgs e)
{
    if (dgvLot.RowCount > 0)
    {
         if (!this.work_proc_sorteos.IsBusy) { work_proc_sorteos.RunWorkerAsync(); }
    }
}
private void work_proc_sorteos_DoWork(object sender, DoWorkEventArgs e)
{
    delProcSort delegado = new delProcSort(procSort);
    delProcJug delJug = new delProcJug(procJug);
    int i = 0; string fechaActual = "";

    try
    {
        if (dgvLot.RowCount > 0)
        {
            while (i < dgvLot.RowCount)
            {
                idSort = Convert.ToInt32(dgvLot.Rows[i].Cells[2].Value.ToString());
                fechaActual = "";
                fechaActual = Convert.ToDateTime(horaServ).ToString("yyyyy-MM-dd");
                fechaActual += " " + dgvLot.Rows[i].Cells[5].Value.ToString();
                horaSort = Convert.ToDateTime(fechaActual);
                codMaxProd = 36;
                rsVerfSort = DateTime.Compare(horaServ, horaSort);
                /*
                string msjInfo = "";
                msjInfo = "resultado sorteo: " + rsVerfSort;
                msjInfo += " hora server: " + hora_server.ToString();
                msjInfo += " hora sorteo: " + hora_sorteo.ToString();
                MessageBox.Show(msjInfo);*/
                        
                if (rsVerfSort >= 0)
                {
                    object[] parametros = new object[] { idSort };
                    this.Invoke(delegado, parametros);
                }
                else { i++; }
                work_proc_sorteos.ReportProgress(i);
             }
        }
        idLot = 0; idSort = 0;

        /////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////

        int v1=0, v2=0, c = 0;
        int rsVerfJug=0;

        if (dgvJug.RowCount > 0)
        {
            while (c < dgvJug.RowCount)
            {
                idSort = Convert.ToInt32(dgvJug.Rows[c].Cells[6].Value.ToString());
                fechaActual = "";
                fechaActual = Convert.ToDateTime(horaServ).ToString("yyyyy-MM-dd");
                fechaActual += " " + dgvJug.Rows[c].Cells[1].Value.ToString();
                horaSortJug = Convert.ToDateTime(fechaActual);
                rsVerfJug = DateTime.Compare(horaServ, horaSortJug);
                /*
                    string msjInfo = "";
                    msj_info = "resultado jugada: " + rsVerfJug;
                    msj_info += " hora servidor: " + hora_server.ToString();
                    msj_info += " hora jugada: " + hora_sorteo_jug.ToString();
                    MessageBox.Show(msj_info);*/
                        
                if (rsVerfJug >= 0)
                {
                    object[] prmJug = new object[] { idSort };
                    this.Invoke(delJug, prmJug);
                    validBorraJug = true;
                }
                else { c++; }
            }
        }
        idLot = 0; idSort = 0;
        id_proceso = 1;
        work_inicia_frm.CancelAsync();
    }
    catch (Exception ex) { id_proceso = 0; MessageBox.Show("Ha Ocurrido el siguiente error: "+ ex.Message,"Verifique."); }
}
private void work_proc_sorteos_ProgressChanged(object sender, ProgressChangedEventArgs e)
{
    lblHoraCierre.Text = msjInfo;
}
private void work_proc_sorteos_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
{
    if (id_proceso==0) { refresc(); }
    if (validBorraJug == true) { busMontTotJug(); } //SI ELIMINA JUGADA DE SORTEO CERRADO ACTUALIZA EL MONTO DEL TICKET
}
private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
{
    if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
    else
    if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
    else { e.Handled = true; }

    char caracter;
    int codigo;
    caracter = Convert.ToChar(e.KeyChar);
    codigo = (int)caracter;

    if (codigo == 13)
    {
        Boolean rsValid = false;
        rsValid = validFrm();
        if (rsValid == false) { return; }

        Boolean rsValidJug = false;
        rsValidJug = valJug();
        if (rsValidJug == false) { return; }

        int  v1=0, v2=0;
        string c1="";
        Boolean validar=true;

        foreach (DataGridViewRow row in dgvLot.Rows)
        {
            DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
            if (Convert.ToBoolean(cell.Value) == true)
            {
                idLot = 0; idSort = 0;
                nombLot  = ""; abrevLot = "";
                idLot = Convert.ToInt32(row.Cells[1].Value.ToString());
                idSort = Convert.ToInt32(row.Cells[2].Value.ToString());
                nombLot  = row.Cells[4].Value.ToString();
                horaSortJug= Convert.ToDateTime(row.Cells[5].Value.ToString());
                abrevLot = row.Cells[7].Value.ToString();

                if (dgvJug.RowCount == 0)
                { 
                    if (Convert.ToInt32(clsMet.montMaxTck) < Convert.ToInt32(txtMonto.Text))
                    {
                        msjInfo = "El maximo por ticket es de: ";
                        msjInfo += clsMet.montMaxTck.ToString("N2");
                        MessageBox.Show(msjInfo, "Verifique.");
                        txtMonto.Focus();
                        validar = false;
                    }
                }
                     
                else if (dgvJug.RowCount > 0)
                {
                    for (int c = 0; c < dgvJug.RowCount; c++)
                    {
                        c1 =dgvJug.Rows[c].Cells[2].Value.ToString();
                        v1 = Convert.ToInt32(dgvJug.Rows[c].Cells[5].Value.ToString());
                        v2 = Convert.ToInt32(dgvJug.Rows[c].Cells[6].Value.ToString());
       
                        mTotalJug = mTotalJug + 
                                    Convert.ToDouble(txt_monto_jug.Text) +
                                    Convert.ToDouble(txtMonto.Text);

                       if (Convert.ToInt32(clsMet.montMaxTck) < Convert.ToInt32(mTotalJug))
                       {
                            msjInfo = "El maximo por ticket es de: ";
                             msjInfo += clsMet.montMaxTck.ToString("N2");
                             MessageBox.Show(msjInfo, "Verifique.");
                             txtMonto.Focus();

                            mTotalJug = 0;
                            validar = false;
                            busMontTotJug();
                            break;
                       }
                        else if ((c1 == txtCodigo.Text) && (v1 == idLot) && (v2 == idSort))
                        {
                            mTotalJug = Convert.ToInt64(txtMonto.Text) + 
                            Convert.ToDouble(this.dgvJug.Rows[c].Cells[4].Value.ToString());

                            if (mTotalJug > Convert.ToInt64(clsMet.monto_max_jug))
                            { mTotalJug = Convert.ToInt64(clsMet.monto_max_jug);  }
                            this.dgvJug.Rows[c].Cells[4].Value = Convert.ToDouble(mTotalJug).ToString("N2");

                            mTotalJug = 0;
                            validar = false;
                            busMontTotJug();
                            break;
                           
                        }
                        else { mTotalJug = 0; validar = true; }
                    }
                }
                if (validar==true)
                {
                    int dtIdlot=0;
                    string dtCodJug="", dtCNombProd="";

                    for (int c = 0; c<=dtNombProd.Rows.Count; c++)
                    {
                        dtIdlot=Convert.ToInt16(dtNombProd.Rows[c][0].ToString());
                        dtCodJug=dtNombProd.Rows[c][1].ToString();
                        dtCNombProd=dtNombProd.Rows[c][2].ToString();
                        dtCNombProd=dtCNombProd.Substring(0,3);

                        if ((idLot==dtIdlot) && (txtCodigo.Text == dtCodJug)){ break; }
                    }

                    DataRow fila_dgv = dtDgvJug.NewRow();
                    fila_dgv["abrev_loteria"]= abrevLot;
                    fila_dgv["hora_sorteo"] = Convert.ToDateTime(horaSortJug.ToString()).ToString("HH:mm:ss");
                    fila_dgv["codigo_jugada"]= txtCodigo.Text;
                    fila_dgv["nomb_product"]= dtCNombProd.ToUpper();
                    fila_dgv["monto"]=Convert.ToDouble(txtMonto.Text).ToString("N2");
                    fila_dgv["id_loteria"]= idLot;
                    fila_dgv["id_sorteo"]= idSort;
                    fila_dgv["nomb_loteria"]= nombLot;

                    dtDgvJug.Rows.Add(fila_dgv);
                    DataView dv = new DataView(dtDgvJug);
                    dv.Sort = "id_sorteo ASC, id_loteria DESC";
                    dgvJug.DataSource = dv;
                    busMontTotJug();
                } 
            }  
        }
        limpSelJug();
    
    }
}
public void busMontTotJug()
{    
    for (int c = 0; c < dgvJug.RowCount; c++)
    {
       mJug= Convert.ToDouble(dgvJug.Rows[c].Cells[4].Value.ToString());
       mTotalJug = mTotalJug + mJug;
    }
    txt_monto_jug.Text = mTotalJug.ToString();
    lblMontJug.Text = mTotalJug.ToString("N2");
    mTotalJug = 0;
} 
public void limpSelJug()
{
    txtCodigo.Text = "";
    txtCodigo.Focus();
    txtMonto.SelectionStart = 0;
    txtMonto.SelectionLength = txtMonto.Text.Length;
}
public void busCuadDiario()
{
    try
    {
        string rsCuadCajDiario = "";
        String[] rsDatCuadCajDiario = null;

        rsCuadCajDiario = objVentas.busCuadCajDiario(Convert.ToInt32(clsMet.idUsu));
        rsDatCuadCajDiario = rsCuadCajDiario.Split('?');
        lblTotVenta.Text = Convert.ToInt32(rsDatCuadCajDiario[0]).ToString("N2");
        lblTotPag.Text = Convert.ToInt32(rsDatCuadCajDiario[1]).ToString("N2");
        lblTotAnul.Text = Convert.ToInt32(rsDatCuadCajDiario[2]).ToString("N2");
        lblTotCaja.Text = Convert.ToInt32(rsDatCuadCajDiario[3]).ToString("N2");
        lblUltTick.Text = rsDatCuadCajDiario[4].ToString();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Ha ocurrido el siguiente error: "+ ex.Message,"Verifique...");
    }
}
private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
{
    if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
    else
    if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
    else { e.Handled = true; }

    char caracter;
    int codigo;
    caracter = Convert.ToChar(e.KeyChar);
    codigo = (int)caracter;

    if (codigo == 13) {  if (txtCodigo.Text.Length > 0) { txtMonto.Focus(); } }
}
public Boolean validFrm()
{
    Boolean validar = true;
    if (validLotSort()==false)
    {
        MessageBox.Show("Elija una loteria y sorteo.", "Verifique.");
        validar = false;
    }    
    else if (string.IsNullOrEmpty(txtCodigo.Text))
    {
         MessageBox.Show("Ingrese un codigo.", "Verifique.");
         txtCodigo.Focus();
         validar = false;
    }
    else if (string.IsNullOrEmpty(txtMonto.Text))
    {
        MessageBox.Show("Ingrese un monto.", "Verifique.");
        txtMonto.Focus();
        validar = false;
    }
    else if (Convert.ToInt32(txtCodigo.Text) > Convert.ToInt32(codMaxProd))
    {
        MessageBox.Show("Codigo invalido.", "Verifique.");
        txtCodigo.Focus();
        validar = false;
    }
    else if (txtCodigo.Text.Length == 1)
    {
        if (txtCodigo.Text != "0") { txtCodigo.Text = txtCodigo.Text.PadLeft(2,'0'); }
    }
     return validar;
}
public Boolean valJug()
{
    Boolean validar = true;
    string msjInfo = "";

    double rsDiv = 0;
    rsDiv = Convert.ToDouble(txtMonto.Text) / Convert.ToDouble(clsMet.monto_multiplo_jug);
    string verfNum = rsDiv.ToString();
    int i = 0;
    bool result = int.TryParse(verfNum, out i);

    if (result == false)
    {
        msjInfo  = "El monto de la jugada deben ser multiplos de: ";
        msjInfo += clsMet.monto_multiplo_jug;
        MessageBox.Show(msjInfo, "Verifique.");
        txtMonto.Focus();
        validar = false;
    }
    else if (Convert.ToInt32(clsMet.monto_min_jug) > Convert.ToInt32(txtMonto.Text))
    {
        msjInfo = "El monto  minimo de la jugada debe ser: ";
        msjInfo += clsMet.monto_min_jug.ToString("N2");
        MessageBox.Show(msjInfo, "Verifique.");
        txtMonto.Focus();
        validar = false;
    }
    else if (Convert.ToInt32(clsMet.monto_max_jug) < Convert.ToInt32(txtMonto.Text))
    {
        msjInfo = "El maximo por jugada debe ser: ";
        msjInfo += clsMet.monto_max_jug.ToString("N2");
        MessageBox.Show(msjInfo, "Verifique.");
        txtMonto.Focus();
        validar = false;
    }
 
    return validar;
}
public Boolean validLotSort()
{
    Boolean validar=false;
    foreach (DataGridViewRow row in dgvLot.Rows)
    {
        DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
        if (Convert.ToBoolean(cell.Value) == true) { validar = true; }
    }
    return validar;
}

public string busTitulo(string prmNombLot, string prmNombSort)
{
    string titulo = "";
    int cantDigRest = 0;
    int cantDigRellenIzq = 0;
    int cant_dig_rellen_der = 0;
    titulo = prmNombLot + " " + prmNombSort.Replace(" ", "");

    if (titulo.Length < 45)
    {
        cantDigRest = 45 - titulo.Length;
        cantDigRest = cantDigRest / 2;
        cantDigRellenIzq  = titulo.Length + cantDigRest;
        cant_dig_rellen_der = cantDigRellenIzq + cantDigRest;
        titulo = titulo.PadLeft(cantDigRellenIzq, ' ');
    }
    titulo = titulo + "/";
    return titulo;   
}
private void btn_pagar_ticket_Click(object sender, EventArgs e)
{
    Boolean rsValidFrm = true;
    rsValidFrm  = validFrmTick();
    string rsVerfTick= "";
    Boolean rsValidStatTick = true;

    try
    {
        if (rsValidStatTick == true)
        {
            rsVerfTick = objVentas.verfStatTicket(
            Convert.ToInt32(clsMet.idUsu),
            txtNroTick.Text, txtNroSerial.Text);

            if (string.IsNullOrEmpty(rsVerfTick)) rsVerfTick = "0";
            rsValidStatTick = validStatTickPagar(Convert.ToInt32(rsVerfTick));

            if (rsValidStatTick == true)
            {
                string rsActStatTick = "";
                string msjInfo;

                rsActStatTick  = objVentas.actStatTicket
                (Convert.ToInt32(clsMet.idUsu),
                txtNroTick.Text, txtNroSerial.Text);

                if (!string.IsNullOrEmpty(rsActStatTick))
                {
                    msjInfo = "Ticket ganador. Monto a pagar: "; 
                    msjInfo += Convert.ToInt64(rsActStatTick).ToString("N2");
                    MessageBox.Show(msjInfo, "Trasacción Exitosa.");
                    busCuadDiario();
                    txtNroTick.Text = "";
                    txtNroSerial.Text = "";
                }
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Ha ocurrido el siguiente error: "+ ex.Message," Verifique...");
    }
 }
public Boolean validFrmTick()
{
    Boolean validar = true;
    if (string.IsNullOrEmpty(txtNroTick.Text))
    {
        MessageBox.Show("Ingrese Nro. ticket.","Verifique.");
        txtNroTick.Focus();
        validar = false;
    }

    else if (string.IsNullOrEmpty(txtNroSerial.Text))
    {
        MessageBox.Show("Ingrese Nro. Serial.", "Verifique.");
        txtNroSerial.Focus();
        validar = false;
    }
    return validar;
}
public Boolean validStatTickPagar(int prmIdStatTick)
{
    Boolean validar = true;
    if (prmIdStatTick == 0)
    {
        MessageBox.Show("Ticket / serial no existe.","Verifique.");
        txtNroSerial.Focus();
        validar = false;
    }

    else if (prmIdStatTick == 1)
    {
        MessageBox.Show("Ticket pendiente por procesar.", "Verifique.");
        txtNroSerial.Focus();
        validar = false;
    }
    else if (prmIdStatTick == 2)
    {
        MessageBox.Show("Ticket fue anulado.", "Verifique.");
        txtNroSerial.Focus();
        validar = false;
    }
    else if (prmIdStatTick == 3)
    {
        MessageBox.Show("Ticket Perdedor.", "Verifique.");
        txtNroSerial.Focus();
        validar = false;
    }
    else if (prmIdStatTick == 5)
    {
         MessageBox.Show("Ticket Ganador ya fue cobrado.", "Verifique.");
         txtNroSerial.Focus();
         validar = false;
    }
    return validar;
}
private void btn_anular_ticket_Click(object sender, EventArgs e)
{
    Boolean rsValidFrm= true;
    rsValidFrm = validFrmTick();
    string rsVerfTicket = "";
    string rsAnulaTick = "";
    string msjInf="";
    Boolean rsValidStatTick = true;

    try
    {
        if (rsValidFrm == true)
        {
            rsVerfTicket = objVentas.verfStatTicket
            (Convert.ToInt32(clsMet.idUsu),
            txtNroTick.Text, txtNroSerial.Text);

            //MessageBox.Show(rs_verf_ticket_anular);
           if (string.IsNullOrEmpty(rsVerfTicket)) rsVerfTicket = "0";

            rsValidStatTick = validStatTicket
            (Convert.ToInt32(rsVerfTicket));

            if (rsValidStatTick == true)
            {
                rsAnulaTick  = objVentas.verfDetTckAnu(txtNroTick.Text);
                if (rsAnulaTick  == "1")
                {
                    msjInf  = "Ticket nro: " + txtNroTick.Text;
                    msjInf += " fue anulado...";
                    MessageBox.Show(msjInf, "Transacción Exitosa.");
                    busCuadDiario();
                    txtNroTick.Text = "";
                    txtNroSerial.Text = "";
                }
                else if (rsAnulaTick == "0")
                {
                    MessageBox.Show("El ticket ya tiene jugadas en proceso no se podra anular...", "Transacción Fallida.");
                }
            }
         }
     }
    catch (Exception ex)
    {
        MessageBox.Show("Ha ocurrido el siguiente error: " + ex.Message, " Verifique...");
    }
}
public Boolean validStatTicket(int prm_id_status_ticket)
{
    Boolean valida = true;
    if (prm_id_status_ticket == 0)
    {
        MessageBox.Show("Ticket / serial no existe.", "Verifique.");
        txtNroSerial.Focus();
        valida = false;
    }
    else if (prm_id_status_ticket == 2)
    {
        MessageBox.Show("Ticket fue anulado.", "Verifique.");
        txtNroSerial.Focus();
        valida = false;
    }
    else if (prm_id_status_ticket == 3)
    {
        MessageBox.Show("Ticket Perdedor.", "Verifique.");
        txtNroSerial.Focus();
        valida = false;
    }
    else if (prm_id_status_ticket == 4)
    {
        MessageBox.Show("Ticket Ganador. No Cancelado.", "Verifique.");
       txtNroSerial.Focus();
       valida = false;
    }
    else if (prm_id_status_ticket == 5)
    {
        MessageBox.Show("Ticket Ganador ya fue cobrado.", "Verifique.");
        txtNroSerial.Focus();
        valida = false;
    }
    return valida;
}
private void btn_verf_ticket_Click(object sender, EventArgs e)
{
    Boolean rsValidFrm= true;
    rsValidFrm = validFrmTick();
    string rs_verf_exists_ticket = "";
    string msj_info = "";

    if (rsValidFrm == true)
    {
        rs_verf_exists_ticket = objVentas.verfExitsMostTick(
                            Convert.ToInt32(clsMet.idUsu),
                            Convert.ToInt64(txtNroTick.Text),
                             Convert.ToInt64(txtNroSerial.Text));

        if (rs_verf_exists_ticket == "1")
        {
            frm_verf_ticket objVerfTick= new frm_verf_ticket();
            objVerfTick.prmNroTck = txtNroTick.Text;
            objVerfTick.prmNroSerial = txtNroSerial.Text;
            objVerfTick.Show();
        }
        if (rs_verf_exists_ticket == "0")
        {
            msj_info = "Ticket / Serial no existe...";
            MessageBox.Show(msj_info, "Verifique."); 
        }
    }
}
private void btn_mov_venta_ticket_Click(object sender, EventArgs e)
{ 
    frm_verf_status_ticket objVerfStatTick = new frm_verf_status_ticket();
    objVerfStatTick.ShowDialog();
}
private void btn_totales_venta_Click(object sender, EventArgs e)
{
    frm_totales_venta_taq objTotVentaTaq = new frm_totales_venta_taq();
    objTotVentaTaq.ShowDialog();
}
private void btn_imprimir_ticket_Click(object sender, EventArgs e)
{
    if (dgvJug.RowCount == 0) { return; }

    string msjInf = "",  nroTck= "";
    string nroSerial = "", fechaAct = "";
    string fTck = "", hTicket = "";
    Boolean rsProces;
    string codJug= "",  nombProd = "";
    string nombLot = "", nombSort = "";
    DateTime fechaHoraVerf, horaSortJug;
    string[] rsDat = new string[7];
    int rsVerfJug, rsVerfTiempo;
    int cont = 0;
    Boolean sortAb = false;

    clsMet.conectar();
    MySqlCommand cmdGrdTck = new MySqlCommand();
    MySqlCommand cmdDetTck = new MySqlCommand();
    MySqlCommand cmdMontTck = new MySqlCommand();
    MySqlTransaction myTrans = null;
    
    try
    {
        ////////////////////////////////////////////////////////////////////////////////////
        /////////////////REGISTRA TICKET ///////////////////////////////////////////////////

        cmdGrdTck.Connection = clsMet.cn_bd;
        myTrans = clsMet.cn_bd.BeginTransaction();
        cmdGrdTck.CommandType = CommandType.StoredProcedure;
        cmdGrdTck.CommandText = "SP_grd_ticket";
        cmdGrdTck.Parameters.AddWithValue("prm_id_grupo", Convert.ToInt32(clsMet.idGrup));
        cmdGrdTck.Parameters.AddWithValue("prm_id_usuario", Convert.ToInt32(clsMet.idUsu));
        MySqlDataReader dr = cmdGrdTck.ExecuteReader();
        dr.Read();

        if (dr.HasRows)
        {
            rsProces=true;
            rsDat[0]=rsProces.ToString();
            rsDat[1]=dr["prm_cont_ticket"].ToString();
            rsDat[2]=dr["prm_nro_Serial"].ToString();
            rsDat[3]=dr["fecha_ticket"].ToString();
            rsDat[4]=dr["hora_ticket"].ToString();
            rsDat[5]=dr["fechaHoraVerf"].ToString();
            rsDat[6]=dr["prmIdTck"].ToString();
        }
        dr.Close();

        rsProces = Convert.ToBoolean(rsDat[0].ToString());
        nroTck = rsDat[1].ToString();
        nroSerial = rsDat[2].ToString();
        fTck = Convert.ToDateTime(rsDat[3]).ToString("dd/MM/yyyy");
        hTicket = rsDat[4].ToString();
        fechaHoraVerf =Convert.ToDateTime(rsDat[5].ToString());
        idTck= rsDat[6].ToString();
        rsVerfTiempo = DateTime.Compare(fechaHoraVerf, horaServ);
        if (rsVerfTiempo > 0) { horaServ = fechaHoraVerf; }

         ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////REGISTRA DETALLE TICKET ////////////////////////////////////
        int c = 0; 
         while (c < dgvJug.RowCount)
         {
            fechaAct = "";
            fechaAct=Convert.ToDateTime(fechaHoraVerf).ToString("yyy-MM-dd");
            fechaAct+=" " + dgvJug.Rows[c].Cells[1].Value.ToString();
            horaSortJug = Convert.ToDateTime(fechaAct);

            nombSort = dgvJug.Rows[c].Cells[1].Value.ToString();
            codJug = dgvJug.Rows[c].Cells[2].Value.ToString();
            nombProd = dgvJug.Rows[c].Cells[3].Value.ToString();
            mJug = Convert.ToDouble(dgvJug.Rows[c].Cells[4].Value.ToString());
            idLot = Convert.ToInt32(dgvJug.Rows[c].Cells[5].Value.ToString());
            idSort= Convert.ToInt32(dgvJug.Rows[c].Cells[6].Value.ToString());
            nombLot = dgvJug.Rows[c].Cells[7].Value.ToString();
            rsVerfJug = DateTime.Compare(fechaHoraVerf, horaSortJug);
            string rsDat3 = "";

            if (codJug.Length == 1) { if (codJug != "0") { codJug = codJug.PadLeft(2, '0'); } }
            if (rsVerfJug < 0)
            {
                cmdDetTck.Connection = clsMet.cn_bd;
                cmdDetTck.CommandType = CommandType.StoredProcedure;
                cmdDetTck.CommandText = "SP_det_ticket";
                cmdDetTck.Parameters.AddWithValue("prmNroTck", nroTck);
                cmdDetTck.Parameters.AddWithValue("prmIdGrup", Convert.ToInt32(clsMet.idGrup));
                cmdDetTck.Parameters.AddWithValue("prmIdUsu", Convert.ToInt32(clsMet.idUsu));
                cmdDetTck.Parameters.AddWithValue("prmIdLot", idLot);
                cmdDetTck.Parameters.AddWithValue("prmIdSort", idSort);
                cmdDetTck.Parameters.AddWithValue("prmCodJug", codJug);
                cmdDetTck.Parameters.AddWithValue("prmMonto", Convert.ToString(mJug).Replace(",", "."));
                rsDat3 = cmdDetTck.ExecuteNonQuery().ToString();
                cmdDetTck.Parameters.Clear();
                 
                if (Convert.ToInt16(rsDat3) == 0) 
                {
                    msjInf = "El producto:\"" + codJug +" - "+ nombProd + "\"";
                    msjInf += " se encuentra bloqueado.";
                    msjInf += " para la loteria:\"" + nombLot + "\"";
                    MessageBox.Show(msjInf.ToUpper(),"Bloqueado.");
                    dgvJug.Rows.RemoveAt(c); c--;
                }
                else if (Convert.ToInt16(rsDat3) == 1) { cont++; }      
            }
            else if (rsVerfJug >= 0)
            {
                sortAb=true;
                dgvJug.Rows.RemoveAt(c); c--;
            }
                c++;
                codJug = ""; mJug = 0;
                idLot = 0; idSort = 0;
         }

            
         ////////////////////////////////////////////////////////////////////////////////////
         /////////////////////////////IMPRIMIR TICKET////////////////////////////////////////
         if (cont == 0)
         {
            if (clsMet.cn_bd.State == ConnectionState.Open) 
            { myTrans.Rollback(); clsMet.Desconectar(); }

            dtDgvJug.Clear();
            dgvJug.DataSource = dtDgvJug;

            mTotalJug = 0;
            txt_monto_jug.Text = "0";
            lblMontJug.Text = "0.00";

            if (sortAb == true)
            {
                msjInf = "Sorteos cerrados, jugadas no procesadas.";
                MessageBox.Show(msjInf.ToUpper(), "Verifique.");
                refresc();
            }
         }
         else if (cont >= 1)
         {
            busMontTotJug();
            cmdMontTck.Connection = clsMet.cn_bd;
            cmdMontTck.CommandType = CommandType.StoredProcedure;
            cmdMontTck.CommandText = "spActMontTck";
            cmdMontTck.Parameters.AddWithValue("prmIdTck", idTck);
            cmdMontTck.Parameters.AddWithValue("prmMont", Convert.ToString(txt_monto_jug.Text).Replace(",", "."));
            cmdMontTck.ExecuteNonQuery().ToString();

            string monto="", cadResult = "";
            int idLotAnt = 0, idLotSig = 0;
            int idSortAnt = 0, idSortSig = 0;
            
            int cont_jud = 0;
            for (int d = 0; d < dgvJug.RowCount; d++)
            {
                cont_jud++;
                nombSort = dgvJug.Rows[d].Cells[1].Value.ToString();
                codJug = dgvJug.Rows[d].Cells[2].Value.ToString();
                nombProd = dgvJug.Rows[d].Cells[3].Value.ToString();
                monto = dgvJug.Rows[d].Cells[4].Value.ToString();
                idLotSig = Convert.ToInt32(dgvJug.Rows[d].Cells[5].Value.ToString());
                idSortSig = Convert.ToInt32(dgvJug.Rows[d].Cells[6].Value.ToString());
                nombLot = dgvJug.Rows[d].Cells[7].Value.ToString();

                if (codJug.Length == 1) { codJug.PadRight(1, ' '); }

                if ((idLotAnt != idLotSig || idSortAnt != idSortSig))
                {
                    if (cadResult.Length > 0) { cadResult += "/"; cont_jud = 1; }
                    cadResult += busTitulo(nombLot, "");
                }

                cadResult += codJug.PadRight(3, ' ');
                cadResult += nombProd.ToUpper().PadRight(4, ' ');
                cadResult += Convert.ToDouble(monto).ToString("N2")+"  ";
                if (cont_jud == 2) { cadResult += "/"; cont_jud = 0; }

                idLotAnt = Convert.ToInt32(dgvJug.Rows[d].Cells[5].Value.ToString());
                idSortAnt = Convert.ToInt32(dgvJug.Rows[d].Cells[6].Value.ToString());
             }

             dtDgvJug.Clear();
             dgvJug.DataSource = dtDgvJug;
             frm_rpt_ticket_venta objRpt = new frm_rpt_ticket_venta();
             objRpt.nombTaq = clsMet.nombUsu;
             objRpt.fecha = fTck;
             objRpt.hora = hTicket;
             objRpt.nroTicket = nroTck.ToString();
             objRpt.nroSerial = nroSerial;
             objRpt.detJug = cadResult;
             objRpt.totVenta = Convert.ToDouble(txt_monto_jug.Text);
             objRpt.nroDiaCad = clsMet.cant_dia_cad_ticket;
             objRpt.ShowDialog();

             lblUltTick.Text = nroTck.ToString();
             mTotalJug = 0;
             txt_monto_jug.Text = "0";
             lblMontJug.Text = "0.00";

             myTrans.Commit();
             busCuadDiario();
             if (sortAb == true) { refresc();}
         }
    }
    catch (Exception ex)
    {
        try { if (clsMet.cn_bd.State == ConnectionState.Open) { myTrans.Rollback(); } }
        catch (MySqlException error)
        {
            if (myTrans.Connection != null)
            {
                msjInfo = "Una excepción de tipo \"" + error.GetType() + " \"";
                msjInfo += " se encontró al intentar revertir la transacción.";
                MessageBox.Show(msjInfo, "Transacción Fallida...");
            }
        }

        msjInfo = "Una excepción de tipo: \"" + ex.GetType() + "\"";
        msjInfo += "\n se encontró al insertar los datos. \n Tome nota del";
        msjInfo += " siguiente error: \"" + ex.Message + "\"";
        MessageBox.Show(msjInfo, "Transacción Fallida...");
    }
    finally { clsMet.Desconectar(); }
}

private void btn_result_lot_Click(object sender, EventArgs e)
{
    frm_result_lot objResultLot = new frm_result_lot();
    objResultLot.ShowDialog();
}
private void frm_ventas_KeyPress(object sender, KeyPressEventArgs e)
{
    char caracter;
    int codigo;
    caracter = Convert.ToChar(e.KeyChar);
    codigo = (int)caracter;

    if ((codigo == 27) || (codigo == 43))
    {
        if (dgvJug.RowCount == 0) { return; }
        string msjInfo = "";
        string nroTick = "" ,nroSerial = "";
        string fechaTick = "" , horaTick = "";
        string rsGrdTick = "";
        string horaVerfJug = "";
        Boolean rsProc;
        string codJug = "";
        DateTime horaSortJugImpTck;
        int rsJugAbImpTck;

        clsMet.conectar();
        MySqlCommand cmdGrdTck = new MySqlCommand();
        MySqlCommand cmdDetTck = new MySqlCommand();
        MySqlTransaction myTrans = null;

        int cont = 0;
        try
        {
            ////////////////////////////////////////////////////////////////////////////////////
            /////////////////REGISTRA TICKET ///////////////////////////////////////////////////

            cmdGrdTck .Connection = clsMet.cn_bd;
            myTrans = clsMet.cn_bd.BeginTransaction();
            cmdGrdTck.CommandType = CommandType.StoredProcedure;
            cmdGrdTck.CommandText = "SP_grd_ticket_copy1";
            cmdGrdTck.Parameters.AddWithValue("prm_id_grupo", Convert.ToInt32(clsMet.idGrup));
            cmdGrdTck.Parameters.AddWithValue("prm_id_usuario", Convert.ToInt32(clsMet.idUsu));
            cmdGrdTck .Parameters.AddWithValue("prm_monto_ticket", txt_monto_jug.Text);

            MySqlDataReader dr = cmdGrdTck.ExecuteReader();
            dr.Read();

            if (dr.HasRows)
            {
                rsProc = true;
                rsGrdTick = 
                rsProc + "?" + 
                dr["prm_cont_ticket"].ToString()  + "?" + 
                dr["prm_nro_Serial"].ToString() + "?" + 
                dr["fecha_ticket"].ToString() + "?" + 
                dr["hora_ticket"].ToString() + "?" +
                dr["horaVerfJug"].ToString();
            }
            else { rsGrdTick= ""; }
            dr.Close();

            string[] rsDatTick = null;
            rsDatTick  = rsGrdTick.Split('?');
            rsProc = Convert.ToBoolean(rsDatTick[0].ToString());
            nroTick = rsDatTick[1].ToString();
            nroSerial = rsDatTick[2].ToString();
            fechaTick = Convert.ToDateTime(rsDatTick[3]).ToString("dd/MM/yyyy");
            horaTick = rsDatTick[4].ToString();
            horaVerfJug = rsDatTick[5].ToString();

            ////////////////////////////////////////////////////////////////////////////////////
            /////////REGISTRA DETALLE TICKET //////////////////////////////////////////////////

            for (int c = 0; c < dgvJug.RowCount; c++)
            {
                horaSortJugImpTck= Convert.ToDateTime(dgvJug.Rows[c].Cells[1].Value.ToString());
                codJug = dgvJug.Rows[c].Cells[2].Value.ToString();
                mJug =Convert.ToInt32(dgvJug.Rows[c].Cells[4].Value.ToString());
                idLot =Convert.ToInt32(dgvJug.Rows[c].Cells[5].Value.ToString());
                idSort = Convert.ToInt32(dgvJug.Rows[c].Cells[6].Value.ToString());

                rsJugAbImpTck = DateTime.Compare(horaServ, horaSortJugImpTck);
                if (rsJugAbImpTck < 0)
                {
                    cmdDetTck.Connection = clsMet.cn_bd;
                    cmdDetTck.CommandType = CommandType.StoredProcedure;
                    cmdDetTck.CommandText = "SP_det_ticket";
                    cmdDetTck.Parameters.AddWithValue("prm_nro_ticket", nroTick);
                    cmdDetTck.Parameters.AddWithValue("prm_id_grupo", Convert.ToInt32(clsMet.idGrup));
                    cmdDetTck.Parameters.AddWithValue("prm_id_usuario", Convert.ToInt32(clsMet.idUsu));
                    cmdDetTck.Parameters.AddWithValue("prm_id_loteria", idLot);
                    cmdDetTck.Parameters.AddWithValue("prm_id_sorteo", idSort);
                    cmdDetTck.Parameters.AddWithValue("prm_codigo_jugada", codJug);
                    cmdDetTck.Parameters.AddWithValue("prm_monto", mJug);

                    cmdDetTck.ExecuteNonQuery();
                    cmdDetTck.Parameters.Clear();
                    cont++;
                }
 
                codJug = "";
                mJug = 0;
                idLot = 0; idSort = 0;
             }
             ////////////////////////////////////////////////////////////////////////////////////
             /////////IMPRIMIR TICKET///////// //////////////////////////////////////////////////

             if (cont== 0)
             {
                if (clsMet.cn_bd.State == ConnectionState.Open) { myTrans.Rollback(); clsMet.Desconectar(); }

                 dtDgvJug.Clear();
                 dgvJug.DataSource = dtDgvJug;

                 mTotalJug= 0;
                 txt_monto_jug.Text = "0";
                 lblMontJug.Text = "0.00";

                 MessageBox.Show("Ha ocurrido un error 5001.","Verifique.");
                 refresc();
             }
             else if (cont >= 1)
             {
                 string cod_jug = "";
                 string nomb_prod = "";
                 string monto;
                 int id_loteria_ant = 0;
                 int id_loteria_sig = 0;
                 int id_sorteo_ant = 0;
                 int id_sorteo_sig = 0;
                 string nomb_loteria = "";
                 string nomb_sorteo = "";
                 string cadena_result = "";

                 int cont_jud = 0;
                 for (int c = 0; c < dgvJug.RowCount; c++)
                 {
                     cont_jud++;

                     nomb_sorteo = dgvJug.Rows[c].Cells[1].Value.ToString();
                     cod_jug = dgvJug.Rows[c].Cells[2].Value.ToString();
                     nomb_prod = dgvJug.Rows[c].Cells[3].Value.ToString();
                     monto = dgvJug.Rows[c].Cells[4].Value.ToString();
                     id_loteria_sig = Convert.ToInt32(dgvJug.Rows[c].Cells[5].Value.ToString());
                     id_sorteo_sig = Convert.ToInt32(dgvJug.Rows[c].Cells[6].Value.ToString());
                     nomb_loteria = dgvJug.Rows[c].Cells[7].Value.ToString();

                     if (cod_jug.Length == 1) { cod_jug.PadRight(1, ' '); }

                     if ((id_loteria_ant != id_loteria_sig || id_sorteo_ant != id_sorteo_sig))
                     {
                         if (cadena_result.Length > 0) { cadena_result += "/"; cont_jud = 1; }
                         cadena_result += busTitulo(nomb_loteria, "");
                     }
                     cadena_result += cod_jug.PadRight(3, ' ') + nomb_prod.ToLower().PadRight(2, ' ') + monto + "     ";
                     if (cont_jud == 3) { cadena_result += "/"; cont_jud = 0; }

                     id_loteria_ant = Convert.ToInt32(dgvJug.Rows[c].Cells[6].Value.ToString());
                     id_sorteo_ant = Convert.ToInt32(dgvJug.Rows[c].Cells[7].Value.ToString());
                 }

                 dtDgvJug.Clear();
                 dgvJug.DataSource = dtDgvJug;

                 frm_rpt_ticket_venta objTickVenta = new frm_rpt_ticket_venta();
                 objTickVenta.nombTaq = clsMet.nombUsu;
                 objTickVenta.fecha = fechaTick;
                 objTickVenta.hora = horaTick;
                 objTickVenta.nroTicket = nroTick.ToString();
                 objTickVenta.nroSerial = nroSerial;
                 objTickVenta.detJug = cadena_result;
                 objTickVenta.totVenta = Convert.ToDouble(txt_monto_jug.Text);
                 objTickVenta.nroDiaCad = clsMet.cant_dia_cad_ticket;
                 objTickVenta.ShowDialog();

                 lblUltTick.Text = nroTick.ToString();
                 mTotalJug = 0;
                 txt_monto_jug.Text = "0";
                 lblMontJug.Text = "0.00";

                 myTrans.Commit();
                 busCuadDiario();
              }
           }
           catch (Exception ex)
           {
            try { if (clsMet.cn_bd.State == ConnectionState.Open) { myTrans.Rollback(); } }
            catch (MySqlException error)
            {
                if (myTrans.Connection != null)
                {
                    msjInfo = "Una excepción de tipo \"" + error.GetType() + " \"";
                    msjInfo += " se encontró al intentar revertir la transacción.";
                    MessageBox.Show(msjInfo, "Transacción Fallida...");
                }
            }

            msjInfo = "Una excepción de tipo: \"" + ex.GetType() + "\"";
            msjInfo += "\n se encontró al insertar los datos. \n Tome nota del";
            msjInfo += " siguiente error: \"" + ex.Message + "\"";
            MessageBox.Show(msjInfo, "Transacción Fallida...");
        }
        finally { clsMet.Desconectar(); }
    }
}
private void btn_repetir_ticket_Click(object sender, EventArgs e)
{
    Boolean validRepetTick=true;
    validRepetTick = rVerfRepetTick();
    if (validRepetTick == true)
    {
        string rsExistTick = "";
        rsExistTick = objVentas.verf_grd_repet_ticket(
                  Convert.ToInt32(clsMet.idUsu),
                                       txtNroTick.Text);
        
        if (rsExistTick == "0")
        {
            MessageBox.Show("El Nº. Ticket introducido no existe...","Verfique.");
            txtNroTick.Focus();
            return;
        }
        else if (rsExistTick == "1")
        {
            foreach (DataGridViewRow row in dgvLot.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                if (cell.Value != null)
                {
                    if (Convert.ToBoolean(cell.Value) == true)
                    {
                        idLot= Convert.ToInt32(row.Cells[1].Value.ToString());
                        idSort = Convert.ToInt32(row.Cells[2].Value.ToString());
                        nombLot  = row.Cells[4].Value.ToString();
                        horaSortJug = Convert.ToDateTime(row.Cells[5].Value.ToString());
                        abrevLot = row.Cells[7].Value.ToString();
                        dtDgvJug = objVentas.repet_jugada_ticket(
                                                    txtNroTick.Text,
                                                    idLot, idSort,
                                                    nombLot,
                                                    Convert.ToDateTime(horaSortJug.ToString()).ToString("HH:mm:ss"),
                                                    abrevLot);
                        idLot = 0; idSort = 0;
                        nombLot=""; abrevLot = "";
                    }
                }
            }
            dtDgvJug = objVentas.busJug(txtNroTick.Text);
            dgvJug.DataSource = dtDgvJug;
            busMontTotJug();
        }
    }
}
public Boolean rVerfRepetTick()
{
    Boolean validar = true;
    if (string.IsNullOrEmpty(txtNroTick.Text))
    {
        MessageBox.Show("Ingrese Nº. Ticket a repetir...","Verifique.");
        txtNroTick.Focus();
        validar = false;
    }
    else if (Convert.ToInt32(txtNroTick.Text)==0)
    {
        MessageBox.Show("Ingrese Nº. Ticket diferente de cero...", "Verifique.");
        txtNroTick.Focus();
        validar = false;
    }
    else if (validLotSort() == false)
    {
        MessageBox.Show("Elija una loteria y sorteo...", "Verifique");
       validar = false;
    }
    return validar;
  }

private void txtNroTick_KeyPress(object sender, KeyPressEventArgs e)
{
    if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
    else
        if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
        else { e.Handled = true; }

    char caracter;
    int codigo;
    caracter = Convert.ToChar(e.KeyChar);
    codigo = (int)caracter;
}

private void txtNroSerial_KeyPress(object sender, KeyPressEventArgs e)
{
    if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
    else
    if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
    else { e.Handled = true; }

    char caracter;
    int codigo;
    caracter = Convert.ToChar(e.KeyChar);
    codigo = (int)caracter;
}

private void dgvLot_CellClick(object sender, DataGridViewCellEventArgs e)
{
    int nroFila; 
    if (dgvLot.RowCount > 0)
    {
       nroFila = Convert.ToInt32(dgvLot.CurrentRow.Index.ToString());
       DataGridViewCheckBoxCell cell = dgvLot.Rows[nroFila].Cells[0] as DataGridViewCheckBoxCell;

       if (Convert.ToBoolean(cell.Value) == true) { cell.Value = false; }
       else if (Convert.ToBoolean(cell.Value) == false) { cell.Value = true; }
       codMaxProd = Convert.ToInt32(dgvLot.Rows[nroFila].Cells[3].Value.ToString());
    }
}

private void dgvJug_CellClick(object sender, DataGridViewCellEventArgs e)
{
    try
    {
        if (dgvJug.RowCount > 0)
        {
            nroFila = Convert.ToInt32(dgvJug.CurrentRow.Index.ToString());
            dgvJug.Rows.RemoveAt(nroFila);
            busMontTotJug();
            txtCodigo.Focus();
        }
    }
    catch (Exception ex) { MessageBox.Show("Ha ocurrido el siguiente error: " + ex.Message,"Verifique.");}
}

private void btn_inprimir_tck_Click(object sender, EventArgs e)
{
    string nroTick="", nroSerial = "";
    string fechaTick = "", horaTick = "";
    int cantTick, permitReimp;
    string montoTick = "";
    int cantMinReimp;

    string codJug = "", nombProd = "";
    int idLotAnt = 0, idLotSig = 0;
    int idSortAnt = 0, idSortSig = 0;
    string nombLot = "", nombSort = "";
    string cadResult = "", monto="";
    string msjInfo = "";

    try
    {
        string rsInfTick= "";
        string[] rsDatInfTick= null;
        rsInfTick = objVentas.busInfTicket(
        Convert.ToInt32(clsMet.idUsu));

        rsDatInfTick = rsInfTick.Split('?');
        cantTick = Convert.ToInt32(rsDatInfTick[0].ToString());
        permitReimp = Convert.ToInt32(rsDatInfTick[1].ToString());
        cantMinReimp = Convert.ToInt32(rsDatInfTick[2].ToString());

        if (cantTick == 0)
        {
            msjInfo = "No se a procesado ticket para reimiprimir el dia de hoy.";
            MessageBox.Show(msjInfo, "Transacción Fallida.");
            return;
        }
        else if (cantTick >= 1)
        {

            if (permitReimp == 0)
            {
                msjInfo = "No se podra reimprimir el ultimo ticket.";
                msjInfo += " Tiempo maximo de reimpresión es de: ";
                msjInfo += cantMinReimp + " minutos.";
                MessageBox.Show(msjInfo, "Transacción Fallida.");
                return;
            }

            if (permitReimp == 1)
            {
                nroTick = rsDatInfTick[3].ToString();
                nroSerial = rsDatInfTick[4].ToString();
                fechaTick = rsDatInfTick[5].ToString().Substring(0, 10);
                fechaTick = Convert.ToDateTime(fechaTick).ToString("dd-MM-yyyy");
                horaTick = clsMet.hora_normal(rsDatInfTick[6].ToString());
                montoTick = rsDatInfTick[7].ToString();
            }
        }
    }
    catch (Exception ex) { MessageBox.Show(ex.Message); return; }

    clsMet.conectar();
    MySqlCommand cmd = new MySqlCommand();
            
    try
    {
        cmd.Connection = clsMet.cn_bd;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SP_det_reimprimir_ticket";
        cmd.Parameters.AddWithValue("prm_id_usuario", Convert.ToInt32(clsMet.idUsu));
        cmd.Parameters.AddWithValue("prm_nro_ticket", nroTick);
        MySqlDataReader dr = cmd.ExecuteReader();
        int cont_jud = 0;

        while (dr.Read())
        {
            idLotSig =Convert.ToInt32(dr["id_loteria"].ToString());
            idSortSig = Convert.ToInt32(dr["id_sorteo"].ToString());
            codJug = dr["codigo_jugada"].ToString();
            nombProd = dr["nomb_product"].ToString();
            monto = dr["monto"].ToString();
            nombSort = dr["nomb_sorteo"].ToString();
            nombLot = dr["nomb_loteria"].ToString();
            cont_jud++;

            if (codJug.Length == 1) { codJug.PadRight(1, ' '); }

            if ((idLotAnt != idLotSig) || idSortAnt != idSortSig)
            {
                if (cadResult.Length > 0) { cadResult += "/"; cont_jud = 1; }
                cadResult += busTitulo(nombLot, nombSort);
            }

            // cadResult  += cod_jug.PadRight(4, ' ');
            //cadResult  += nomb_prod.Substring(0, 3).ToLower().PadRight(5, ' ');
            cadResult += codJug.PadRight(3, ' ');
            cadResult += nombProd.ToLower().PadRight(2, ' ');
            cadResult += monto + "     ";

            if (cont_jud == 3) { cadResult += "/"; cont_jud = 0; }
            idLotAnt = idLotSig;
            idSortAnt = idSortSig;
        }
        dr.Close();

        frm_rpt_ticket_venta objTickVenta = new frm_rpt_ticket_venta();
        objTickVenta.nombTaq = clsMet.nombUsu;
        objTickVenta.fecha =fechaTick;
        objTickVenta.hora = horaTick;
        objTickVenta.nroTicket = nroTick;
        objTickVenta.nroSerial = nroSerial;
        objTickVenta.detJug = cadResult;
        objTickVenta.totVenta = Convert.ToDouble(montoTick);
        objTickVenta.nroDiaCad = clsMet.cant_dia_cad_ticket;
        objTickVenta.ShowDialog();
    }
    catch (Exception ex) { MessageBox.Show(ex.Message); }
    finally { clsMet.Desconectar(); }
  }
private void btn_calc_Click(object sender, EventArgs e)
{
    System.Diagnostics.Process p = new System.Diagnostics.Process();
    p.StartInfo.FileName = @"calc.exe";
    p.Start();
    p.WaitForExit();
}
private void BtnCClave_Click(object sender, EventArgs e)
{
    frm_cambio_clave objCclave = new frm_cambio_clave();
    objCclave.ShowDialog();
}
private void btnImp_Click(object sender, EventArgs e)
{
    frm_config_impresora objConfImp = new frm_config_impresora();
    objConfImp.ShowDialog();
}
private void btn_salir_Click_1(object sender, EventArgs e)
{
    string msjInfo;
    msjInfo = "¿Esta usted seguro que desea salir del sistema?";
    if (MessageBox.Show(msjInfo, "Verifique.", MessageBoxButtons.YesNo) == DialogResult.Yes)
    {
        Application.Exit();
    }
}
public void refresc()
{
    this.Hide();
    frm_ventas objRefresc= new frm_ventas();
            objRefresc.Show();
}

}
}
