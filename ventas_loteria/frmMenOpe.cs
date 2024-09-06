using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ventas_loteria
{
    public partial class frmMenOpe : Form
    {
        public frmMenOpe()
        {
            InitializeComponent();
        }

        string HoraAct = "", FechaAct = "";
        string[] rsDat = null;

        clsMet objMenOpe = new clsMet();

        private void frmMenOpe_Load(object sender, EventArgs e)
        {
            this.Text = "Menu Operaciones";
            rsDat = objMenOpe.busFechHoraServ();

            clsMet.FechaActual = Convert.ToDateTime(rsDat[0].ToString()).ToString("yyyy/MM/dd");
            FechaAct = Convert.ToDateTime(rsDat[0].ToString()).ToString("dd/MM/yyyy");
            HoraAct = Convert.ToDateTime(rsDat[1].ToString()).ToString("hh:mm:ss");
        }

        private void btnCc_Click(object sender, EventArgs e)
        {
            frm_cambio_clave frm = new frm_cambio_clave();
            frm.Show();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            frm_result_lot frm = new frm_result_lot();
            frm.ShowDialog();
        }

        private void btnAnulTck_Click(object sender, EventArgs e)
        {
            frm_anular_ticket frm = new frm_anular_ticket();
            frm.Show();
        }

        private void btnTckTaq_Click(object sender, EventArgs e)
        {
            frm_verf_ticket_taq frm = new frm_verf_ticket_taq();
            frm.ShowDialog();
        }
        private void btnProcResult_Click(object sender, EventArgs e)
        {
            frm_proc_result_loteria frm = new frm_proc_result_loteria();
            frm.ShowDialog();
        }

        private void btnGrupUsu_Click(object sender, EventArgs e)
        {
            frm_grupos_usuarios frm = new frm_grupos_usuarios();
            frm.ShowDialog();
        }

        private void btnContVent_Click(object sender, EventArgs e)
        {
            frmContVent frm = new frmContVent();
            frm.ShowDialog();
        }

        private void frmMenOpe_KeyPress(object sender, KeyPressEventArgs e)
        {

            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;
            if (codigo == 27) 
            {
                string msjInf;
                msjInf = "¿Esta usted seguro que desea salir del sistema?";
                if (MessageBox.Show(msjInf, "Verifique.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }

          
        }

        private void btnLimTaq_Click(object sender, EventArgs e)
        {
            frmLimTaq frm = new frmLimTaq();
            frm.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            frm_ventas frm = new frm_ventas();
            frm.ShowDialog();

        }

        private void btnCuadTaq_Click(object sender, EventArgs e)
        {
            frm_cuadre_taq frm =new frm_cuadre_taq();
            frm.ShowDialog();
        }
    }
}
