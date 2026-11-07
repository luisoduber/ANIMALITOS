using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ventas_loteria
{
    public partial class frm_verf_ticket : Form
    {
        public frm_verf_ticket()
        {
            InitializeComponent();
        }

        clsMet objTck = new clsMet();
        public string prmNroTck, prmNroSerial;
        private void frm_verf_ticket_Load(object sender, EventArgs e)
        {
            rtbMostTck.Font = new Font("Consolas", 10, FontStyle.Regular);
            this.Text = "Verifica Ticket.";
            string rsMostTckInf = "";
            string rsMostTckDet = "";
            string[] rsDatMostTckDet = null;

            string nombTaq="", nombStatTck="", nombDiv="";
            string fechReg="", horaReg="";
            int idTipTck = 0;
            double mTck = 0, mPag = 0;

            rsMostTckInf = objTck.SPMostInfTck(prmNroTck,prmNroSerial);
            rsDatMostTckDet = rsMostTckInf.Split('?');

            idTipTck = Convert.ToInt32(rsDatMostTckDet[0].ToString());
            nombTaq = rsDatMostTckDet[1].ToString();
            nombDiv = rsDatMostTckDet[2].ToString();
            nombStatTck = rsDatMostTckDet[3].ToString();
            mTck = Convert.ToDouble(rsDatMostTckDet[4].ToString());
            mPag = Convert.ToDouble(rsDatMostTckDet[5].ToString());
            fechReg = Convert.ToDateTime(rsDatMostTckDet[6]).ToString("dd/MM/yyyy");
            horaReg = Convert.ToDateTime(rsDatMostTckDet[7]).ToString("hh:mm tt", CultureInfo.InvariantCulture).ToUpper();

            if (idTipTck == 1)
            {
                rsMostTckDet = objTck.busMostDetTck(Convert.ToInt64(prmNroTck),
                                            Convert.ToInt64(prmNroSerial));

                rsDatMostTckDet = rsMostTckDet.Split('?');
                rtbMostTck.Text = " Taquilla:" + nombTaq;
                rtbMostTck.Text += "\n Divisa:" + nombDiv;
                rtbMostTck.Text += "\n Ticket:" + prmNroTck;
                rtbMostTck.Text += "\n Fecha:" + fechReg;
                rtbMostTck.Text += "\n Hora:" + horaReg;
                rtbMostTck.Text += "\n Status:" + nombStatTck.ToUpper();
                rtbMostTck.Text += "\n " + rsMostTckDet;
                rtbMostTck.Text += "\n Monto total ticket:";
                rtbMostTck.Text +=  mTck.ToString("N2") + " " + nombDiv;
                rtbMostTck.Text += "\n Verifique su ticket.";

                rtbMostTck.Text += "\n Ticket caduca:";
                rtbMostTck.Text += clsMet.cantDiaCadTck + " Dias.";
                rtbMostTck.Text += "\n Nota:" + clsMet.ntMsjTck;
            }
            else if (idTipTck == 2)
            {
                rsMostTckDet = objTck.busMostDetTckTrip(Convert.ToInt64(prmNroTck),
                                            Convert.ToInt64(prmNroSerial));

                rtbMostTck.Text = " Taquilla:" + nombTaq;
                rtbMostTck.Text += "\n Divisa:" + nombDiv;
                rtbMostTck.Text += "\n Ticket:" + prmNroTck;
                rtbMostTck.Text += "\n Fecha:" + fechReg;
                rtbMostTck.Text += "\n Hora:" + horaReg;
                rtbMostTck.Text += "\n Status:" + nombStatTck.ToUpper();
                rtbMostTck.Text += "\n " + rsMostTckDet;
                rtbMostTck.Text += "\n Monto total ticket:";
                rtbMostTck.Text += mTck.ToString("N2") + " " + nombDiv;
                rtbMostTck.Text += "\n Valido por ";
                rtbMostTck.Text += clsMet.cantSortTrip;
                rtbMostTck.Text += " sorteos descritos.";
            }
        }
        private void frm_verf_ticket_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;

            if (codigo == 27) { this.Close(); }
        }
    }
}
