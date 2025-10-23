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
    public partial class frm_verf_status_ticket : Form
    {
        public frm_verf_status_ticket()
        {
            InitializeComponent();
        }
        clsMet objStatTck = new clsMet();
        DataTable dtCboStatTck = new DataTable();
        DataTable dtDgvStatTck = new DataTable();

        int idStatTck = 0, cantTck = 0;
        double mTotEnt = 0, mTotSal = 0;
        double mTotCaja = 0;
        int id_proceso = 0;

        string rsTotVent = "";
        string[] rsDatTotVent = null;

        private void frm_verf_status_ticket_Load(object sender, EventArgs e)
        {
            this.Text = "Ticket Taquilla.";
            this.dgvStatTck.AllowUserToAddRows = false;
            this.dgvStatTck.RowHeadersVisible = false;

            this.dtpFechIni.Value =  Convert.ToDateTime(clsMet.FechaActual);
            this.dtpFechIni.Format = DateTimePickerFormat.Custom;
            this.dtpFechIni.CustomFormat = "dd-MM-yyyy";

            this.dtpFechFin.Value =  Convert.ToDateTime(clsMet.FechaActual);
            this.dtpFechFin.Format = DateTimePickerFormat.Custom;
            this.dtpFechFin.CustomFormat = "dd-MM-yyyy";

            this.work_inicia_frm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.work_inicia_frm_DoWork);
            this.work_inicia_frm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.work_inicia_frm_OnProgressChanged);
            this.work_inicia_frm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.work_inicia_frm_OnRunWorkerCompleted);
            this.work_inicia_frm.RunWorkerAsync();
        }

        private void work_inicia_frm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dtCboStatTck = objStatTck.busStatTckFilt();
                dtDgvStatTck = objStatTck.busMovStatTck
                (Convert.ToInt32(clsMet.idUsu));

                id_proceso = 1;
                work_inicia_frm.CancelAsync();
            }
            catch (Exception ex)
            {
                id_proceso = 0;
                MessageBox.Show("Ha ocurrido el siguiente error: " + ex.Message, "Verifique");
            }
        }

        private void work_inicia_frm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void work_inicia_frm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (id_proceso == 1)
            {
                this.cboStatTck.DisplayMember = "nmb_status_ticket";
                this.cboStatTck.ValueMember = "id_status_ticket";
                this.cboStatTck.DataSource = dtCboStatTck;

                this.dgvStatTck.DataSource = null;
                this.dgvStatTck.DataSource = dtDgvStatTck;
                busTotCuadCaja();
            }
            else if (id_proceso == 0)
            {
                MessageBox.Show("Error verificando licencia", "Verifique.");
            }
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void  busTotCuadCaja()
    {
        try
        {
            rsTotVent = objStatTck.busTotVent(
                Convert.ToInt32(clsMet.idUsu),
                Convert.ToDateTime(dtpFechIni.Text).ToString("yyyy-MM-dd"),
                Convert.ToDateTime(dtpFechFin.Text).ToString("yyyy-MM-dd"),
                idStatTck);

            rsDatTotVent = rsTotVent.Split('?');
            cantTck = Convert.ToInt32(rsDatTotVent[0].ToString());
            mTotEnt = Convert.ToDouble(rsDatTotVent[1].ToString());
            mTotSal= Convert.ToDouble(rsDatTotVent[2].ToString());
            mTotCaja = mTotEnt - mTotSal;

            lbl_status_ticket.Text = cboStatTck.Text;
            lbl_monto_entrada.Text = mTotEnt.ToString("N2");
            lbl_monto_salida.Text = mTotSal.ToString("N2");
            lbl_monto_total_caja.Text = mTotCaja.ToString("N2");
            lbl_cant_ticket.Text = cantTck.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ha ocurrido el siguiente error: "+ ex.Message,"Verifique.");
        }
    }

        private void dgvStatTck_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string nroTck = "", nroSerial = "";

            if (dgvStatTck.RowCount > 0)

            nroTck = dgvStatTck.CurrentRow.Cells[2].Value.ToString();
            nroSerial = dgvStatTck.CurrentRow.Cells[3].Value.ToString();

            frm_verf_ticket objVerfTck = new frm_verf_ticket();
            objVerfTck.prmNroTck = nroTck;
            objVerfTck.prmNroSerial = nroSerial;
            objVerfTck.ShowDialog();
        }
        private void frm_verf_status_ticket_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;
            if (codigo == 27) { this.Close(); }
        }
        private void btn_imprimir_cuadre_Click(object sender, EventArgs e)
        {
            frm_rpt_cuadre_diario objRpt = new frm_rpt_cuadre_diario();
            objRpt.nombTaq = clsMet.nombUsu;
            objRpt.fecha = DateTime.Today.ToString("dd/MM/yyyy");
            objRpt.hora = DateTime.Now.ToString("hh:mm");
            objRpt.fechaIni = dtpFechIni.Text;
            objRpt.fechaFin = dtpFechFin.Text;
            objRpt.status = lbl_status_ticket.Text;
            objRpt.cantTicket = lbl_cant_ticket.Text;
            objRpt.totalEnt=Convert.ToDouble(lbl_monto_entrada.Text);
            objRpt.totalSal= Convert.ToDouble(lbl_monto_salida.Text);
            objRpt.totalCaja = Convert.ToDouble(lbl_monto_total_caja.Text);
            objRpt.Show();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            idStatTck= Convert.ToInt32(cboStatTck.SelectedValue.ToString());

            DateTime fechIni = dtpFechIni.Value.Date;
            DateTime fechFin = dtpFechFin.Value.Date;
            int cantDifDias = fechIni.CompareTo(fechFin);

            if (cantDifDias > 0)
            {
                MessageBox.Show("Fecha inicial no debe ser mayor a fecha final", "Verifique");
                return;
            }

            dtDgvStatTck = objStatTck.busStatTckXfilt
                (Convert.ToInt32(clsMet.idUsu),
                Convert.ToDateTime(dtpFechIni.Text).ToString("yyyy-MM-dd"),
                Convert.ToDateTime(dtpFechFin.Text).ToString("yyyy-MM-dd"),
                idStatTck);

            this.dgvStatTck.DataSource = dtDgvStatTck;
            busTotCuadCaja();
        }
    }

    }

