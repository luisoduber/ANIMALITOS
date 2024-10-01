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
    public partial class frm_cuadre_taq_gral : Form
    {
        public frm_cuadre_taq_gral()
        {
            InitializeComponent();
        }

        clsMet objMet = new clsMet();
        DataTable dtDgvCuad= new DataTable();
        DataTable dtCboGrup = new DataTable();
        DataTable dtCboTaq = new DataTable();
        int idGrup = 0;
        int idProc = 0;

        private void frm_cuadre_taq_gral_Load(object sender, EventArgs e)
        {
            this.Text = "Cuadre General Taquillas.".ToUpper();
            this.dgvCuadGrup.AllowUserToAddRows = false;
            this.dgvCuadGrup.RowHeadersVisible = false;

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
                dtCboGrup = objMet.busGrupTod();
                idProc = 1;
                work_inicia_frm.CancelAsync();
                idGrup = Convert.ToInt16(dtCboGrup.Rows[0][0].ToString());
                dtDgvCuad = objMet.busVentGrupTod
                (idGrup,
                Convert.ToDateTime(dtpFechIni.Text).ToString("yyyy-MM-dd"),
                Convert.ToDateTime(dtpFechFin.Text).ToString("yyyy-MM-dd"));
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
        private void work_inicia_frm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (idProc == 1)
            {
                this.cboGrup.DisplayMember = "nomb_grupo";
                this.cboGrup.ValueMember = "id_grupo";
                this.cboGrup.DataSource = dtCboGrup;
                this.dgvCuadGrup.DataSource = dtDgvCuad;
            }
            else if (idProc == 0)
            {
                MessageBox.Show("Error verificando licencia", "Verifique.");
            }

        }
        private void cboGrup_SelectionChangeCommitted(object sender, EventArgs e)
        {

            idGrup = Convert.ToInt32(cboGrup.SelectedValue.ToString());
            if (idGrup == 0)
            {
                dtDgvCuad = objMet.busVentGrupTod
                (idGrup,
                Convert.ToDateTime(dtpFechIni.Text).ToString("yyyy-MM-dd"),
                Convert.ToDateTime(dtpFechFin.Text).ToString("yyyy-MM-dd"));
            }
            else if (idGrup > 0)
            {
                dtDgvCuad = objMet.busVentGrup
                (idGrup,
                Convert.ToDateTime(dtpFechIni.Text).ToString("yyyy-MM-dd"),
                Convert.ToDateTime(dtpFechFin.Text).ToString("yyyy-MM-dd"));
            }
            this.dgvCuadGrup.DataSource = dtDgvCuad;
        }

        private void frm_cuadre_taq_gral_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;
            if (codigo == 27) { this.Close(); }
        }
    }
}


