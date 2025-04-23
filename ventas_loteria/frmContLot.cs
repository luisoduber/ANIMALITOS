using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        DataTable dtDgvBloqLot = new DataTable();
        int idProc = 0, idPerf = 0;
        int idBloqLot = 0, idStat = 0;
        int idGrup = 0; string msjInf = "";
        string nombLot = "";

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
                string rsDat = "";
                idBloqLot = Convert.ToInt16(dgvBloqLot.CurrentRow.Cells[0].Value.ToString());
                idStat = Convert.ToInt16(dgvBloqLot.CurrentRow.Cells[1].Value.ToString());
                nombLot = dgvBloqLot.CurrentRow.Cells[2].Value.ToString();

                rsDat = objMet.actStatLot(idBloqLot, idStat);
                idGrup = Convert.ToInt16(cboGrup.SelectedValue);
                dtDgvBloqLot = objMet.busBloqLot(idGrup);
                dgvBloqLot.DataSource = dtDgvBloqLot;

            }
        }

        private void wkIniFrm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (idProc == 1)
            {

                this.cboGrup.DisplayMember = "nombGrup";
                this.cboGrup.ValueMember = "idGrup";
                this.cboGrup.DataSource = dtCboGrup;

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
    }
}
