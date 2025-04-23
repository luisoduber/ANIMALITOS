
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
namespace ventas_loteria
{
    public partial class frmTrip : Form
    {
        public frmTrip()
        {
            InitializeComponent();
        }

        clsMet objMet = new clsMet();
        DataTable dtDgvLot = new DataTable();
        DataTable dtCboLot = new DataTable();
        DataTable dtDgvJug = new DataTable();
        DataTable dtNombProd = new DataTable();

        int idGrup = 0;
        int idLot = 0, idSort = 0;
        int idUsu = 0, idPerf = 0;
        string nombLot = "", nombSort = "";
        double mJug = 0, mTotJug = 0;
        int idProc = 0, codMaxProd = 0;

        string HoraAct = "", FechaAct = "";
        string[] rsDat = new string[2];
        string msjInf = "", abLot = "";
        int nroFil = 0;

        string codJug1 = "", nombProd1 = "";
        string codJug2 = "", nombProd2 = "";
        string codJug3 = "", nombProd3 = "";

        string nombProdAb1 = "", nombProdAb2 = "";
        string nombProdAb3 = "";

        private void frmTrip_Load(object sender, EventArgs e)
        {
            this.Text = "Ventas Tripletas.";
            this.dgvLot.AllowUserToAddRows = false;
            this.dgvLot.RowHeadersVisible = false;

            this.dgvJug.AllowUserToAddRows = false;
            this.dgvJug.RowHeadersVisible = false;
            this.dgvJug.ColumnHeadersVisible = false;

            idGrup = Convert.ToInt32(clsMet.idGrup);
            idUsu = Convert.ToInt32(clsMet.idUsu);
            idPerf = Convert.ToInt32(clsMet.idPerf);

            dtDgvJug.Columns.Add("idLot", typeof(string));
            dtDgvJug.Columns.Add("nombLot", typeof(string));
            dtDgvJug.Columns.Add("abLot", typeof(string));
            dtDgvJug.Columns.Add("codJug1", typeof(string));
            dtDgvJug.Columns.Add("nombProdAb1", typeof(string));
            dtDgvJug.Columns.Add("nombProd1", typeof(string));
            dtDgvJug.Columns.Add("codJug2", typeof(string));
            dtDgvJug.Columns.Add("nombProdAb2", typeof(string));
            dtDgvJug.Columns.Add("nombProd2", typeof(string));
            dtDgvJug.Columns.Add("codJug3", typeof(string));
            dtDgvJug.Columns.Add("nombProdAb3", typeof(string));
            dtDgvJug.Columns.Add("nombProd3", typeof(string));
            dtDgvJug.Columns.Add("mJug", typeof(string));
            dtDgvJug.Columns.Add("prmDesd", typeof(string));
            dtDgvJug.Columns.Add("prmHast", typeof(string));

            this.wkIniFrm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkIniFrm_DoWork);
            this.wkIniFrm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.wkIniFrm_OnProgressChanged);
            this.wkIniFrm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wkIniFrm_OnRunWorkerCompleted);
            this.wkIniFrm.RunWorkerAsync();
        }

        private void wkIniFrm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dtCboLot = objMet.listLotTod(idGrup);
                dtDgvLot = objMet.busLotTrip(idGrup);
                dtNombProd = objMet.busNombProd();
                rsDat = objMet.busFechHoraServ();

                idProc = 1;
                wkIniFrm.CancelAsync();
                e.Cancel = wkIniFrm.CancellationPending;
            }
            catch (Exception ex)
            {
                idProc = 0;
                MessageBox.Show(ex.Message, "Verifique.");
            }
        }

        private void wkIniFrm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void wkIniFrm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (idProc == 1)
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

                dgvLot.DataSource = dtDgvLot;
            }
        }

        private void txtMont_KeyPress(object sender, KeyPressEventArgs e)
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

                Boolean valid = true;
                foreach (DataGridViewRow row in dgvLot.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(cell.Value) == true)
                    {
                        idLot = 0; nombLot = "";
                        idLot = Convert.ToInt32(row.Cells[1].Value.ToString());
                        nombLot = row.Cells[2].Value.ToString();
                        abLot = row.Cells[3].Value.ToString();
                        codMaxProd = Convert.ToInt32(row.Cells[4].Value.ToString());

                        if
                        (
                            (Convert.ToInt32(txtCod1.Text) <= codMaxProd) &&
                            (Convert.ToInt32(txtCod2.Text) <= codMaxProd) &&
                            (Convert.ToInt32(txtCod3.Text) <= codMaxProd)
                         )

                        {
                            if (dgvJug.RowCount == 0)
                            {
                                if (Convert.ToInt32(clsMet.mMaxTrip) < Convert.ToInt32(txtMont.Text))
                                {
                                    msjInf = "El maximo por tripleta es de: ";
                                    msjInf += clsMet.montMaxTck.ToString("N2");
                                    MessageBox.Show(msjInf, "Verifique.");
                                    txtMont.Focus();
                                    valid = false;
                                }
                                else { valid = true; }
                            }
                        }
                        else if (Convert.ToInt32(txtCod1.Text) > codMaxProd)
                        {
                            msjInf = "Codigo: \"" + txtCod1.Text + "\"";
                            msjInf += " invalido para la loteria: ";
                            msjInf += "\"" + nombLot.ToUpper() + "\"";
                            MessageBox.Show(msjInf, "Verifique.");
                            txtCod1.Focus();
                            valid = false;
                        }
                        else if (Convert.ToInt32(txtCod2.Text) > codMaxProd)
                        {
                            msjInf = "Codigo: \"" + txtCod2.Text + "\"";
                            msjInf += " invalido para la loteria: ";
                            msjInf += "\"" + nombLot.ToUpper() + "\"";
                            MessageBox.Show(msjInf, "Verifique.");
                            txtCod2.Focus();
                            valid = false;
                        }
                        else if (Convert.ToInt32(txtCod3.Text) > codMaxProd)
                        {
                            msjInf = "Codigo: \"" + txtCod3.Text + "\"";
                            msjInf += " invalido para la loteria: ";
                            msjInf += "\"" + nombLot.ToUpper() + "\"";
                            MessageBox.Show(msjInf, "Verifique.");
                            txtCod3.Focus();
                            valid = false;
                        }

                        if (valid == true)
                        {
                            int dtIdlot = 0;
                            string dtCodJug = "", dtCNombProd = "";
                            string dtCNombProdAb = "";

                            int cant = 0;
                            for (int c = 0; c <= dtNombProd.Rows.Count; c++)
                            {
                                dtIdlot = Convert.ToInt16(dtNombProd.Rows[c][0].ToString());
                                dtCodJug = dtNombProd.Rows[c][1].ToString();
                                dtCNombProd = dtNombProd.Rows[c][2].ToString();
                                dtCNombProdAb = dtCNombProd.Substring(0, 3);

                                if (txtCod1.Text.Length == 1)
                                {
                                    if (txtCod1.Text != "0")
                                    { txtCod1.Text = txtCod1.Text.PadLeft(2, '0'); }
                                }

                                if (txtCod2.Text.Length == 1)
                                {
                                    if (txtCod2.Text != "0")
                                    { txtCod2.Text = txtCod2.Text.PadLeft(2, '0'); }
                                }

                                if (txtCod3.Text.Length == 1)
                                {
                                    if (txtCod3.Text != "0")
                                    { txtCod3.Text = txtCod3.Text.PadLeft(2, '0'); }
                                }

                                if ((idLot == dtIdlot) && (txtCod1.Text == dtCodJug)) { nombProdAb1=dtCNombProdAb; nombProd1 = dtCNombProd; cant++; }
                                else if ((idLot == dtIdlot) && (txtCod2.Text == dtCodJug)) { nombProdAb2 = dtCNombProdAb; nombProd2 = dtCNombProd; cant++; }
                                else if ((idLot == dtIdlot) && (txtCod3.Text == dtCodJug)) { nombProdAb3 = dtCNombProdAb; nombProd3 = dtCNombProd; cant++; }
                                if (cant == 3) { break; }
                            }

                            DataRow filDgv = dtDgvJug.NewRow();
                            filDgv["idLot"] = idLot;
                            filDgv["nombLot"] = nombLot;
                            filDgv["abLot"] = abLot;
                            filDgv["codJug1"] = txtCod1.Text;
                            filDgv["nombProdAb1"] = nombProdAb1.ToUpper();
                            filDgv["nombProd1"] = nombProd1.ToUpper();
                            filDgv["codJug2"] = txtCod2.Text;
                            filDgv["nombProdAb2"] = nombProdAb2.ToUpper();
                            filDgv["nombProd2"] = nombProd2.ToUpper();
                            filDgv["codJug3"] = txtCod3.Text;
                            filDgv["nombProdAb3"] = nombProdAb3.ToUpper();
                            filDgv["nombProd3"] = nombProd3.ToUpper();
                            filDgv["mJug"] = Convert.ToDouble(txtMont.Text).ToString("N2");
                            filDgv["prmDesd"] = "";
                            filDgv["prmHast"] = "";

                            dtDgvJug.Rows.Add(filDgv);
                            DataView dv = new DataView(dtDgvJug);
                            dv.Sort = "idLot DESC";
                            dgvJug.DataSource = dv;
                            busMontTotJug();
                        }
                    } 
                }
                limpJug();

            }
        }

        public Boolean validFrm()
        {
            Boolean valid= true;
            if (string.IsNullOrEmpty(txtCod1.Text))
            {
                MessageBox.Show("Ingrese un codigo.", "Verifique.");
                txtCod1.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtCod2.Text))
            {
                MessageBox.Show("Ingrese un codigo.", "Verifique.");
                txtCod2.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtCod3.Text))
            {
                MessageBox.Show("Ingrese un codigo.", "Verifique.");
                txtCod3.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtMont.Text))
            {
                MessageBox.Show("Ingrese un monto.", "Verifique.");
                txtMont.Focus();
                valid = false;
            }
            
            if (txtCod1.Text.Length == 1)
            {
                if (txtCod1.Text != "0") { txtCod1.Text = txtCod1.Text.PadLeft(2, '0'); }
            }
            if (txtCod2.Text.Length == 1)
            {
                if (txtCod2.Text != "0") { txtCod2.Text = txtCod2.Text.PadLeft(2, '0'); }
            }
            if (txtCod3.Text.Length == 1)
            {
                if (txtCod3.Text != "0") { txtCod3.Text = txtCod3.Text.PadLeft(2, '0'); }
            }

            return valid;
        }
        public Boolean valJug()
        {
            Boolean valid = true;
            string msjInf = "";

            double rsDiv = 0;
            rsDiv = Convert.ToDouble(txtMont.Text) / Convert.ToDouble(clsMet.monto_multiplo_jug);
            string verfNum = rsDiv.ToString();
            int i = 0;
            bool result = int.TryParse(verfNum, out i);

            if (result == false)
            {
                msjInf = "El monto de la tripleta deben ser multiplos de: ";
                msjInf += clsMet.monto_multiplo_jug;
                MessageBox.Show(msjInf, "Verifique.");
                txtMont.Focus();
                valid = false;
            }
            else if (Convert.ToInt32(clsMet.monto_min_jug) > Convert.ToInt32(txtMont.Text))
            {
                msjInf = "El monto  minimo de la tripleta debe ser: ";
                msjInf += clsMet.monto_min_jug.ToString("N2");
                MessageBox.Show(msjInf, "Verifique.");
                txtMont.Focus();
                valid = false;
            }
            else if (Convert.ToInt32(clsMet.mMaxTrip) < Convert.ToInt32(txtMont.Text))
            {
                msjInf = "El maximo por tripleta debe ser: ";
                msjInf += clsMet.monto_max_jug.ToString("N2");
                MessageBox.Show(msjInf, "Verifique.");
                txtMont.Focus();
                valid = false;
            }

            return valid;
        }
        public void limpJug()
        {
            txtCod1.Clear();
            txtCod2.Clear();
            txtCod3.Clear();
            txtCod1.Focus();
            txtMont.SelectionStart = 0;
            txtMont.SelectionLength = txtMont.Text.Length;
        }

        private void dgvJug_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvJug.RowCount > 0)
            {
                nroFil = Convert.ToInt32(dgvJug.CurrentRow.Index.ToString());
                dgvJug.Rows.RemoveAt(nroFil);
                //busMontTotJug();
                txtCod1.Focus();
            }
        }

        private void btnImpTck_Click(object sender, EventArgs e)
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
            int cont = 0, idTck = 0;
            Boolean sortAb = false;

            MySqlTransaction myTrans = null;

            try
            {
                ////////////////////////////////////////////////////////////////////////////////////
                /////////////////REGISTRA TICKET ///////////////////////////////////////////////////

                using (MySqlConnection cnBd = new MySqlConnection())
                {
                    cnBd.ConnectionString = clsMet.cn; cnBd.Open();
                    clsMet.idCn = 1;
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        busMontTotJug();
                        cmd.Connection = cnBd;
                        myTrans = cnBd.BeginTransaction();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SPgrdTckTrip";
                        cmd.Parameters.AddWithValue("prmIdGrup", idGrup);
                        cmd.Parameters.AddWithValue("prmIdUsu", idUsu);
                        cmd.Parameters.AddWithValue("prmMont", Convert.ToString(txtMJug.Text).Replace(",", "."));
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            rsProces = true;
                            rsDat[0] = rsProces.ToString();
                            rsDat[1] = dr["prmNroTck"].ToString();
                            rsDat[2] = dr["prmNroSer"].ToString();
                            rsDat[3] = dr["fechTck"].ToString();
                            rsDat[4] = dr["horTck"].ToString();
                            rsDat[5] = dr["prmIdTck"].ToString();

                            rsProces = Convert.ToBoolean(rsDat[0].ToString());
                            nroTck = rsDat[1].ToString();
                            nroSerial = rsDat[2].ToString();
                            fTck = Convert.ToDateTime(rsDat[3]).ToString("dd/MM/yyyy");
                            hTck = rsDat[4].ToString();
                            // idTck = rsDat[5].ToString();
                        }
                        dr.Close();
                    }

                    int c = 0;
                    while (c < dgvJug.RowCount)
                    {
                        idLot = Convert.ToInt32(dgvJug.Rows[c].Cells[0].Value.ToString());
                        nombLot = dgvJug.Rows[c].Cells[1].Value.ToString();
                        codJug1 = dgvJug.Rows[c].Cells[3].Value.ToString();
                        nombProdAb1 = dgvJug.Rows[c].Cells[4].Value.ToString();
                        nombProd1 = dgvJug.Rows[c].Cells[5].Value.ToString();
                        codJug2 = dgvJug.Rows[c].Cells[6].Value.ToString();
                        nombProdAb2 = dgvJug.Rows[c].Cells[7].Value.ToString();
                        nombProd2 = dgvJug.Rows[c].Cells[8].Value.ToString();
                        codJug3 = dgvJug.Rows[c].Cells[9].Value.ToString();
                        nombProdAb3 = dgvJug.Rows[c].Cells[10].Value.ToString();
                        nombProd3 = dgvJug.Rows[c].Cells[11].Value.ToString();
                        mJug = Convert.ToDouble(dgvJug.Rows[c].Cells[12].Value.ToString());

                        DataRow filDgv = dtDgvJug.NewRow();
                        filDgv["idLot"] = idLot;
                        filDgv["nombLot"] = nombLot;
                        filDgv["abLot"] = abLot;
                        filDgv["codJug1"] = txtCod1.Text;
                        filDgv["nombProdAb1"] = nombProdAb1.ToUpper();
                        filDgv["nombProd1"] = nombProd1.ToUpper();
                        filDgv["codJug2"] = txtCod2.Text;
                        filDgv["nombProdAb2"] = nombProdAb2.ToUpper();
                        filDgv["nombProd2"] = nombProd2.ToUpper();
                        filDgv["codJug3"] = txtCod3.Text;
                        filDgv["nombProdAb3"] = nombProdAb3.ToUpper();
                        filDgv["nombProd3"] = nombProd3.ToUpper();
                        filDgv["mJug"] = Convert.ToDouble(txtMont.Text).ToString("N2");
                        filDgv["prmDesd"] = "";
                        filDgv["prmHast"] = "";

                        string rsDat3 = "";

                        if (codJug.Length == 1) { if (codJug != "0") { codJug = codJug.PadLeft(2, '0'); } }

                        using (MySqlCommand cmd2 = new MySqlCommand())
                        {
                            cmd2.Connection = cnBd;
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.CommandText = "SPdetTckTrip";
                            cmd2.Parameters.AddWithValue("prmNroTck", nroTck);
                            cmd2.Parameters.AddWithValue("prmIdGrup", idGrup);
                            cmd2.Parameters.AddWithValue("prmIdUsu", idUsu);
                            cmd2.Parameters.AddWithValue("prmIdLot", idLot);
                            cmd2.Parameters.AddWithValue("prmCodJug1", codJug1);
                            cmd2.Parameters.AddWithValue("prmNombProd1", nombProd1.ToUpper());
                            cmd2.Parameters.AddWithValue("prmCodJug2", codJug2);
                            cmd2.Parameters.AddWithValue("prmNombProd2", nombProd2.ToUpper());
                            cmd2.Parameters.AddWithValue("prmCodJug3", codJug3);
                            cmd2.Parameters.AddWithValue("prmNombProd3", nombProd3.ToUpper());
                            cmd2.Parameters.AddWithValue("prmMont", Convert.ToString(mJug).Replace(",", "."));
                            MySqlDataReader dr2 = cmd2.ExecuteReader();
                            dr2.Read();
                            cmd2.Parameters.Clear();
                            dgvJug.Rows[c].Cells[13].Value = dr2["prmFechSortIni"].ToString();
                            dgvJug.Rows[c].Cells[14].Value = dr2["prmFechSortFin"].ToString();
                            dr2.Close();
                        }
                        c++;
                    }

                    myTrans.Commit();
                }

                ////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////IMPRIMIR TICKET////////////////////////////////////////

                string monto = "", cadResult = "";
                int idLotAnt = 0, idLotSig = 0;
                string tripIni = "", tripFin = "";

                int cont_jud = 0;
                for (int d = 0; d < dgvJug.RowCount; d++)
                {
                    cont_jud++;
                    idLotSig = Convert.ToInt32(dgvJug.Rows[d].Cells[0].Value.ToString());
                    nombLot = dgvJug.Rows[d].Cells[1].Value.ToString();
                    codJug1 = dgvJug.Rows[d].Cells[3].Value.ToString();
                    nombProd1 = dgvJug.Rows[d].Cells[5].Value.ToString();
                    codJug2 = dgvJug.Rows[d].Cells[6].Value.ToString();
                    nombProd2 = dgvJug.Rows[d].Cells[8].Value.ToString();
                    codJug3 = dgvJug.Rows[d].Cells[9].Value.ToString();
                    nombProd3 = dgvJug.Rows[d].Cells[11].Value.ToString();
                    monto = dgvJug.Rows[d].Cells[12].Value.ToString();
                    tripIni = dgvJug.Rows[d].Cells[13].Value.ToString();
                    tripFin = dgvJug.Rows[d].Cells[14].Value.ToString();

                    if (codJug1.Length == 1) { codJug1.PadRight(1, ' '); }
                    if (codJug2.Length == 1) { codJug2.PadRight(1, ' '); }
                    if (codJug3.Length == 1) { codJug3.PadRight(1, ' '); }

                    if (idLotAnt != idLotSig)
                    {
                        if (cadResult.Length > 0) { cadResult += "?"; cont_jud = 1; }
                        // cadResult += busTit(nombLot, "");
                    }

                    int dtIdlot = 0;
                    int cant = 0;
                    
                    cadResult += "Tripleta ";
                    cadResult += nombLot.ToUpper() + "?";
                    cadResult += tripIni + "?";
                    cadResult += tripFin + "?";
                    cadResult += nombProd1.ToUpper() + " ";
                    cadResult += nombProd2.ToUpper() + " ";
                    cadResult += nombProd3.ToUpper() + "?"; ;

                    cadResult += "Monto jugando:";
                    cadResult += Convert.ToDouble(monto).ToString("N2");
                    cadResult += " " + clsMet.NombDivisa.ToUpper() + "?";
                    idLotAnt = Convert.ToInt32(dgvJug.Rows[d].Cells[0].Value.ToString());
                }

                dtDgvJug.Clear();
                dgvJug.DataSource = dtDgvJug;
                frmTckTrip objRpt = new frmTckTrip();
                objRpt.nombTaq = clsMet.nombUsu;
                objRpt.fecha = fTck;
                objRpt.hora = hTck;
                objRpt.nroTicket = nroTck.ToString();
                objRpt.nroSerial = nroSerial;
                objRpt.detJug = cadResult;
                objRpt.totVenta = Convert.ToDouble(txtMJug.Text);
                objRpt.nroDiaCad = clsMet.cantDiaCadTck;
                objRpt.ShowDialog();
                clsMet.verfAct = true;

            }
            catch (Exception ex)
            {
                try {  myTrans.Rollback(); }
                catch (MySqlException error)
                {
                    if (myTrans.Connection != null)
                    {
                        msjInf = "Una excepción de tipo \"" + error.GetType() + " \"";
                        msjInf += " se encontró al intentar revertir la transacción.";
                        MessageBox.Show(msjInf, "Transacción Fallida...");
                    }
                }

                msjInf = "Una excepción de tipo: \"" + ex.GetType() + "\"";
                msjInf += "\n se encontró al insertar los datos. \n Tome nota del";
                msjInf += " siguiente error: \"" + ex.Message + "\"";
                MessageBox.Show(msjInf, "Transacción Fallida...");
            }
        }
        public void busMontTotJug()
        {
            for (int c = 0; c < dgvJug.RowCount; c++)
            {
                mJug = Convert.ToDouble(dgvJug.Rows[c].Cells[12].Value.ToString());
                mTotJug = mTotJug + mJug;
            }
            txtMJug.Text = mTotJug.ToString();
            mTotJug = 0;
        }

        private void dgvLot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int nroFil;
            if (dgvLot.RowCount > 0)
            {
                nroFil = Convert.ToInt32(dgvLot.CurrentRow.Index.ToString());
                DataGridViewCheckBoxCell cell = dgvLot.Rows[nroFil].Cells[0] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(cell.Value) == true) { cell.Value = false; }
                else if (Convert.ToBoolean(cell.Value) == false) { cell.Value = true; }
            }
        }

        private void txtCod1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
            if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }

            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;

            if (codigo == 13) { if (txtCod1.Text.Length > 0) { txtCod2.Focus(); } }
        }
        private void txtCod2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
           if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }

            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;

            if (codigo == 8) { if (txtCod2.Text.Length == 0) { txtCod1.Focus(); } }
            else if (codigo == 13)
            {
                if (txtCod2.Text.Length > 0) { txtCod3.Focus(); }
            }
        }
        private void txtCod3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
            if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }

            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;

            if (codigo == 8) { if (txtCod3.Text.Length == 0) { txtCod2.Focus(); } }
            else if (codigo == 13) { if (txtCod3.Text.Length > 0) { txtMont.Focus(); } }
        }


        private void frmTrip_Activated(object sender, EventArgs e)
        {
            txtCod1.Focus();
        }

        private void frmTrip_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;
            if (codigo == 27) { this.Close(); }
        }

    }
}
