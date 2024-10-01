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

namespace ventas_loteria
{
    public partial class frm_verf_ticket_taq : Form
    {
        public frm_verf_ticket_taq()
        {
            InitializeComponent();
        }

        clsMet objMet = new clsMet();
        DataTable dtDgvSort = new DataTable();
        DataTable dtCboLot = new DataTable();
        DataTable dtCboTaq = new DataTable();
        DataTable dtDgvDetJug = new DataTable();

        int idLot = 0, idSort= 0;
        int idTaq = 0;
        string fechLot = "";
        int idProc = 0;
        private void frm_verf_ticket_taq_Load(object sender, EventArgs e)
        {
            this.Text = "Verifica Ticket Taquilla.";
            this.dgvSort.AllowUserToAddRows = false;
            this.dgvSort.RowHeadersVisible = false;

            this.dgvDetJug.AllowUserToAddRows = false;
            this.dgvDetJug.RowHeadersVisible = false;
            this.dgvDetJug.ColumnHeadersVisible = false;

            gp_cant_jug.Text = "cantidad jugadas: 0";

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
                dtCboLot = objMet.listLotTod();
                dtDgvSort = objMet.busLotProcRs();
                dtCboTaq = objMet.busGrupTaq
                            (Convert.ToInt32(clsMet.idGrup));

                idProc= 1;
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
                dgvSort.DataSource = dtDgvSort;
                this.cboTaq.DisplayMember = "nick";
                this.cboTaq.ValueMember = "id_usuario";
                this.cboTaq.DataSource = dtCboTaq;

                this.cboLot.DisplayMember = "nombLot";
                this.cboLot.ValueMember = "idLot";
                this.cboLot.DataSource = dtCboLot;
            }
        }
        private void dgvSort_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSort.RowCount > 0)
            {
                idTaq = Convert.ToInt32(cboTaq.SelectedValue.ToString());
                fechLot = Convert.ToDateTime(dtp_fecha.Text).ToString("yyyy-MM-dd");

                idLot = Convert.ToInt32(dgvSort.CurrentRow.Cells[0].Value.ToString());
                idSort= Convert.ToInt32(dgvSort.CurrentRow.Cells[3].Value.ToString());

                dtDgvDetJug = objMet.busJugTaq(idLot,idSort,idTaq,fechLot);
                dgvDetJug.DataSource = dtDgvDetJug;

                gp_cant_jug.Text = "Cantidad jugadas: " + dgvDetJug.RowCount;
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

        private void cboLot_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idLot = Convert.ToInt16(cboLot.SelectedValue);
            dtDgvSort = objMet.listSortTod(idLot);
            dgvSort.DataSource = dtDgvSort;
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
