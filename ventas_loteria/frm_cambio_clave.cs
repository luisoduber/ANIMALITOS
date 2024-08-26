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
    public partial class frm_cambio_clave : Form
    {
        public frm_cambio_clave()
        {
            InitializeComponent();
        }

        clsMet objCc = new clsMet();
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_cambio_clave_Load(object sender, EventArgs e)
        {
            this.Text = "Cambiar Clave.";
            txtClavAct.Focus();
        }
        public Boolean validFrm()
        {
            Boolean validar = true;

            if (string.IsNullOrEmpty(txtClavAct.Text))
            {
                MessageBox.Show("Ingrese su clave.", "Verifique.");
                txtClavAct.Focus();
                validar = false;
            }

            else if (txtClavAct.Text.Length < 8)
            {
                MessageBox.Show("Clave actual no debe ser menor de 8 digitos.", "Verifique.");
                txtClavAct.Focus();
                validar = false;
            }

            else if (string.IsNullOrEmpty(txtClavNew.Text))
            {
                MessageBox.Show("Ingrese clave nueva.", "Verifique.");
                txtClavNew.Focus();
                validar = false;
            }

            else if (txtClavNew.Text.Length < 8)
            {
                MessageBox.Show("Clave nueva no debe ser menor de 8 digitos.", "Verifique.");
                txtClavNew.Focus();
                validar = false;
            }

            else if (string.IsNullOrEmpty(txtRepClav.Text))
            {
                MessageBox.Show("Repetir clave nueva.", "Verifique.");
                txtRepClav.Focus();
                validar = false;
            }

            else if (txtRepClav.Text.Length < 8)
            {
                MessageBox.Show("Repetir clave nueva no debe ser menor de 8 digitos.", "Verifique.");
                txtRepClav.Focus();
                validar = false;
            }

            else if (txtClavAct.Text == txtClavNew.Text)
            {
                MessageBox.Show("Clave nueva / actual deben ser diferentes.", "Verifique.");
                txtClavNew.Focus();
                validar = false;
            }

            else if (txtClavNew.Text != txtRepClav.Text)
            {
                MessageBox.Show("Clave nueva / repetir clave no coinciden.", "Verifique.");
                txtRepClav.Focus();
                validar = false;
            }
            return validar;
        }

        public void limpFrm()
        {
            txtClavAct.Text = "";
            txtClavNew.Text = "";
            txtRepClav.Text = "";
            txtClavAct.Focus();
        }

        private void frm_cambio_clave_Activated(object sender, EventArgs e)
        {
            txtClavAct.Focus();
        }
        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }
        private void frm_cambio_clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;
            if (codigo == 27) { this.Close();}
        }
        private void txtRepClav_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;

            if (codigo == 13) 
            {
                Boolean rsValid= validFrm();
                if (rsValid == true)
                {
                    string rsVerfClave;
                    rsVerfClave = objCc.busClavUsu(
                        Convert.ToInt32(clsMet.idUsu));

                    string claveActBd = rsVerfClave;
                    if (txtClavAct.Text != claveActBd)
                    {
                        MessageBox.Show("Clave actual errada.", "Verifique.");
                        txtClavAct.Focus();
                        return;
                    }
                    else if (txtClavAct.Text == claveActBd)
                    {
                        string rsCambClav;
                        rsCambClav = objCc.cambClavUsuario(
                            Convert.ToInt32(clsMet.idUsu),
                            txtClavNew.Text);

                        if (rsCambClav == "1")
                        {
                            MessageBox.Show("Su clave fue cambiada Exitosamente.", "Transacción Exitosa.");
                            limpFrm();
                        }
                        else
                        {
                           MessageBox.Show("Ha ocurrido el siguiente error:" + rsCambClav, "Verifique.");
                        }
                    }

                }
            }
        }

        private void txtClavAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;

            if (codigo == 13) { txtClavNew.Focus(); }
        }

        private void txtClavNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;
            
            if (codigo == 13) { txtRepClav.Focus(); }
        }
    }
}
