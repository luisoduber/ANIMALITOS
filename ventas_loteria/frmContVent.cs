using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ventas_loteria
{
    public partial class frmContVent : Form
    {
        public frmContVent()
        {
            InitializeComponent();
        }

        clsMet objMet = new clsMet();
        DataTable dtCboGrup = new DataTable();
        DataTable dtDgvSort = new DataTable();
        DataTable dtCboLot = new DataTable();
        DataTable dtCboTaq = new DataTable();
        DataTable dtDgvProd = new DataTable();
        DataTable dtDgvProdBloq = new DataTable();

        int idLot = 0, idSort = 0;
        int idGrup = 0, IdDiv = 0;
        string fechLot = "", codProd = "";
        string nombLot = "", nombSort = "";
        string nombProd = "", msjInf = "";
        int idProc = 0;
        int idStat = 0, idTaq = 0;
        int idUsu = 0, idPerf = 0;

        private void frm_proc_result_loteria_Load(object sender, EventArgs e)
        {
            this.Text = "Control de Ventas.".ToUpper();
            this.dgvSort.AllowUserToAddRows = false;
            this.dgvSort.RowHeadersVisible = false;

            this.dgvProdBloq.AllowUserToAddRows = false;
            this.dgvProdBloq.RowHeadersVisible = false;

            this.dgvProd.AllowUserToAddRows = false;
            this.dgvProd.RowHeadersVisible = false;
            idPerf = Convert.ToInt32(clsMet.idPerf);

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
                dtCboLot = objMet.listLotContVent();
                idLot = Convert.ToInt16(dtCboLot.Rows[0][0]);
                dtDgvSort = objMet.listSortContVentTod(idLot);
                dtDgvProd = objMet.busContVentTaq(idLot);

                idProc = 1;
                work_inicia_frm.CancelAsync();
            }
            catch (Exception ex)
            {
                idProc = 0;
                MessageBox.Show(ex.Message, "Verifique");
            }
        }

        private void cboGrup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idGrup = Convert.ToInt16(cboGrup.SelectedValue);
            dtCboTaq = objMet.BusTaqContVent(idGrup);
            this.cboTaq.DisplayMember = "nick";
            this.cboTaq.ValueMember = "id_usuario";
            this.cboTaq.DataSource = dtCboTaq;

            idLot = Convert.ToInt32(cboLot.SelectedValue);
            idSort = Convert.ToInt32(dgvSort.CurrentRow.Cells[0].Value.ToString());

            dtDgvProdBloq = objMet.listProdBloqFilt(idGrup, idLot, idSort);
            dgvProdBloq.DataSource = dtDgvProdBloq;
        }

        private void work_inicia_frm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        private void work_inicia_frm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (idProc == 1)
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
                dtDgvProdBloq = objMet.listProdBloq(idGrup, idLot);

                this.cboTaq.DisplayMember = "nick";
                this.cboTaq.ValueMember = "id_usuario";
                this.cboTaq.DataSource = dtCboTaq;

                this.cboLot.DisplayMember = "nombLot";
                this.cboLot.ValueMember = "idLot";
                this.cboLot.DataSource = dtCboLot;

                dgvSort.DataSource = dtDgvSort;
                dgvProd.DataSource = dtDgvProd;
                dgvProdBloq.DataSource = dtDgvProdBloq;
            }
        }

        private void dgvSort_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSort.RowCount > 0)
            {
                idGrup = Convert.ToInt16(cboGrup.SelectedValue);
                idLot = Convert.ToInt32(cboLot.SelectedValue);
                idSort = Convert.ToInt32(dgvSort.CurrentRow.Cells[0].Value.ToString());

                dtDgvProdBloq = objMet.listProdBloqFilt(idGrup, idLot, idSort);
                dgvProdBloq.DataSource = dtDgvProdBloq;
            }
        }
        private void dgvProdBloq_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdBloq.RowCount > 0)
            {
                idGrup = Convert.ToInt16(cboGrup.SelectedValue);
                idUsu = Convert.ToInt32(dgvProdBloq.CurrentRow.Cells[0].Value.ToString());
                idLot = Convert.ToInt32(dgvProdBloq.CurrentRow.Cells[1].Value.ToString());
                idSort = Convert.ToInt32(dgvProdBloq.CurrentRow.Cells[2].Value.ToString());
                codProd = dgvProdBloq.CurrentRow.Cells[4].Value.ToString();
                nombProd = dgvProdBloq.CurrentRow.Cells[5].Value.ToString();
                nombLot = dgvProdBloq.CurrentRow.Cells[6].Value.ToString();

                string rsDat = "";
                msjInf = "Realmente desea desbloquear el producto: ";
                msjInf += "\"" + codProd + " - " + nombProd + "\"";
                msjInf += " Para el sorteo: \"" + nombLot.ToUpper() + "\"";
                msjInf += " esta usted seguro?";

                if (MessageBox.Show(msjInf.ToUpper(), "Verifique.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    rsDat = objMet.actStatProd(idGrup, idUsu, idLot, idSort, codProd, 2);
                    if (rsDat == "true")
                    {
                        dtDgvProdBloq = objMet.listProdBloq(idGrup, idLot);
                        dgvProdBloq.DataSource = dtDgvProdBloq;
                    }
                    else { MessageBox.Show("Ha ocurrido el siguiente error:" + rsDat, "Verifique."); }
                }
            }
        }

        private void cboLot_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idGrup = Convert.ToInt16(cboGrup.SelectedValue);
            idLot = Convert.ToInt16(cboLot.SelectedValue);
            dtDgvSort = objMet.listSortContVentTod(idLot);
            dgvSort.DataSource = dtDgvSort;

            idLot = Convert.ToInt16(cboLot.SelectedValue);
            dtDgvProd = objMet.busContVentTaq(idLot);
            dgvProd.DataSource = dtDgvProd;

            dtDgvProdBloq = objMet.listProdBloq(idGrup, idLot);
            dgvProdBloq.DataSource = dtDgvProdBloq;
        }

        private void dgvProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProd.RowCount > 0)
            {
                idUsu = Convert.ToInt16(cboTaq.SelectedValue.ToString());
                idGrup = Convert.ToInt16(cboGrup.SelectedValue);
                idLot = Convert.ToInt32(cboLot.SelectedValue);
                idSort = Convert.ToInt32(dgvSort.CurrentRow.Cells[0].Value.ToString());
                codProd = dgvProd.CurrentRow.Cells[0].Value.ToString();
                nombProd = dgvProd.CurrentRow.Cells[1].Value.ToString();
                nombLot = dgvSort.CurrentRow.Cells[1].Value.ToString();

                string rsDat = "";
                msjInf = "Realmente desea bloquear el producto: ";
                msjInf += "\"" + codProd + " - " + nombProd + "\"";
                msjInf += " Para el sorteo: \"" + nombLot.ToUpper() + "\"";
                msjInf += " esta usted seguro?";

                if (MessageBox.Show(msjInf.ToUpper(), "Verifique.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if ((idUsu == 0) && (idSort == 0)){ rsDat = objMet.actStatProdTod(idGrup,idLot,codProd,1); }
                    else { rsDat = objMet.actStatProd(idGrup, idUsu, idLot, idSort, codProd, 1); }
                    if (rsDat == "true")
                    {
                        dtDgvProdBloq = objMet.listProdBloq(idGrup, idLot);
                        dgvProdBloq.DataSource = dtDgvProdBloq;
                    }
                    else { MessageBox.Show("Ha ocurrido el siguiente error:" + rsDat, "Verifique."); }
                }
            }
        }
        private void frmContVent_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;
            if (codigo == 27) { this.Close(); }
        }
       
    }
}
