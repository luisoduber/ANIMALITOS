﻿using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;


namespace ventas_loteria
{
    public partial class frmLimTaq : Form
    {
        public frmLimTaq()
        {
            InitializeComponent();
        }

        clsMet objFunc = new clsMet();
        DataTable dtCboTaq = new DataTable();
        DataTable dtDgvLimTaq = new DataTable();

        int idLot = 0, idSort = 0;
        string mMaxAn = "", msjInf = "";
        int idStat = 0, idTaq = 0;
        int idGrup = 0, idUsu = 0;
        int idProc = 0;

        private void frmLimTaq_Load(object sender, EventArgs e)
        {
            this.Text = "Control Limites Taquillas.";
            this.dgvLimTaq.AllowUserToAddRows = false;
            this.dgvLimTaq.RowHeadersVisible = false;

            this.dgvLimTaq.AllowUserToAddRows = false;
            this.dgvLimTaq.RowHeadersVisible = false;
            idGrup = Convert.ToInt32(clsMet.idGrup);

            this.work_inicia_frm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.work_inicia_frm_DoWork);
            this.work_inicia_frm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.work_inicia_frm_OnProgressChanged);
            this.work_inicia_frm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.work_inicia_frm_OnRunWorkerCompleted);
            this.work_inicia_frm.RunWorkerAsync();
        }
        private void frmLimTaq_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;
            if (codigo == 27) { this.Close(); }
        }

        private void btnGrd_Click(object sender, EventArgs e)
        {
            Boolean valid = true;
            valid = validFrm();
            string rsGrd = "";
            idTaq=Convert.ToInt32(cboTaq.SelectedValue);   

            if (valid == true)
            {
                rsGrd= objFunc.actLimTaq(idGrup,idTaq,
                                         txtCupAn.Text);

                if (rsGrd == "true")
                {
                    MessageBox.Show("Actualización Realizada.", "Transacción Exitosa.");
                    dtDgvLimTaq = objFunc.busLimTaq(idGrup);
                    dgvLimTaq.DataSource = dtDgvLimTaq;
                    limpFrm();
                }
                else
                {
                    MessageBox.Show("Ha Ocurrido el siguiente error:" + rsGrd, "Verifique");
                }
            }
        }
        private void work_inicia_frm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dtCboTaq = objFunc.BusTaqContVent(idGrup);
                dtDgvLimTaq = objFunc.busLimTaq(idGrup);

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

        private void frmLimTaq_Activated(object sender, EventArgs e)
        {
            txtCupAn.Focus();
        }

        private void cboTaq_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtCupAn.Focus();
        }

        private void txtCupAn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
                if (Char.IsControl(e.KeyChar)) 
            { e.Handled = false; }
            else { e.Handled = true; }
        }

        private void work_inicia_frm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (idProc == 1)
            {
                dgvLimTaq.DataSource = dtDgvLimTaq;
                this.cboTaq.DisplayMember = "nick";
                this.cboTaq.ValueMember = "id_usuario";
                this.cboTaq.DataSource = dtCboTaq;
            }
        }
        private void dgvLimTaq_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLimTaq.RowCount > 0)
            {
                idTaq = Convert.ToInt16(dgvLimTaq.CurrentRow.Cells[0].Value.ToString());
                mMaxAn = dgvLimTaq.CurrentRow.Cells[2].Value.ToString();
                cboTaq.SelectedValue = idTaq;
                cboTaq.Enabled = false;
                txtCupAn.Text = mMaxAn;
                txtCupAn.Focus();
            }
        }
        public Boolean validFrm()
        {
            Boolean valid = true;
            if (string.IsNullOrEmpty(txtCupAn.Text))
            {
                MessageBox.Show("Ingrese un valor.", "Verifique.");
                txtCupAn.Focus();
                valid = false;
            }
            else if (Convert.ToInt32(txtCupAn.Text) == 0)
            {
                MessageBox.Show("Ingrese un valor maor de cero (0).", "Verifique.");
                txtCupAn.Focus();
                valid = false;
            }
            return valid;
        }
        public void limpFrm()
        {
            txtCupAn.Text = "";
            txtCupAn.Focus();
            cboTaq.Enabled = true;
            cboTaq.SelectedIndex = 0;
            idTaq = 0;

        }


    }
}