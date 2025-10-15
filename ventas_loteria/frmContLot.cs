using DevComponents.Schedule.Model;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ventas_loteria
{
    public partial class frmContLot : Form
    {
        public frmContLot()
        {
            InitializeComponent();
        }

        clsMet objMet = new clsMet();
        DataTable dtCboGrup = new DataTable();
        DataTable dtCboStat = new DataTable();
        DataTable dtDgvBloqLot = new DataTable();
        int idProc = 0, idPerf = 0;
        int idBloqLot = 0, idStat = 0;
        int idGrup = 0; string msjInf = "";
        string nombLot = "", monto="";
        string cMont = "", rsFormat = "";
        int dig=0; Boolean proc = true;

        private void frmContLot_Load(object sender, EventArgs e)
        {
            this.Text = "Control Loterias.".ToUpper();
            this.dgvBloqLot.AllowUserToAddRows = false;
            this.dgvBloqLot.RowHeadersVisible = false;
            idPerf = Convert.ToInt16(clsMet.idPerf);

            this.wkIniFrm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkIniFrm_DoWork);
            this.wkIniFrm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.wkIniFrm_OnProgressChanged);
            this.wkIniFrm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wkIniFrm_OnRunWorkerCompleted);
            this.wkIniFrm.RunWorkerAsync();
        }
        private void wkIniFrm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dtCboGrup = objMet.BusGrup();
                dtCboStat = objMet.BusStat();
                idProc = 1;
                wkIniFrm.CancelAsync();
            }
            catch (Exception ex)
            {
                idProc = 0;
                MessageBox.Show(ex.Message, "Verifique");
            }
        }
        private void wkIniFrm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void wkIniFrm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (idProc == 1)
            {
                this.cboGrup.DisplayMember = "nombGrup";
                this.cboGrup.ValueMember = "idGrup";
                this.cboGrup.DataSource = dtCboGrup;

                this.cboStat.DisplayMember = "nomb_status";
                this.cboStat.ValueMember = "id_status";
                this.cboStat.DataSource = dtCboStat;

                if (idPerf == 2)
                {
                    idGrup = Convert.ToInt32(clsMet.idGrup);
                    cboGrup.Enabled = false;
                    cboGrup.SelectedValue = idGrup;
                }
                else if (idPerf == 3) { idGrup = Convert.ToInt16(dtCboGrup.Rows[0][0].ToString()); }

                dtDgvBloqLot = objMet.busBloqLot(idGrup);
                dgvBloqLot.DataSource = dtDgvBloqLot;
            }
        }

        private void txtMont_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                dig = Convert.ToInt32((Keys)e.KeyChar);
                e.Handled = true;

                if (dig == 8)
                {
                    if (string.IsNullOrEmpty(cMont)) { rsFormat = "0,00"; }
                    if (cMont.Length == 0) { rsFormat = "0,00"; }
                    else if (cMont.Length >= 1)
                    {
                        cMont = cMont.Substring(0, cMont.Length - 1);

                        if (cMont.Length == 0) { rsFormat = "0,00"; proc = false; }
                        else { proc = true; }
                    }
                }

                else if (dig == 45) { proc = true; }
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
               
                if (proc == true) { rsFormat = objMet.formatMonto(cMont); }
                txtMont.Text = rsFormat;
                txtMont.SelectionStart = txtMont.Text.Length;
            }
            catch (Exception ex) { MessageBox.Show("Ha ocurrido el siguiente error:" + ex.Message, "Verifique..."); }

            /*#################################################################################################################
            * ###############################################################################################################*/

            if (dig == 13)
            {
                Boolean rsValidFrm = validFrm();
                if (rsValidFrm == true)
                {
                    string rsDat = "";
                    idStat = Convert.ToInt16(cboStat.SelectedValue.ToString());
                    rsDat = objMet.actStatLot(idBloqLot, idStat, 
                            txtMont.Text.Replace(".", "").Replace(",", "."));

                    idGrup = Convert.ToInt16(cboGrup.SelectedValue);
                    dtDgvBloqLot = objMet.busBloqLot(idGrup);
                    dgvBloqLot.DataSource = dtDgvBloqLot;
                    limpFrm();
                }
            }
        }
        public void limpFrm()
        {
            txtMont.Text = "0,00";
            cMont = "";
        }
        public Boolean validFrm()
        {
            Boolean valid = true;
            if (string.IsNullOrEmpty(txtMont.Text))
            {
                MessageBox.Show("Ingrese un monto", "Verifique...");
                txtMont.Focus();
                valid = false;
            }
            else if (Convert.ToDouble(txtMont.Text)==0)
            {
                MessageBox.Show("Ingrese un monto mayor a cero (0).", "Verifique...");
                txtMont.Focus();
                valid = false;
            }
            return valid;
        }

       
        private void frmContLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int cod = 0;
            caracter = Convert.ToChar(e.KeyChar);
            cod = (int)caracter;
            if (cod == 27) { this.Close(); }
        }

        private void cboGrup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idGrup = Convert.ToInt16(cboGrup.SelectedValue);
            dtDgvBloqLot = objMet.busBloqLot(idGrup);
            dgvBloqLot.DataSource = dtDgvBloqLot;
        }

        private void dgvBloqLot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBloqLot.RowCount > 0)
            {
                idBloqLot = Convert.ToInt16(dgvBloqLot.CurrentRow.Cells[0].Value.ToString());
                idStat = Convert.ToInt16(dgvBloqLot.CurrentRow.Cells[1].Value.ToString());
                nombLot = dgvBloqLot.CurrentRow.Cells[2].Value.ToString();
                monto = dgvBloqLot.CurrentRow.Cells[3].Value.ToString();
                cMont = objMet.limpMonto(Convert.ToDouble(monto).ToString("N2"));

                cboStat.SelectedValue = idStat;
                txtMont.Text = Convert.ToDouble(monto).ToString("N2");
                txtMont.Focus();
            }
        }
    }
}
