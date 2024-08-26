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
    public partial class frm_cuadre_taq_gral : Form
    {
        public frm_cuadre_taq_gral()
        {
            InitializeComponent();
        }

        clsMet obj_cuadre_taq = new clsMet();
        DataTable dt_dgv_cuadre_taq = new DataTable();
        DataTable dt_cbo_grupos = new DataTable();
        DataTable dt_cbo_taquilla = new DataTable();
        int id_grupos_taq = 0;

        int id_proceso = 0;

        private void frm_cuadre_taq_gral_Load(object sender, EventArgs e)
        {
            this.Text = "Cuadre General Taquillas.";
            this.dgv_cuadre_taq.AllowUserToAddRows = false;
            this.dgv_cuadre_taq.RowHeadersVisible = false;

            this.dtp_fecha_ini.Value =  Convert.ToDateTime(clsMet.FechaActual);
            this.dtp_fecha_ini.Format = DateTimePickerFormat.Custom;
            this.dtp_fecha_ini.CustomFormat = "dd-MM-yyyy";

            this.dtp_fecha_fin.Value =  Convert.ToDateTime(clsMet.FechaActual);
            this.dtp_fecha_fin.Format = DateTimePickerFormat.Custom;
            this.dtp_fecha_fin.CustomFormat = "dd-MM-yyyy";

            btn_buscar.Enabled = false;

            this.work_inicia_frm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.work_inicia_frm_DoWork);
            this.work_inicia_frm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.work_inicia_frm_OnProgressChanged);
            this.work_inicia_frm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.work_inicia_frm_OnRunWorkerCompleted);
            this.work_inicia_frm.RunWorkerAsync();
        }


        private void work_inicia_frm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                //dt_dgv_cuadre_taq = obj_cuadre_taq.bus_cuadre_taq
                //                        (Convert.ToInt32(clsMet.id_grupo));

                dt_cbo_grupos = obj_cuadre_taq.bus_grupos();

                id_proceso = 1;
                work_inicia_frm.CancelAsync();
            }
            catch (Exception error)
            {
                id_proceso = 0;
                MessageBox.Show(error.Message, "Verifique");
            }

        }

        private void work_inicia_frm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {


        }
        private void work_inicia_frm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (id_proceso == 1)
            {

                //this.dgv_cuadre_taq.DataSource = null;
                //this.dgv_cuadre_taq.DataSource = dt_dgv_cuadre_taq;
                //bus_totales_venta();

                this.cbo_grupos.DisplayMember = "nomb_grupo";
                this.cbo_grupos.ValueMember = "id_grupo";
                this.cbo_grupos.DataSource = dt_cbo_grupos;
                

            }

            else if (id_proceso == 0)
            {
                MessageBox.Show("Error verificando licencia", "Verifique.");

            }

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {

            DateTime fecha_ini = dtp_fecha_ini.Value.Date;
            DateTime fecha_fin = dtp_fecha_fin.Value.Date;
            int id_usuario = Convert.ToInt32(cbo_taquilla.SelectedValue.ToString());
            int cant_dif_dias = fecha_ini.CompareTo(fecha_fin);

            if (cant_dif_dias > 0)
            {
                MessageBox.Show("Fecha inicial no debe ser mayor a fecha final", "Verifique");
                return;
            }

            dt_dgv_cuadre_taq = obj_cuadre_taq.busTotCuadreGrupoTaqFiltro
                                        (id_grupos_taq,
                                        id_usuario,
                                         Convert.ToDateTime(dtp_fecha_ini.Text).ToString("yyyy-MM-dd"),
                                         Convert.ToDateTime(dtp_fecha_fin.Text).ToString("yyyy-MM-dd")
                                         );

            this.dgv_cuadre_taq.DataSource = dt_dgv_cuadre_taq;
        }

        private void cbo_grupos_SelectionChangeCommitted(object sender, EventArgs e)
        {

            id_grupos_taq = Convert.ToInt32(cbo_grupos.SelectedValue.ToString());

            dt_cbo_grupos = obj_cuadre_taq.bus_ventas_todas_grupos
                                        (id_grupos_taq,
                                         Convert.ToDateTime(dtp_fecha_ini.Text).ToString("yyyy-MM-dd"),
                                        Convert.ToDateTime(dtp_fecha_fin.Text).ToString("yyyy-MM-dd"));

            this.dgv_cuadre_taq.DataSource = dt_cbo_grupos;

            if (id_grupos_taq== 0)
            {
                cbo_taquilla.Enabled = false;
                btn_buscar.Enabled = false;
            }
            else if (id_grupos_taq > 0)
            {

                dt_cbo_taquilla = obj_cuadre_taq.busGrupoTaq
                                          (id_grupos_taq);

                this.cbo_taquilla.DisplayMember = "nick";
                this.cbo_taquilla.ValueMember = "id_usuario";
                this.cbo_taquilla.DataSource = dt_cbo_taquilla;

                cbo_taquilla.Enabled = true;
                btn_buscar.Enabled = true;
            }


        }
    }
}


