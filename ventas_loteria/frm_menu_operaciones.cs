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
    public partial class frm_menu_operaciones : Form
    {
        public frm_menu_operaciones()
        {
            InitializeComponent();
        }

        string fechaHora = "", FechaAct = "";
        string[] rsDat =null;
        string HoraAct = "";
        TimeSpan HoraNew = new TimeSpan();

        int hNew=0, mNew=0, sNew=0;
        int hAct = 0, mAct = 0, sAct = 0;

        clsMet objMenuOpe = new clsMet();

        private void cerrarSessiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msj_salir_apli;
            msj_salir_apli = "¿Esta usted seguro que desea salir del sistema?";
            if (MessageBox.Show(msj_salir_apli, "Verifique.", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frm_menu_operaciones_Load(object sender, EventArgs e)
        {
            rsDat = objMenuOpe.busFechHoraServ();
            clsMet.FechaActual = Convert.ToDateTime(rsDat[0].ToString()).ToString("yyyy/MM/dd");
            FechaAct = Convert.ToDateTime(rsDat[0].ToString()).ToString("dd/MM/yyyy");
            HoraAct = Convert.ToDateTime(rsDat[1].ToString()).ToString("hh:mm:ss");
           
            string[] data = HoraAct.Split(':');
            hAct = Convert.ToInt16(data[0]);
            mAct = Convert.ToInt16(data[1]);
            sAct = Convert.ToInt16(data[2]);
            HoraNew = new TimeSpan(hAct, mAct, sAct);

            timer1.Enabled = false;
            timer1.Interval = 1000;

            this.Text = " - Usuario:";
            this.Text += clsMet.nombUsu.ToUpper();
            this.Text += " - Fecha: ";
            this.Text += FechaAct;
            this.ControlBox = true;

            //////////////////////////////////////////
            //////////////TAQUILLAS///////////////////

            if (Convert.ToInt32(clsMet.idPerf) == 1)
            {
                procResultadosToolStripMenuItem.Visible = false;
                cuadreGruposToolStripMenuItem.Visible = false;
                cuadreTaquillasToolStripMenuItem.Visible = false;
                crearGruposUsuariosToolStripMenuItem.Visible = false;
                anularTicketToolStripMenuItem.Visible = false;
                ticketTaquillasToolStripMenuItem.Visible = false;
                resultadosToolStripMenuItem.Visible = false;

                this.Size = new Size(860, 620);
                Form frm = this.MdiChildren.FirstOrDefault(x => x is frm_cuadre_taq);
                frm = new frm_ventas();
                frm.MdiParent = this;
                frm.Show();

            }
            //////////////////////////////////////////
            //////////////OPERACIONES/////////////////

            else if (Convert.ToInt32(clsMet.idPerf) == 2)
            {
                ventasToolStripMenuItem.Visible = true;
                procResultadosToolStripMenuItem.Visible = true;
                crearGruposUsuariosToolStripMenuItem.Visible = false;
                cuadreGruposToolStripMenuItem.Visible = false;

                Form frm = this.MdiChildren.FirstOrDefault(x => x is frm_cuadre_taq);
                frm = new frm_cuadre_taq();
                frm.MdiParent = this;
                frm.Show();
            }

            //////////////////////////////////////////
            //////////////ADMINISTRADOR///////////////


            else if (Convert.ToInt32(clsMet.idPerf) == 3)
            {
                this.Size = new Size(1000, 590);
                Form frm = this.MdiChildren.FirstOrDefault(x => x is frmContVent);
                frm = new frm_proc_result_loteria();
                frm.MdiParent = this;
                frm.Show();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            HoraNew = HoraNew.Add(TimeSpan.FromSeconds(1));
            string[] data = HoraNew.ToString(@"hh\:mm\:ss").Split(':');
            hNew = Convert.ToInt16(data[0].ToString());
            mNew = Convert.ToInt16(data[1].ToString());
            sNew = Convert.ToInt16(data[2].ToString());
            HoraNew = new TimeSpan(hNew, mNew, sNew);

            fechaHora = "Fecha: ";
            fechaHora += FechaAct;
            fechaHora += " - Hora: ";
            fechaHora += HoraNew.ToString();

            this.Text = "Usuario:";
            this.Text += clsMet.nombUsu.ToUpper();
            this.Text += " - " + fechaHora;
        }

        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.FirstOrDefault(x => x is frm_cambio_clave);
            if (frm != null)
            {
                frm.Close();
            }
            frm = new frm_cambio_clave();
            frm.MdiParent = this;
            frm.Show();
        }
        private void crearGruposUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_grupos_usuarios);

            if (frm == null)
            {
                frm_grupos_usuarios obj_abrir_grupos_usuarios = new frm_grupos_usuarios();
                obj_abrir_grupos_usuarios.Show();
            }
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = this.MdiChildren.FirstOrDefault(x => x is frm_ventas);
            if (frm != null)
            {   
                frm.Close();
            }

            frm = new frm_ventas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void procResultadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.FirstOrDefault(x => x is frmContVent);
            if (frm != null)
            {
                frm.Close();
            }
            frm = new frm_proc_result_loteria();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cuadreTaquillasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = this.MdiChildren.FirstOrDefault(x => x is frm_cuadre_taq);
            if (frm != null)
            {
                frm.Close();
            }
            frm = new frm_cuadre_taq();
            frm.MdiParent = this;
            frm.Show();
        }

        private void impresoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = this.MdiChildren.FirstOrDefault(x => x is frm_config_impresora);
            if (frm != null)
            {
                frm.Close();
            }
            frm = new frm_config_impresora();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cuadreGruposToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = this.MdiChildren.FirstOrDefault(x => x is frm_cuadre_taq_gral);
            if (frm != null)
            {
                frm.Close();
            }
            frm = new frm_cuadre_taq_gral();
            frm.MdiParent = this;
            frm.Show();
        }

        private void anularTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = this.MdiChildren.FirstOrDefault(x => x is frm_anular_ticket);
            if (frm != null)
            {
                frm.Close();
            }
            frm = new frm_anular_ticket();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ticketTaquillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 590);
            Form frm = this.MdiChildren.FirstOrDefault(x => x is frm_verf_ticket_taq);
            if (frm != null)
            {
                frm.Close();
            }
            frm = new frm_verf_ticket_taq();
            frm.MdiParent = this;
            frm.Show();
        }

        private void resultadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = this.MdiChildren.FirstOrDefault(x => x is frm_result_lot);
            if (frm != null)
            {
                frm.Close();
            }

            frm = new frm_result_lot();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
