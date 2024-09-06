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

        clsMet objFunc = new clsMet();
        DataTable dtDgvSort = new DataTable();
        DataTable dtCboLot = new DataTable();
        DataTable dtCboTaq = new DataTable();
        DataTable dtCboDiv = new DataTable();
        DataTable dtDgvVent = new DataTable();

        int idLot = 0, idSort = 0;
        int idGrup = 0, IdDiv = 0;
        string fechLot = "", codProd = "";
        string nombLot = "", nombSort = "";
        string nombProd = "", msjInf = "";
        int idProc = 0;
        int idStat = 0, idTaq = 0;
        int idUsu = 0;

        private void frm_proc_result_loteria_Load(object sender, EventArgs e)
        {
            this.Text = "Control de Ventas.";
            this.dgvSort.AllowUserToAddRows = false;
            this.dgvSort.RowHeadersVisible = false;

            this.dgvVent.AllowUserToAddRows = false;
            this.dgvVent.RowHeadersVisible = false;
            idGrup = Convert.ToInt32(clsMet.idGrup);

            this.work_inicia_frm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.work_inicia_frm_DoWork);
            this.work_inicia_frm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.work_inicia_frm_OnProgressChanged);
            this.work_inicia_frm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.work_inicia_frm_OnRunWorkerCompleted);
            this.work_inicia_frm.RunWorkerAsync();
        }

        private void work_inicia_frm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dtCboTaq = objFunc.BusTaqContVent(idGrup);
                dtCboLot = objFunc.listLotTod();
                //dtCboDiv = objFunc.busDivisa();
                dtDgvSort = objFunc.busLotProcRs();

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
            if (idProc == 1)
            {
                dgvSort.DataSource = dtDgvSort;
                this.cboTaq.DisplayMember = "nick";
                this.cboTaq.ValueMember = "id_usuario";
                this.cboTaq.DataSource = dtCboTaq;

                this.cboLot.DisplayMember = "nombLot";
                this.cboLot.ValueMember = "idLot";
                this.cboLot.DataSource = dtCboLot;
            }
        }
        private void cboLot_SelectedValueChanged(object sender, EventArgs e)
        {
            idLot = Convert.ToInt16(cboLot.SelectedValue);
            dtDgvSort = objFunc.listSortTod(idLot);
            dgvSort.DataSource = dtDgvSort;
        }
        private void dgvSort_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTaq = Convert.ToInt16(cboTaq.SelectedValue.ToString());
            idLot = Convert.ToInt32(dgvSort.CurrentRow.Cells[0].Value.ToString());
            idSort = Convert.ToInt32(dgvSort.CurrentRow.Cells[3].Value.ToString());

            dtDgvVent = objFunc.busContVentTaq(idGrup, idTaq, idLot, idSort);
            dgvVent.DataSource = dtDgvVent;
        }
        private void dgvVent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVent.RowCount > 0)
            {
                idUsu = Convert.ToInt16(cboTaq.SelectedValue);
                idGrup = Convert.ToInt32(dgvVent.CurrentRow.Cells[0].Value.ToString());
                idLot = Convert.ToInt32(dgvSort.CurrentRow.Cells[0].Value.ToString());
                idSort = Convert.ToInt32(dgvSort.CurrentRow.Cells[3].Value.ToString());
                codProd = dgvVent.CurrentRow.Cells[3].Value.ToString();
                nombProd = dgvVent.CurrentRow.Cells[4].Value.ToString();
                nombLot = dgvSort.CurrentRow.Cells[1].Value.ToString();

                string rsDat = "";
                msjInf = "Realmente desea bloquear el producto: ";
                msjInf += "\"" + codProd + " - " + nombProd + "\"";
                msjInf += " Para el sorteo: \"" + nombLot.ToUpper() + "\"";
                msjInf += " esta usted seguro?";

                if (MessageBox.Show(msjInf.ToUpper(), "Verifique.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    rsDat = objFunc.ActStatProd(idGrup, idUsu, idLot, idSort, codProd);
                    if (rsDat == "1")
                    {
                        idLot = Convert.ToInt32(dgvSort.CurrentRow.Cells[0].Value.ToString());
                        idSort = Convert.ToInt32(dgvSort.CurrentRow.Cells[3].Value.ToString());
                        IdDiv = 0;

                        dtDgvVent = objFunc.busContVent(idGrup, idUsu, idLot, idSort, IdDiv);
                        dgvVent.DataSource = dtDgvVent;
                    }
                    else { MessageBox.Show("Ha ocurrido el siguiente error:" + rsDat, "Verifique."); }
                }
            }
        }
        private void cboDiv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            /*
            idLot = Convert.ToInt32(dgvLot.CurrentRow.Cells[0].Value.ToString());
            idSort = Convert.ToInt32(dgvLot.CurrentRow.Cells[3].Value.ToString());
            IdDiv = Convert.ToInt16(cboDiv.SelectedValue.ToString());

            dtDgvVent =objFunc.busContVent(idGrup,idLot,idSort,IdDiv);
            dgvVent.DataSource = dtDgvVent;
            */
        }
        private void frmContVent_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;
            if (codigo == 27) { this.Close(); }
        }
        private void dgvVent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.dgvVent.Rows[e.RowIndex].Cells[6].Value.ToString()))
            {
                idStat = Convert.ToInt16(this.dgvVent.Rows[e.RowIndex].Cells[6].Value);
                if (idStat == 1)
                {
                    dgvVent.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                }
                if (idStat == 2)
                {
                    dgvVent.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                }
            }
        }
    }
}
