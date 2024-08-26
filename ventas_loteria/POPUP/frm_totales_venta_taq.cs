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
    public partial class frm_totales_venta_taq : Form
    {
        public frm_totales_venta_taq()
        {
            InitializeComponent();
        }

        clsMet objTotVent = new clsMet();
        DataTable dtDgvTotVentas = new DataTable();

        int id_proceso = 0;

        private void frm_totales_venta_taq_Load(object sender, EventArgs e)
        {
            this.Text = "Verifica Ventas Taquilla."; 
            this.dgvTotVentas.AllowUserToAddRows = false;
            this.dgvTotVentas.RowHeadersVisible = false;

            this.dtpFechaIni.Value =  Convert.ToDateTime(clsMet.FechaActual);
            this.dtpFechaIni.Format = DateTimePickerFormat.Custom;
            this.dtpFechaIni.CustomFormat = "dd-MM-yyyy";

            this.dtpFechaFin.Value =  Convert.ToDateTime(clsMet.FechaActual);
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
                dtDgvTotVentas = objTotVent.busTotVentas
                       (Convert.ToInt32(clsMet.idUsu));

                id_proceso = 1;
                work_inicia_frm.CancelAsync();
            }
            catch (Exception ex)
            {
                id_proceso = 0;
                MessageBox.Show("Ha ocurrido el siguiente error: "+ ex.Message, "Verifique");
            }
        }

        private void work_inicia_frm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        private void work_inicia_frm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (id_proceso == 1)
            {
                this.dgvTotVentas.DataSource = null;
                this.dgvTotVentas.DataSource = dtDgvTotVentas;
                busTotVentas();
            }
        }
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            DateTime fechaIni = dtpFechaIni.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date;
            int cantDifDias = fechaIni.CompareTo(fechaFin);

            if (cantDifDias > 0)
            {
                MessageBox.Show("Fecha inicial no debe ser mayor a fecha final", "Verifique");
                return;
            }

            dtDgvTotVentas = objTotVent.busTotVentasFiltro
                               (Convert.ToInt32(clsMet.idUsu),
             Convert.ToDateTime(dtpFechaIni.Text).ToString("yyyy-MM-dd"),
             Convert.ToDateTime(dtpFechaFin.Text).ToString("yyyy-MM-dd"));

            this.dgvTotVentas.DataSource = dtDgvTotVentas;
            busTotVentas();
        }
        public void busTotVentas()
        {
            try
            {
                string rsTotVentas = "";
                string[] rsDatTotVentas = null;

                Double mTotEnt = 0, mTotSal = 0;
                Double mTotBal = 0, mTotTaq = 0;

                rsTotVentas = objTotVent.busTotVentas(
                Convert.ToInt32(clsMet.idUsu),
                Convert.ToDateTime(dtpFechaIni.Text).ToString("yyyy-MM-dd"),
                Convert.ToDateTime(dtpFechaFin.Text).ToString("yyyy-MM-dd"));

                rsDatTotVentas = rsTotVentas.Split('?');
                mTotEnt = Convert.ToDouble(rsDatTotVentas[0].ToString());
                mTotSal = Convert.ToDouble(rsDatTotVentas[1].ToString());
                mTotBal = Convert.ToDouble(rsDatTotVentas[2].ToString());
                mTotTaq = Convert.ToDouble(rsDatTotVentas[3].ToString());

                lblMontoEnt.Text = mTotEnt.ToString("N2");
                lblMontoSal.Text = mTotSal.ToString("N2");
                lblMontoBal.Text = mTotBal.ToString("N2");
                lblMontoTaq.Text = mTotTaq.ToString("N2");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido el siguiente error: " + ex.Message, "Veifique");
            }
        }
        private void frm_totales_venta_taq_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;
            if (codigo == 27) { this.Close(); }
        }
    }
}
