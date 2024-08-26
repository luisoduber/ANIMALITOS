using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ventas_loteria
{
    public partial class frm_result_lot : Form
    {
        public frm_result_lot()
        {
            InitializeComponent();
        }

        clsMet objResultLot = new clsMet();
        DataTable dtDgvResultLot = new DataTable();
        DataTable dtCboLot = new DataTable();
       
        int id_proceso = 0;

        private void frm_result_lot_Load(object sender, EventArgs e)
        {
            this.Text = "Resultados Loteria."; 
            this.dgvResultLot.AllowUserToAddRows = false;
            this.dgvResultLot.AllowUserToAddRows = false;
            this.dgvResultLot.RowHeadersVisible = false;

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
               
                dtCboLot = objResultLot.busLotResult();
                dtDgvResultLot = objResultLot.busResultLot();

                id_proceso = 1;
                work_inicia_frm.CancelAsync();
            }
            catch (Exception ex)
            {
                id_proceso = 0;
                MessageBox.Show("Ha Ocurrido el siguiente error: "+ ex.Message, "Verifique");
            }
        }

        private void work_inicia_frm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        private void work_inicia_frm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (id_proceso == 1)
            {
                cboLot.DisplayMember = "nomb_loteria";
                cboLot.ValueMember = "id_loteria";
                cboLot.DataSource = dtCboLot;
                dgvResultLot.DataSource = dtDgvResultLot;
            }
        }
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtp_fecha.Value.Date;
            DateTime fechHoy = DateTime.Today;
            int cantDifDias = fecha.CompareTo(fechHoy);
            int idLot= Convert.ToInt32(cboLot.SelectedValue.ToString());

            if (cantDifDias > 0)
            {
                MessageBox.Show("Fecha inicial no debe ser mayor a fecha actual...", "Verifique.");
                return;
            }

            dtDgvResultLot = objResultLot.busResultLotfilt
                                        (idLot, 
            Convert.ToDateTime(dtp_fecha.Text).ToString("yyyy-MM-dd"));
            dgvResultLot.DataSource = dtDgvResultLot;
        }
        private void frm_result_lot_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;

            if (codigo == 27) { this.Close(); }
        }
    }
}
