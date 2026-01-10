using DevComponents.DotNetBar.Controls;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Tsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ventas_loteria
{
    public partial class frm_ventas : Form
    {
        public frm_ventas()
        {
            InitializeComponent();
        }

        clsMet objMet= new clsMet();
        DataTable dtDgvSort = new DataTable();
        DataTable dtCboLot = new DataTable();
        DataTable dtDgvJug = new DataTable();
        DataTable dtNombProd = new DataTable();
        crear_ticket ticket = new crear_ticket();

        string idTck = "";
        int idLot = 0, idSort = 0;
        int idUsu = 0, codMaxProd = 0;
        string nombLot = "", nombSort = "";
        double mTotalJug = 0;
        double mJug = 0;
        int idGrup=0, idPerf = 0;
        int id_proceso = 0;

        int nroFila = 0;
        int rsVerfSort;
        string fechaHoraServ = "";
        string rsJug = "";

        string abrevLot = "", msjInfo = "";
        DateTime horaServ, horaSort, horaSortJug;
        Boolean validBorraJug = false;

        string fechaHora = "", FechaAct = "";
        string[] rsDat = null;
        string HoraAct = "";
        string[] rsVerfStatTaq = new string[3];

        List<int> ListSortDel = new List<int>();
        List<int> ListJudDel = new List<int>();

        int dig = 0;
        string rsForm = "";
        Boolean proc = false;
        string cMont = "";
        private void frm_ventas_Load(object sender, EventArgs e)
        {

            if (Convert.ToInt16(clsMet.idUsu) == 36) { txtMonto.Text = "0,00"; }
            else { txtMonto.Text = ""; }
            txtCodigo.Focus();

            this.Text = "Ventas Taquilla.";
            tmpReloj.Enabled = true;
            tmpReloj.Interval = 1000;

            tmpProceso.Enabled = true;
            tmpProceso.Interval = 60000;

            this.dgvSort.AllowUserToAddRows = false;
            this.dgvSort.RowHeadersVisible = false;

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

            idGrup = Convert.ToInt32(clsMet.idGrup);
            idUsu = Convert.ToInt32(clsMet.idUsu);
            idPerf = Convert.ToInt32(clsMet.idPerf);
            this.KeyPreview = true;

            LblNombDivisa.Text = clsMet.NombDivisa.ToUpper();
            lblTotVenta.Text = "0,00";
            lblTotVentAn.Text = "0,00";
            lblTotVentTrip.Text = "0,00";
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
                dtCboLot = objMet.listLotTod(idGrup);
                dtDgvSort = objMet.busLot(idUsu);
                dtNombProd = objMet.busNombProd();
                fechaHoraServ = objMet.verfHoraServ(idUsu);
                rsDat = objMet.busFechHoraServ();

                id_proceso = 1;
                work_inicia_frm.CancelAsync();
                e.Cancel = work_inicia_frm.CancellationPending;
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
                this.cboLot.DisplayMember = "nombLot";
                this.cboLot.ValueMember = "idLot";
                this.cboLot.DataSource = dtCboLot;

                clsMet.FechaActual = Convert.ToDateTime(rsDat[0].ToString()).ToString("yyyy/MM/dd");
                FechaAct = Convert.ToDateTime(rsDat[0].ToString()).ToString("dd/MM/yyyy");
                HoraAct = Convert.ToDateTime(rsDat[1].ToString()).ToString("hh:mm:ss");

                this.Text = "Usuario:".ToUpper();
                this.Text += clsMet.nombUsu.ToUpper();
                this.Text += " - Fecha: ".ToUpper();
                this.Text += FechaAct;

                dgvSort.DataSource = dtDgvSort;
                horaServ = Convert.ToDateTime(fechaHoraServ);
                msjInfo = "Hora Cierre: ";
                msjInfo += Convert.ToDateTime(fechaHoraServ).ToString("hh:mm:ss");

                lblHoraCierre.Text = msjInfo;
                busCuadCaj();
            }
        }

        private void tmpReloj_Tick(object sender, EventArgs e)
        {
            horaServ = horaServ.AddSeconds(1);
            msjInfo = "Hora Cierre: " + horaServ.ToString("hh:mm:ss");
            lblHoraCierre.Text = msjInfo;
        }
        private void tmpProceso_Tick(object sender, EventArgs e)
        {
            if (dgvSort.RowCount > 0)
            {
                if (!this.work_proc_sorteos.IsBusy) { work_proc_sorteos.RunWorkerAsync(); }
            }
        }
        private void work_proc_sorteos_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0; string fechaActual = "";
            if (this.IsDisposed || !this.IsHandleCreated) return;

            try
            {
                int idStatTaq = 0;
                rsVerfStatTaq=objMet.VerfStatTaq(idUsu);

                //MessageBox.Show(rsVerfStatTaq[0].ToString()+" "+ rsVerfStatTaq[2].ToString(), "Verifique.");
                if (Convert.ToBoolean(rsVerfStatTaq[0]) == false)
                {
                    msjInfo = rsVerfStatTaq[1];
                    MessageBox.Show(msjInfo, "Verifique.");
                }
                else if (Convert.ToBoolean(rsVerfStatTaq[0]) == true)
                {
                    idStatTaq =Convert.ToInt16(rsVerfStatTaq[2]);

                    if (idStatTaq == 2)
                    {
                        msjInfo = "Usuario Inactivo. Contacte Con El ";
                        msjInfo+= "Administrador del Sistema.";
                        MessageBox.Show(msjInfo, "Verifique.");

                        if (tmpReloj != null) { tmpReloj.Stop(); tmpReloj.Dispose(); tmpReloj = null; }
                        if (tmpProceso != null) { tmpProceso.Stop(); tmpProceso.Dispose(); tmpProceso = null; }
                        if (work_proc_sorteos != null && work_proc_sorteos.IsBusy) { work_proc_sorteos.CancelAsync(); }
                        Application.Exit();
                    }
                }


                if (dgvSort.RowCount > 0)
                {
                    while (i < dgvSort.RowCount)
                    {
                        idSort = Convert.ToInt32(dgvSort.Rows[i].Cells[2].Value.ToString());
                        fechaActual = "";
                        fechaActual = Convert.ToDateTime(horaServ).ToString("yyyyy-MM-dd");
                        fechaActual += " " + dgvSort.Rows[i].Cells[5].Value.ToString();
                        horaSort = Convert.ToDateTime(fechaActual);
                        rsVerfSort = DateTime.Compare(horaServ, horaSort);

                        if (rsVerfSort >= 0)
                        {
                            //ListSortDel.Add(idSort);
                            this.Invoke(new Action(() => { dgvSort.Rows.RemoveAt(i); }));
                        }
                        else { i++; }

                    }
                }
                idLot = 0; idSort = 0;

                /////////////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////////////

                int v1 = 0, v2 = 0, c = 0;
                int rsVerfJug = 0;

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

                        if (rsVerfJug >= 0)
                        {
                            //ListJudDel.Add(idSort);
                            this.Invoke(new Action(() =>{ dgvJug.Rows.RemoveAt(c); }));
                            validBorraJug = true;
                        }
                        else { c++; }
                            
                    }
                }
                idLot = 0; idSort = 0;
                id_proceso = 1;
               
            }
            catch (Exception ex) { id_proceso = 0; MessageBox.Show("Ha Ocurrido el siguiente error: " + ex.Message, "Verifique 5."); }
            finally
            {
                if (work_proc_sorteos != null && work_proc_sorteos.IsBusy)
                {
                    work_proc_sorteos.CancelAsync();
                    e.Cancel = work_proc_sorteos.CancellationPending;
                }
            }
        }
        private void work_proc_sorteos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
           
        }
        private void work_proc_sorteos_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (this.IsDisposed) return;
                //if (id_proceso == 0) { refresc(); }
                if (validBorraJug == true) { busMontTotJug(); } //SI ELIMINA JUGADA DE SORTEO CERRADO ACTUALIZA EL MONTO DEL TICKET
                /*
                if (dgvJug.RowCount > 0)
                {
                    if (ListSortDel.Count > 0)
                    {
                       
                        Debug.WriteLine("ListSortDel.Count " + ListSortDel.Count);
                        int a = 0, b = 0, idSort = 0, idSortDel = 0;
                        while (a < ListSortDel.Count)
                        {
                            idSortDel = ListSortDel[a];
                            while (b < dgvSort.RowCount)
                            {
                                Debug.WriteLine("idSort" + idSort +" --- sorteo borrar" + idSortDel);
                                idSort = Convert.ToInt32(dgvSort.Rows[b].Cells[2].Value.ToString());
                                if (idSort == idSortDel) { { MessageBox.Show("sorteo borrado" + idSortDel); dgvSort.Rows.RemoveAt(b); } }
                                else { b++; }

                            }
                            a++;
                        }
                        ListSortDel.Clear();

                    }
                }

                if (dgvJug.RowCount > 0)
                {
                    if (ListJudDel.Count > 0)
                    {
                        Debug.WriteLine("ListJudDel.Count " + ListJudDel.Count);
                        int c = 0, d = 0, idSort = 0, idSortDel = 0;
                        while (c < ListJudDel.Count)
                        {
                            idSortDel = ListJudDel[c];
                            while (d < dgvJug.RowCount)
                            {
                                idSort = Convert.ToInt32(dgvJug.Rows[d].Cells[6].Value.ToString());
                                if (idSort == idSortDel) { { dgvJug.Rows.RemoveAt(d); } }
                                else { d++; }
                            }
                            c++;
                        }
                        ListJudDel.Clear();
                    }
                }
                */
            }
            catch (Exception ex)
            {
                msjInfo = "Ha Ocurrido el siguiente error en: ";
                msjInfo += "work_proc_sorteos_OnRunWorkerCompleted. ";
                MessageBox.Show(msjInfo + ex.Message, "Verifique.");
            }
        }
        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
            if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }

            if (Convert.ToInt16(clsMet.idUsu) == 36)
            {

                try
                {
                    dig = Convert.ToInt32((Keys)e.KeyChar);
                    e.Handled = true;

                    if (dig == 8)
                    {

                        if (string.IsNullOrEmpty(cMont)) { rsForm = "0,00"; }
                        if (cMont.Length == 0) { rsForm = "0,00"; }
                        else if (cMont.Length >= 1)
                        {
                            cMont = cMont.Substring(0, cMont.Length - 1);

                            if (cMont.Length == 0) { rsForm = "0,00"; proc = false; }
                            else if ((cMont.Length == 1) && (cMont == "-"))
                            { rsForm = "0,00"; cMont = ""; proc = false; }
                            else { proc = true; }
                        }
                    }

                    else if (dig == 45)
                    {
                        if (!cMont.Contains(Convert.ToChar(e.KeyChar)))
                        {
                            cMont = Convert.ToChar(e.KeyChar) + cMont; proc = true;
                        }
                    }

                    else if ((dig >= 48) && (dig <= 57))
                    {
                        cMont += e.KeyChar.ToString();

                        if (Convert.ToDouble(cMont) == 0)
                        {
                            cMont = cMont.Substring(0, cMont.Length - 1);
                            proc = false;
                        }
                        else { proc = true; }
                    }

                    /*#################################################################################################################
                     * ###############################################################################################################*/

                    if (proc == true) { rsForm = objMet.formatMonto(cMont); }

                    txtMonto.Text = rsForm;
                    txtMonto.SelectionStart = txtMonto.Text.Length;
                }
                catch (Exception ex) { MessageBox.Show("Ha ocurrido el siguiente error:" + ex.Message, "Verifique..."); }
            }

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

                int v1 = 0, v2 = 0;
                string c1 = "";
                Boolean valid= true;

                foreach (DataGridViewRow row in dgvSort.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(cell.Value) == true)
                    {
                        idLot = 0; idSort = 0;
                        nombLot = ""; abrevLot = "";
                        idLot = Convert.ToInt32(row.Cells[1].Value.ToString());
                        idSort = Convert.ToInt32(row.Cells[2].Value.ToString());
                        codMaxProd= Convert.ToInt32(row.Cells[3].Value.ToString());
                        nombLot = row.Cells[4].Value.ToString();
                        horaSortJug = Convert.ToDateTime(row.Cells[5].Value.ToString());
                        abrevLot = row.Cells[7].Value.ToString();

                        // MessageBox.Show(codMaxProd.ToString());
                        if (Convert.ToInt32(txtCodigo.Text) <= codMaxProd)
                        {
                            if (dgvJug.RowCount == 0)
                            {
                                if (Convert.ToDouble(clsMet.montMaxTck) < Convert.ToDouble(txtMonto.Text))
                                {
                                    msjInfo = "El maximo por ticket es de: ";
                                    msjInfo += clsMet.montMaxTck.ToString("N2");
                                    MessageBox.Show(msjInfo, "Verifique.");
                                    txtMonto.Focus();
                                    valid = false;
                                }
                                else { valid = true; }
                            }

                            else if (dgvJug.RowCount > 0)
                            {
                                for (int c = 0; c < dgvJug.RowCount; c++)
                                {
                                    c1 = dgvJug.Rows[c].Cells[2].Value.ToString();
                                    v1 = Convert.ToInt32(dgvJug.Rows[c].Cells[5].Value.ToString());
                                    v2 = Convert.ToInt32(dgvJug.Rows[c].Cells[6].Value.ToString());

                                    mTotalJug = mTotalJug +
                                                Convert.ToDouble(txt_monto_jug.Text) +
                                                Convert.ToDouble(txtMonto.Text);

                                    if (Convert.ToDouble(clsMet.montMaxTck) < Convert.ToDouble(mTotalJug))
                                    {
                                        msjInfo = "El maximo por ticket es de: ";
                                        msjInfo += clsMet.montMaxTck.ToString("N2");
                                        MessageBox.Show(msjInfo, "Verifique.");
                                        txtMonto.Focus();

                                        mTotalJug = 0;
                                        valid = false;
                                        busMontTotJug();
                                        break;
                                    }
                                    else if ((c1 == txtCodigo.Text) && (v1 == idLot) && (v2 == idSort))
                                    {
                                        mTotalJug = Convert.ToDouble(txtMonto.Text) +
                                        Convert.ToDouble(this.dgvJug.Rows[c].Cells[4].Value.ToString());

                                        if (mTotalJug > Convert.ToDouble(clsMet.monto_max_jug))
                                        { mTotalJug = Convert.ToDouble(clsMet.monto_max_jug); }
                                        this.dgvJug.Rows[c].Cells[4].Value = Convert.ToDouble(mTotalJug).ToString("N2");

                                        mTotalJug = 0;
                                        valid = false;
                                        busMontTotJug();
                                        break;

                                    }
                                    else { mTotalJug = 0; valid = true; }
                                }
                            }
                        }
                        else if (Convert.ToInt32(txtCodigo.Text) > codMaxProd)
                        {
                            msjInfo  = "Codigo: \"" + txtCodigo.Text + "\"";
                            msjInfo += " invalido para la loteria: ";
                            msjInfo += "\"" + nombLot.ToUpper() + "\"";
                            MessageBox.Show(msjInfo, "Verifique.");
                            txtCodigo.Focus();
                            valid= false;
                        }

                        if (valid == true)
                        {
                            int dtIdlot = 0;
                            string dtCodJug = "", dtCNombProd = "";

                            for (int c = 0; c <= dtNombProd.Rows.Count; c++)
                            {
                                dtIdlot = Convert.ToInt16(dtNombProd.Rows[c][0].ToString());
                                dtCodJug = dtNombProd.Rows[c][1].ToString();
                                dtCNombProd = dtNombProd.Rows[c][2].ToString();
                                dtCNombProd = dtCNombProd.Substring(0, 3);

                                if ((idLot == dtIdlot) && (txtCodigo.Text == dtCodJug)) { break; }
                            }

                            DataRow fila_dgv = dtDgvJug.NewRow();
                            fila_dgv["abrev_loteria"] = abrevLot;
                            fila_dgv["hora_sorteo"] = Convert.ToDateTime(horaSortJug.ToString()).ToString("HH:mm:ss");
                            fila_dgv["codigo_jugada"] = txtCodigo.Text;
                            fila_dgv["nomb_product"] = dtCNombProd.ToUpper();
                            fila_dgv["monto"] = Convert.ToDouble(txtMonto.Text).ToString("N2");
                            fila_dgv["id_loteria"] = idLot;
                            fila_dgv["id_sorteo"] = idSort;
                            fila_dgv["nomb_loteria"] = nombLot;

                            dtDgvJug.Rows.Add(fila_dgv);
                            DataView dv = new DataView(dtDgvJug);
                            dv.Sort = "hora_sorteo DESC, id_sorteo ASC, codigo_jugada ASC";
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
                mJug = Convert.ToDouble(dgvJug.Rows[c].Cells[4].Value.ToString());
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
        public void busCuadCaj()
        {
            try
            {
                string rsCuadCaj= "";
                String[] rsDatCuadCaj = null;

                rsCuadCaj = objMet.busCuadCajDiario(Convert.ToInt32(clsMet.idUsu));
                rsDatCuadCaj= rsCuadCaj.Split('?');
                lblTotVenta.Text = Convert.ToDouble(rsDatCuadCaj[0]).ToString("N2");
                lblTotVentAn.Text = Convert.ToDouble(rsDatCuadCaj[1]).ToString("N2");
                lblTotVentTrip.Text = Convert.ToDouble(rsDatCuadCaj[2]).ToString("N2");
                lblTotPag.Text = Convert.ToDouble(rsDatCuadCaj[3]).ToString("N2");
                lblTotAnul.Text = Convert.ToDouble(rsDatCuadCaj[4]).ToString("N2");
                lblTotCaja.Text = Convert.ToDouble(rsDatCuadCaj[5]).ToString("N2");
                lblUltTick.Text = rsDatCuadCaj[6].ToString();
                lblUltTick.Text = rsDatCuadCaj[6].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido el siguiente error: " + ex.Message, "Verifique...5");
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

            if (codigo == 13) { if (txtCodigo.Text.Length > 0) { txtMonto.Focus(); } }
        }
        public Boolean validFrm()
        {
            Boolean validar = true;
            if (validLotSort() == false)
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
            else if (txtCodigo.Text.Length == 1)
            {
                if (txtCodigo.Text != "0") { txtCodigo.Text = txtCodigo.Text.PadLeft(2, '0'); }
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

            /*
            if (result == false)
            {
                msjInfo = "El monto de la jugada deben ser multiplos de: ";
                msjInfo += clsMet.monto_multiplo_jug;
                MessageBox.Show(msjInfo, "Verifique.");
                txtMonto.Focus();
                validar = false;
            }
            */
            if (Convert.ToDouble(clsMet.monto_min_jug) > Convert.ToDouble(txtMonto.Text))
            {
                msjInfo = "El monto  minimo de la jugada debe ser: ";
                msjInfo += clsMet.monto_min_jug.ToString("N2");
                MessageBox.Show(msjInfo, "Verifique.");
                txtMonto.Focus();
                validar = false;
            }
            else if (Convert.ToDouble(clsMet.monto_max_jug) < Convert.ToDouble(txtMonto.Text))
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
            Boolean validar = false;
            foreach (DataGridViewRow row in dgvSort.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(cell.Value) == true) { validar = true; }
            }
            return validar;
        }

        public string busTit(string prmNombLot, string prmNombSort)
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
                cantDigRellenIzq = titulo.Length + cantDigRest;
                cant_dig_rellen_der = cantDigRellenIzq + cantDigRest;
                titulo = titulo.PadLeft(cantDigRellenIzq, ' ');
            }
            titulo = titulo + "/";
            return titulo;
        }
        private void btn_pagar_ticket_Click(object sender, EventArgs e)
        {
            Boolean rsValidFrm = true;
            rsValidFrm = validFrmTck();
            string rsVerfTick = "";
            Boolean rsValidStatTick = true;

           
                if (rsValidStatTick == true)
                {
                    rsVerfTick = objMet.verfStatTck(
                    Convert.ToInt32(clsMet.idUsu),
                    txtNroTick.Text, txtNroSerial.Text);

                    if (string.IsNullOrEmpty(rsVerfTick)) rsVerfTick = "0";
                    rsValidStatTick = validStatTickPag(Convert.ToInt32(rsVerfTick));

                    if (rsValidStatTick == true)
                    {
                        string rsActStatTick = "";
                        string msjInf="";

                        rsActStatTick = objMet.actStatTck
                        (Convert.ToInt32(clsMet.idUsu),
                        txtNroTick.Text, txtNroSerial.Text);

                        if (!string.IsNullOrEmpty(rsActStatTick))
                        {
                            msjInf = "Ticket ganador. Monto a pagar: ";
                            msjInf += Convert.ToInt64(rsActStatTick).ToString("N2");
                            MessageBox.Show(msjInf, "Trasacción Exitosa.");
                            busCuadCaj();
                            txtNroTick.Text = "";
                            txtNroSerial.Text = "";
                        }
                    }
                }
           
        }
        public Boolean validFrmTck()
        {
            Boolean validar = true;
            if (string.IsNullOrEmpty(txtNroTick.Text))
            {
                MessageBox.Show("Ingrese Nro. ticket.", "Verifique.");
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
        public Boolean validStatTickPag(int prmIdStatTick)
        {
            Boolean validar = true;
            if (prmIdStatTick == 0)
            {
                MessageBox.Show("Ticket / serial no existe.", "Verifique.");
                txtNroSerial.Focus();
                validar = false;
            }

            else if (prmIdStatTick == 1)
            {
                MessageBox.Show("Ticket pendiente por proc.", "Verifique.");
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
            Boolean rsValidFrm = true;
            rsValidFrm = validFrmTck();
            string rsVerfTck= "";
            string rsAnulaTick = "";
            string msjInf = "";
            Boolean rsValidStatTick = true;

            try
            {
                if (rsValidFrm == true)
                {
                    rsVerfTck = objMet.verfStatTck
                    (Convert.ToInt32(clsMet.idUsu),
                    txtNroTick.Text, txtNroSerial.Text);

                    //MessageBox.Show(rs_verf_ticket_anular);
                    if (string.IsNullOrEmpty(rsVerfTck)) rsVerfTck = "0";

                    rsValidStatTick = validStatTck
                    (Convert.ToInt32(rsVerfTck));

                    if (rsValidStatTick == true)
                    {
                        rsAnulaTick = objMet.verfDetTckAnu(txtNroTick.Text);
                        if (rsAnulaTick == "1")
                        {
                            msjInf  = "Ticket nro: " + txtNroTick.Text;
                            msjInf += " fue anulado...";
                            MessageBox.Show(msjInf, "Transacción Exitosa.");
                            busCuadCaj();
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
        public Boolean validStatTck(int prmIdStatTck)
        {
            Boolean valida = true;
            if (prmIdStatTck == 0)
            {
                MessageBox.Show("Ticket / serial no existe.", "Verifique.");
                txtNroSerial.Focus();
                valida = false;
            }
            else if (prmIdStatTck == 2)
            {
                MessageBox.Show("Ticket fue anulado.", "Verifique.");
                txtNroSerial.Focus();
                valida = false;
            }
            else if (prmIdStatTck == 3)
            {
                MessageBox.Show("Ticket Perdedor.", "Verifique.");
                txtNroSerial.Focus();
                valida = false;
            }
            else if (prmIdStatTck == 4)
            {
                MessageBox.Show("Ticket Ganador. No Cancelado.", "Verifique.");
                txtNroSerial.Focus();
                valida = false;
            }
            else if (prmIdStatTck == 5)
            {
                MessageBox.Show("Ticket Ganador ya fue cobrado.", "Verifique.");
                txtNroSerial.Focus();
                valida = false;
            }
            return valida;
        }
        private void btn_verf_ticket_Click(object sender, EventArgs e)
        {
            Boolean rsValidFrm = true;
            rsValidFrm = validFrmTck();
            string rs_verf_exists_ticket = "";
            string msj_info = "";

            if (rsValidFrm == true)
            {
                rs_verf_exists_ticket = objMet.verfExitsMostTick(
                                    Convert.ToInt32(clsMet.idUsu),
                                    Convert.ToInt64(txtNroTick.Text),
                                     Convert.ToInt64(txtNroSerial.Text));

                if (rs_verf_exists_ticket == "1")
                {
                    frm_verf_ticket objVerfTick = new frm_verf_ticket();
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

            string msjInf = "", nroTck = "";
            string nroSerial = "", fechaAct = "";
            string fTck = "", hTck = "";
            Boolean rsProces;
            string codJug = "", nombProd = "";
            string nombLot = "", nombSort = "";
            double mJugBd = 0;
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
                cmdGrdTck.CommandText = "SPgrdTck";
                cmdGrdTck.Parameters.AddWithValue("prmIdGrup", idGrup);
                cmdGrdTck.Parameters.AddWithValue("prmIdUsu", idUsu);
                cmdGrdTck.Parameters.AddWithValue("prmIdTipTck", 1);
                MySqlDataReader dr = cmdGrdTck.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    rsProces = true;
                    rsDat[0] = rsProces.ToString();
                    rsDat[1] = dr["prmContTck"].ToString();
                    rsDat[2] = dr["prmNroSer"].ToString();
                    rsDat[3] = dr["fecha_ticket"].ToString();
                    rsDat[4] = dr["hora_ticket"].ToString();
                    rsDat[5] = dr["fechaHoraVerf"].ToString();
                    rsDat[6] = dr["prmIdTck"].ToString();
                }
                dr.Close();

                rsProces = Convert.ToBoolean(rsDat[0].ToString());
                nroTck = rsDat[1].ToString();
                nroSerial = rsDat[2].ToString();
                fTck = Convert.ToDateTime(rsDat[3]).ToString("dd/MM/yyyy");
                hTck = rsDat[4].ToString();
                fechaHoraVerf = Convert.ToDateTime(rsDat[5].ToString());
                idTck = rsDat[6].ToString();
                rsVerfTiempo = DateTime.Compare(fechaHoraVerf, horaServ);
                if (rsVerfTiempo > 0) { horaServ = fechaHoraVerf; }

                ////////////////////////////////////////////////////////////////////////////////////
                ////////////////////////REGISTRA DETALLE TICKET ////////////////////////////////////
                int c = 0;
                while (c < dgvJug.RowCount)
                {
                    fechaAct = "";
                    fechaAct = Convert.ToDateTime(fechaHoraVerf).ToString("yyy-MM-dd");
                    fechaAct += " " + dgvJug.Rows[c].Cells[1].Value.ToString();
                    horaSortJug = Convert.ToDateTime(fechaAct);

                    nombSort = dgvJug.Rows[c].Cells[1].Value.ToString();
                    codJug = dgvJug.Rows[c].Cells[2].Value.ToString();
                    nombProd = dgvJug.Rows[c].Cells[3].Value.ToString();
                    mJug = Convert.ToDouble(dgvJug.Rows[c].Cells[4].Value.ToString());
                    idLot = Convert.ToInt32(dgvJug.Rows[c].Cells[5].Value.ToString());
                    idSort = Convert.ToInt32(dgvJug.Rows[c].Cells[6].Value.ToString());
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
                        cmdDetTck.Parameters.AddWithValue("prmMonto", Convert.ToString(mJug).Replace(".", "").Replace(",", "."));
                        MySqlDataReader drDetTck = cmdDetTck.ExecuteReader();
                        //rsDat3 = cmdDetTck.ExecuteNonQuery().ToString();
                        drDetTck.Read();
                        rsDat3 = drDetTck["prmGrd"].ToString();
                        mJugBd = Convert.ToDouble(drDetTck["prmMonto"].ToString().Replace(".",","));
                        drDetTck.Close();
                        cmdDetTck.Parameters.Clear();

                        if (Convert.ToInt16(rsDat3) == 0)
                        {
                            msjInf = "El sorteo:\"" + nombLot + "\"";
                            msjInf += " se encuentra bloqueado.";
                            MessageBox.Show(msjInf.ToUpper(), " ¡ Bloqueado !");
                            dgvJug.Rows.RemoveAt(c); c--;
                        }

                        else if (Convert.ToInt16(rsDat3) == 1)
                        {
                            msjInf = "El producto:\"" + codJug + " - " + nombProd + "\"";
                            msjInf += " se encuentra bloqueado.";
                            msjInf += " para la loteria:\"" + nombLot + "\"";
                            MessageBox.Show(msjInf.ToUpper(), " ¡ Bloqueado !");
                            dgvJug.Rows.RemoveAt(c); c--;
                        }
                        else if (Convert.ToInt16(rsDat3) == 2)
                        {
                            msjInf = "El cupo para el ";
                            msjInf += "producto:\"" + codJug + " - " + nombProd + "\"";
                            msjInf += " se encuentra agotado.";
                            msjInf += " para la loteria:\"" + nombLot + "\"";
                            MessageBox.Show(msjInf.ToUpper(), "¡ Cupo Agotado !");
                            dgvJug.Rows.RemoveAt(c); c--;

                        }
                        else if (Convert.ToInt16(rsDat3) == 3)
                        {
                            if (mJug != mJugBd)
                            {
                                dgvJug.Rows[c].Cells[4].Value = mJugBd.ToString("N2"); ;
                                msjInf = "El cupo disponible para el ";
                                msjInf += "producto:\"" + codJug + " - " + nombProd + "\"";
                                msjInf += " es de:" + mJugBd;
                                msjInf += " para la loteria:\"" + nombLot + "\"";
                                MessageBox.Show(msjInf, "¡ Cupo Disponible !");
                            }
                            cont++;
                        }
                    }
                    else if (rsVerfJug >= 0)
                    {
                        sortAb = true;
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

                    string monto = "", cadResult = "";
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
                            cadResult += busTit(nombLot, "");
                        }

                        cadResult += codJug.PadRight(3, ' ');
                        cadResult += nombProd.ToUpper().PadRight(4, ' ');
                        cadResult += Convert.ToDouble(monto).ToString("N2") + "  ";
                        if (cont_jud == 2) { cadResult += "/"; cont_jud = 0; }

                        idLotAnt = Convert.ToInt32(dgvJug.Rows[d].Cells[5].Value.ToString());
                        idSortAnt = Convert.ToInt32(dgvJug.Rows[d].Cells[6].Value.ToString());
                    }

                    dtDgvJug.Clear();
                    dgvJug.DataSource = dtDgvJug;
                    frm_rpt_ticket_venta objRpt = new frm_rpt_ticket_venta();
                    objRpt.nombTaq = clsMet.nombUsu;
                    objRpt.fecha = fTck;
                    objRpt.hora = hTck;
                    objRpt.nroTicket = nroTck.ToString();
                    objRpt.nroSerial = nroSerial;
                    objRpt.detJug = cadResult;
                    objRpt.totVenta = Convert.ToDouble(txt_monto_jug.Text);
                    objRpt.totVenta = Convert.ToDouble(txt_monto_jug.Text);
                    objRpt.nroDiaCad = clsMet.cantDiaCadTck;
                    objRpt.ShowDialog();

                    lblUltTick.Text = nroTck.ToString();
                    mTotalJug = 0;
                    txt_monto_jug.Text = "0";
                    lblMontJug.Text = "0.00";

                    if (Convert.ToInt16(clsMet.idUsu) == 36) { txtMonto.Text = "0.00"; cMont = ""; }
                    txtCodigo.Focus();

                    myTrans.Commit();
                    busCuadCaj();
                    if (sortAb == true) { refresc(); }
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
            int cod=0;
            caracter = Convert.ToChar(e.KeyChar);
            cod = (int)caracter;

            if ((cod == 27) || (cod == 43))
            {
                if (dgvJug.RowCount == 0) { return; }

                string msjInf = "", nroTck = "";
                string nroSerial = "", fechaAct = "";
                string fTck = "", hTck = "";
                Boolean rsProces;
                string codJug = "", nombProd = "";
                string nombLot = "", nombSort = "";
                double mJugBd = 0;
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
                    cmdGrdTck.CommandText = "SPgrdTck";
                    cmdGrdTck.Parameters.AddWithValue("prmIdGrup", idGrup);
                    cmdGrdTck.Parameters.AddWithValue("prmIdUsu", idUsu);
                    cmdGrdTck.Parameters.AddWithValue("prmIdTipTck", 1);
                    MySqlDataReader dr = cmdGrdTck.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        rsProces = true;
                        rsDat[0] = rsProces.ToString();
                        rsDat[1] = dr["prmContTck"].ToString();
                        rsDat[2] = dr["prmNroSer"].ToString();
                        rsDat[3] = dr["fecha_ticket"].ToString();
                        rsDat[4] = dr["hora_ticket"].ToString();
                        rsDat[5] = dr["fechaHoraVerf"].ToString();
                        rsDat[6] = dr["prmIdTck"].ToString();
                    }
                    dr.Close();

                    rsProces = Convert.ToBoolean(rsDat[0].ToString());
                    nroTck = rsDat[1].ToString();
                    nroSerial = rsDat[2].ToString();
                    fTck = Convert.ToDateTime(rsDat[3]).ToString("dd/MM/yyyy");
                    hTck = rsDat[4].ToString();
                    fechaHoraVerf = Convert.ToDateTime(rsDat[5].ToString());
                    idTck = rsDat[6].ToString();
                    rsVerfTiempo = DateTime.Compare(fechaHoraVerf, horaServ);
                    if (rsVerfTiempo > 0) { horaServ = fechaHoraVerf; }

                    ////////////////////////////////////////////////////////////////////////////////////
                    ////////////////////////REGISTRA DETALLE TICKET ////////////////////////////////////
                    int c = 0;
                    while (c < dgvJug.RowCount)
                    {
                        fechaAct = "";
                        fechaAct = Convert.ToDateTime(fechaHoraVerf).ToString("yyy-MM-dd");
                        fechaAct += " " + dgvJug.Rows[c].Cells[1].Value.ToString();
                        horaSortJug = Convert.ToDateTime(fechaAct);

                        nombSort = dgvJug.Rows[c].Cells[1].Value.ToString();
                        codJug = dgvJug.Rows[c].Cells[2].Value.ToString();
                        nombProd = dgvJug.Rows[c].Cells[3].Value.ToString();
                        mJug = Convert.ToDouble(dgvJug.Rows[c].Cells[4].Value.ToString());
                        idLot = Convert.ToInt32(dgvJug.Rows[c].Cells[5].Value.ToString());
                        idSort = Convert.ToInt32(dgvJug.Rows[c].Cells[6].Value.ToString());
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
                            cmdDetTck.Parameters.AddWithValue("prmMonto", Convert.ToString(mJug).Replace(".", "").Replace(",", "."));
                            MySqlDataReader drDetTck = cmdDetTck.ExecuteReader();
                            //rsDat3 = cmdDetTck.ExecuteNonQuery().ToString();
                            drDetTck.Read();
                            rsDat3 = drDetTck["prmGrd"].ToString();
                            mJugBd = Convert.ToDouble(drDetTck["prmMonto"].ToString().Replace(".", ","));
                            drDetTck.Close();
                            cmdDetTck.Parameters.Clear();

                            if (Convert.ToInt16(rsDat3) == 0)
                            {
                                msjInf = "El sorteo:\"" + nombLot + "\"";
                                msjInf += " se encuentra bloqueado.";
                                MessageBox.Show(msjInf.ToUpper(), " ¡ Bloqueado !");
                                dgvJug.Rows.RemoveAt(c); c--;
                            }

                            else if (Convert.ToInt16(rsDat3) == 1)
                            {
                                msjInf = "El producto:\"" + codJug + " - " + nombProd + "\"";
                                msjInf += " se encuentra bloqueado.";
                                msjInf += " para la loteria:\"" + nombLot + "\"";
                                MessageBox.Show(msjInf.ToUpper(), " ¡ Bloqueado !");
                                dgvJug.Rows.RemoveAt(c); c--;
                            }
                            else if (Convert.ToInt16(rsDat3) == 2)
                            {
                                msjInf = "El cupo para el ";
                                msjInf += "producto:\"" + codJug + " - " + nombProd + "\"";
                                msjInf += " se encuentra agotado.";
                                msjInf += " para la loteria:\"" + nombLot + "\"";
                                MessageBox.Show(msjInf.ToUpper(), "¡ Cupo Agotado !");
                                dgvJug.Rows.RemoveAt(c); c--;

                            }
                            else if (Convert.ToInt16(rsDat3) == 3)
                            {
                                if (mJug != mJugBd)
                                {
                                    dgvJug.Rows[c].Cells[4].Value = mJugBd.ToString("N2"); ;
                                    msjInf = "El cupo disponible para el ";
                                    msjInf += "producto:\"" + codJug + " - " + nombProd + "\"";
                                    msjInf += " es de:" + mJugBd;
                                    msjInf += " para la loteria:\"" + nombLot + "\"";
                                    MessageBox.Show(msjInf, "¡ Cupo Disponible !");
                                }
                                cont++;
                            }
                        }
                        else if (rsVerfJug >= 0)
                        {
                            sortAb = true;
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

                        string monto = "", cadResult = "";
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
                                cadResult += busTit(nombLot, "");
                            }

                            cadResult += codJug.PadRight(3, ' ');
                            cadResult += nombProd.ToUpper().PadRight(4, ' ');
                            cadResult += Convert.ToDouble(monto).ToString("N2") + "  ";
                            if (cont_jud == 2) { cadResult += "/"; cont_jud = 0; }

                            idLotAnt = Convert.ToInt32(dgvJug.Rows[d].Cells[5].Value.ToString());
                            idSortAnt = Convert.ToInt32(dgvJug.Rows[d].Cells[6].Value.ToString());
                        }

                        dtDgvJug.Clear();
                        dgvJug.DataSource = dtDgvJug;
                        frm_rpt_ticket_venta objRpt = new frm_rpt_ticket_venta();
                        objRpt.nombTaq = clsMet.nombUsu;
                        objRpt.fecha = fTck;
                        objRpt.hora = hTck;
                        objRpt.nroTicket = nroTck.ToString();
                        objRpt.nroSerial = nroSerial;
                        objRpt.detJug = cadResult;
                        objRpt.totVenta = Convert.ToDouble(txt_monto_jug.Text);
                        objRpt.totVenta = Convert.ToDouble(txt_monto_jug.Text);
                        objRpt.nroDiaCad = clsMet.cantDiaCadTck;
                        objRpt.ShowDialog();

                        lblUltTick.Text = nroTck.ToString();
                        mTotalJug = 0;
                        txt_monto_jug.Text = "0";
                        lblMontJug.Text = "0.00";

                        if (Convert.ToInt16(clsMet.idUsu) == 36) { txtMonto.Text = "0.00"; cMont = ""; }
                        txtCodigo.Focus();

                        myTrans.Commit();
                        busCuadCaj();
                        if (sortAb == true) { refresc(); }
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
            Boolean validRepetTick = true;
            validRepetTick = rVerfRepetTick();
            if (validRepetTick == true)
            {
                string rsExistTick = "";
                rsExistTick = objMet.verf_grd_repet_ticket(
                          Convert.ToInt32(clsMet.idUsu),
                                               txtNroTick.Text);

                if (rsExistTick == "0")
                {
                    MessageBox.Show("El Nº. Ticket introducido no existe...", "Verfique.");
                    txtNroTick.Focus();
                    return;
                }
                else if (rsExistTick == "1")
                {
                    foreach (DataGridViewRow row in dgvSort.Rows)
                    {
                        DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                        if (cell.Value != null)
                        {
                            if (Convert.ToBoolean(cell.Value) == true)
                            {
                                idLot = Convert.ToInt32(row.Cells[1].Value.ToString());
                                idSort = Convert.ToInt32(row.Cells[2].Value.ToString());
                                nombLot = row.Cells[4].Value.ToString();
                                horaSortJug = Convert.ToDateTime(row.Cells[5].Value.ToString());
                                abrevLot = row.Cells[7].Value.ToString();
                                dtDgvJug = objMet.repet_jugada_ticket(
                                                            txtNroTick.Text,
                                                            idLot, idSort,
                                                            nombLot,
                                                            Convert.ToDateTime(horaSortJug.ToString()).ToString("HH:mm:ss"),
                                                            abrevLot);
                                idLot = 0; idSort = 0;
                                nombLot = ""; abrevLot = "";
                            }
                        }
                    }
                    dtDgvJug = objMet.busJug(txtNroTick.Text);
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
                MessageBox.Show("Ingrese Nº. Ticket a repetir...", "Verifique.");
                txtNroTick.Focus();
                validar = false;
            }
            else if (Convert.ToInt32(txtNroTick.Text) == 0)
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

        private void dgvSort_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int nroFil;
            if (dgvSort.RowCount > 0)
            {
                nroFil = Convert.ToInt32(dgvSort.CurrentRow.Index.ToString());
                DataGridViewCheckBoxCell cell = dgvSort.Rows[nroFil].Cells[0] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(cell.Value) == true) { cell.Value = false; }
                else if (Convert.ToBoolean(cell.Value) == false) { cell.Value = true; }
            }
        }

        private void btnSal_Click(object sender, EventArgs e)
        {
            string msjInf = "";
            if (idPerf == 1)
            {
                msjInf = "¿Esta usted seguro que desea salir del sistema?";
                if (MessageBox.Show(msjInf, "Verifique.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    if (this.work_proc_sorteos.IsBusy)
                    {
                        msjInf = "Se esta ejecutando el procedimiento asincrono";
                        msjInf += " para proc los sorteos, por ";
                        msjInf += " favor espere.";
                        MessageBox.Show(msjInf, "¡ Espere !");
                    }
                    else { Application.Exit(); }
                }
            }
            else 
            {
                if (this.work_proc_sorteos.IsBusy)
                {
                    msjInf = "Se esta ejecutando el procedimiento asincrono";
                    msjInf += " para proc los sorteos, por ";
                    msjInf += " favor espere.";
                    MessageBox.Show(msjInf, "¡ Espere !");
                }
                else { this.Close(); }
               
            }
        }

        private void btnVerfVent_Click(object sender, EventArgs e)
        {
            frmVentLot objFrm = new frmVentLot();
            objFrm.ShowDialog();
        }

        private void frm_ventas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tmpReloj != null) { tmpReloj.Stop(); tmpReloj.Dispose(); tmpReloj = null; }
            if (tmpProceso != null) { tmpProceso.Stop(); tmpProceso.Dispose(); tmpProceso = null; }
            if (work_proc_sorteos != null && work_proc_sorteos.IsBusy){ work_proc_sorteos.CancelAsync(); }
        }

        private void btnTrip_Click(object sender, EventArgs e)
        {
            frmTrip objFrm = new frmTrip();
            objFrm.ShowDialog();

           if(clsMet.verfAct==true) { busCuadCaj(); clsMet.verfAct = false; }
        }

        private void cboLot_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idLot = Convert.ToInt16(cboLot.SelectedValue);
            dtDgvSort = objMet.listSortVentTod(idUsu,idLot);
            dgvSort.DataSource = dtDgvSort;
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
            catch (Exception ex) { MessageBox.Show("Ha ocurrido el siguiente error: " + ex.Message, "Verifique."); }
        }

        private void btn_inprimir_tck_Click(object sender, EventArgs e)
        {
            string nroTck = "", nroSer = "";
            string fTck = "", hTck = "";
            int cantTick, permitReimp;
            string mTck = "";
            int cantMinReimp;

            string codJug = "", nombProd = "";
            int idLotAnt = 0, idLotSig = 0;
            int idSortAnt = 0, idSortSig = 0;
            string nombLot = "", nombSort = "";
            string cadRs = "", monto = "";
            string msjInfo = "";

            try
            {
                string rsInfTick = "";
                string[] rsDatInfTick = null;
                rsInfTick = objMet.busInfTicket(
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
                        nroTck = rsDatInfTick[3].ToString();
                        nroSer = rsDatInfTick[4].ToString();
                        fTck = Convert.ToDateTime(rsDatInfTick[5].ToString()).ToString("dd/MM/yyyy");
                        hTck = rsDatInfTick[6].ToString();
                        mTck = rsDatInfTick[7].ToString();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }

            try
            {
                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = clsMet.cn; cnBd.Open();
                    int contJud = 0; clsMet.idCn = 1;

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPreimpTck";
                        cmd.Parameters.AddWithValue("prmIdUsu", Convert.ToInt32(clsMet.idUsu));
                        cmd.Parameters.AddWithValue("prmNroTck", nroTck);
                        MySqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            idLotSig = Convert.ToInt32(dr["idLot"].ToString());
                            idSortSig = Convert.ToInt32(dr["idSort"].ToString());
                            codJug = dr["codJug"].ToString();
                            nombProd = dr["nombProd"].ToString();
                            monto = dr["mont"].ToString();
                            nombSort = dr["nombSort"].ToString();
                            nombLot = dr["nombLot"].ToString();
                            contJud++;

                            if (codJug.Length == 1) { codJug.PadRight(1, ' '); }

                            if ((idLotAnt != idLotSig) || idSortAnt != idSortSig)
                            {
                                if (cadRs.Length > 0) { cadRs += "/"; contJud = 1; }
                                cadRs += busTit(nombLot, nombSort);
                            }

                            cadRs += codJug.PadRight(3, ' ');
                            cadRs += nombProd.Substring(0,3).ToUpper().PadRight(4, ' ');
                            cadRs += Convert.ToDouble(monto).ToString("N2") + "  ";
                            if (contJud == 2) { cadRs += "/"; contJud = 0; }

                            idLotAnt = idLotSig;
                            idSortAnt = idSortSig;
                        }
                        dr.Close();
                    }
                }

                frm_rpt_ticket_venta objTckVent = new frm_rpt_ticket_venta();
                objTckVent.nombTaq = clsMet.nombUsu;
                objTckVent.fecha = fTck;
                objTckVent.hora = hTck;
                objTckVent.nroTicket = nroTck;
                objTckVent.nroSerial = nroSer;
                objTckVent.detJug = cadRs;
                objTckVent.totVenta = Convert.ToDouble(mTck);
                objTckVent.nroDiaCad = clsMet.cantDiaCadTck;
                objTckVent.ShowDialog();
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
        public void refresc()
        {
            this.Hide();
            frm_ventas objRefresc = new frm_ventas();
            objRefresc.Show();
        }

    }
}
