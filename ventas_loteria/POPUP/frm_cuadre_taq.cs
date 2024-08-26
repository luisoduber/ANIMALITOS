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
    public partial class frm_cuadre_taq : Form
    {
        public frm_cuadre_taq()
        {
            InitializeComponent();
        }

        clsMet objCuadreTaq = new clsMet();
        DataTable dtDgvCuadreTaq = new DataTable();
        DataTable dtCboTaq = new DataTable();
        DataTable dtCboDivisa = new DataTable();
        int id_proceso = 0;
        private void frm_cuadre_taq_Load(object sender, EventArgs e)
        {
            this.Text = "Cuadre Taquillas.";
            this.dgvCuadreTaq.AllowUserToAddRows = false;
            this.dgvCuadreTaq.RowHeadersVisible = false;

            this.dtpFechaIni.Value =  Convert.ToDateTime(clsMet.FechaActual);
            this.dtpFechaIni.Format = DateTimePickerFormat.Custom;
            this.dtpFechaIni.CustomFormat = "dd-MM-yyyy";

            this.dtpFechaFin.Value = Convert.ToDateTime(clsMet.FechaActual);
            this.dtpFechaFin.Format = DateTimePickerFormat.Custom;
            this.dtpFechaFin.CustomFormat = "dd-MM-yyyy";

            this.work_inicia_frm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.work_inicia_frm_DoWork);
            this.work_inicia_frm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.work_inicia_frm_OnProgressChanged);
            this.work_inicia_frm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.work_inicia_frm_OnRunWorkerCompleted);
            this.work_inicia_frm.RunWorkerAsync();
        }
        private void work_inicia_frm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dtDgvCuadreTaq = objCuadreTaq.busTotCuadreGrupoTaq
                    (Convert.ToInt32(clsMet.idGrup));

                dtCboTaq = objCuadreTaq.busGrupoTaq
               (Convert.ToInt32(clsMet.idGrup));

                dtCboDivisa = objCuadreTaq.busDivisa();

                id_proceso = 1;
                work_inicia_frm.CancelAsync();
            }
            catch (Exception ex)
            {
                id_proceso = 0;
                MessageBox.Show("Ha ocurrido el siguiente error: "+ ex.Message, "Verifique.");
            }
        }
        private void work_inicia_frm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        private void work_inicia_frm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (id_proceso == 1)
            {
                this.dgvCuadreTaq.DataSource = dtDgvCuadreTaq;

                this.cboTaq.DisplayMember="nick";
                this.cboTaq.ValueMember="id_usuario";
                this.cboTaq.DataSource = dtCboTaq;

                this.cboDivisa.DisplayMember = "nombDivisa";
                this.cboDivisa.ValueMember = "idDivisa";
                this.cboDivisa.DataSource = dtCboDivisa;
            }
        }
        private void cboDivisa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DateTime fechaIni = dtpFechaIni.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date;
            int idUsuario = Convert.ToInt32(cboTaq.SelectedValue.ToString());
            int idDivisa = Convert.ToInt32(cboDivisa.SelectedValue.ToString());
            int cantDifDias = fechaIni.CompareTo(fechaFin);

            if (cantDifDias > 0)
            {
                MessageBox.Show("Fecha inicial no debe ser mayor a fecha final.", "Verifique.");
                return;
            }

            dtDgvCuadreTaq = objCuadreTaq.busTotGrupoTaqXDivisa(
            Convert.ToInt32(clsMet.idGrup),
            idUsuario,
            idDivisa,
            Convert.ToDateTime(dtpFechaIni.Text).ToString("yyyy-MM-dd"),
            Convert.ToDateTime(dtpFechaFin.Text).ToString("yyyy-MM-dd"));
            this.dgvCuadreTaq.DataSource = dtDgvCuadreTaq;
        }
        private void cboTaq_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DateTime fechaIni = dtpFechaIni.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date;
            int idUsuario = Convert.ToInt32(cboTaq.SelectedValue.ToString());
            int cantDifDias = fechaIni.CompareTo(fechaFin);

            if (cantDifDias > 0)
            {
                MessageBox.Show("Fecha inicial no debe ser mayor a fecha final.", "Verifique.");
                return;
            }

            dtDgvCuadreTaq = objCuadreTaq.busTotCuadreGrupoTaqFiltro
            (Convert.ToInt32(clsMet.idGrup),
            idUsuario,
            Convert.ToDateTime(dtpFechaIni.Text).ToString("yyyy-MM-dd"),
            Convert.ToDateTime(dtpFechaFin.Text).ToString("yyyy-MM-dd"));
            this.dgvCuadreTaq.DataSource = dtDgvCuadreTaq;
        }
        private void frm_cuadre_taq_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;
            if (codigo == 27) { this.Close(); }
        }

        private void dtpFechaIni_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}


