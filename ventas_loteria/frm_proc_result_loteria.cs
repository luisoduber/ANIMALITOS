using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using HtmlAgilityPack;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace ventas_loteria
{
    public partial class frm_proc_result_loteria : Form
    {
        public frm_proc_result_loteria()
        {
            InitializeComponent();
        }

        clsMet objFunc = new clsMet();
        DataTable dtDgvLot = new DataTable();
        DataTable dtcboTipProc = new DataTable();
        DataTable dtDgvJug= new DataTable();
        HtmlWeb web = new HtmlWeb();

        int idLot = 0, idSort = 0;
        int idGrup;
        string fechLot = "";
        int cantResultCarg = 0;
        int codMaxProd;
        string msj_proc_result = "";
        string nombLot = "";
        string nombSort= "";
        int idProc = 0;

        string[] rsNombLot = null;
        string prmNombLot = "";

        string[] rs_rs_lot = null;
        string prmRsLot = "";

        string rsHoraLot = "";
        string prmHoraLot = "";

        string horaSortBus="";
        string nombLotBus="";

        string rsGan = "";
        string[] prmGrdRs = null;
        string rsGrdRsLot = "";

        int id_det_jug = 0;
        int nro_ticket = 0;
        string cod_jug = "";
        long monto_jug = 0;

        int cont = 0;
        int contRegPed = 0;
        int contRegGan = 0;
        string rsDat = "";
        string msjInf="";
        int rsVerfJugCer= 0;
private void frm_proc_result_loteria_Load(object sender, EventArgs e)
{
    this.Text = "Procesar Resultados...";
    this.dgvLot.AllowUserToAddRows = false;
    this.dgvLot.RowHeadersVisible = false;

    this.dgvJug.AllowUserToAddRows = false;
    this.dgvJug.RowHeadersVisible = false;
    this.dgvJug.ColumnHeadersVisible = false;

    lbl_msj_info.Text = "";
    txtCod.Enabled = false;
    dtpFecha.Enabled = false;
    idGrup=Convert.ToInt32(clsMet.idGrup);

    gb_info_proc_result.Text = "Jug:0. Gan:0. Perd:0...";
    gp_cant_jug.Text = "cantidad jugadas: 0";

    this.dtpFecha.Value  = Convert.ToDateTime(clsMet.FechaActual);
    this.dtpFecha.Format = DateTimePickerFormat.Custom;
    this.dtpFecha.CustomFormat = "dd-MM-yyyy";

    this.work_inicia_frm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.work_inicia_frm_DoWork);
    this.work_inicia_frm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.work_inicia_frm_OnProgressChanged);
    this.work_inicia_frm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.work_inicia_frm_OnRunWorkerCompleted);
    this.work_inicia_frm.RunWorkerAsync();

    this.work_proc_result.DoWork += new System.ComponentModel.DoWorkEventHandler(this.work_proc_result_DoWork);
    this.work_proc_result.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.work_proc_result_ProgressChanged);
    this.work_proc_result.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.work_proc_result_OnRunWorkerCompleted);

    this.work_bus_result_lot.DoWork += new System.ComponentModel.DoWorkEventHandler(this.work_bus_result_lot_DoWork);
    this.work_bus_result_lot.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.work_bus_result_lot_OnProgressChanged);
    this.work_bus_result_lot.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.work_bus_result_lot_OnRunWorkerCompleted);
 }

delegate void delCargJug(int prmIdgrupo, int prmIdSorteo, 
                            string prmCodResult, string prmNombLot);
private void cargJug(int prmIdgrupo, int prmIdSorteo,
                      string prmCodResult, string prmNombLot)
{
    msjInf="Resultado Nro: \"" + prmCodResult + "\"";
    gpReult.Text="Loteria: "+ prmNombLot;

    lbl_msj_info.Text = msjInf;
    fechLot = Convert.ToDateTime(dtpFecha.Text).ToString("yyyy-MM-dd");

    //VERIFICA SI HAY JUGADAS Y LAS TRAE AL GRID PARA PROCESARLA
    dtDgvJug = objFunc.busJugProcResult(prmIdgrupo,prmIdSorteo, fechLot);
    dgvJug.DataSource = dtDgvJug;
    gp_cant_jug.Text = "Cantidad jugadas: " + dgvJug.RowCount;

    this.pb_info_proc_result.Minimum = 0;
    this.pb_info_proc_result.Maximum = dgvJug.RowCount - 1;
    this.pb_info_proc_result.Value = 0;
    //MessageBox.Show("cargar jugadas: ");
}

