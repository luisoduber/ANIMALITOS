using DevComponents.DotNetBar.Controls;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ventas_loteria
{
    public partial class frm_verf_ticket_taq : Form
    {
        public frm_verf_ticket_taq()
        {
            InitializeComponent();
        }

        clsMet objMet = new clsMet();
        DataTable dtCboGrup = new DataTable();
        DataTable dtCboLot = new DataTable();
        DataTable dtCboTaq = new DataTable();
        DataTable dtDgvDetJug = new DataTable();

        int idLot = 0, idSort= 0;
        int idTaq = 0, idGrup=0;
        string fechLot = "";
        int idPerf=0, idProc = 0;
        private void frm_verf_ticket_taq_Load(object sender, EventArgs e)
        {
            this.Text = "Verifica Ticket Taquilla.";
            this.dgvDetJug.AllowUserToAddRows = false;
            this.dgvDetJug.RowHeadersVisible = false;
            this.dgvDetJug.ColumnHeadersVisible = false;
            idPerf = Convert.ToInt16(clsMet.idPerf);

            gp_cant_jug.Text = "Ticket Ganadores: 0";
            this.dtp_fecha.Value = Convert.ToDateTime(clsMet.FechaActual);
            this.dtp_fecha.Format = DateTimePickerFormat.Custom;
            this.dtp_fecha.CustomFormat = "dd-MM-yyyy";

            this.work_inicia_frm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.work_inicia_frm_DoWork);
            this.work_inicia_frm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.work_inicia_frm_OnProgressChanged);
            this.work_inicia_frm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.work_inicia_frm_OnRunWorkerCompleted);
            this.work_inicia_frm.RunWorkerAsync();
        }
        private void work_inicia_frm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dtCboGrup = objMet.BusGrup();
                if (idPerf == 1 || idPerf == 2) { idGrup = Convert.ToInt32(clsMet.idGrup); }
                else if (idPerf == 3) { idGrup = Convert.ToInt16(dtCboGrup.Rows[0][0].ToString()); }

                dtDgvDetJug = objMet.busJugTaq(idGrup);
                dtCboTaq = objMet.busGrupTaq(idGrup);

                idProc = 1;
                work_inicia_frm.CancelAsync();
           }
            catch (Exception ex)
            {
              idProc = 0;
              MessageBox.Show("Ha ocurrido el siguiente error: "+ex.Message, "Verifique");
            }
        }
        private void work_inicia_frm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        private void work_inicia_frm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (idProc == 1)
            {

                this.cboGrup.DisplayMember = "nombGrup";
                this.cboGrup.ValueMember = "idGrup";
                this.cboGrup.DataSource = dtCboGrup;

                this.cboTaq.DisplayMember = "nick";
                this.cboTaq.ValueMember = "id_usuario";
                this.cboTaq.DataSource = dtCboTaq;

                if (idPerf == 2)
                {
                    idGrup = Convert.ToInt32(clsMet.idGrup);
                    cboGrup.Enabled = false;
                    cboGrup.SelectedValue = idGrup;
                }
                else if (idPerf == 3)
                {
                    cboGrup.Enabled = true;
                    cboGrup.SelectedIndex = 0;
                }

                dgvDetJug.DataSource = dtDgvDetJug;
                gp_cant_jug.Text = "Ticket Ganadores: " + dgvDetJug.RowCount;
                dtp_fecha.Enabled = true;
            }
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void frm_verf_ticket_taq_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;
            if (codigo == 27) { this.Close(); }
        }

        private void dgvDetJug_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetJug.Rows.Count > 0)
            {
                string nroTck = "", nroSerial = "";

                nroTck = dgvDetJug.CurrentRow.Cells[0].Value.ToString();
                nroSerial = dgvDetJug.CurrentRow.Cells[1].Value.ToString();

                frm_verf_ticket objVerfTck = new frm_verf_ticket();
                objVerfTck.prmNroTck = nroTck;
                objVerfTck.prmNroSerial = nroSerial;
                objVerfTck.ShowDialog();
            }
        }

        private void cboGrup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idGrup = Convert.ToInt16(cboGrup.SelectedValue.ToString());
            dtDgvDetJug = objMet.busJugTaq(idGrup);
            dgvDetJug.DataSource = dtDgvDetJug;

            dtCboTaq = objMet.busGrupTaq(idGrup);
            this.cboTaq.DisplayMember = "nick";
            this.cboTaq.ValueMember = "id_usuario";
            this.cboTaq.DataSource = dtCboTaq;
        }

        private void cboTaq_SelectionChangeCommitted(object sender, EventArgs e)
        {

            idTaq = Convert.ToInt32(cboTaq.SelectedValue.ToString());
            fechLot = Convert.ToDateTime(dtp_fecha.Text).ToString("yyyy-MM-dd");

            dtDgvDetJug = objMet.busJugTaqFilt(idGrup, idTaq, fechLot);
            dgvDetJug.DataSource = dtDgvDetJug;

            gp_cant_jug.Text = "Ticket Ganadores: " + dgvDetJug.RowCount;
            dtp_fecha.Enabled = true;
        }

        private void btnRs_Click(object sender, EventArgs e)
        {
            frm_result_lot frm = new frm_result_lot();
            frm.ShowDialog();
        }
        private void txt_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
           //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar)) {  e.Handled = false; }
            else
            if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }
    }
}
