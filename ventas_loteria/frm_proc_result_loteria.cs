using HtmlAgilityPack;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;


namespace ventas_loteria
{
    public partial class frm_proc_result_loteria : Form
    {
        public frm_proc_result_loteria()
        {
            InitializeComponent();
        }

        clsMet objMet = new clsMet();
        DataTable dtDgvSort = new DataTable();
        DataTable dtCboLot = new DataTable();
        DataTable dtcboTipProc = new DataTable();
        DataTable dtDgvJug = new DataTable();
        DataTable dtCboTipTck = new DataTable();
        HtmlWeb web = new HtmlWeb();

        int idLot = 0, idSort = 0;
        int idGrup = 0, idPerf = 0;
        int idTipTck = 0;
        string fechLot = "";
        int cantRsCarg = 0;
        int codMaxProd;
        string msjProcRs = "";
        string nombLot = "";
        string nombAn = "";
        string codRsLot = "";
        string nombSort = "";
        int idProc = 0;
        Boolean ValGrdRs = false;
        Boolean ValJug = false;

        string[] rsNombLot = null;
        string prmNombLot = "";

        string[] rs_rs_lot = null;
        string prmRsLot = "";

        string rsHoraLot = "";
        string prmHoraLot = "";

        string horaSortBus = "";
        string nombLotBus = "";

        string rsGan = "";
        string[] prmGrdRs = null;
        string rsGrdRsLot = "";

        int idDetJug = 0;
        string  nroTck = "";
        string cod_jug = "";
        long monto_jug = 0;

        string mTck="";
        int idUsu = 0, idStatTck = 0;