private void timer1_Tick(object sender, EventArgs e)
{
    txtCod.Text = "";
    txtCod.Enabled = false;
    if (clsMet.id_conexion == 0) { lbl_msj_info.Text = clsMet.msj_error_cn; return; }

    if (!this.work_bus_result_lot.IsBusy) 
    {  
        gpReult.Text = "Loteria: ";
        fechLot  = Convert.ToDateTime(dtpFecha.Text).ToString("yyyy-MM-dd");
        this.work_bus_result_lot.RunWorkerAsync(); 
    }
}
public string result_grupoN(string prmUrl, string prmIdLot,
                            string prmIdSort, string prmNombLot,
                            string prmHoraSort)
{
            MessageBox.Show(prmNombLot +  " --- " + prmHoraSort);
            var htmlDoc = web.Load(prmUrl);
    var node = htmlDoc.DocumentNode.SelectNodes("//div[@class='col-xs-6 col-sm-3']");
    //var node = htmlDoc.DocumentNode.SelectNodes("//div[@class='col-xs-6 col-sm-3']/div/img[@class='img-responsive']");
    string rsDat = "";
    string prmNombLotPw="";
    string prmHoraSortPw = "";

    foreach (var node1 in node)
    {
        prmNombLotPw  = node1.ChildNodes[0].InnerHtml.ToString().Replace("<br>", "*");
        rsNombLot = prmNombLotPw.Split('*');
        prmRsLot = node1.ChildNodes[2].InnerText.ToString().Replace("-", "*");
        rs_rs_lot = prmHoraLot.Split('*');
        prmHoraSortPw = node1.ChildNodes[3].InnerText.ToString();
                
        if (prmNombLot.ToUpper() == rsNombLot[1].ToUpper())
        { 
            if(prmHoraSort == prmHoraSortPw) { MessageBox.Show("break"); break; }
        }         
    }
            
    /*
            rs_det_loteria = prm_grd_result[contador_array].Split('-');
            idLot = Convert.ToInt32(rs_det_loteria[0].ToString());
            idSort = Convert.ToInt32(rs_det_loteria[1].ToString());
            cod_result_lot = rs_det_loteria[2].ToString();
            nombLot = rs_det_loteria[3].ToString();*/
            return rsDat;
        }

