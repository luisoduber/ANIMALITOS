using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using ventas_loteria.Properties;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Deployment.Application;

namespace ventas_loteria
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();

        }

        clsMet objLog = new clsMet();
        frmMenOpe objFrmMenOpe= new frmMenOpe();
        frm_ventas objFrmventas = new frm_ventas();

        string rsLog;
        String[] rsDatLog;
        int idStat=0;
        string clave;
        string nombCnRed;
        string statusCnRed;
        string[] rsVerfMac = new string[3];
        string[] rsPrmGral = new string[2];
        int idStatMac, idUsuMac;

        private void frm_login_Load(object sender, EventArgs e)
        {
            //clsMet.cadena_conexion = Settings.Default.cadCnBd;
            // clsMet.cadena_conexion = clsMet.descifrar(Settings.Default.cadCnBd, clsMet.clave_ed);
            //MessageBox.Show(clsMet.descifrar(clsMet.cadena_conexion, clsMet.clave_ed));

            //clsMet.cadena_conexion = "Server=localhost;port=3306;Database=loterias; Uid=grupodab_prog;Pwd='root';";
            clsMet.cadena_conexion = "Server=68.178.200.104;port=8689;Database=loterias; Uid=grupodab_prog;Pwd='NeM{.B2kP.@FkgZt{4x$[#s,GY&j4+F%';";

            this.Text = "Autenticación Usuario...";
            btn_recordar_clave.FlatAppearance.BorderSize = 0;
            txtUsuario.Focus();

            rsPrmGral = objLog.busPrmGral();
            clsMet.cant_dia_cad_ticket = Convert.ToInt32(rsPrmGral[0].ToString());
            clsMet.nota_msj_ticket = rsPrmGral[1].ToString();

            /*  System.Deployment.Application.ApplicationDeployment
              ad = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;

               clsMet.version_pro = "Versión:" + ad.CurrentVersion.ToString();*/
        }

        public Boolean validFrmLog()
        {
            Boolean valid = true;
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Ingrese Nombre del Usuario.", "verifique.");
                txtUsuario.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtClave.Text))
            {
                MessageBox.Show("Ingrese Clave del Usuario.", "verifique.");
                txtClave.Focus();
                valid = false;
            }

            else if (txtClave.Text.Length < 8)
            {
                MessageBox.Show("Clave debe contener minimo 8 digitos.", "verifique.");
                txtClave.Focus();
                valid = false;
            }

            return valid;
        }
        public string[] obtMacEquipo(int prmIdUsuario)
        {
            NetworkInterface[] interfaces = null;
            interfaces = NetworkInterface.GetAllNetworkInterfaces();
            string mac_address = string.Empty;
            string[] rsDat = new string[3];
            int i = 0, idStatusMac = 0;

            try
            {
                if (interfaces != null && interfaces.Length > 0)
                {
                    foreach (NetworkInterface adaptador in interfaces) // Recorrer todas las interfaces de red
                    {
                        mac_address = "";
                        PhysicalAddress direccion = adaptador.GetPhysicalAddress();   // Obtener la dirección fisica
                        byte[] bytes = direccion.GetAddressBytes(); // Obtener en modo de arreglo de bytes la dirección

                        for (i = 0; i < bytes.Length; i++) // Recorrer todos los bytes de la direccion
                        {
                            // Pasar el byte a un formato legible para el usuario
                            mac_address += bytes[i].ToString("X2");
                            /* if (i != bytes.Length - 1)
                             {
                                 // Agregar un separador, por formato
                                 mac_address += "-";
                             }*/
                        }

                        nombCnRed = adaptador.Name.ToString().ToLower().Trim();
                        statusCnRed = adaptador.OperationalStatus.ToString().ToLower().Trim();

                        if ((!string.IsNullOrEmpty(mac_address)) && (statusCnRed == "up"))
                        {
                            rsDat = objLog.verfMacTaq(mac_address, prmIdUsuario);
                            idStatusMac = Convert.ToInt32(rsDat[1].ToString());
                            if (idStatusMac == 1) { break; }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido el siguiente error: " + ex.Message, "Verifique");
            }
            return rsDat;
        }

        private void frm_login_Activated(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            Boolean rsValidFrm = validFrmLog();
            if (rsValidFrm == false) { return; }
            rsLog = objLog.verfLogUsu(txtUsuario.Text);
            if (clsMet.id_conexion == 0)
            {
                MessageBox.Show("Error No se a Establecido Conexión Al Servidor.", "verifique.");
                return;
            }
            else if (string.IsNullOrEmpty(rsLog))
            {
                MessageBox.Show("Usuario no existe. Verifique.", "Autenticación Fallida.");
                txtUsuario.Focus();
                return;
            }

            rsDatLog = rsLog.Split('?');
            clsMet.menbrete_info = "Operador: " + rsDatLog[0];
            clsMet.menbrete_info += " - ( " + txtUsuario.Text + " )";

            clsMet.nombUsu = rsDatLog[0];
            clave = rsDatLog[1];
            idStat = Convert.ToInt32(rsDatLog[2]);
            clsMet.idPerf = rsDatLog[3];
            clsMet.idUsu = rsDatLog[4];
            clsMet.nomb_perfil = rsDatLog[5];
            clsMet.idGrup = rsDatLog[6];
            clsMet.monto_max_jug = Convert.ToInt32(rsDatLog[7]);
            clsMet.montMaxTck = Convert.ToInt32(rsDatLog[8]);
            clsMet.monto_Xunidad = Convert.ToInt32(rsDatLog[9]);
            clsMet.monto_multiplo_jug = Convert.ToInt32(rsDatLog[10].ToString());
            clsMet.monto_min_jug = Convert.ToInt32(rsDatLog[11].ToString());
            clsMet.nomb_imp = rsDatLog[12].ToString();
            clsMet.ancho_ticket = rsDatLog[13].ToString();
            clsMet.num_letra = rsDatLog[14].ToString();
            clsMet.NombDivisa = rsDatLog[15].ToString();

            if (clave != txtClave.Text)
            {
                MessageBox.Show("Clave invalida. Verifique.", "Autenticación Fallida.");
                txtClave.Focus();
                return;
            }
            else if (clave == txtClave.Text)
            {
                if (idStat == 1)
                {
                    if (Convert.ToInt32(clsMet.idPerf) == 1)
                    {
                        rsVerfMac = obtMacEquipo(Convert.ToInt32(clsMet.idUsu));
                        idStatMac = Convert.ToInt32(rsVerfMac[1].ToString());
                        idUsuMac = Convert.ToInt32(rsVerfMac[2].ToString());

                        if ((idStatMac == 0) || (idStatMac == 2))
                        {
                            this.Text = ("No autorizado. Accesso no permitido...").ToUpper();
                            txtUsuario.Enabled = false;
                            txtClave.Enabled = false;
                            BtnIngresar.Enabled = false;
                            btn_recordar_clave.Enabled = false;
                        }
                        else if (idStatMac == 1)
                        {
                            // Activo
                            recuerdame();
                            this.Hide();
                            objFrmventas.Show();
                        }
                    }
                    else
                    {
                        //Activo
                        this.Hide();
                        objFrmMenOpe.Show();
                    }
                }
                else if (idStat == 2)
                {
                    //INACTIVO
                    MessageBox.Show("Usuario Inactivo. Contacte Con El Administrador del Sistema.", "Verifique.");
                    return;
                }
            }
        }
        private void txtNombUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;

            if (codigo == 13)
            {
                e.Handled = true;
                if (txtUsuario.Text.Length > 0) { txtClave.Focus(); }
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;

            if (codigo == 13)
            {
                e.Handled = true;
                Boolean rsValidFrm = validFrmLog();
                if (rsValidFrm == false) { return; }

                rsLog = objLog.verfLogUsu(txtUsuario.Text);
                if (clsMet.id_conexion == 0)
                {
                    MessageBox.Show("Error No se a Establecido Conexión Al Servidor.", "verifique.");
                    return;
                }
                else if (string.IsNullOrEmpty(rsLog))
                {
                    MessageBox.Show("Usuario no existe. Verifique.", "Autenticación Fallida.");
                    txtUsuario.Focus();
                    return;
                }

                rsDatLog = rsLog.Split('?');
                clsMet.menbrete_info = "Operador: " + rsDatLog[0];
                clsMet.menbrete_info += " - ( " + txtUsuario.Text + " )";

                clsMet.nombUsu = rsDatLog[0];
                clave = rsDatLog[1];
                idStat = Convert.ToInt32(rsDatLog[2]);
                clsMet.idPerf = rsDatLog[3];
                clsMet.idUsu = rsDatLog[4];
                clsMet.nomb_perfil = rsDatLog[5];
                clsMet.idGrup = rsDatLog[6];
                clsMet.monto_max_jug = Convert.ToInt32(rsDatLog[7]);
                clsMet.montMaxTck = Convert.ToInt32(rsDatLog[8]);
                clsMet.monto_Xunidad = Convert.ToInt32(rsDatLog[9]);
                clsMet.monto_multiplo_jug = Convert.ToInt32(rsDatLog[10].ToString());
                clsMet.monto_min_jug = Convert.ToInt32(rsDatLog[11].ToString());
                clsMet.nomb_imp = rsDatLog[12].ToString();
                clsMet.ancho_ticket = rsDatLog[13].ToString();
                clsMet.num_letra = rsDatLog[14].ToString();
                clsMet.NombDivisa = rsDatLog[15].ToString();

                if (clave != txtClave.Text)
                {
                    MessageBox.Show("Clave invalida. Verifique.", "Autenticación Fallida.");
                    txtClave.Focus();
                    return;
                }
                else if (clave == txtClave.Text)
                {
                    if (idStat == 1)
                    {
                        if (Convert.ToInt32(clsMet.idPerf) == 1)
                        {
                            rsVerfMac = obtMacEquipo(Convert.ToInt32(clsMet.idUsu));
                            idStatMac = Convert.ToInt32(rsVerfMac[1].ToString());
                            idUsuMac = Convert.ToInt32(rsVerfMac[2].ToString());

                            if ((idStatMac == 0) || (idStatMac == 2))
                            {
                                this.Text = ("No autorizado. Accesso no permitido...").ToUpper();
                                txtUsuario.Enabled = false;
                                txtClave.Enabled = false;
                                BtnIngresar.Enabled = false;
                                btn_recordar_clave.Enabled = false;
                            }
                            else if (idStatMac == 1)
                            {
                                // Activo
                                recuerdame();
                                this.Hide();
                                objFrmventas.Show();
                            }
                        }
                        else
                        {
                            //Activo
                            this.Hide();
                            objFrmMenOpe.Show();
                        }
                    }
                    else if (idStat == 2)
                    {
                        //INACTIVO
                        MessageBox.Show("Usuario Inactivo. Contacte Con El Administrador del Sistema.", "Verifique.");
                        return;
                    }
                }
            }
        }
        private void frm_login_KeyPress(object sender, KeyPressEventArgs e)
        {
            int digito;
            digito = Convert.ToInt32((Keys)e.KeyChar);

            if (digito == 27) 
            {
                string msjInfo = "";
                msjInfo = "¿Esta usted seguro que desea salir del sistema?";
                if (MessageBox.Show(msjInfo, "Verifique.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;

            if (codigo == 13)
            {
                e.Handled = true;
                if (txtUsuario.TextLength > 0) txtClave.Focus();
            }
        }

        public void recuerdame()
        {
            if (chkRecord.Checked == true)
            {
                Settings.Default.chkLog = true;
                Settings.Default.usuario = txtUsuario.Text;
                Settings.Default.clave = txtClave.Text;
            }
            else if (chkRecord.Checked == false)
            {
                Settings.Default.chkLog = false;
                Settings.Default.usuario = "";
                Settings.Default.clave = "";
            }
            Settings.Default.Save();
            Settings.Default.Reload();
        }
    }
}

