using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ventas_loteria
{
    public partial class frmTckTrip : Form
    {
        public frmTckTrip()
        {
            InitializeComponent();
        }

        public string nombTaq;
        public string fecha, hora;
        public string nroTicket, nroSerial;
        public int nroDiaCad;
        public string detJug;
        public double totVenta;
        int idProc = 0;

        private void frmTckTrip_Load(object sender, EventArgs e)
        {
            this.Text = "Imprimiendo.";
            this.wkIniFrm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkIniFrm_DoWork);
            this.wkIniFrm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.wkIniFrm_OnProgressChanged);
            this.wkIniFrm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wkIniFrm_OnRunWorkerCompleted);
            this.wkIniFrm.RunWorkerAsync();
        }
        private void wkIniFrm_DoWork(object sender, DoWorkEventArgs e)
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
                wkIniFrm.CancelAsync();
            }
            catch (Exception ex)
            {
                idProc = 0;
                MessageBox.Show("Ha ocurrido el siguiente error: " + ex.Message, "Verifique");
            }
        }
        private void wkIniFrm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void wkIniFrm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (idProc == 1) { this.Close(); }
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

            int ini_x = 0;
            int ini_y = 0;
            int offset = 0;

            string head1, head2;
            string head3, head4;
            string separador;
            string foot1, foot2;

            string[] rsDetJug= detJug.Split('?');
            //MessageBox.Show(rs_det_jug.Length.ToString());

            head1 = "Taquilla:" + nombTaq.ToUpper();
            head2 = "Divisa:" + clsMet.NombDivisa.ToUpper();
            head3 = "Fecha:" + fecha + "  Hora:" + hora;
            head4 = "Ticket:" + nroTicket + "  Serial:" + nroSerial;
            separador = "=================================";
            foot1 = "Total venta:" + totVenta.ToString("N2");
            foot1 += " " + clsMet.NombDivisa.ToUpper();
            foot2 = "Valido por:" + clsMet.cantSortTrip;
            foot2 += " sorteos descritos.";

            grafico.DrawString(head1, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            grafico.DrawString(head2, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            grafico.DrawString(head3, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            grafico.DrawString(head4, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;
            grafico.DrawString(separador, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);
            offset = offset + interlineado;

            int d = 0;
            for (int c = 0; c < rsDetJug.Length; c++)
            {
                
                if (!string.IsNullOrEmpty(rsDetJug[c].ToString()))
                {
                    d++;
                    offset = offset + interlineado;
                    grafico.DrawString(rsDetJug[c].ToString(), fuente, new SolidBrush(Color.Black),
                                                                             ini_x, ini_y + offset);

                    if (d == 5) { offset = offset + interlineado; d = 0; }
                }
            }
            offset = offset + interlineado;
            offset = offset + interlineado;
            grafico.DrawString(separador, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);

            offset = offset + interlineado;
            grafico.DrawString(foot1, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);

            offset = offset + interlineado;
            grafico.DrawString(foot2, fuente, new SolidBrush(Color.Black), ini_x, ini_y + offset);

            e.HasMorePages = false;
        }
    }
}