public string rsGrup1(string prmUrl, string prmIdLot,
                            string prmIdSort, string prmNombLot,
                            string prmHoraSortBus)
{ 
    var htmlDoc = web.Load(prmUrl);
    var node = htmlDoc.DocumentNode.SelectNodes("//div[@class='col-xs-6 col-sm-3']");
    string result = "";
    string prmNombLotPw="";

    foreach (var node1 in node)
    {
        prmNombLotPw = node1.ChildNodes[0].InnerHtml.ToString().Replace("<br>", "*");
        rsNombLot = prmNombLotPw.Split('*');
        prmHoraLot  = node1.ChildNodes[2].InnerText.ToString().Replace("-", "*");
        rs_rs_lot = prmHoraLot.Split('*');
        prmHoraLot = node1.ChildNodes[3].InnerText.ToString();

        if ((rsNombLot[1].ToLower().Trim() == prmNombLot) && (prmHoraLot == prmHoraSortBus))
        {
            //VERIFICA SI HAY RESULTADO EN LA LOTERIA SI NO VIENE VACIO
            if (!string.IsNullOrEmpty(rs_rs_lot[0].ToString().Trim()))
            {
                result += prmIdLot + "-";
                result += prmIdSort + "-";
                result += rs_rs_lot[0].ToString().Trim();
                result += "-" + rsNombLot[1].ToString();
                result += " " + prmHoraSortBus;
            }
             break;
        }
    }
            return result;
}
public string result_grupo2(string prmUrl, string prmIdLotBus,
                            string prmIdSorBus, string prmHoraSortBus,
                            string prmNombLot)
{
    var html_RA = web.Load(prmUrl);
    var nodeResult = html_RA.DocumentNode.SelectNodes("//div[@class='col-md-3 custom-sec-img animated fadeInDown']//div//div/img");
    var nodeHora = html_RA.DocumentNode.SelectNodes("//div[@class='col-md-3 custom-sec-img animated fadeInDown']//div//div/h2");

    string rsHS = "";
    string[] datosHS = null;

    string rsRL = "";
    string[] datosRL = null;
    int contHS = 0, contRL = 0;
    string result = "";

    foreach (var node_HS in nodeHora)
    {
        rsHS = node_HS.InnerText.Replace(" ", "/");

        datosHS = rsHS.Split('/');
        Console.WriteLine(datosHS[0].ToString());

        if (datosHS[0].ToString() == prmHoraSortBus)
        {
            foreach (var node_RL in nodeResult)
            {
                rsRL = node_RL.Attributes["src"].Value;
                datosRL = rsRL.Split('/');

                datosRL[2] = datosRL[2].Replace(".jpg", "");
                datosRL[2] = datosRL[2].Replace(".png", "");
                Console.WriteLine(datosRL[2].ToString());

                if (contRL == contHS) 
                {
                    result  = prmIdLotBus + "-" + prmIdSorBus;
                    result += "-" + datosRL[2].ToString().Trim();
                    result += "-" + prmNombLot + " ";
                    result +=  datosHS[0].ToString();
                    contRL = 0;
                    break;  
                }
                else { contRL++; }
            }
        }
        contHS++;
    }
    return result;
}
    private void work_bus_result_lot_DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
            var urlGrup1= @"https://www.tuazar.com/loteria/animalitos/resultados/";
            var urlRA = @"https://www.ruletactiva.com.ve/";
      
            string idLotBus="";
            string idSortBus="";

            clsMet.conectar();
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = clsMet.cn_bd;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_bus_sorteos_proc_result_auto";
            MySqlDataReader dr = cmd.ExecuteReader();

                string rsLot = "";

            while (dr.Read())
            {

                idLotBus = dr["id_loteria"].ToString();
                idSortBus = dr["id_sorteo"].ToString();
                horaSortBus =Convert.ToDateTime(dr["hora_sorteo"].ToString()).ToString("hh:mm");
                nombLotBus = dr["nomb_loteria"].ToString().ToLower();

                /////////////////////////////////////////////////////////////////////////////////////
                // LOTTO - GRANJITA - LUCKY ANIMAL - LOTTO REY - CHANCE CON ANIMALITOS - ///////////
                // GUACHAR ACTIVO - SELVA PLUS /////////

                if ((idLotBus == "1")  || (idLotBus == "4")  || 
                    (idLotBus == "5")  || (idLotBus == "10") ||
                    (idLotBus == "11") || (idLotBus == "12") || 
                    (idLotBus == "13"))
                {
                    if (string.IsNullOrEmpty(rsGan))
                    {
                        rsGan += rsGrup1(urlGrup1,idLotBus,idSortBus,
                                         nombLotBus,horaSortBus);
                    }
                    else
                    {
                        rsLot=rsGrup1(urlGrup1,idLotBus,idSortBus,nombLotBus,horaSortBus);
                        if (!string.IsNullOrEmpty(rsLot)) { rsGan += "/" + rsLot; }
                    }
                }
                /////////////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////// RULETA ACTIVA ////////////////////////////////////

                else if ((idLotBus == "8"))
                {
                    if (string.IsNullOrEmpty(rsGan))
                    {
                        rsGan += result_grupo2(urlRA,idLotBus,idSortBus,
                                                   horaSortBus,nombLotBus);
                    }
                    else
                    {
                        rsGan += "/" + result_grupo2(urlRA,idLotBus,idSortBus,
                                                          horaSortBus,nombLotBus);
                    }
                }
            }  
                dr.Close();

                ////////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////////

              //MessageBox.Show(rs_ganador);

           if ((string.IsNullOrEmpty(rsGan)) && (idProc == 1)) 
           {
                msjInf="No se encontraron resultados...";
           }
           else if (!string.IsNullOrEmpty(rsGan))
           {
               //MessageBox.Show(rsGan);
               prmGrdRs = rsGan.Split('/');
               rsGan= "";
               int contArr = 0;

               string codRsLot="";
               string[] rsDetLot = null;

               while (contArr < prmGrdRs.Length)
               {
                   rsDetLot = prmGrdRs[contArr].Split('-');
                   idLot = Convert.ToInt32(rsDetLot[0].ToString());
                   idSort = Convert.ToInt32(rsDetLot[1].ToString());
                   codRsLot = rsDetLot[2].ToString();
                   nombLot = rsDetLot[3].ToString();

                   if (codRsLot.Length==1) { if (codRsLot!="0") { codRsLot=codRsLot.PadLeft(2, '0'); }}
                   rsGrdRsLot = objFunc.grdActResultLot(idLot, idSort,
                                                       codRsLot,fechLot);
 
                   if (rsGrdRsLot=="1")
                   {
                       delCargJug delegado = new delCargJug(cargJug);
                       object[] prm = new object[] {idGrup,idSort,codRsLot,nombLot};
                       this.Invoke(delegado, prm);

                       if (dgvJug.RowCount > 0)
                       {
                           int contRs = 0;
                           cantResultCarg = dgvJug.RowCount - 1;

                           msj_proc_result = "Jug:0. Gan:0. Perd:0...";
                           contRegPed = 0;
                           contRegGan = 0;

                           while (contRs<= cantResultCarg)
                           {
                               id_det_jug = Convert.ToInt32(dgvJug.Rows[contRs].Cells[0].Value.ToString().Trim());
                               nro_ticket = Convert.ToInt32(dgvJug.Rows[contRs].Cells[1].Value.ToString().Trim());
                               cod_jug = dgvJug.Rows[contRs].Cells[5].Value.ToString().Trim();

                               rsDat = objFunc.busProcResultLot(id_det_jug,idLot,idSort,codRsLot);
                               if (rsDat=="0") { contRegPed++; }
                               else if (rsDat=="1") { contRegGan++; }
                               msj_proc_result = "Jug:" + dgvJug.RowCount + ". Gan: " + contRegGan;
                               msj_proc_result += ". Perd: " + contRegPed + "...";

                               work_bus_result_lot.ReportProgress(contRs);
                               contRs++;
                           }
                       }
                   }
                   contArr++;
               }
           }
           idProc = 1;
           work_bus_result_lot.CancelAsync();
        }
        catch (Exception ex) 
        { 
            idProc = 0;
            msjInf = ex.Message;
            MessageBox.Show("Ha ocurrido siguiente el siguiente error: "+ msjInf, "Verifique.");
        }
        finally { clsMet.Desconectar(); }
     }
    private void work_bus_result_lot_OnProgressChanged(object sender, ProgressChangedEventArgs e)
    {
         //SELECCIONA LA BARRA COMPLETA
         dgvJug.CurrentCell = dgvJug.Rows[e.ProgressPercentage].Cells[1];

         //MUEVE LA BARRA PARA DEPLAZAR LOS REGISTROS
         dgvJug.FirstDisplayedScrollingRowIndex = e.ProgressPercentage;
         this.pb_info_proc_result.Value = e.ProgressPercentage;
         gb_info_proc_result.Text = msj_proc_result;
    }
    private void work_bus_result_lot_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (idProc == 1)
        {
            dtDgvJug= objFunc.busJugPendProc(idGrup);
            dgvJug.DataSource = dtDgvJug;
            gp_cant_jug.Text = "Cantidad jugadas: " + dgvJug.RowCount;

            lbl_msj_info.Text = msjInf;
            txtCod.Text = "";
        }
        else if (idProc == 0) { this.Refresh();  }
        rsGan = "";
        fechLot  = "";
    }
    private void work_inicia_frm_DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
            dtDgvLot = objFunc.busLotProcResult();
            dtcboTipProc = objFunc.busTipProc();
            dtDgvJug = objFunc.busJugPendProc(idGrup);
            idProc = 1;
            work_inicia_frm.CancelAsync();
        }
        catch (Exception ex)
        {
          idProc = 0;
          MessageBox.Show(ex.Message, "Verifique");
        }
    }
    private void work_inicia_frm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    }
    private void work_inicia_frm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
       if (idProc == 1)
       {
          dgvLot.DataSource = dtDgvLot;
          cboTipProc.DisplayMember="nomb_tipo_proc_datos";
          cboTipProc.ValueMember="id_tipo_proc_datos";
          cboTipProc.DataSource=dtcboTipProc;

          dgvJug.DataSource = dtDgvJug;
          gp_cant_jug.Text = "Cantidad jugadas: " + dgvJug.RowCount;

          txtCod.Text = "";
          txtCod.Enabled = false;
          dtpFecha.Enabled = false;

          cboTipProc.SelectedValue = 2;
          timer1.Enabled = true;
          timer1.Interval = 10000;
       }
    }
    private void work_proc_result_DoWork(object sender, DoWorkEventArgs e)
    {
        this.work_proc_result.ReportProgress(0, "");
        try
        {
            cont = 0;
            contRegPed = 0;
            contRegGan=0;

            while (cont <= cantResultCarg)
            {
                id_det_jug =Convert.ToInt32(dgvJug.Rows[cont].Cells[0].Value.ToString().Trim());
                nro_ticket = Convert.ToInt32(dgvJug.Rows[cont].Cells[1].Value.ToString().Trim());
                cod_jug = dgvJug.Rows[cont].Cells[5].Value.ToString().Trim();
                rsVerfJugCer = Convert.ToInt32(dgvJug.Rows[cont].Cells[9].Value.ToString().Trim());

                if (rsVerfJugCer == 0)
                {
                    rsDat = objFunc.busProcResultLot(id_det_jug,idLot, 
                                                     idSort,txtCod.Text);

                    work_proc_result.ReportProgress(cont);
                    cont++;

                    if (rsDat == "0") { contRegPed++; }
                    else if (rsDat == "1") { contRegGan++; }
                    msj_proc_result= "Jug:" + dgvJug.RowCount;
                    msj_proc_result+=". Gan: " + contRegGan;
                    msj_proc_result+=". Perd: " + contRegPed + "...";
                }
            }
            work_proc_result.CancelAsync();
            idProc = 1;
        }
        catch (Exception ex)
        {
           string msjErr = "";
           msjErr = "Ha ocurrido un Error En la Linea: " + dgvJug.RowCount + "---" + ex.Message;
           MessageBox.Show(msjErr, "Transacción Fallida.");
           idProc = 0;
        }
    }
    private void work_proc_result_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
       //SELECCIONA LA BARRA COMPLETA
       dgvJug.CurrentCell = dgvJug.Rows[e.ProgressPercentage].Cells[1];

       //MUEVE LA BARRA PARA DEPLAZAR LOS REGISTROS
       dgvJug.FirstDisplayedScrollingRowIndex = e.ProgressPercentage;
       this.pb_info_proc_result.Value = e.ProgressPercentage;
       gb_info_proc_result.Text = msj_proc_result;
    }
    private void work_proc_result_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {

       if (idProc == 1)
       {
            lbl_msj_info.Text += " Ticket procesados ...";
            gb_info_proc_result.Text = msj_proc_result;
            fechLot =Convert.ToDateTime(dtpFecha.Text).ToString("yyyy-MM-dd");

            dtDgvJug= objFunc.busJugProcResult(idLot,idSort,fechLot);
            dgvJug.DataSource = dtDgvJug;
            cboTipProc.SelectedValue = 2;
            timer1.Enabled = true;

            txtCod.Text = "";
            txtCod.Enabled = false;
       }
    }
    private void dgv_loterias_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (dgvLot.RowCount > 0)
        {
            fechLot = Convert.ToDateTime(dtpFecha.Text).ToString("yyyy-MM-dd");
            idLot = Convert.ToInt32(dgvLot.CurrentRow.Cells[0].Value.ToString());
            codMaxProd = Convert.ToInt32(dgvLot.CurrentRow.Cells[2].Value.ToString());
            nombLot = dgvLot.CurrentRow.Cells[1].Value.ToString();

            idSort= Convert.ToInt32(dgvLot.CurrentRow.Cells[3].Value.ToString());
            nombSort = dgvLot.CurrentRow.Cells[5].Value.ToString();

            dtDgvJug =objFunc.busJugProcResult(idGrup,idSort,fechLot);
            dgvJug.DataSource = dtDgvJug;
            gp_cant_jug.Text = "Cantidad jugadas: " + dgvJug.RowCount;

            txtCod.Enabled = true;
            dtpFecha.Enabled = true;
            txtCod.Text = "";
            txtCod.Focus();

          cboTipProc.SelectedValue = 1;
          timer1.Enabled = false;
        }
    }
    private void btn_salir_Click(object sender, EventArgs e)
    {
        this.Close();   
    }
    public Boolean validFrm()
    {
        Boolean validar = true;
        if (string.IsNullOrEmpty(txtCod.Text))
        {
            MessageBox.Show("Ingrese Codigo...", "Verifique");
            txtCod.Focus();
            validar = false;
        }
        else if (Convert.ToInt32(txtCod.Text) > codMaxProd )
        {
            MessageBox.Show("Codigo invalido...", "Verifique");
            txtCod.Focus();
            validar = false;
        }
        else if (txtCod.Text.Length == 1)
        {
            if ((Convert.ToInt32(txtCod.Text) >= 1) && (Convert.ToInt32(txtCod.Text) <= 9))
            {
                txtCod.Text = "0" + txtCod.Text;
            }
        }
        return validar;
    }
    private void cboTipProc_SelectionChangeCommitted(object sender, EventArgs e)
    {
       int idTipPoc=0;
       idTipPoc = Convert.ToInt32(cboTipProc.SelectedValue.ToString());

        if (idTipPoc == 1) 
        { 
            timer1.Enabled = false;
            txtCod.Text = "";
            txtCod.Enabled = true;
            txtCod.Focus();
        }
        else if (idTipPoc == 2)
        {
           timer1.Enabled = true;
           dtDgvJug = objFunc.busJugPendProc(idGrup);
           dgvJug.DataSource = dtDgvJug;
           gp_cant_jug.Text = "Cantidad jugadas: " + dgvJug.RowCount;

           txtCod.Text = "";
           txtCod.Enabled = false;
           dtpFecha.Enabled = false;
           this.dtpFecha.Value = DateTime.Now;
        }
    }

    private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
    {
              //Para obligar a que sólo se introduzcan números 
        if (Char.IsDigit(e.KeyChar)) {  e.Handled = false; }
        else
        if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
        else { e.Handled = true; }

            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }

        char caracter;
        int codigo;
        caracter = Convert.ToChar(e.KeyChar);
        codigo = (int)caracter;

        if (codigo == 13)
        {
            Boolean rsValidFrm= true;
            rsValidFrm = validFrm();

            if (rsValidFrm == true)
        {
            string msjInf= "Realmente desea Procesador el resultado: " + txtCod.Text;
            msjInf += " Para la loteria: \" " + nombLot.ToUpper() + " \"";
            msjInf += " del: \" " + nombSort.ToUpper() + " \"";
            msjInf += " esta usted seguro?";

            if (MessageBox.Show(msjInf, "Verifique.", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                fechLot = Convert.ToDateTime(dtpFecha.Text).ToString("yyyy-MM-dd");
                rsGrdRsLot=objFunc.grdActResultLot(idLot,idSort,
                                                  txtCod.Text,fechLot);

                if (rsGrdRsLot=="1")
                {
                    lbl_msj_info.Text = "Resultado Nro: \"" + txtCod.Text + "\"";
                    gpReult.Text="Loteria: "+ nombLot;
                    fechLot  = "";           
                }
                if (dgvJug.RowCount > 0)
                {
                    cantResultCarg = dgvJug.RowCount - 1;
                    this.pb_info_proc_result.Minimum = 0;
                    this.pb_info_proc_result.Maximum = cantResultCarg;
                    this.pb_info_proc_result.Value = 0;
                    this.work_proc_result.RunWorkerAsync();
                }
                    
            }
        }     
        }
    }

    private void frm_proc_result_loteria_KeyPress(object sender, KeyPressEventArgs e)
    {
         char caracter;
         int codigo;
         caracter = Convert.ToChar(e.KeyChar);
         codigo = (int)caracter;
         if (codigo == 27) { this.Close();}
    }

    private void dgvJug_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        rsVerfJugCer = Convert.ToInt32(this.dgvJug.Rows[e.RowIndex].Cells[9].Value.ToString());
        if (rsVerfJugCer == 1)
        {
            dgvJug.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
        }
    }   
}
}
