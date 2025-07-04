using Org.BouncyCastle.Asn1.Tsp;
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
using ZstdSharp.Unsafe;

namespace ventas_loteria
{
    public partial class frmVentLot : Form
    {
        public frmVentLot()
        {
            InitializeComponent();
        }

        clsMet objMet = new clsMet();
        DataTable dtDgvSort = new DataTable();
        DataTable dtCboGrup = new DataTable();
        DataTable dtCboTaq = new DataTable();
        DataTable dtCboLot = new DataTable();

        int idUsu=0, idPerf=0;
        int idGrup=0, idProc = 0;

        private void frmVentLot_Load(object sender, EventArgs e)
        {

            this.Text = "Ventas Loterias...".ToUpper();
            this.dtpFechIni.Value = Convert.ToDateTime(clsMet.FechaActual);
            this.dtpFechIni.Format = DateTimePickerFormat.Custom;
            this.dtpFechIni.CustomFormat = "dd-MM-yyyy";

            this.dtpFechFin.Value = Convert.ToDateTime(clsMet.FechaActual);
            this.dtpFechFin.Format = DateTimePickerFormat.Custom;
            this.dtpFechFin.CustomFormat = "dd-MM-yyyy";

            idUsu = Convert.ToInt32(clsMet.idUsu);
            idPerf = Convert.ToInt32(clsMet.idPerf);

            lblVent.Text = "0,00";
            lblPrem.Text = "0,00";
            lblAn.Text = "0,00";
            lblUt.Text = "0,00";

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
                if (idPerf == 2){ idGrup = Convert.ToInt32(clsMet.idGrup);}
                else if (idPerf == 3) { idGrup = Convert.ToInt16(dtCboGrup.Rows[0][0].ToString()); }

                dtCboTaq = objMet.BusTaqContVent(idGrup);
                dtCboLot = objMet.listLot(idGrup);

                idProc = 1;
                wkIniFrm.CancelAsync();
                e.Cancel = wkIniFrm.CancellationPending;
            }
            catch (Exception ex)
            {
                idProc = 0;
                MessageBox.Show(ex.Message, "Verifique.");
            }
        }
        private void wkIniFrm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void wkIniFrm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (idProc == 1)
            {
                if (idPerf == 2)
                {
                    cboGrup.Enabled = false;
                    cboGrup.SelectedValue = idGrup;
                }

                this.cboGrup.DisplayMember = "nombGrup";
                this.cboGrup.ValueMember = "idGrup";
                this.cboGrup.DataSource = dtCboGrup;

                this.cboTaq.DisplayMember = "nick";
                this.cboTaq.ValueMember = "id_usuario";
                this.cboTaq.DataSource = dtCboTaq;

                this.cboLot.DisplayMember = "nombLot";
                this.cboLot.ValueMember = "idLot";
                this.cboLot.DataSource = dtCboLot;
            }
        }

        private void cboLot_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string[] rsDat = new string[6];
            DateTime fechIni = dtpFechIni.Value.Date;
            DateTime fechFin = dtpFechFin.Value.Date;
            int cantDif = fechIni.CompareTo(fechFin);
            int idLot= 0;

            idGrup = Convert.ToInt16(cboGrup.SelectedValue.ToString());
            idUsu = Convert.ToInt16(cboTaq.SelectedValue.ToString());
            idLot = Convert.ToInt16(cboLot.SelectedValue.ToString());

            if (cantDif > 0)
            {
                MessageBox.Show("Fecha inicial no debe ser mayor a fecha final...", "Verifique.");
                return;
            }

            rsDat = objMet.VerfVentLot(idGrup,idUsu, idLot,
                Convert.ToDateTime(dtpFechIni.Text).ToString("yyyy-MM-dd"), 
                Convert.ToDateTime(dtpFechFin.Text).ToString("yyyy-MM-dd"));

            if (Convert.ToInt16(rsDat[0]) == 0)
            {
                MessageBox.Show(rsDat[1].ToString(), "¡ Verifique !");
            }
            else if (Convert.ToInt16(rsDat[0]) == 1)
            {
                lblVent.Text = Convert.ToDouble(rsDat[2]).ToString("N2");
                lblPrem.Text= Convert.ToDouble(rsDat[3]).ToString("N2");
                lblAn.Text = Convert.ToDouble(rsDat[4]).ToString("N2");
                lblUt.Text = Convert.ToDouble(rsDat[5]).ToString("N2");
            }

        }

        private void frmVentLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int cod = 0;
            caracter = Convert.ToChar(e.KeyChar);
            cod = (int)caracter;
            if (cod == 27) { this.Close(); }
        }
    }
}