        int cont = 0;
        int contRegPed = 0;
        int contRegGan = 0;
        string rsDat = "";
        string msjInf = "";
        int rsVerfJugCer = 0;
        List<UserAg> _listUserAg = new List<UserAg>();
        private void frm_proc_result_loteria_Load(object sender, EventArgs e)
        {
            this.Text = "proc Resultados...".ToUpper();
            this.dgvSort.AllowUserToAddRows = false;
            this.dgvSort.RowHeadersVisible = false;

            this.dgvJug.AllowUserToAddRows = false;
            this.dgvJug.RowHeadersVisible = false;
            this.dgvJug.ColumnHeadersVisible = false;

            idPerf = Convert.ToInt16(clsMet.idPerf);
            lblMsjInf.Text = "";
            lblMsjErr.Text = "";
            txtCod.Enabled = false;
            dtpFecha.Enabled = false;
            idGrup = Convert.ToInt32(clsMet.idGrup);

            gbInfProcRs.Text = "Jug:0. Gan:0. Perd:0...";
            gp_cant_jug.Text = "cantidad jugadas: 0";

            this.dtpFecha.Value = Convert.ToDateTime(clsMet.FechaActual);
            this.dtpFecha.Format = DateTimePickerFormat.Custom;
            this.dtpFecha.CustomFormat = "dd-MM-yyyy";

            this.wkIniFrm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkIniFrm_DoWork);
            this.wkIniFrm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.wkIniFrm_OnProgressChanged);
            this.wkIniFrm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wkIniFrm_OnRunWorkerCompleted);
            this.wkIniFrm.RunWorkerAsync();

            this.wkProcRsMan.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkProcRsMan_DoWork);
            this.wkProcRsMan.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.wkProcRsMan_ProgressChanged);
            this.wkProcRsMan.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wkProcRsMan_OnRunWorkerCompleted);

            this.wkProcRsAut.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkProcRsAut_DoWork);
            this.wkProcRsAut.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.wkProcRsAut_OnProgressChanged);
            this.wkProcRsAut.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wkProcRsAut_OnRunWorkerCompleted);

            this.wkProcJugAut.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkProcJugAut_DoWork);
            this.wkProcJugAut.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.wkProcJugAut_OnProgressChanged);
            this.wkProcJugAut.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wkProcJugAut_OnRunWorkerCompleted);
        }
        private void wkIniFrm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _listUserAg = objMet.ListUserAg();
                dtCboLot = objMet.listLotTod(idGrup);
                dtDgvSort = objMet.busLotProcRs();
                dtcboTipProc = objMet.busTipProc();
                dtCboTipTck = objMet.busTipTck();
                dtDgvJug = objMet.busJugPendProc(idPerf, idGrup);
                idProc = 1;
                wkIniFrm.CancelAsync();
            }
            catch (Exception ex)
            {
                idProc = 0;
                MessageBox.Show(ex.Message, "Verifique 2");
            }
        }
        private void wkIniFrm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        private void wkIniFrm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (idProc == 1)
            {
                dgvSort.DataSource = dtDgvSort;
                cboTipProc.DisplayMember = "nomb_tipo_proc_datos";
                cboTipProc.ValueMember = "id_tipo_proc_datos";
                cboTipProc.DataSource = dtcboTipProc;

                this.cboLot.DisplayMember = "nombLot";
                this.cboLot.ValueMember = "idLot";
                this.cboLot.DataSource = dtCboLot;

                this.cboTipTck.DisplayMember = "nombTipTckLar";
                this.cboTipTck.ValueMember = "idTipTck";
                this.cboTipTck.DataSource = dtCboTipTck;

                dgvJug.DataSource = dtDgvJug;
                gp_cant_jug.Text = "Cantidad jugadas: " + dgvJug.RowCount;

                txtCod.Text = "";
                txtCod.Enabled = false;
                dtpFecha.Enabled = false;

                cboTipProc.SelectedValue = 2;
                timer1.Enabled = true;
                timer1.Interval = 120000;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtCod.Text = "";
            txtCod.Enabled = false;
            // if (clsMet.idCn == 0) { lblMsjInf.Text = clsMet.msj_error_cn; return; }

            if ((this.wkProcRsAut.IsBusy == false) && (this.wkProcJugAut.IsBusy == false))
            {
                gpReult.Text = "Loteria: ";
                fechLot = Convert.ToDateTime(dtpFecha.Text).ToString("yyyy-MM-dd");
                lblMsjInf.Text = "verificando...".ToUpper();
                this.wkProcRsAut.RunWorkerAsync();
            }
        }
        private void wkProcRsAut_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var urlTuAzar = @"https://www.tuazar.com/loteria/animalitos/resultados/";
                var urlLotHoy = @"https://loteriadehoy.com/animalitos/resultados/";
                var urlTuAzFr = @"https://www.tuazar.com/loteria/frutas/resultados/";
                var urlRA = @"https://www.ruletactiva.com.ve/";
                var urlLotVen = @"https://lotoven.com/animalitos/";
     
                var html = "";

                string idLotBus = "";
                string idSortBus = "";
                string rsLot = "";
                rsGan = "";

                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = clsMet.cn; cnBd.Open();
                    clsMet.idCn = 1;

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = cnBd;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPBusSortProcRsAut";

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            using (DataTable dtInfSort = new DataTable())
                            {
                                da.Fill(dtInfSort);
                                if (dtInfSort.Rows.Count > 0)
                                {
                                    //html=scrapPw(urlLotHoy);

                                    for (int c = 0; c <= dtInfSort.Rows.Count - 1; c++)
                                    {
                                        idLotBus = dtInfSort.Rows[c][0].ToString();
                                        idSortBus = dtInfSort.Rows[c][1].ToString();
                                        horaSortBus = Convert.ToDateTime(dtInfSort.Rows[c][2].ToString()).ToString("hh:mm");
                                        nombLotBus = dtInfSort.Rows[c][3].ToString().ToLower();

                                        rsLot = rsTuAzar(urlTuAzar, idLotBus, idSortBus, nombLotBus, horaSortBus);
                                        if (string.IsNullOrEmpty(rsLot)) { rsLot = rsTuAzar(urlTuAzFr, idLotBus, idSortBus, nombLotBus, horaSortBus); }
                                        if (string.IsNullOrEmpty(rsLot)) { rsLot = rsIndLotHoy(idLotBus, idSortBus, nombLotBus, horaSortBus); }

                                        if (!string.IsNullOrEmpty(rsLot))
                                        {
                                            if (string.IsNullOrEmpty(rsGan)) { rsGan += rsLot; }
                                            else { rsGan += "/" + rsLot; }
                                        }

                                        //MessageBox.Show(rsLot, "rsLot");
                                        //MessageBox.Show(rsGan);


                                        /////////////////////////////////////////////////////////////////////////////////////
                                        ////////////////////////////////// RULETA ACTIVA ////////////////////////////////////

                                        else if ((idLotBus == "8"))
                                        {
                                            if (string.IsNullOrEmpty(rsGan))
                                            {
                                                rsGan += result_grupo2(urlRA, idLotBus, idSortBus,
                                                                           horaSortBus, nombLotBus);
                                            }
                                            else
                                            {
                                                rsGan += "/" + result_grupo2(urlRA, idLotBus, idSortBus,
                                                                              horaSortBus, nombLotBus);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                if (string.IsNullOrEmpty(rsGan)) { msjInf = "No se ubicaron resultados...".ToUpper(); }
                else if (!string.IsNullOrEmpty(rsGan))
                {
                    prmGrdRs = rsGan.Split('/');
                    rsGan = "";
                    int contArr = 0;
                    string[] rsDetLot = null;

                    while (contArr < prmGrdRs.Length)
                    {
                        rsDetLot = prmGrdRs[contArr].Split('-');
                        idLot = Convert.ToInt32(rsDetLot[0].ToString());
                        idSort = Convert.ToInt32(rsDetLot[1].ToString());
                        codRsLot = rsDetLot[2].ToString();
                        nombAn = rsDetLot[3].ToString();
                        nombLot = rsDetLot[4].ToString();

                        if (codRsLot.Length == 1) { if (codRsLot != "0") { codRsLot = codRsLot.PadLeft(2, '0'); } }
                        rsGrdRsLot = objMet.grdActRstLot(idLot, idSort, codRsLot, fechLot);
                        if (rsGrdRsLot == "1") { wkProcRsAut.ReportProgress(contArr); }
                        contArr++;
                    }
                }

                idProc = 1;
            }
            catch (MySqlException ex) { idProc = 0; msjInf = ex.Message; Console.WriteLine("resultados: " + ex.Message); }
            catch (Exception ex) { idProc = 0; msjInf = ex.Message; }
            finally { wkProcRsAut.CancelAsync(); e.Cancel = wkProcRsAut.CancellationPending; }
        }
        private void wkProcRsAut_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            msjInf = "Resultado:\"" + codRsLot + "\"";
            msjInf += " - " + nombAn.ToUpper();
            gpReult.Text = "Loteria: " + nombLot;
            lblMsjInf.Text = msjInf.ToUpper();

        }
        private void wkProcRsAut_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show(e.Cancelled.ToString());
            //if (e.Cancelled == true) { MessageBox.Show("cancelado"); }
            //if (e.Cancelled == false) { MessageBox.Show("no cancelado"); }

            if (idProc == 1)
            {
                if (string.IsNullOrEmpty(rsGan)) { lblMsjInf.Text = msjInf; }
                lblMsjErr.Text = "";
                wkProcJugAut.RunWorkerAsync();
            }
            else if (idProc == 0) { lblMsjErr.Text = "wkProcRsAut: " + msjInf; }
        }


        private void wkProcJugAut_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dtDgvJug = objMet.busJugProcRs(idPerf, idGrup, fechLot);
                if (dtDgvJug.Rows.Count > 0)
                {
                    int contRs = 0;
                    cantRsCarg = dtDgvJug.Rows.Count - 1;

                    msjProcRs = "Jug:0. Gan:0. Perd:0...";
                    contRegPed = 0;
                    contRegGan = 0;

                    while (contRs <= cantRsCarg)
                    {
                        idDetJug = Convert.ToInt32(dtDgvJug.Rows[contRs][0].ToString().Trim());
                        idLot = Convert.ToInt32(dtDgvJug.Rows[contRs][1].ToString().Trim());
                        idSort = Convert.ToInt32(dtDgvJug.Rows[contRs][2].ToString().Trim());
                        idTipTck = Convert.ToInt32(dtDgvJug.Rows[contRs][3].ToString().Trim());
                        nroTck = dtDgvJug.Rows[contRs][4].ToString().Trim();
                        cod_jug = dtDgvJug.Rows[contRs][9].ToString().Trim();
                        mTck = dtDgvJug.Rows[contRs][11].ToString().Trim().Replace(".", "").Replace(",", ".");
                        codRsLot = dtDgvJug.Rows[contRs][14].ToString().Trim();
                        idUsu=Convert.ToInt32(dtDgvJug.Rows[contRs][15].ToString().Trim());
                        idStatTck = Convert.ToInt32(dtDgvJug.Rows[contRs][16].ToString().Trim());

                            //if (idTipTck == 1) { rsDat = objMet.busProcRsLot(idDetJug, idLot, idSort, codRsLot); }
                            //else if (idTipTck == 2) { rsDat = objMet.busProcRsLotTrip(idDetJug, idLot, codRsLot); }

                            if (idTipTck == 1) { rsDat = objMet.busProcRsLot(idDetJug, idLot, idSort, idUsu, idStatTck, 
                                                                        nroTck, mTck, cod_jug, codRsLot); }

                        else if (idTipTck == 2) { rsDat = objMet.busProcRsLotTrip(idDetJug, idLot, idUsu, idStatTck, 
                                                                                  nroTck, mTck, cod_jug,codRsLot); }

                        if (rsDat == "0") {  contRegPed++; }
                        else if (rsDat == "1") { contRegGan++; }
                        msjProcRs = "Jug:" + dtDgvJug.Rows.Count + ". Gan: " + contRegGan;
                        msjProcRs += ". Perd: " + contRegPed + "...";
                        wkProcJugAut.ReportProgress(contRs);
                        contRs++;
                    }

                    idProc = 1;
                }
            }
            catch (Exception ex) { idProc = 0; msjInf = "wkProcJugAut: " + ex.Message; }
            finally { wkProcJugAut.CancelAsync(); e.Cancel = wkProcRsAut.CancellationPending; }
        }
        private void wkProcJugAut_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            if (Convert.ToInt16(e.ProgressPercentage) == 0)
            {
                dgvJug.DataSource = dtDgvJug;
                gp_cant_jug.Text = "Cantidad jugadas: " + dgvJug.RowCount;

                pbInfProcRs.Minimum = 0;
                pbInfProcRs.Maximum = 0;
                pbInfProcRs.Maximum = dtDgvJug.Rows.Count - 1;
                pbInfProcRs.Value = 0;
            }

            dgvJug.CurrentCell = dgvJug.Rows[e.ProgressPercentage].Cells[4];
            dgvJug.FirstDisplayedScrollingRowIndex = e.ProgressPercentage;
            this.pbInfProcRs.Value = e.ProgressPercentage;
            gbInfProcRs.Text = msjProcRs;

        }
        private void wkProcJugAut_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show(e.Cancelled.ToString());
            //if (e.Cancelled == true) { MessageBox.Show("cancelado"); }
            //if (e.Cancelled == false) { MessageBox.Show("no cancelado"); }
            if (idProc == 1)
            {
                dtDgvJug = objMet.busJugPendProc(idPerf, idGrup);
                dgvJug.DataSource = dtDgvJug;
                gp_cant_jug.Text = "Cantidad jugadas: " + dgvJug.RowCount;

                lblMsjInf.Text = msjInf;
                lblMsjErr.Text = "";
                txtCod.Text = "";
            }
            else if (idProc == 0) { lblMsjErr.Text = msjInf; this.Refresh(); }
            rsGan = "";
            fechLot = "";
        }

        private void wkProcRsMan_DoWork(object sender, DoWorkEventArgs e)
        {
            this.wkProcRsMan.ReportProgress(0, "");
            try
            {
                cont = 0;
                contRegPed = 0;
                contRegGan = 0;

                while (cont <= cantRsCarg)
                {
                    idDetJug = Convert.ToInt32(dtDgvJug.Rows[cont][0].ToString().Trim());
                    idLot = Convert.ToInt32(dtDgvJug.Rows[cont][1].ToString().Trim());
                    idSort = Convert.ToInt32(dtDgvJug.Rows[cont][2].ToString().Trim());
                    idTipTck = Convert.ToInt32(dtDgvJug.Rows[cont][3].ToString().Trim());
                    nroTck = dtDgvJug.Rows[cont][4].ToString().Trim();
                    cod_jug = dtDgvJug.Rows[cont][9].ToString().Trim();
                    mTck = dtDgvJug.Rows[cont][11].ToString().Trim().Replace(".", "").Replace(",", ".");
                    codRsLot = dtDgvJug.Rows[cont][14].ToString().Trim();
                    idUsu = Convert.ToInt32(dtDgvJug.Rows[cont][15].ToString().Trim());
                    idStatTck = Convert.ToInt32(dtDgvJug.Rows[cont][15].ToString().Trim());
              
                    if (rsVerfJugCer == 0)
                    {
                        //if (idTipTck == 1) { rsDat = objMet.busProcRsLot(idDetJug, idLot, idSort, txtCod.Text); }
                        //else if (idTipTck == 2) { rsDat = objMet.busProcRsLotTrip(idDetJug, idLot, txtCod.Text); }

                        if (idTipTck == 1) { rsDat = objMet.busProcRsLot(idDetJug, idLot, idSort, idUsu, idStatTck, 
                                                                        nroTck, mTck, cod_jug, txtCod.Text); }
                        else if (idTipTck == 2) { rsDat = objMet.busProcRsLotTrip(idDetJug, idLot, idUsu, idStatTck,
                                                                                  nroTck, mTck, cod_jug, txtCod.Text); }

                        wkProcRsMan.ReportProgress(cont);
                        cont++;
                        if (rsDat == "0") { contRegPed++; }
                        else if (rsDat == "1") { contRegGan++; }
                        msjProcRs = "Jug:" + dgvJug.RowCount;
                        msjProcRs += ". Gan: " + contRegGan;
                        msjProcRs += ". Perd: " + contRegPed + "...";
                    }
                }

                idProc = 1;
            }
            catch (Exception ex)
            {
                string msjErr = "";
                msjErr = "Ha ocurrido un Error En la Linea: " + dgvJug.RowCount + "---" + ex.Message;
                idProc = 0;
            }
            finally { wkProcRsMan.CancelAsync(); e.Cancel = wkProcRsMan.CancellationPending; }
        }
        private void wkProcRsMan_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //SELECCIONA LA BARRA COMPLETA
            dgvJug.CurrentCell = dgvJug.Rows[e.ProgressPercentage].Cells[4];
            //MUEVE LA BARRA PARA DEPLAZAR LOS REGISTROS
            dgvJug.FirstDisplayedScrollingRowIndex = e.ProgressPercentage;
            this.pbInfProcRs.Value = e.ProgressPercentage;
            gbInfProcRs.Text = msjProcRs;
        }
        private void wkProcRsMan_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (idProc == 1)
            {
                lblMsjInf.Text += " Ticket procesados ...";
                gbInfProcRs.Text = msjProcRs;
                fechLot = Convert.ToDateTime(dtpFecha.Text).ToString("yyyy-MM-dd");

                dtDgvJug = objMet.busJugProcRs(idLot, idSort, fechLot);
                dgvJug.DataSource = dtDgvJug;
                cboTipProc.SelectedValue = 2;
                timer1.Enabled = true;

                txtCod.Text = "";
                txtCod.Enabled = false;
            }
            else if (idProc == 0)
            {
                lblMsjErr.Text = msjInf;
            }
        }
        private void dgvSort_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSort.RowCount > 0)
            {
                fechLot = Convert.ToDateTime(dtpFecha.Text).ToString("yyyy-MM-dd");
                idLot = Convert.ToInt32(dgvSort.CurrentRow.Cells[0].Value.ToString());
                codMaxProd = Convert.ToInt32(dgvSort.CurrentRow.Cells[2].Value.ToString());
                nombLot = dgvSort.CurrentRow.Cells[1].Value.ToString();

                idSort = Convert.ToInt32(dgvSort.CurrentRow.Cells[3].Value.ToString());
                nombSort = dgvSort.CurrentRow.Cells[5].Value.ToString();

                dtDgvJug = objMet.busJugProcRsMan(idPerf, idGrup, idSort, fechLot);
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
        public Boolean validFrm()
        {
            Boolean validar = true;
            if (string.IsNullOrEmpty(txtCod.Text))
            {
                MessageBox.Show("Ingrese Codigo...", "Verifique");
                txtCod.Focus();
                validar = false;
            }
            else if (Convert.ToInt32(txtCod.Text) > codMaxProd)
            {
                MessageBox.Show("Codigo invalido...", "Verifique");
                txtCod.Focus();
                validar = false;
            }
            else if (txtCod.Text.Length == 1)
            {
                if (
                        (Convert.ToInt32(txtCod.Text) >= 1) &&
                        (Convert.ToInt32(txtCod.Text) <= 9)
                   )
                {
                    txtCod.Text = "0" + txtCod.Text;
                }
            }
            return validar;
        }
        private void cboTipProc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idTipPoc = 0;
            idTipPoc = Convert.ToInt32(cboTipProc.SelectedValue.ToString());

            if (idTipPoc == 1)
            {
                timer1.Enabled = false;
                txtCod.Text = "";
                txtCod.Enabled = true;
                dtpFecha.Enabled = true;
                txtCod.Focus();
            }
            else if (idTipPoc == 2)
            {
                timer1.Enabled = true;
                dtpFecha.Enabled = false;
                dtDgvJug = objMet.busJugPendProc(idPerf, idGrup);
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
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
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
                Boolean rsValidFrm = true;
                rsValidFrm = validFrm();

                if (rsValidFrm == true)
                {
                    string msjInf = "Realmente desea Procesador el resultado: " + txtCod.Text;
                    msjInf += " Para la loteria: \" " + nombLot.ToUpper() + " \"";
                    msjInf += " del: \" " + nombSort.ToUpper() + " \"";
                    msjInf += " esta usted seguro?";

                    if (MessageBox.Show(msjInf, "Verifique 3.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        fechLot = Convert.ToDateTime(dtpFecha.Text).ToString("yyyy-MM-dd");
                        rsGrdRsLot = objMet.grdActRstLot(idLot, idSort,
                                                          txtCod.Text, fechLot);

                        if (rsGrdRsLot == "1")
                        {
                            lblMsjInf.Text = "Resultado Nro: \"" + txtCod.Text + "\"";
                            gpReult.Text = "Loteria: " + nombLot;
                            fechLot = "";
                        }
                        if (dgvJug.RowCount > 0)
                        {
                            cantRsCarg = dgvJug.RowCount - 1;
                            this.pbInfProcRs.Minimum = 0;
                            this.pbInfProcRs.Maximum = cantRsCarg;
                            this.pbInfProcRs.Value = 0;
                            this.wkProcRsMan.RunWorkerAsync();
                        }

                    }
                }
            }
        }

        private void frm_proc_result_loteria_KeyPress(object sender, KeyPressEventArgs e)
        {

            char caracter;
            int cod=0;
            caracter = Convert.ToChar(e.KeyChar);
            cod = (int)caracter;
            if (cod == 27)
            {
                if (this.wkProcRsAut.IsBusy)
                {
                    msjInf = "Se esta ejecutando el procedimiento asincrono";
                    msjInf += " para proc los resultados, por ";
                    msjInf += " favor espere.";
                    MessageBox.Show(msjInf, "¡ Espere !");
                }
                else { this.Close(); }
            }

        }

        private void dgvJug_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            rsVerfJugCer = Convert.ToInt32(this.dgvJug.Rows[e.RowIndex].Cells[13].Value.ToString());
            if (rsVerfJugCer == 1)
            {
                dgvJug.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
            }
        }

        public string result_grupoN(string prmUrl, string prmIdLot,
                            string prmIdSort, string prmNombLot,
                            string prmHoraSort)
        {
            MessageBox.Show(prmNombLot + " --- " + prmHoraSort);
            var htmlDoc = web.Load(prmUrl);
            var node = htmlDoc.DocumentNode.SelectNodes("//div[@class='col-xs-6 col-sm-3']");
            string rsDat = "";
            string prmNombLotPw = "";
            string prmHoraSortPw = "";

            foreach (var node1 in node)
            {
                prmNombLotPw = node1.ChildNodes[0].InnerHtml.ToString().Replace("<br>", "*");
                rsNombLot = prmNombLotPw.Split('*');
                prmRsLot = node1.ChildNodes[2].InnerText.ToString().Replace("-", "*");
                rs_rs_lot = prmHoraLot.Split('*');
                prmHoraSortPw = node1.ChildNodes[3].InnerText.ToString();

                if (prmNombLot.ToUpper() == rsNombLot[1].ToUpper())
                {
                    if (prmHoraSort == prmHoraSortPw) { MessageBox.Show("break"); break; }
                }
            }
            return rsDat;
        }

       public string rsTuAzar(string prmUrl, string prmIdLot,
                                    string prmIdSort, string prmNombLot,
                                    string prmHoraSortBus)
        {
            string result = "";
            int idUserAg= 0;
            Random rand = new Random();
            int indAl = rand.Next(_listUserAg.Count);
            idUserAg = _listUserAg[indAl].idUserAg;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(prmUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("User-Agent", _listUserAg[indAl].cdUserAg.ToString());
                    using (var res = client.GetAsync(prmUrl).Result)
                    {
                        if (res.IsSuccessStatusCode)
                        {
                            string html = res.Content.ReadAsStringAsync().Result;
                            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                            htmlDoc.LoadHtml(html);
                            var node = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'col-xs-6 col-sm-3')]");

                            string msjPru = "";
                            if (node == null) { msjInf = "El nodo verificado es NULL o no a sido encontrado"; Console.WriteLine(msjInf); }
                            else if (node != null)
                            {
                                foreach (var node1 in node)
                                {
                                    var rsNombLot = node1.SelectSingleNode("./div[1]");
                                    string nombLotPw = rsNombLot?
                                    .InnerHtml
                                    .Replace("<br>", "-")   // quita la palabra
                                    .Trim();

                                    string[] rsDatLot = nombLotPw.Split('-');
                                    string rsNombLotNew = rsDatLot[1].ToString();
                                    
                                    var rslot = node1.SelectSingleNode("./div[3]/span");
                                    string rsLotPw = rslot?
                                        .InnerText
                                        .Replace("\n", " ")
                                        .Trim();

                                    string[] rsDatAni = rsLotPw.Split('-');
                                    string rsAni = rsDatAni[0].ToString();
                                    string rsNombAni = rsDatAni[1].ToString();

                                    var horaLot = node1.SelectSingleNode(".//div[contains(@class,'horario')]/span");
                                    string horaLotPw = horaLot?.InnerText?.Trim();

                                    msjPru = "Loteria: " + rsNombLotNew;
                                    msjPru += " Resultado: " + rsAni+" - "+ rsNombAni;
                                    msjPru += " Hora: " + horaLotPw;
                                    //MessageBox.Show(msjPru);

                                    horaLotPw = horaLotPw.Replace("AM", "")?
                                    .Replace("PM", "")
                                    .Trim();

                                    if (horaLotPw.Length == 4) { horaLotPw = "0" + horaLotPw; }
                                    //MessageBox.Show(rsNombLotNew.ToLower().Trim() +" - "+ prmNombLot + " | " + horaLotPw + " - " + prmHoraSortBus);

                                    if ((rsNombLotNew.ToLower().Trim() == prmNombLot) && (horaLotPw == prmHoraSortBus))
                                    {
                                        //MessageBox.Show(rsAni.ToString().Trim(),"rsAni.ToString().Trim()");
                                        //VERIFICA SI HAY RESULTADO EN LA LOTERIA SI NO VIENE VACIO
                                        if (!string.IsNullOrEmpty(rsAni.ToString().Trim()))
                                        {
                                            result += prmIdLot + "-";
                                            result += prmIdSort + "-";
                                            result += rsAni.ToString().Trim() +"-";
                                            result += rsNombAni + "-";
                                            result +=  rsNombLotNew.ToString();
                                            result += " " + prmHoraSortBus;

                                            //MessageBox.Show(result);
                                            break;
                                        }
                                        
                                    }
                                }
                            }
                        }
                    }
                } 
            }
            catch (Exception ex) 
            {
                msjInf = "Error: User-Agent id - " + idUserAg.ToString();
                msjInf += " | ";
                msjInf += ex.Message; 
               
            }
            return result;
        }

        public string scrapPw(string prmUrl)
        {
            string html = "";
            try
            {
                using (var client = new HttpClient())
                {
                    Console.WriteLine(prmUrl);
                    ListUserAg _ListUserAg = new ListUserAg();
                    List<UserAg> _UserAg = new List<UserAg>();
                    _UserAg = _ListUserAg._UserAg();

                    Random rand = new Random();
                    int indAl = rand.Next(_UserAg.Count);

                    client.BaseAddress = new Uri(prmUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("User-Agent", _UserAg[indAl].cdUserAg.ToString());

                    //Console.WriteLine("indice: " + _UserAg.Count);
                    //Console.WriteLine("User-Agent: ", _UserAg[indAl].cdUserAg.ToString() + " --> " + indAl);
                    using (var res = client.GetAsync(prmUrl).Result)
                    {
                        if (res.IsSuccessStatusCode) {  html = res.Content.ReadAsStringAsync().Result;}
                    }
                }
            }
            catch (Exception ex) { msjInf = ex.Message; Console.WriteLine("exception: " + msjInf); }
            return html;
        }


        public async Task<string> LottResult(string prmIdLot, string prmIdSort,
                                   string prmNombLot, string prmHoraSortBus)
        {
            string result = "";
            try
            {
                //MessageBox.Show(prmNombLot);
                using (var client = new HttpClient())
                {
                    string prmUrl = "";
                    prmUrl = @"https://www.lottoresultados.com/resultados/animalitos";

                    Random rand = new Random();
                    int indAl = rand.Next(_listUserAg.Count);

                    client.BaseAddress = new Uri(prmUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("User-Agent", _listUserAg[indAl].cdUserAg.ToString());

                    using (var res = await client.GetAsync(prmUrl))
                    {
                        if (res.IsSuccessStatusCode)
                        {
                            string html = await res.Content.ReadAsStringAsync();
                            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                            htmlDoc.LoadHtml(html);

                            var tipoNode = htmlDoc.DocumentNode.SelectSingleNode("//h2[contains(@class,'h3')]/text()");
                            var nombreNode = htmlDoc.DocumentNode.SelectSingleNode("//h2[contains(@class,'h3')]/small");
                            var items = htmlDoc.DocumentNode.SelectNodes("//li[contains(@class,'step-item')]");

                            string tipo = tipoNode?.InnerText.Trim();
                            string nombreLoteria = nombreNode?.InnerText.Trim();

                            string rsAni = "";
                            string nombAni = "";
                            string prmNombLotPw = "";
                            string[] rsDatAn = new string[6];
                            string[] rsDatLot = new string[6];
                            string cadAn = "", cadLot = "";

                            if (items == null) { msjInf = "El nodo verificado es NULL o no a sido encontrado"; Console.WriteLine(msjInf); }
                            else if (items != null)
                            {

                                foreach (var item in items)
                                {

                                    var horaNode = item.SelectSingleNode(".//h4");
                                    var textoNode = item.SelectSingleNode(".//p[contains(@class,'step-text')]");

                                    string hora = horaNode?.InnerText.Trim();
                                    string texto = textoNode?.InnerText.Trim();

                                    int? codigo = null;
                                    string animal = null;

                                    if (!string.IsNullOrEmpty(texto) &&
                                        texto != "Próximo" &&
                                        texto != "Pendiente")
                                    {
                                        var partes = texto.Split(' ', 2);
                                        if (partes.Length == 2 && int.TryParse(partes[0], out int cod))
                                        {
                                            codigo = cod;
                                            animal = partes[1];
                                        }
                                    }

                                    MessageBox.Show(nombreLoteria + " | " + codigo + " | " + animal, " data pagina");

                                    if ((prmNombLotPw.ToLower() == prmNombLot) && (prmHoraLot == prmHoraSortBus))
                                    {
                                        //VERIFICA SI HAY RESULTADO EN LA LOTERIA SI NO VIENE VACIO
                                        if (!string.IsNullOrEmpty(rsAni))
                                        {
                                            result += prmIdLot + "-";
                                            result += prmIdSort + "-";
                                            result += rsAni + "-";
                                            result += nombAni + "-";
                                            result += prmNombLotPw + " ";
                                            result += prmHoraSortBus;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex) { msjInf = ex.Message; Console.WriteLine("exception: " + msjInf); }
            return result;
        }



        public string rsGenLotHoy(string html, string prmIdLot,
                            string prmIdSort, string prmNombLot,
                            string prmHoraSortBus)
        {
            string result = "";
            try
            {
                HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(html);
                var node = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'circle-legend')]");
                var node2 = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'title-center')]");

                string rsAni = "";
                string nombAni = "";
                string prmNombLotPw = "";
                string[] rsDat = new string[6];
                string rsDatLot = "";

                if (node == null) { msjInf = "El nodo verificado es NULL o no a sido encontrado"; Console.WriteLine(msjInf); }
                else if (node != null)

                    //var node = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'col-xs-6 col-sm-3')]");

                    if (node2 == null) { result = "El nodo verificado es NULL o no a sido encontrado"; Console.WriteLine(result); }
                    else { Console.WriteLine("funciono"); MessageBox.Show("si node 2"); }

                foreach (var node1 in node2)
                {
                    var h3Nod = node1.SelectNodes("./h3");
                    prmNombLotPw = h3Nod[0].InnerText.ToString();
                    prmNombLotPw = prmNombLotPw.ToLower();
                    prmNombLotPw = prmNombLotPw.Trim();

                    if (prmNombLotPw == prmNombLot) { MessageBox.Show("h3Nod --> " + h3Nod[0].InnerText.ToString() + "--> Loteria --> " + prmNombLot +" --> break"); break; }
                }
                {
                    foreach (var node1 in node)
                    {
                        var h4Nod = node1.SelectNodes("./h4");
                        var h5Nod = node1.SelectNodes("./h5");

                        rsDatLot = h4Nod[0].InnerText.ToString().Trim();
                        rsDatLot += "/" + h5Nod[0].InnerText.ToString().Trim();
                        rsDatLot = rsDatLot.Replace(" ", "/");

                        rsDat = rsDatLot.Split('/');
                        rsAni = rsDat[0].ToString();
                        nombAni = rsDat[1].ToString();
                   

                        if (rsDat.Length == 6) { prmHoraLot = rsDat[4].ToString(); }
                        else if (rsDat.Length == 7) { prmHoraLot = rsDat[5].ToString(); }

                        //MessageBox.Show(prmNombLot + "    " + prmHoraSortBus + "   " + rsAni + "   " + prmNombLotPw + "   " + prmHoraLot);
                        //MessageBox.Show(prmNombLot + "    " + prmNombLot.Trim().Length + "   " + prmNombLotPw + "   " + prmNombLotPw.Trim().Length);
                        if ((prmNombLotPw.ToLower() == prmNombLot) && (prmHoraLot == prmHoraSortBus))
                        {
                            //VERIFICA SI HAY RESULTADO EN LA LOTERIA SI NO VIENE VACIO
                            if (!string.IsNullOrEmpty(rsAni))
                            {
                                result += prmIdLot + "-";
                                result += prmIdSort + "-";
                                result += rsAni;
                                result += "-" + prmNombLotPw;
                                result += " " + prmHoraSortBus;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { msjInf = ex.Message; Console.WriteLine("exception: " + msjInf); }
            return result;
        }
        public string rsIndLotHoy(  string prmIdLot, string prmIdSort, 
                                    string prmNombLot,string prmHoraSortBus)
        {
            string result = "";
            try
            {
                //MessageBox.Show(prmNombLot);
                using (var client = new HttpClient())
                {
                    string prmUrl = "";
                    prmUrl = @"https://loteriadehoy.com/animalito/";

                    if (Convert.ToInt16(prmIdLot) == 22) { prmUrl += prmNombLot.Replace(" ", "-"); }
                    else if (Convert.ToInt16(prmIdLot) == 26) { prmUrl += prmNombLot.Replace(" ", "").ToLower(); }
                    else { prmUrl += prmNombLot.Replace(" ", ""); }
                    prmUrl += "/resultados/";
                    Console.WriteLine(prmUrl);

                    Random rand = new Random();
                    int indAl = rand.Next(_listUserAg.Count);
                    //int indAl = rand.Next(_UserAg.Count);

                    //MessageBox.Show(_listUserAg[indAl].cdUserAg.ToString());
                    client.BaseAddress = new Uri(prmUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("User-Agent", _listUserAg[indAl].cdUserAg.ToString());
                    //client.DefaultRequestHeaders.Add("User-Agent", _UserAg[indAl].cdUserAg.ToString());

                    //Console.WriteLine("indice: " + _UserAg.Count);
                    //Console.WriteLine("User-Agent: ", _UserAg[indAl].cdUserAg.ToString() + " --> " + indAl);
                    using (var res = client.GetAsync(prmUrl).Result)
                    {
                        if (res.IsSuccessStatusCode)
                        {

                            string html = res.Content.ReadAsStringAsync().Result;
                            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                            htmlDoc.LoadHtml(html);
                            var node = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'circle-legend')]");

                            string rsAni = "";
                            string nombAni = "";
                            string prmNombLotPw = "";
                            string[] rsDatAn = new string[6];
                            string[] rsDatLot = new string[6];
                            string cadAn ="", cadLot = "";

                            if (node == null) { msjInf = "El nodo verificado es NULL o no a sido encontrado"; Console.WriteLine(msjInf); }
                            else if (node != null)
                            {
                               
                                foreach (var node1 in node)
                                {
                                    var h4Nod = node1.SelectNodes("./h4");
                                    var h5Nod = node1.SelectNodes("./h5");

                                    cadAn = h4Nod[0].InnerText.ToString().Trim();
                                    cadAn = cadAn.Replace(" ", "/");

                                    cadLot =  h5Nod[0].InnerText.ToString().Trim();
                                    cadLot = cadLot.Replace(" ", "/");

                                    rsDatAn = cadAn.Split('/');
                                    rsAni = rsDatAn[0].ToString();
                                    
                                    if (rsDatAn.Length == 2) { nombAni = rsDatAn[1].ToString(); }
                                    else if (rsDatAn.Length == 3) { nombAni = rsDatAn[1].ToString() +" " + rsDatAn[2].ToString(); }
                                    else if (rsDatAn.Length == 4) { nombAni = rsDatAn[1].ToString() + " " + rsDatAn[2].ToString() +" " + rsDatAn[3].ToString(); }

                                    rsDatLot = cadLot.Split('/');
                                    //MessageBox.Show("h4: " + cadAn + "  ----> " + "h5: " + cadLot);

                                    if (Convert.ToInt16(prmIdLot) == 10) 
                                    { 
                                        prmNombLotPw = rsDatLot[0].ToString();
                                        prmNombLotPw += rsDatLot[1].ToString();
                                        prmHoraLot = rsDatLot[2].ToString();
                                    }
                                    else if (Convert.ToInt16(prmIdLot) == 11) 
                                    {
                                        prmNombLotPw = rsDatLot[0].ToString();
                                        prmNombLotPw += " " + rsDatLot[1].ToString();
                                        prmNombLotPw += " " + rsDatLot[2].ToString();
                                        prmHoraLot = rsDatLot[3].ToString();
                                    }
                                    else if (Convert.ToInt16(prmIdLot) == 14) 
                                    {
                                        prmNombLotPw = rsDatLot[0].ToString();
                                        prmNombLotPw += " " + rsDatLot[1].ToString();
                                        prmNombLotPw += " " + rsDatLot[2].ToString().Substring(0, 2);
                                        prmHoraLot = rsDatLot[3].ToString();
                                    }
                                    else if (Convert.ToInt16(prmIdLot) == 19 || Convert.ToInt16(prmIdLot) == 20) 
                                    {
                                        prmNombLotPw = rsDatLot[0].ToString();
                                        prmNombLotPw += " " + rsDatLot[1].ToString();
                                        prmNombLotPw += " " + rsDatLot[2].ToString();
                                        prmHoraLot = rsDatLot[3].ToString();
                                    }
                                    else if (Convert.ToInt16(prmIdLot) == 21 || Convert.ToInt16(prmIdLot) == 22)
                                    {

                                        if (Convert.ToInt16(prmIdLot) == 22) 
                                        { prmNombLotPw = rsDatLot[0].ToString().Replace("-", " "); }
                                        else { prmNombLotPw = rsDatLot[0].ToString(); }
                                       
                                        prmHoraLot = rsDatLot[1].ToString();
                                    }
                                    else if (Convert.ToInt16(prmIdLot) == 26)
                                    {
                                        prmNombLotPw = rsDatLot[0].ToString();
                                        prmNombLotPw += " " + rsDatLot[1].ToString();
                                        prmNombLotPw += " " + rsDatLot[2].ToString();
                                        prmNombLotPw += " " + rsDatLot[3].ToString();
                                        prmHoraLot = rsDatLot[4].ToString();
                                    }
                                    else
                                    {
                                        prmNombLotPw = rsDatLot[0].ToString();
                                        prmNombLotPw += " " + rsDatLot[1].ToString();
                                        prmHoraLot = rsDatLot[2].ToString();
                                    }
                                    prmNombLotPw = prmNombLotPw.ToLower();
                                    prmNombLotPw = prmNombLotPw.Trim();

                                    //MessageBox.Show("loterias: "+prmNombLotPw+ " ----> Hora: " + prmHoraLot);
                                    //MessageBox.Show("loterias II: " + prmNombLot);

                                    //MessageBox.Show(prmNombLot + "    " + prmHoraSortBus + "   " + rsAni + "   " + prmNombLotPw + "   " + prmHoraLot);
                                    //MessageBox.Show(prmNombLot + "    " + prmNombLot.Trim().Length + "   " + prmNombLotPw + "   " + prmNombLotPw.Trim().Length);
                                   // MessageBox.Show(prmNombLotPw.ToLower()+" --> "+ prmNombLot+ " | hora --> "+prmHoraLot +" --- "+ prmHoraSortBus,"loteria ");

                                    if ((prmNombLotPw.ToLower() == prmNombLot) && (prmHoraLot == prmHoraSortBus))
                                    {
                                        //VERIFICA SI HAY RESULTADO EN LA LOTERIA SI NO VIENE VACIO
                                        if (!string.IsNullOrEmpty(rsAni))
                                        {
                                            result += prmIdLot + "-";
                                            result += prmIdSort + "-";
                                            result += rsAni +"-";
                                            result += nombAni + "-";
                                            result += prmNombLotPw + " ";
                                            result += prmHoraSortBus;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex) { msjInf = ex.Message; Console.WriteLine("exception: " + msjInf); }
            return result;
        }

        public string rsLotVen(string html, string prmIdLot,
                            string prmIdSort, string prmNombLot,
                            string prmHoraSortBus)
        {
            string result = "";
            try
            {
                string nodCon = "";
                nodCon = "//div[@id='" + prmNombLot.Replace(" ", "") + "']";
                nodCon +="//div[contains(@class, 'counter-wrapper')]";

                HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(html);
                var node = htmlDoc.DocumentNode.SelectNodes(nodCon);

                if (node == null) { msjInf = "El nodo verificado es NULL o no a sido encontrado"; Console.WriteLine(msjInf); }
                else if (node != null)
                {
                    string rsGan = "", rsHor = "";
                    string codAn = "", nombAn = "";
                    string horSort = "", CodSort = "";

                    foreach (var node1 in node)
                    {
                        var h3Nod = node1.SelectSingleNode(".//span[contains(@class, 'info')]");
                        var h4Nod = node1.SelectSingleNode((".//span[contains(@class, 'horario')]"));
                        rsGan = h3Nod.InnerText.Trim().ToString();
                        rsGan = rsGan.Replace(" ", "/");
                        string[] rsDatGan = rsGan.Split('/');
                        codAn = rsDatGan[0];
                        nombAn = rsDatGan[1];

                        rsHor = h4Nod.InnerText.Trim().ToString();
                        rsHor = rsHor.Replace(" ", "/");
                        string[] rsDatHor = rsHor.Split('/');
                        horSort = rsDatHor[0];
                        CodSort = rsDatHor[1];

                        if (horSort == prmHoraSortBus)
                        {
                            //VERIFICA SI HAY RESULTADO EN LA LOTERIA SI NO VIENE VACIO
                            if (!string.IsNullOrEmpty(codAn.ToString().Trim()))
                            {
                                result += prmIdLot + "-";
                                result += prmIdSort + "-";
                                result += codAn.ToString().Trim();
                                result += "-" + prmNombLot.ToString();
                                result += " " + prmHoraSortBus;
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex) { msjInf = ex.Message; }
            return result;
        }
        public string rsGrup20(string prmIdLot,
                            string prmIdSort, string prmNombLot,
                            string prmHoraSortBus)
        {
            string result = "";
            try
            {
                string prmUrl = "";
                prmUrl = "https://loteriadehoy.com/animalito/";
                prmUrl += prmNombLot.Replace(" ", "");
                prmUrl += "/resultados/";

                // MessageBox.Show("url: "+prmUrl);
                var htmlDoc = web.Load(prmUrl);
                var node = htmlDoc.DocumentNode.SelectNodes("//div[@class='circle-legend']");

                string rsAni = "";
                string nombAni = "";
                string prmNombLotPw = "";
                string[] rsDat = new string[6];
                string rsDatLot = "";

                foreach (var node1 in node)
                {
                    var h4Nod = node1.SelectNodes("./h4");
                    var h5Nod = node1.SelectNodes("./h5");

                    rsDatLot = h4Nod[0].InnerText.ToString().Trim();
                    rsDatLot += "/" + h5Nod[0].InnerText.ToString().Trim();
                    rsDatLot = rsDatLot.Replace(" ", "/");

                    rsDat = rsDatLot.Split('/');
                    rsAni = rsDat[0].ToString();
                    nombAni = rsDat[1].ToString();
                    prmNombLotPw = rsDat[2].ToString().Trim();

                    if (Convert.ToInt16(prmIdLot) == 10) { prmNombLotPw += rsDat[3].ToString().Trim(); }
                    else { prmNombLotPw += " " + rsDat[3].ToString().Trim(); }

                    if (Convert.ToInt16(prmIdLot) == 11) { prmNombLotPw += " " + rsDat[4].ToString(); }
                    else if (Convert.ToInt16(prmIdLot) == 14) { prmNombLotPw += " " + rsDat[4].ToString().Substring(0, 2); }
                    else if (Convert.ToInt16(prmIdLot) == 19) { prmNombLotPw += " " + rsDat[4].ToString(); }
                    prmNombLotPw = prmNombLotPw.ToLower();
                    prmNombLotPw = prmNombLotPw.Trim();

                    if (rsDat.Length == 6) { prmHoraLot = rsDat[4].ToString(); }
                    else if (rsDat.Length == 7) { prmHoraLot = rsDat[5].ToString(); }

                    //MessageBox.Show(prmNombLot + "    " + prmHoraSortBus + "   " + rsAni + "   " + prmNombLotPw + "   " + prmHoraLot);
                    //MessageBox.Show(prmNombLot + "    " + prmNombLot.Trim().Length + "   " + prmNombLotPw + "   " + prmNombLotPw.Trim().Length);
                    if ((prmNombLotPw.ToLower() == prmNombLot) && (prmHoraLot == prmHoraSortBus))
                    {
                        //VERIFICA SI HAY RESULTADO EN LA LOTERIA SI NO VIENE VACIO
                        if (!string.IsNullOrEmpty(rsAni))
                        {
                            result += prmIdLot + "-";
                            result += prmIdSort + "-";
                            result += rsAni;
                            result += "-" + prmNombLotPw;
                            result += " " + prmHoraSortBus;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex) { msjInf = ex.Message; }
            return result;
        }


        private void cboLot_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idLot = Convert.ToInt16(cboLot.SelectedValue);
            dtDgvSort = objMet.listSortTod(idLot);
            dgvSort.DataSource = dtDgvSort;
        }

        private void btn_pagar_ticket_Click(object sender, EventArgs e)
        {
            if (wkProcRsAut.IsBusy == true) { MessageBox.Show("servicio activo"); }
        }

        private void btnRs_Click(object sender, EventArgs e)
        {
            if (this.wkProcRsAut.IsBusy)
            {
                msjInf = "Se esta ejecutando el procedimiento asincrono";
                msjInf += " para proc los resultados, por ";
                msjInf += " favor espere.";
                MessageBox.Show(msjInf, "¡ Espere !");
            }
            else
            {
                frm_result_lot frm = new frm_result_lot();
                frm.ShowDialog();
            }
        }

        private void lblMsjInf_Click(object sender, EventArgs e)
        {

        }

        private void cboTipTck_SelectionChangeCommitted(object sender, EventArgs e)
        {

            int idTipJug = 0;
            idTipJug= Convert.ToInt16(cboTipTck.SelectedValue);
            dtDgvJug = objMet.busTipJugPendProc(idPerf, idGrup, idTipJug);
            dgvJug.DataSource = dtDgvJug;
            gp_cant_jug.Text = "Cantidad jugadas: " + dgvJug.RowCount;
        }

        private void frm_proc_result_loteria_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer1 != null) { timer1.Stop(); timer1.Dispose(); timer1 = null; }
            if (wkProcRsAut != null && wkProcRsAut.IsBusy) { wkProcRsAut.CancelAsync(); }
            if (wkProcJugAut != null && wkProcJugAut.IsBusy) { wkProcJugAut.CancelAsync(); }
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
                            result = prmIdLotBus + "-" + prmIdSorBus;
                            result += "-" + datosRL[2].ToString().Trim();
                            result += "-" + prmNombLot + " ";
                            result += datosHS[0].ToString();
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
        private void btnVentLot_Click(object sender, EventArgs e)
        {
            if (this.wkProcRsAut.IsBusy)
            {
                msjInf = "Se esta ejecutando el procedimiento asincrono";
                msjInf += " para proc los resultados, por ";
                msjInf += " favor espere.";
                MessageBox.Show(msjInf, "¡ Espere !");
            }
            else
            {
                frmVentLot objFrm = new frmVentLot();
                objFrm.ShowDialog();
            }
           
        }
    }
}
