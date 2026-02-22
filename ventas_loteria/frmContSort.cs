using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ventas_loteria
{
    public partial class frmContSort : Form
    {
        public frmContSort()
        {
            InitializeComponent();
        }

        clsMet objMet = new clsMet();
        DataTable dtCboGrup = new DataTable();
        DataTable dtDgvSort = new DataTable();
        DataTable dtCboLot = new DataTable();
        DataTable dtCboTaq = new DataTable();
        DataTable dtdgvSortBloqII = new DataTable();

        int idLot = 0, idSort = 0;
        int idGrup = 0, IdDiv = 0;
        string fechLot = "", codProd = "";
        string nombLot = "", nombSort = "";
        string nombTaq = "", msjInf = "";
        int idStat = 0, idTaq = 0;
        int idUsu = 0, idPerf=0;
        int idProc = 0;

        private void frmContSort_Load(object sender, EventArgs e)
        {
            this.Text = "Control de Sorteos.".ToUpper();
            this.dgvSort.AllowUserToAddRows = false;
            this.dgvSort.RowHeadersVisible = false;

            this.dgvSortBloqII.AllowUserToAddRows = false;
            this.dgvSortBloqII.RowHeadersVisible = false;
            idPerf = Convert.ToInt32(clsMet.idPerf);

            this.work_inicia_frm.WorkerReportsProgress = true;
            this.work_inicia_frm.WorkerSupportsCancellation = true;

            this.work_inicia_frm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.work_inicia_frm_DoWork);
            this.work_inicia_frm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.work_inicia_frm_OnProgressChanged);
            this.work_inicia_frm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.work_inicia_frm_OnRunWorkerCompleted);
            this.work_inicia_frm.RunWorkerAsync();
        }

        private void work_inicia_frm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dtCboGrup = objMet.BusGrup();
                if (idPerf == 2) { idGrup = Convert.ToInt16(clsMet.idGrup); }
                else if (idPerf == 3) { idGrup = Convert.ToInt16(dtCboGrup.Rows[0][0]); }
                
                dtCboTaq = objMet.BusTaqContVent(idGrup);
                idTaq= Convert.ToInt16(dtCboTaq.Rows[0][0]);
                dtCboLot = objMet.listLotContVent(idTaq);

                idLot = Convert.ToInt16(dtCboLot.Rows[0][0]);
                dtDgvSort = objMet.listSortContVentTod(idLot);

                idProc = 1;
                work_inicia_frm.CancelAsync();
            }
            catch (Exception ex)
            {
                idProc = 0;
                MessageBox.Show(ex.Message, "Verifique");
            }
        }

        private void work_inicia_frm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void work_inicia_frm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.cboGrup.DisplayMember = "nombGrup";
            this.cboGrup.ValueMember = "idGrup";
            this.cboGrup.DataSource = dtCboGrup;

            if (idPerf == 2)
            {
                idGrup = Convert.ToInt32(clsMet.idGrup);
                cboGrup.Enabled = false;
                cboGrup.SelectedValue = idGrup;
            }
            else if (idPerf == 3) { idGrup = Convert.ToInt16(dtCboGrup.Rows[0][0].ToString()); }

            dtCboTaq = objMet.BusTaqContVent(idGrup);
            dtdgvSortBloqII = objMet.listSortBloq(idGrup, idLot);

            this.cboTaq.DisplayMember = "nick";
            this.cboTaq.ValueMember = "id_usuario";
            this.cboTaq.DataSource = dtCboTaq;

            this.cboLot.DisplayMember = "nombLot";
            this.cboLot.ValueMember = "idLot";
            this.cboLot.DataSource = dtCboLot;
            dgvSort.DataSource = dtDgvSort;
            dgvSortBloqII.DataSource = dtdgvSortBloqII;
        }
        private void dgvSortBloqII_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvSortBloqII.RowCount > 0)
            {
                idGrup = Convert.ToInt16(cboGrup.SelectedValue);
                idUsu = Convert.ToInt32(dgvSortBloqII.CurrentRow.Cells[0].Value.ToString());
                idLot = Convert.ToInt32(dgvSortBloqII.CurrentRow.Cells[1].Value.ToString());
                idSort = Convert.ToInt32(dgvSortBloqII.CurrentRow.Cells[2].Value.ToString());
                nombTaq = dgvSortBloqII.CurrentRow.Cells[3].Value.ToString();
                nombSort = cboLot.Text.ToUpper() + " - ";
                nombSort += dgvSortBloqII.CurrentRow.Cells[4].Value.ToString();

                string rsDat = "";
                msjInf = "Realmente desea desbloquear el sorteo: ";
                msjInf += "\"" + nombSort + "\" ";
                msjInf += "para la taquilla: ";
                msjInf += "\"" + nombTaq + "\" ";
                msjInf += " esta usted seguro?";

                if (MessageBox.Show(msjInf.ToUpper(), "Verifique.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    rsDat = objMet.actStatSort(idGrup,idUsu,idLot,idSort,2);
                    if (rsDat == "true")
                    {
                        dtdgvSortBloqII = objMet.listSortBloq(idGrup,idLot);
                        dgvSortBloqII.DataSource = dtdgvSortBloqII;
                    }
                    else { MessageBox.Show("Ha ocurrido el siguiente error:" + rsDat, "Verifique."); }
                }
            }
        }
        private void cboGrup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idGrup = Convert.ToInt16(cboGrup.SelectedValue);
            dtCboTaq = objMet.BusTaqContVent(idGrup);

            this.cboTaq.DisplayMember = "nick";
            this.cboTaq.ValueMember = "id_usuario";
            this.cboTaq.DataSource = dtCboTaq;

            idTaq = Convert.ToInt16(cboTaq.SelectedValue);
            dtCboLot = objMet.listLotContVent(idTaq);

            this.cboLot.DisplayMember = "nombLot";
            this.cboLot.ValueMember = "idLot";
            this.cboLot.DataSource = dtCboLot;
            idLot = Convert.ToInt16(cboLot.SelectedValue);

            dtDgvSort = objMet.listSortContVentTod(idLot);
            dgvSort.DataSource = dtDgvSort;

            dtdgvSortBloqII = objMet.listSortBloq(idGrup, idLot);
            dgvSortBloqII.DataSource = dtdgvSortBloqII;
        }
        private void dgvSort_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSort.RowCount > 0)
            {
                idGrup = Convert.ToInt16(cboGrup.SelectedValue);
                idLot = Convert.ToInt32(cboLot.SelectedValue);
                idSort = Convert.ToInt32(dgvSort.CurrentRow.Cells[0].Value.ToString());
                dtdgvSortBloqII = objMet.listProdSortFilt(idGrup,idLot,idSort);
                dgvSortBloqII.DataSource = dtdgvSortBloqII;
            }
        }
        private void dgvSort_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSort.RowCount > 0)
            {
                idGrup = Convert.ToInt16(cboGrup.SelectedValue);
                idUsu = Convert.ToInt32(cboTaq.SelectedValue);
                idLot = Convert.ToInt32(cboLot.SelectedValue);
                idSort = Convert.ToInt32(dgvSort.CurrentRow.Cells[0].Value.ToString());
                nombLot = cboLot.Text.ToUpper();
                nombSort = dgvSort.CurrentRow.Cells[1].Value.ToString();

                string rsDat = "";
                msjInf = "Realmente desea bloquear el sorteo: ";
                msjInf += "\"" + nombSort + "\"";
                msjInf += " esta usted seguro?";

                if (MessageBox.Show(msjInf.ToUpper(), "Verifique.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if ((idUsu == 0) && (idSort == 0)) { /*rsDat = objMet.actStatProdTod(idGrup, idLot, codProd, 1);*/ }
                    else { rsDat = objMet.actStatSort(idGrup,idUsu,idLot,idSort,1); }
                    if (rsDat == "true")
                    {
                        dtdgvSortBloqII = objMet.listSortBloq(idGrup,idLot);
                        dgvSortBloqII.DataSource = dtdgvSortBloqII;
                    }
                    else { MessageBox.Show("Ha ocurrido el siguiente error:" + rsDat, "Verifique."); }
                }
            }
        }

        private void cboTaq_SelectionChangeCommitted(object sender, EventArgs e)
        {

            idTaq = Convert.ToInt16(cboTaq.SelectedValue);
            dtCboLot = objMet.listLotContVent(idTaq);

            this.cboLot.DisplayMember = "nombLot";
            this.cboLot.ValueMember = "idLot";
            this.cboLot.DataSource = dtCboLot;
            idLot = Convert.ToInt16(cboLot.SelectedValue);

            dtDgvSort = objMet.listSortContVentTod(idLot);
            dgvSort.DataSource = dtDgvSort;

            dtdgvSortBloqII = objMet.listSortBloq(idGrup, idLot);
            dgvSortBloqII.DataSource = dtdgvSortBloqII;
        }

        private void frmContSort_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;
            if (codigo == 27) { this.Close(); }
        }
        private void cboLot_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idGrup = Convert.ToInt16(cboGrup.SelectedValue);
            idLot = Convert.ToInt16(cboLot.SelectedValue);
            dtDgvSort = objMet.listSortContVentTod(idLot);
            dgvSort.DataSource = dtDgvSort;

            dtdgvSortBloqII = objMet.listSortBloq(idGrup,idLot);
            dgvSortBloqII.DataSource = dtdgvSortBloqII;
        }
    }
}
