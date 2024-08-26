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
            this.Text = "Verifica Ticket.";
            string rsMostTckInf = "";
            string rsMostTckDet = "";
            string[] rsDatMostTckDet = null;

            string nombTaq="", nombStatTck="";
            string fechReg="", horaReg="";
            long mTck = 0, mPag = 0;

            rsMostTckInf = objTck.SPMostInfTck(prmNroTck,prmNroSerial);
            rsDatMostTckDet = rsMostTckInf.Split('?');

            nombTaq = rsDatMostTckDet[0].ToString();
            nombStatTck = rsDatMostTckDet[1].ToString();
            mTck = Convert.ToInt64(rsDatMostTckDet[2].ToString());
            mPag = Convert.ToInt64(rsDatMostTckDet[3].ToString());
            fechReg = Convert.ToDateTime(rsDatMostTckDet[4]).ToString("dd/MM/yyyy");
            horaReg = Convert.ToDateTime(rsDatMostTckDet[5]).ToString("hh:mm tt").ToUpper();

            rsMostTckDet = objTck.busMostDetTck(Convert.ToInt64(prmNroTck),
                                             Convert.ToInt64(prmNroSerial));

            rsDatMostTckDet = rsMostTckDet.Split('?');
            rtbMostTck.Text = "\n Taquilla: " + nombTaq;
            rtbMostTck.Text += "\n Ticket: " + prmNroTck;
            rtbMostTck.Text += "\n Fecha: " + fechReg;
            rtbMostTck.Text += "\n Hora: " + horaReg;
            rtbMostTck.Text += "\n Status: " + nombStatTck.ToLower();
            rtbMostTck.Text += "\n " + rsMostTckDet;
            rtbMostTck.Text += "-------------------------------------";
            rtbMostTck.Text += "\n Monto total ticket: " + mTck.ToString("N2");
            rtbMostTck.Text += "\n Verifique su ticket.";
            rtbMostTck.Text += "\n Ticket caduca: ";
            rtbMostTck.Text += clsMet.cant_dia_cad_ticket +" Dias.";
            rtbMostTck.Text += "\n Nota: " + clsMet.nota_msj_ticket;
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
