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
    public partial class frm_anular_ticket : Form
    {
        public frm_anular_ticket()
        {
            InitializeComponent();
        }

        clsMet objAnulTck = new clsMet();
        int idStat = 0;
        private void btn_bus_ticket_Click(object sender, EventArgs e)
        {
            Boolean rsValidFrm = true;
            rsValidFrm = validFrm();
            if (rsValidFrm == true) { detAnTck(); }
        }
        public void detAnTck()
        {
            string rsMostInfTck = "";
            string rsMostDetTck = "";
            string[] rsDatMostDetTck= null;

            string nombTaq = "", nombStatTck = "";
            string fechaReg = "", horaReg = "";
            long mTck = 0, mPag = 0;
            
            rsMostInfTck = objAnulTck.SPMostInfTck(txt_nro_ticket.Text);

            if (string.IsNullOrEmpty(rsMostInfTck))
            {
                MessageBox.Show("Nro. Ticket: " + txt_nro_ticket.Text + " No existe.", "Verifique.");
                txt_nro_ticket.Focus();
            }
            else if (!string.IsNullOrEmpty(rsMostInfTck))
            {
                rsDatMostDetTck = rsMostInfTck.Split('?');
                nombTaq = rsDatMostDetTck[0].ToString();
                nombStatTck = rsDatMostDetTck[1].ToString();
                mTck = Convert.ToInt64(rsDatMostDetTck[2].ToString());
                mPag = Convert.ToInt64(rsDatMostDetTck[3].ToString());
                fechaReg = Convert.ToDateTime(rsDatMostDetTck[4]).ToString("dd/MM/yyyy");
                horaReg = Convert.ToDateTime(rsDatMostDetTck[5]).ToString("hh:mm tt");
                idStat = Convert.ToInt32(rsDatMostDetTck[6].ToString());

                rsMostDetTck = objAnulTck.SPMostDetTckAn
                (Convert.ToInt64(txt_nro_ticket.Text));

                rsDatMostDetTck = rsMostDetTck.Split('?');
                rtbMostTck.Text = "\n Taquilla: " + nombTaq;
                rtbMostTck.Text += "\n Ticket: " + txt_nro_ticket.Text;
                rtbMostTck.Text += "\n Fecha: " + fechaReg;
                rtbMostTck.Text += "\n Hora: ";
                rtbMostTck.Text += horaReg.ToUpper();
                rtbMostTck.Text += "\n Status: " + nombStatTck.ToLower();
                rtbMostTck.Text += "\n " + rsMostDetTck;
                rtbMostTck.Text += "-------------------------------------";
                rtbMostTck.Text += "\n Monto total ticket: " + mTck.ToString("N2");
                rtbMostTck.Text += "\n Verifique su ticket.";
                rtbMostTck.Text += "\n Ticket caduca: ";
                rtbMostTck.Text += clsMet.cant_dia_cad_ticket + " Dias.";
                rtbMostTck.Text += "\n Nota: " + clsMet.nota_msj_ticket;

                if (idStat == 1) { btn_anular_ticket.Enabled = true; }
                else { btn_anular_ticket.Enabled = false; }
            }
        }
        private void txt_nro_ticket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)){ e.Handled = false; }
            else
                if (Char.IsControl(e.KeyChar)) { e.Handled = false;}
                else { e.Handled = true; }

        }
        private void btn_anular_ticket_Click(object sender, EventArgs e)
        {
            try
            {
                if (idStat != 1)
                {
                    MessageBox.Show("El Ticket no se podra anular...", "Verifique.");
                    return;
                }
                string rsAnulTck= "";
                rsAnulTck = objAnulTck.anTck(txt_nro_ticket.Text);

                if (Convert.ToInt32(rsAnulTck) > 0)
                {
                    MessageBox.Show("Ticket anulado correctamente...", "Transsacción Exitosa.");
                    detAnTck();
                    limpFrm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha Ocurrido el siguiente error: "+ ex.Message,"Verifique.");
            }
        }
        public Boolean validFrm()
        {
            Boolean validar = true;
            if (string.IsNullOrEmpty(txt_nro_ticket.Text))
            {
                MessageBox.Show("Ingrese Nro. Ticket...", "Verifique.");
                txt_nro_ticket.Focus();
                validar = false;
            }
            else if (Convert.ToInt32(txt_nro_ticket.Text) == 0)
            {
                MessageBox.Show("Nro. Ticket Debe ser diferente de cero...", "Verifique.");
                txt_nro_ticket.Focus();
                txt_nro_ticket.SelectionStart = 0;
                txt_nro_ticket.SelectionLength = txt_nro_ticket.Text.Length;
                validar = false;
            }
            return validar;
        }
        public void limpFrm()
        {
            idStat = 0;
            txt_nro_ticket.Text = "";
            txt_nro_ticket.Focus();
            btn_anular_ticket.Enabled = false; 
        }
        private void frm_anular_ticket_Load(object sender, EventArgs e)
        {
            this.Text = "Anular Ticket Taquilla.";
            btn_anular_ticket.Enabled = false;
        }

        private void frm_anular_ticket_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;

            if (codigo == 27) { this.Close(); }
        }
    }
}
