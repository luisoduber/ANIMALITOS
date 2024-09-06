using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
//using CrystalDecisions.CrystalReports.Engine;

namespace ventas_loteria
{
    public partial class frm_rpt_cuadre_diario : Form
    {
        public frm_rpt_cuadre_diario()
        {
            InitializeComponent();
        }

        public string nombTaq;
        public string fecha, hora;
        public string status;
        public string cantTicket;
        public string fechaIni, fechaFin;
        public double totalEnt, totalSal;
        public double totalCaja;
        int id_proceso = 0;

        private void frm_rpt_cuadre_diario_Load(object sender, EventArgs e)
        {
            this.Text = "Imprimiendo.";
            this.work_inicia_frm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.work_inicia_frm_DoWork);
            this.work_inicia_frm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.work_inicia_frm_OnProgressChanged);
            this.work_inicia_frm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.work_inicia_frm_OnRunWorkerCompleted);
            this.work_inicia_frm.RunWorkerAsync();
        }

        private void work_inicia_frm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                fechaIni = fechaIni.Replace("-", "/");
                fechaFin = fechaFin.Replace("-", "/");

                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = clsMet.nomb_imp;
                pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("custom", 12897, 228);
                pd.PrintController = new StandardPrintController();

                Margins margins = new Margins(0, 0, 0, 0);
                pd.DefaultPageSettings.PaperSize.Height = 0;
                pd.DefaultPageSettings.Margins = margins;

                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                pd.Print();

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
                this.Close();      
            }

            else if (id_proceso == 0)
            {
                MessageBox.Show("Error imprimiendo...", "Verifique.");
                this.Close();
            }
        }
        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics grafico = e.Graphics;
            Font fuente = new Font("arial", Convert.ToInt32(clsMet.num_letra));
            int interlineado = Font.Height;

            if (Convert.ToInt32(clsMet.num_letra) == 6) { interlineado = 8; }
            else if (Convert.ToInt32(clsMet.num_letra) == 7) { interlineado = 9; }
            else if (Convert.ToInt32(clsMet.num_letra) == 8) { interlineado = 10; }

            int ini_x = 0;
            int ini_y = 0;
            int offset = 0;

            string header1, header2;
            string header3, header4;
            string header5, separador;

            string section1, section2;
            string section3;

            header1 = "Taquilla:" + nombTaq.ToUpper();
            header2 = "Divisa:" + clsMet.NombDivisa.ToUpper();
            header3 = "Fecha:" + fecha + "  Hora:" + hora;
            header4 = "Fecha ini:" + fechaIni;
            header5 = "Fecha fin:" + fechaFin;
            separador = "==============================";
            section1 = "Status:" + status + "  Ticket:" + cantTicket;
            section2 = "Ventas:" + totalEnt.ToString("N2") + "  Premios:" + totalSal.ToString("N2");
            section3 = "Caja:" + totalCaja.ToString("N2");
            
            grafico.DrawString(header1, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            grafico.DrawString(header2, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            grafico.DrawString(header3, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            grafico.DrawString(header4, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            grafico.DrawString(header5, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            grafico.DrawString(separador, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            grafico.DrawString(section1, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            grafico.DrawString(section2, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            grafico.DrawString(section3, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            grafico.DrawString(separador, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            e.HasMorePages = false;
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel1_Click_1(object sender, EventArgs e)
        {

        }




    }
}
