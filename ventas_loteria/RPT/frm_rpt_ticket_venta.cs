using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Diagnostics;
//using CrystalDecisions.CrystalReports.Engine;

namespace ventas_loteria
{
    public partial class frm_rpt_ticket_venta : Form
    {
        public frm_rpt_ticket_venta()
        {
            InitializeComponent();
        }

        public string nombTaq;
        public string fecha, hora;
        public string nroTicket, nroSerial;
        public int nroDiaCad, idTipTck;
        public string detJug;
        public double totVent;
        int idProc = 0;

        private void frm_rpt_ticket_venta_Load(object sender, EventArgs e)
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
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = clsMet.nomb_imp;
                pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("custom", 12897, 228);
                pd.PrintController = new StandardPrintController();

                Margins margins = new Margins(0, 0, 0, 0);
                pd.DefaultPageSettings.PaperSize.Height = 0;
                pd.DefaultPageSettings.Margins = margins;

                //MessageBox.Show(pd.PrinterSettings.PaperSizes[2].ToString());
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                pd.Print();

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
                this.Close();      
            }
            else if (idProc == 0)
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
            else if (Convert.ToInt32(clsMet.num_letra) == 8) { interlineado = 13; }

            int interlTrip = 20;

            int ini_x = 0;
            int ini_y = 0;
            int offset = 0;

            string header1 , header2;
            string header3 , header4;
            string separador;
            string footer1, footer2;
            string[] rsDetJug = null;
            if (idTipTck==1) { rsDetJug  = detJug.Split('/'); }
            else if (idTipTck == 2) {  rsDetJug  = detJug.Split('?'); }

            header1 = "Taquilla:" + nombTaq.ToUpper();
            header2 = "Divisa:" + clsMet.NombDivisa.ToUpper();
            header3 = "Fecha:" + fecha + "  Hora:" + hora;
            header4 = "Ticket:" + nroTicket + "  Serial:" + nroSerial;
            separador = "================================";
            footer1 = "Total venta:"  +totVent.ToString("N2");
            footer2 = "REVISE TICKET. CADUCA:"+ nroDiaCad + " DIAS.";

            grafico.DrawString(header1, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            grafico.DrawString(header2, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            grafico.DrawString(header3, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            grafico.DrawString(header4, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;
            grafico.DrawString(separador, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);

            int contTrip = 0;
            for (int c = 0; c < rsDetJug.Length; c++)
            {
                if (idTipTck == 1) 
                { 
               
                    if (!string.IsNullOrEmpty(rsDetJug [c].ToString()))
                    {
                        offset = offset + interlineado;
                        grafico.DrawString(rsDetJug [c].ToString(), fuente, new SolidBrush(Color.Black), 
                                                                                 ini_x, ini_y + offset);
                    }
                }

                else if (idTipTck == 2) 
                {
                    if (!string.IsNullOrEmpty(rsDetJug[c].ToString()))
                    {
                        offset = offset + interlineado;
                        grafico.DrawString(rsDetJug[c].ToString(), fuente, new SolidBrush(Color.Black),
                                                                                 ini_x, ini_y + offset);

                        contTrip++;
                        if ((contTrip == 5) && (c != rsDetJug.Length - 2)) 
                        { contTrip = 0; offset = offset + interlineado; }
                    }
                }
            }

            offset = offset + interlineado;
            grafico.DrawString(separador, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);

            offset = offset + interlineado;
            grafico.DrawString(footer1, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);

            offset = offset + interlineado;
            grafico.DrawString(footer2, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);

            e.HasMorePages = false;
        }

    }
}
