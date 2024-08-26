using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ventas_loteria
{
  
    public partial class frm_config_impresora : Form
    {
        public frm_config_impresora()
        {
            InitializeComponent();
        }

        class impresora
        {
            public string idImp { get; set; }
            public string nombImp { get; set; }
        }
        List<impresora> listImp = new List<impresora>();
        int id_proceso = 0;
        clsMet objConfImp= new clsMet();
        DataTable dtCboAnchTck = new DataTable();
        DataTable dtCboNumLetra = new DataTable();

        string rsConfImp = "";
        String[] rsDat = null;

        string nombImp = "";
        string anchTck = "";
        string numLetra = "";
        private void frm_config_impresora_Load(object sender, EventArgs e)
        {
            this.Text = "Configurar Impresora.";
            this.work_inicia_frm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.work_inicia_frm_DoWork);
            this.work_inicia_frm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.work_inicia_frm_OnProgressChanged);
            this.work_inicia_frm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.work_inicia_frm_OnRunWorkerCompleted);
            this.work_inicia_frm.RunWorkerAsync();
        }

        private void work_inicia_frm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //////////////////////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////////////////////////

                foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    listImp.Add(new impresora() { idImp = strPrinter, nombImp = strPrinter });
                }

                //////////////////////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////////////////////////

                rsConfImp = objConfImp.busConfImp(Convert.ToInt32(clsMet.idUsu));

                if (!string.IsNullOrEmpty(rsConfImp))
                {
                    rsDat = rsConfImp.Split('?');
                    nombImp = rsDat[0].ToString();
                    anchTck = rsDat[1].ToString();
                    numLetra = rsDat[2].ToString();
                }
                else { nombImp = ""; anchTck = ""; numLetra = ""; }

                //////////////////////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////////////////////////

                dtCboAnchTck = objConfImp.busAnchTck();
                dtCboNumLetra = objConfImp.busNumLetra();

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
                cboImp.DataSource = listImp;
                cboImp.DisplayMember = "nombImp";
                cboImp.ValueMember = "idImp";

                cboAnchTck.DataSource = dtCboAnchTck;
                cboAnchTck.DisplayMember = "nomb_ancho_ticket";
                cboAnchTck.ValueMember = "nomb_ancho_ticket";

                cboNumLetra.DataSource = dtCboNumLetra;
                cboNumLetra.DisplayMember = "num_letra";
                cboNumLetra.ValueMember = "num_letra";

                if (string.IsNullOrEmpty(nombImp)){ cboImp.SelectedIndex = 0; }
                else { cboImp.SelectedValue = nombImp; }

                if (string.IsNullOrEmpty(anchTck)){ cboAnchTck.SelectedIndex=0; }
                else { cboAnchTck.SelectedValue = anchTck.ToString(); }

                if (string.IsNullOrEmpty(numLetra)) { cboNumLetra.SelectedIndex = 0; }
                else { cboNumLetra.SelectedValue = numLetra.ToString(); }

            }

            else if (id_proceso == 0)
            {
                MessageBox.Show("Ha ocurrido un error...", "Verifique.");
            }

        }
        private void btn_ingresar_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_probar_imp_Click(object sender, EventArgs e)
        {
            nombImp = cboImp.Text;
            anchTck = cboAnchTck.Text;
            numLetra = cboNumLetra.Text;

            string rsConfImp = "";
            rsConfImp = objConfImp.actGrdConfImp(Convert.ToInt32(clsMet.idUsu),
                                                               nombImp, anchTck, numLetra);

            if ((rsConfImp == "1") || (rsConfImp == "2"))
            {
                clsMet.nomb_imp = nombImp;
                clsMet.ancho_ticket = anchTck;
                clsMet.num_letra = numLetra;

                frm_rpt_imp_prueba objRptImpPrueba = new frm_rpt_imp_prueba();
                objRptImpPrueba.Show();
            }
            else
            {
                MessageBox.Show("Ha ocurrido el siguinete error: " + rsConfImp, "Transacción Fallida.");
            } 
        }
        private void frm_config_impresora_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;

            if (codigo == 27) { this.Close(); }
        }
    }
}
