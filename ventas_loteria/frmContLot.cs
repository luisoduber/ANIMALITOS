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
        DataTable dtCboTaq = new DataTable();
        DataTable dtCboStat = new DataTable();
        DataTable dtDgvBloqLot = new DataTable();
        int idProc = 0, idPerf = 0;
        int idBloqLot = 0, idStat = 0;
        int idGrup = 0; string msjInf = "";
        string nombLot = "", montoBs="";
        string montoUsd="";
        string cMontBs = "", rsFormat = "";
        string cMontUsd = "";
        int dig=0; Boolean proc = true;
        int idTaq = 0;

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
                if (idPerf == 1 || idPerf == 2) { idGrup = Convert.ToInt32(clsMet.idGrup); }
                else if (idPerf == 3) { idGrup = Convert.ToInt16(dtCboGrup.Rows[0][0].ToString()); }

                dtCboTaq = objMet.BusTaqContVent(idGrup);
                idTaq = Convert.ToInt16(dtCboTaq.Rows[0][0].ToString());

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

                this.cboTaq.DisplayMember = "nick";
                this.cboTaq.ValueMember = "id_usuario";
                this.cboTaq.DataSource = dtCboTaq;

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

                dtDgvBloqLot = objMet.busBloqLot(idTaq);
                dgvBloqLot.DataSource = dtDgvBloqLot;
            }
        }

        private void txtMontBs_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                dig = Convert.ToInt32((Keys)e.KeyChar);
                e.Handled = true;

                if (dig == 8)
                {
                    if (string.IsNullOrEmpty(cMontBs)) { rsFormat = "0,00"; }
                    if (cMontBs.Length == 0) { rsFormat = "0,00"; }
                    else if (cMontBs.Length >= 1)
                    {
                        cMontBs = cMontBs.Substring(0, cMontBs.Length - 1);

                        if (cMontBs.Length == 0) { rsFormat = "0,00"; proc = false; }
                        else { proc = true; }
                    }
                }

                else if (dig == 45) { proc = true; }
                else if ((dig >= 48) && (dig <= 57))
                {
                    cMontBs += e.KeyChar.ToString();

                    if (Convert.ToDouble(cMontBs) == 0)
                    {
                        cMontBs = cMontBs.Substring(0, cMontBs.Length - 1);
                        proc = false;
                    }
                    else { proc = true; }
                }

                /*#################################################################################################################
                 * ###############################################################################################################*/
               
                if (proc == true) { rsFormat = objMet.formatMonto(cMontBs); }
                txtMontBs.Text = rsFormat;
                txtMontBs.SelectionStart = txtMontBs.Text.Length;
                txtMontBs.SelectionLength = 0;

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
                            txtMontBs.Text.Replace(".", "").Replace(",", "."),
                            txtMontUsd.Text.Replace(".", "").Replace(",", ".")
                            );

                    idTaq = Convert.ToInt16(cboTaq.SelectedValue);
                    dtDgvBloqLot = objMet.busBloqLot(idTaq);
                    dgvBloqLot.DataSource = dtDgvBloqLot;
                    limpFrm();
                }
            }
        }
        public void limpFrm()
        {
            txtMontBs.Text = "0,00";
            txtMontUsd.Text = "0,00";
            cMontBs = "";
            cMontUsd = "";
        }

        private void cboTaq_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idTaq = Convert.ToInt16(cboTaq.SelectedValue.ToString());
            this.cboTaq.DisplayMember = "nick";
            this.cboTaq.ValueMember = "id_usuario";
            this.cboTaq.DataSource = dtCboTaq;

            dtDgvBloqLot = objMet.busBloqLot(idTaq);
            dgvBloqLot.DataSource = dtDgvBloqLot;
        }

        private void txtMontUsd_KeyPress(object sender, KeyPressEventArgs e)
        {
             try
            {
                dig = Convert.ToInt32((Keys)e.KeyChar);
                e.Handled = true;

                if (dig == 8)
                {
                    if (string.IsNullOrEmpty(cMontUsd)) { rsFormat = "0,00"; }
                    if (cMontUsd.Length == 0) { rsFormat = "0,00"; }
                    else if (cMontUsd.Length >= 1)
                    {
                        cMontUsd = cMontUsd.Substring(0, cMontUsd.Length - 1);

                        if (cMontUsd.Length == 0) { rsFormat = "0,00"; proc = false; }
                        else { proc = true; }
                    }
                }

                else if (dig == 45) { proc = true; }
                else if ((dig >= 48) && (dig <= 57))
                {
                    cMontUsd += e.KeyChar.ToString();

                    if (Convert.ToDouble(cMontUsd) == 0)
                    {
                        cMontUsd = cMontUsd.Substring(0, cMontUsd.Length - 1);
                        proc = false;
                    }
                    else { proc = true; }
                }

                /*#################################################################################################################
                 * ###############################################################################################################*/
               
                if (proc == true) { rsFormat = objMet.formatMonto(cMontUsd); }
                txtMontUsd.Text = rsFormat;
                txtMontUsd.SelectionStart = txtMontBs.Text.Length;
                txtMontUsd.SelectionLength = 0;

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
                            txtMontBs.Text.Replace(".", "").Replace(",", "."),
                            txtMontUsd.Text.Replace(".", "").Replace(",", ".")
                            );

                    idTaq = Convert.ToInt16(cboTaq.SelectedValue);
                    dtDgvBloqLot = objMet.busBloqLot(idTaq);
                    dgvBloqLot.DataSource = dtDgvBloqLot;
                    limpFrm();
                }
            }
        }

        public Boolean validFrm()
        {
            Boolean valid = true;
            if (string.IsNullOrEmpty(txtMontBs.Text))
            {
                MessageBox.Show("Ingrese un monto", "Verifique...");
                txtMontBs.Focus();
                valid = false;
            }
            else if (Convert.ToDouble(txtMontBs.Text)==0)
            {
                MessageBox.Show("Ingrese un monto mayor a cero (0).", "Verifique...");
                txtMontBs.Focus();
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

            dtCboTaq = objMet.BusTaqContVent(idGrup);
            idTaq = Convert.ToInt16(dtCboTaq.Rows[0][0].ToString());

            this.cboTaq.DisplayMember = "nick";
            this.cboTaq.ValueMember = "id_usuario";
            this.cboTaq.DataSource = dtCboTaq;

            dtDgvBloqLot = objMet.busBloqLot(idTaq);
            dgvBloqLot.DataSource = dtDgvBloqLot;
        }

        private void dgvBloqLot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBloqLot.RowCount > 0)
            {
                idBloqLot = Convert.ToInt16(dgvBloqLot.CurrentRow.Cells[0].Value.ToString());
                idStat = Convert.ToInt16(dgvBloqLot.CurrentRow.Cells[1].Value.ToString());
                nombLot = dgvBloqLot.CurrentRow.Cells[2].Value.ToString();
                montoBs = dgvBloqLot.CurrentRow.Cells[3].Value.ToString();
                montoUsd= dgvBloqLot.CurrentRow.Cells[4].Value.ToString();
                cMontBs = objMet.limpMonto(Convert.ToDouble(montoBs).ToString("N2"));
                cMontUsd = objMet.limpMonto(Convert.ToDouble(montoUsd).ToString("N2"));

                cboStat.SelectedValue = idStat;
                txtMontBs.Text = Convert.ToDouble(montoBs).ToString("N2");
                txtMontUsd.Text = Convert.ToDouble(montoUsd).ToString("N2");
                txtMontBs.Focus();
                txtMontBs.SelectionStart = txtMontBs.Text.Length;
                txtMontBs.SelectionLength = 0;
            }
        }
    }
}
