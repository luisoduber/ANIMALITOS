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
    public partial class frm_grupos_usuarios : Form
    {
        public frm_grupos_usuarios()
        {
            InitializeComponent();
        }

        clsMet objFunc = new clsMet();
        DataTable dtDgvGrupos = new DataTable();
        DataTable dtCboLetRif = new DataTable();
        DataTable dtCodTelf = new DataTable();
        DataTable dtCboStatGrup = new DataTable();
        DataTable dtDgvUsu = new DataTable();
        DataTable dtCboStatUsu= new DataTable();
        DataTable dtCboPerfUsu = new DataTable();
        DataTable dtCboPregSeg = new DataTable();
        DataTable dtDgvMac = new DataTable();
        DataTable dtCboStatMac = new DataTable();
        DataTable dtCboStatMacFilt = new DataTable();
        DataTable dtCboCuad = new DataTable();
        DataTable dtCboDivisa = new DataTable();

        int idProc = 0, idGrup = 0;
        int idUsu = 0, idGrupUsu=0;
        int idPerf=0;
        string nombGrup = "";
        int idMac = 0;

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frm_grupos_usuarios_Load(object sender, EventArgs e)
        {
            this.Text = "Registrar Grupos / Usuarios Taquilla.";
            lbl_version_pro.Text = clsMet.version_pro;
            idPerf = Convert.ToInt16(clsMet.idPerf);
            idGrup = Convert.ToInt16(clsMet.idGrup);

            this.dgvGrup.AllowUserToAddRows = false;
            this.dgvGrup.RowHeadersVisible = false;

            this.dgvUsu.AllowUserToAddRows = false;
            this.dgvUsu.RowHeadersVisible = false;

            this.dgvMac.AllowUserToAddRows = false;
            this.dgvMac.RowHeadersVisible = false;

            this.dgvUsu.Enabled = false;
            gp_usuarios.Enabled = false;
            gp_usuarios2.Enabled = false;

            this.work_inicia_frm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.work_inicia_frm_DoWork);
            this.work_inicia_frm.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.work_inicia_frm_OnProgressChanged);
            this.work_inicia_frm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.work_inicia_frm_OnRunWorkerCompleted);
            this.work_inicia_frm.RunWorkerAsync();
        }
        private void work_inicia_frm_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dtDgvGrupos = objFunc.busGrup(idUsu,idPerf,idGrup);
                dtCboLetRif = objFunc.busLetRif();
                dtCodTelf = objFunc.busCodTlf();
                dtCboStatGrup = objFunc.busStat();
                dtCboStatUsu = objFunc.busStat();
                dtCboPerfUsu = objFunc.busPerf(idPerf);
                dtCboPregSeg = objFunc.busPregSeg();
                dtCboStatMac = objFunc.busStatMac();
                dtCboCuad = objFunc.busTipCuad();
                dtCboDivisa= objFunc.busDivisa();
                dtDgvMac = objFunc.busMac(idPerf,idGrup);
                dtCboStatMacFilt = objFunc.busStatMac();

                idProc = 1;
                work_inicia_frm.CancelAsync();
            }
            catch (Exception ex)
            {
                idProc = 0;
                MessageBox.Show("Ha Ocurrido el siguiente error:"+ ex.Message, "Verifique.");
            }

        }
        private void work_inicia_frm_OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        private void work_inicia_frm_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (idProc == 1)
            {

                this.dgvGrup.DataSource = dtDgvGrupos;
                this.dgvMac.DataSource = dtDgvMac;

                this.cboLetRif.DisplayMember = "nomb_letra_rif";
                this.cboLetRif.ValueMember = "nomb_letra_rif";
                this.cboLetRif.DataSource = dtCboLetRif;

                this.cboCodTelf.DisplayMember = "nomb_cod_area";
                this.cboCodTelf.ValueMember = "nomb_cod_area";
                this.cboCodTelf.DataSource = dtCodTelf;

                this.cboStatGrup.DisplayMember = "nomb_status";
                this.cboStatGrup.ValueMember = "id_status";
                this.cboStatGrup.DataSource = dtCboStatGrup;

                this.cboPregSeg.DisplayMember = "nomb_preg_seguridad";
                this.cboPregSeg.ValueMember = "id_preg_seguridad";
                this.cboPregSeg.DataSource = dtCboPregSeg;

                this.cboStatusUsuario.DisplayMember = "nomb_status";
                this.cboStatusUsuario.ValueMember = "id_status";
                this.cboStatusUsuario.DataSource = dtCboStatUsu;

                this.cboPerfUsu.DisplayMember = "nomb_perfil";
                this.cboPerfUsu.ValueMember = "id_perfil";
                this.cboPerfUsu.DataSource = dtCboPerfUsu;

                this.cboTipoCuadre.DisplayMember = "nomb_cuadre";
                this.cboTipoCuadre.ValueMember = "id_tipo_cuadre";
                this.cboTipoCuadre.DataSource = dtCboCuad;

                this.cboDivisa.DisplayMember = "nombDivisa";
                this.cboDivisa.ValueMember = "idDivisa";
                this.cboDivisa.DataSource = dtCboDivisa;

                this.cboStatus.DisplayMember = "nomb_status";
                this.cboStatus.ValueMember = "id_status";
                this.cboStatus.DataSource = dtCboStatMac;

                this.cboStatusMacFiltro.DisplayMember = "nomb_status";
                this.cboStatusMacFiltro.ValueMember = "id_status";
                this.cboStatusMacFiltro.DataSource = dtCboStatMacFilt;
            }

            else if (idProc == 0)
            {
                MessageBox.Show("Error verificando licencia", "Verifique.");
            }
        }

        private void frm_grupos_usuarios_Activated(object sender, EventArgs e)
        {
            txtFiltNombGrup.Focus();
        }
        public Boolean validFrmGrup()
        {
            Boolean validar = true;
            if (string.IsNullOrEmpty(txtNombGrup.Text))
            {
                MessageBox.Show("Ingrese nombre grupo.", "Verifique.");
                txtNombGrup.Focus();
                validar = false;
            }
            else if (string.IsNullOrEmpty(txtRs.Text))
            {
                MessageBox.Show("Ingrese Razon social.", "Verifique.");
                txtRs.Focus();
                validar = false;
            }
            else if (string.IsNullOrEmpty(txtNroRif.Text))
            {
                MessageBox.Show("Ingrese Nro. RIF.", "Verifique.");
                txtNroRif.Focus();
                validar = false;
            }
            else if (txtNroRif.Text.Length < 9)
            {
                MessageBox.Show("La cantidad de digs del RIF son 9.", "Verifique.");
                txtNroRif.Focus();
                validar = false;
            }
            else if (string.IsNullOrEmpty(txtNroTlf.Text))
            {
                MessageBox.Show("Ingrese Nro. Telefono.", "Verifique.");
                txtNroTlf.Focus();
                validar = false;
            }
            else if (txtNroTlf.Text.Length < 7)
            {
                MessageBox.Show("La cantidad de digs del Nro. Telefono son 7.", "Verifique.");
                txtNroTlf.Focus();
                validar = false;
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Ingrese dirección.", "Verifique.");
                txtDireccion.Focus();
                validar = false;
            }
            else if (string.IsNullOrEmpty(txt_email.Text))
            {
                MessageBox.Show("Ingrese email.", "Verifique.");
                txt_email.Focus();
                validar = false;
            }
            else if (clsMet.verf_email(txt_email.Text) == false)
            {
                MessageBox.Show("Ingrese un email valido.", "Verifique.");
                txt_email.Focus();
                validar = false;
            }

            return validar;
        }

        public Boolean validFrm()
        {
            Boolean validar = true;

            if (string.IsNullOrEmpty(txtNombUsu.Text))
            {
                MessageBox.Show("Ingrese Usuario.", "Verifique.");
                txtNombUsu.Focus();
                validar = false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Ingrese email.", "Verifique.");
                txtEmail.Focus();
                validar = false;
            }

            else if (clsMet.verf_email(txtEmail.Text) == false)
            {
                MessageBox.Show("Ingrese un email valido.", "Verifique.");
                txtEmail.Focus();
                validar = false;
            }

            else if (string.IsNullOrEmpty(txtRespSeg.Text))
            {
                MessageBox.Show("Ingrese respuesta seguridad.", "Verifique.");
                txtRespSeg.Focus();
                validar = false;
            }


            else if (string.IsNullOrEmpty(txtPorcTaq.Text))
            {
                MessageBox.Show("Ingrese el porcentaje de la taquilla.", "Verifique.");
                txtPorcTaq.Focus();
                validar = false;
            }
            else if (Convert.ToInt32(txtPorcTaq.Text) > 100)
            {
                MessageBox.Show("Porcentaje taquilla no debe ser mayor de 100.", "Verifique.");
                txtPorcTaq.Focus();
                validar = false;
            }

            else if (string.IsNullOrEmpty(txtPorcSist.Text))
            {
                MessageBox.Show("Ingrese el porcentaje del sistema.", "Verifique.");
                txtPorcSist.Focus();
                validar = false;
            }

            else if (Convert.ToInt32(txtPorcSist.Text) > 100)
            {
                MessageBox.Show("Porcentaje sistema no debe ser mayor de 100.", "Verifique.");
                txtPorcSist.Focus();
                validar = false;
            }

            else if (string.IsNullOrEmpty(txtMontMaxJug.Text))
            {
                MessageBox.Show("Ingrese monto maximo por jugada.", "Verifique.");
                txtMontMaxJug.Focus();
                validar = false;
            }

            else if (string.IsNullOrEmpty(txtMontMaxTick.Text))
            {
                MessageBox.Show("Ingrese monto maximo por ticket.", "Verifique.");
                txtMontMaxTick.Focus();
                validar = false;
            }

            else if (string.IsNullOrEmpty(txtMontXunid.Text))
            {
                MessageBox.Show("Ingrese monto a pagar por cada unidad.", "Verifique.");
                txtMontXunid.Focus();
                validar = false;
            }

            else if (string.IsNullOrEmpty(txtMultJUg.Text))
            {
                MessageBox.Show("Ingrese el monto multiplo de la jugada.", "Verifique.");
                txtMultJUg.Focus();
                validar = false;
            }

            else if (Convert.ToInt32(txtMultJUg.Text)==0)
            {
                MessageBox.Show("Monto multiplo de la jugada debe ser diferente de cero.", "Verifique.");
                txtMultJUg.Focus();
                validar = false;
            }
            
            else if (string.IsNullOrEmpty(txtMinJug.Text))
            {
                MessageBox.Show("Ingrese el monto minimo de la jugada.", "Verifique.");
                txtMinJug.Focus();
                validar = false;
            }

            else if (Convert.ToInt32(txtMinJug.Text)==0)
            {
                MessageBox.Show("Monto minimo de la jugada debe ser diferente de cero.", "Verifique.");
                txtMinJug.Focus();
                validar = false;
            }

             else if (string.IsNullOrEmpty(txtUnidBase.Text))
            {
                MessageBox.Show("Ingrese el monto Unidad/Base de la jugada.", "Verifique.");
                txtUnidBase.Focus();
                validar = false;
            }

             else if (Convert.ToInt32(txtUnidBase.Text)==0)
            {
                MessageBox.Show("Monto Unidad/Base de la jugada debe ser diferente de cero.", "Verifique.");
                txtUnidBase.Focus();
                validar = false;
            }

            else if (string.IsNullOrEmpty(txtCierSort.Text))
            {
                MessageBox.Show("Ingrese la cantidad de minutos para el cierre del sorteo.", "Verifique.");
                txtCierSort.Focus();
                validar = false;
            }
            else if (Convert.ToInt16(txtCierSort.Text)>40)
            {
                MessageBox.Show("la cantidad de minutos para el cierre del sorteo no debe ser mayor de 40.", "Verifique.");
                txtCierSort.Focus();
                validar = false;
            }

            else if (Convert.ToInt32(txtCierSort.Text) == 0)
            {
                MessageBox.Show("Cantidad de minutos para el cierre del sorteo debe ser diferente de cero.", "Verifique.");
                txtCierSort.Focus();
                validar = false;
            }
            else if (idUsu == 0)
            {
                if (string.IsNullOrEmpty(txtClave.Text))
                {
                    MessageBox.Show("Ingrese una clave.", "Verifique.");
                    txtClave.Focus();
                    validar = false;
                }

                else if (txtClave.Text.Length < 8)
                {
                    MessageBox.Show("La Clave debe ser igual o mayor a 8 digs.", "Verifique.");
                    txtClave.Focus();
                    validar = false;
                }
            }
            return validar;
        }

        public Boolean validMac()
        {
            Boolean validar = true;

            if (string.IsNullOrEmpty(txtMac.Text))
            {
                MessageBox.Show("Ingrese la dirección MAC del usuuario.", "Verifique.");
                txtMac.Focus();
                validar = false;
            }

            else if (txtMac.Text.Length != 12)
            {
                MessageBox.Show("La dirección MAC debe contener 12 digs.", "Verifique.");
                txtMac.Focus();
                validar = false;
            }
            return validar;
        }

        private void dgvGrup_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvGrup.RowCount > 0)
            {
                string rs = "", letRif = "";
                string nroRif = "", codTelf = "";
                string nroTelf = "", email = "";
                string direccion = "";
                string fechaReg = "", horaReg = "";
                int idStat=0;

                idGrup= Convert.ToInt32(dgvGrup.CurrentRow.Cells[0].Value.ToString());
                nombGrup = dgvGrup.CurrentRow.Cells[1].Value.ToString();
                rs = dgvGrup.CurrentRow.Cells[2].Value.ToString();
                letRif = dgvGrup.CurrentRow.Cells[3].Value.ToString().Substring(0, 1);
                nroRif = dgvGrup.CurrentRow.Cells[3].Value.ToString().Substring(1, 9);
                direccion = dgvGrup.CurrentRow.Cells[4].Value.ToString();
                codTelf = dgvGrup.CurrentRow.Cells[5].Value.ToString().Substring(0, 4);
                nroTelf = dgvGrup.CurrentRow.Cells[5].Value.ToString().Substring(4, 7);
                email = dgvGrup.CurrentRow.Cells[6].Value.ToString();
                fechaReg = dgvGrup.CurrentRow.Cells[7].Value.ToString();
                horaReg = dgvGrup.CurrentRow.Cells[8].Value.ToString();
                idStat = Convert.ToInt32(dgvGrup.CurrentRow.Cells[9].Value.ToString());

                txtNombGrup.Text = nombGrup;
                txtRs.Text = rs;
                cboLetRif.SelectedValue = letRif;
                txtNroRif.Text = nroRif;
                cboCodTelf.SelectedValue = codTelf;
                txtNroTlf.Text = nroTelf;
                txtDireccion.Text = direccion;
                txt_email.Text = email;
                lblFechReg.Text = fechaReg;
                lblHoraHeg.Text = horaReg;
                cboStatGrup.SelectedValue = idStat;

                txtNombGrup.Enabled = false;
                cboLetRif.Enabled = false;
                txtNroRif.Enabled = false;
                txt_email.Enabled = false;

                limpFrmUsu();
                dtDgvUsu = objFunc.busUsu(idGrup);
                dgvUsu.DataSource = dtDgvUsu;

                this.dgvUsu.Enabled = true;
                gp_usuarios.Enabled = true;
                gp_usuarios2.Enabled = true;
                txtClave.Focus();
            }
        }
        public string verf_cant_usuarios()
        {
            int cant_usuario;
            cant_usuario = Convert.ToInt32(objFunc.cantUsuGrup(idGrup));
            cant_usuario++;

            string msj = "";
            if (cant_usuario < 10) { msj = "0" + cant_usuario; }
            else if (cant_usuario >= 10) { msj = cant_usuario.ToString(); }
            return msj;
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            Boolean rsValid = true;
            rsValid = validFrmGrup();
            string rsGrdActGrup = "";

            if (rsValid == true)
            {
                string letRif = cboLetRif.SelectedValue.ToString();
                string rif = letRif + txtNroRif.Text;

                string codTlf = cboCodTelf.SelectedValue.ToString();
                string nroTlf = codTlf+ txtNroTlf.Text;
                int idStat = Convert.ToInt32(cboStatGrup.SelectedValue.ToString());

                rsGrdActGrup = objFunc.grdActGrupos(idGrup, txtNombGrup.Text.ToUpper(),
                                                    txtRs.Text.ToUpper(), rif, 
                                                    nroTlf, txtDireccion.Text,
                                                    txt_email.Text.ToUpper(), idStat);

                    if (rsGrdActGrup == "1")
                    {
                        MessageBox.Show("Se ha creado / actualizado el grupo de manera exitosa.", "Transacción Exitosa.");
                        dtDgvGrupos = objFunc.busGrup(idUsu, idPerf, idGrup);
                        this.dgvGrup.DataSource = dtDgvGrupos;
                        this.dgvUsu.DataSource = null;
                        limpFrmGrup();
                        limpFrmUsu();
                    }
                    else
                    {
                        MessageBox.Show("Ha Ocurrido el siguiente error: " + rsGrdActGrup, "Verifique");
                    }
            }
        }
        private void dgvUsu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsu.RowCount > 0)
            {
                int idDivisa, idPerfUsu;
                int idStatUsu, idPregSeg;
                string nombUsu, emailUsu;
                string fechRegUsu, horaRegUsu;
                string respSeg;
                float porcTaq, porcCasa;
                float porcSist;
                int mMaxJug, mMaxTck;
                int mXunid, multJug;
                int minJug, unidBase;
                int cierreSort;
                int idTipCuad;
                string macAddr;

                idUsu= Convert.ToInt32(dgvUsu.CurrentRow.Cells[0].Value.ToString());
                idGrupUsu= Convert.ToInt32(dgvUsu.CurrentRow.Cells[1].Value.ToString());
                idDivisa = Convert.ToInt32(dgvUsu.CurrentRow.Cells[2].Value.ToString());
                idPerfUsu = Convert.ToInt32(dgvUsu.CurrentRow.Cells[3].Value.ToString());
                idStatUsu = Convert.ToInt32(dgvUsu.CurrentRow.Cells[4].Value.ToString());
                nombUsu = dgvUsu.CurrentRow.Cells[5].Value.ToString();
                emailUsu = dgvUsu.CurrentRow.Cells[6].Value.ToString();
                fechRegUsu = dgvUsu.CurrentRow.Cells[9].Value.ToString();
                horaRegUsu = dgvUsu.CurrentRow.Cells[10].Value.ToString();
                idPregSeg = Convert.ToInt32(dgvUsu.CurrentRow.Cells[11].Value.ToString());
                respSeg = dgvUsu.CurrentRow.Cells[12].Value.ToString();
                porcTaq = Convert.ToSingle(dgvUsu.CurrentRow.Cells[13].Value.ToString());
                porcCasa = Convert.ToSingle(dgvUsu.CurrentRow.Cells[14].Value.ToString());
                porcSist = Convert.ToSingle(dgvUsu.CurrentRow.Cells[15].Value.ToString());
                mMaxJug = Convert.ToInt32(dgvUsu.CurrentRow.Cells[16].Value.ToString());
                mMaxTck = Convert.ToInt32(dgvUsu.CurrentRow.Cells[17].Value.ToString());
                mXunid = Convert.ToInt32(dgvUsu.CurrentRow.Cells[18].Value.ToString());
                multJug = Convert.ToInt32(dgvUsu.CurrentRow.Cells[19].Value.ToString());
                minJug = Convert.ToInt32(dgvUsu.CurrentRow.Cells[20].Value.ToString());
                unidBase = Convert.ToInt32(dgvUsu.CurrentRow.Cells[21].Value.ToString());
                cierreSort = Convert.ToInt32(dgvUsu.CurrentRow.Cells[22].Value.ToString());
                idTipCuad = Convert.ToInt32(dgvUsu.CurrentRow.Cells[23].Value.ToString());
                macAddr = dgvUsu.CurrentRow.Cells[24].Value.ToString();

                txtNombUsu.Text = nombUsu;
                txtEmail.Text = emailUsu;
                lblFechaReg.Text = fechRegUsu;
                lblHoraReg.Text = horaRegUsu;
                cboStatusUsuario.SelectedValue = idStatUsu;
                cboPerfUsu.SelectedValue = idPerfUsu;
                cboPregSeg.SelectedValue = idPregSeg;
                txtRespSeg.Text = respSeg;
                txtPorcTaq.Text = porcTaq.ToString();
                lblPorcCasa.Text = porcCasa.ToString();
                txtPorcSist.Text = porcSist.ToString();
                txtMontMaxJug.Text = mMaxJug.ToString();
                txtMontMaxTick.Text = mMaxTck.ToString();
                txtMontXunid.Text = mXunid.ToString();
                txtMultJUg.Text = multJug.ToString();
                txtMinJug.Text = minJug.ToString();
                txtUnidBase.Text = unidBase.ToString();
                txtCierSort.Text = cierreSort.ToString();
                cboTipoCuadre.SelectedValue = idTipCuad;
                cboDivisa.SelectedValue = idDivisa;
                txtMac.Text = macAddr;
                txtEmail.Focus();
            }
        }
        public void limpFrmGrup()
        {
            txtNombGrup.Text = "";
            txtRs.Text = "";
            cboLetRif.SelectedIndex = 0;
            txtNroRif.Text = "";
            cboCodTelf.SelectedIndex = 0;
            txtNroTlf.Text = "";
            txtDireccion.Text = "";
            txt_email.Text = "";
            lblFechReg.Text = "";
            lblHoraHeg.Text = "";
            cboStatGrup.SelectedIndex = 0;
            idGrup = 0;

            txtNombGrup.Enabled = true;
            cboLetRif.Enabled = true;
            txtNroRif.Enabled = true;
            txt_email.Enabled = true;
        }

        public void limpFrmUsu()
        {

            txtNombUsu.Text = "";
            txtClave.Text = "";
            txtEmail.Text = "";
            lblFechaReg.Text = "";
            lblHoraReg.Text = "";
            txtRespSeg.Text = "";
            txtPorcTaq.Text = "";
            txtPorcSist.Text = "";
            lblPorcCasa.Text = "";
            txtMontMaxJug.Text = "";
            txtMontMaxTick.Text = "";
            txtMontXunid.Text = "";
            txtMultJUg.Text= "";
            txtMinJug.Text= "";
            txtUnidBase.Text= "";
            txtCierSort.Text = "";
            txtMac.Text = "";
            cboStatusUsuario.SelectedIndex = 0;
            cboPerfUsu.SelectedIndex = 0;
            cboPregSeg.SelectedIndex = 0;
            cboTipoCuadre.SelectedIndex = 0;
            cboDivisa.SelectedIndex = 0;
            txtMac.Text = "";
            idUsu= 0;
        }

        private void txt_porc_taq_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPorcTaq.Text))
            {
                lblPorcCasa.Text = "100";
            }
            else if (!string.IsNullOrEmpty(txtPorcTaq.Text))
            {
                if (Convert.ToDouble(txtPorcTaq.Text) > 100)
                {
                    MessageBox.Show("Porcentaje taquilla no debe ser mayor de 100.", "Verifique.");
                    txtPorcTaq.Focus();
                    return;
                }
                else
                {
                    double porc_global = 100;
                    double porc_casa = 0;
                    lblPorcCasa.Text = (porc_global - Convert.ToDouble(txtPorcTaq.Text)).ToString();

                }
            }
        }

        private void txtNroTlf_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar)){  e.Handled = false; }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                { e.Handled = false;}
            //el resto de teclas pulsadas se desactivan 
            else{ e.Handled = true;}
        }

        private void txtNroRif_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            { e.Handled = false; }
            //el resto de teclas pulsadas se desactivan 
            else { e.Handled = true; }
        }

        private void txt_porc_taq_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            bool IsNeg = false;
            int nroDec = 0;
            int nroNeg = 0;
            for (int i = 0; i < txtPorcTaq.Text.Length; i++)
            {
                if (txtPorcTaq.Text[i] == '.')
                    IsDec = true;
                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }
            for (int i = 0; i < txtPorcTaq.Text.Length; i++)
            {
                if (txtPorcTaq.Text[i] == '-')
                    IsNeg = true;
            }
            if (IsNeg && nroNeg == 1)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else if (e.KeyChar == 45)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }


        private void txtDirMac_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;

            if (codigo == 13)
            {
                if (txtDirMac.Text.Length > 0)
                {
                    dtDgvMac = objFunc.busMacXfiltro(txtDirMac.Text);
                    this.dgvMac.DataSource = dtDgvMac;
                }
                else
                {
                    dtDgvMac = objFunc.busMac(idPerf, idGrup);
                    this.dgvMac.DataSource = dtDgvMac;
                }
            }
        }
        private void cbo_status_mac_filtro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idStatMac=0;
            idStatMac = Convert.ToInt32(cboStatusMacFiltro.SelectedValue.ToString());

            dtDgvMac = objFunc.busMacXfiltStat(idStatMac);
            this.dgvMac.DataSource = dtDgvMac;
        }
        private void dgvMac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMac.RowCount > 0)
            {

                string fechaRegMac ,horaRegMac;
                string nombGrupo, nombTaq;
                string statMac, macTaq;


                idMac = Convert.ToInt16(dgvMac.CurrentRow.Cells[0].Value.ToString());
                macTaq= dgvMac.CurrentRow.Cells[4].Value.ToString();
                fechaRegMac = dgvMac.CurrentRow.Cells[5].Value.ToString();
                horaRegMac  = dgvMac.CurrentRow.Cells[6].Value.ToString();
                statMac = dgvMac.CurrentRow.Cells[7].Value.ToString();
                nombGrupo = dgvMac.CurrentRow.Cells[8].Value.ToString();
                nombTaq = dgvMac.CurrentRow.Cells[9].Value.ToString();

                lblFechaRegMac.Text = fechaRegMac;
                lblHoraRegMac.Text = horaRegMac;
                lblNombGrupoMac.Text = nombGrupo;
                lblNombTaqMac.Text = nombTaq;
                lblMac.Text = macTaq;
                lblMacStatus.Text = statMac;
            }
        }

        private void btn_salir_mac_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_salir_grupos_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtMontMaxJug_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            { e.Handled = false; }
            //el resto de teclas pulsadas se desactivan 
            else { e.Handled = true; }
        }

        private void txtMontMaxTick_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            { e.Handled = false; }
            //el resto de teclas pulsadas se desactivan 
            else { e.Handled = true; }
        }

        private void txt_monto_xUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            { e.Handled = false; }
            //el resto de teclas pulsadas se desactivan 
            else { e.Handled = true; }
        }

        private void btn_salir_usuarios_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int idStat = Convert.ToInt32(cboStatus.SelectedValue.ToString());
            if (idMac == 0)
            {
                MessageBox.Show("Seleccione una mac.", "Verifique");
                return;
            }

            string rsGrdAsocMac = objFunc.actStatMac(idMac,idStat);
            if (rsGrdAsocMac == "1")
            {
                MessageBox.Show("Se ha cambiado el status de la mac de manera exitosa.", "Transacción Exitosa.");
                dtDgvMac = objFunc.busMac(idPerf, idGrup);
                this.dgvMac.DataSource = dtDgvMac;

                idMac = 0;
                cboStatus.SelectedIndex = 0;
                lblMacStatus.Text = "";
            }
            else
            {
                MessageBox.Show("Error contacte al administrador.", "verifique.");
            }
        }
        private void txtPorcSist_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            { e.Handled = false; }
            //el resto de teclas pulsadas se desactivan 
            else { e.Handled = true; }
        }

        private void txt_multiplo_jug_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            { e.Handled = false; }
            //el resto de teclas pulsadas se desactivan 
            else { e.Handled = true; }
        }

        private void txtMinJug_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            { e.Handled = false; }
            //el resto de teclas pulsadas se desactivan 
            else { e.Handled = true; }
        }

        private void txtUnidBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            { e.Handled = false; }
            //el resto de teclas pulsadas se desactivan 
            else { e.Handled = true; }
        }

        private void frm_grupos_usuarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            char caracter;
            int codigo;
            caracter = Convert.ToChar(e.KeyChar);
            codigo = (int)caracter;
            if (codigo == 27) { this.Close(); }
        }

        private void txtCierSort_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            { e.Handled = false; }
            //el resto de teclas pulsadas se desactivan 
            else { e.Handled = true; }
        }

        private void btnRegUsuario_Click(object sender, EventArgs e)
        {
            Boolean rsValidFrm = true;
            Boolean rsValidMac = true;
            rsValidFrm = validFrm();
            if (rsValidFrm==true)
            {
                string rsGrdActUsu = "";
                int idStat, idPerf;
                int idPregSeg, idTipoCuadre;
                int idDivisa;

                idStat = Convert.ToInt32(cboStatusUsuario.SelectedValue.ToString());
                idPerf= Convert.ToInt32(cboPerfUsu.SelectedValue.ToString());
                idPregSeg = Convert.ToInt32(cboPregSeg.SelectedValue.ToString());
                idTipoCuadre = Convert.ToInt32(cboTipoCuadre.SelectedValue.ToString());
                idDivisa = Convert.ToInt32(cboDivisa.SelectedValue.ToString());

                if (idPerf == 1) 
                {
                    rsValidMac = validMac(); 
                    if (rsValidMac == false) { return; }
                }

                rsGrdActUsu = objFunc.grdActUsuarios(idGrup, idUsu, idDivisa,
                                                        txtNombUsu.Text, txtClave.Text,
                                                        txtEmail.Text, idStat,
                                                        idPerf, idPregSeg,
                                                         txtRespSeg.Text, txtPorcTaq.Text,
                                                        lblPorcCasa.Text, txtPorcSist.Text,
                                                        Convert.ToInt32(txtMontMaxJug.Text),
                                                        Convert.ToInt32(txtMontMaxTick.Text),
                                                        Convert.ToInt32(txtMontXunid.Text),
                                                        idTipoCuadre,
                                                        Convert.ToInt32(txtMultJUg.Text),
                                                        Convert.ToInt32(txtMinJug.Text),
                                                        Convert.ToInt32(txtUnidBase.Text),
                                                        Convert.ToInt32(txtCierSort.Text),
                                                        txtMac.Text.ToUpper());

                //MessageBox.Show(rs_grd_act_usuarios);
                if (rsGrdActUsu == "1")
                {
                    MessageBox.Show("Se ha creado / actualizado el usuario de manera exitosa.", "Transacción Exitosa.");
                    dtDgvUsu = objFunc.busUsu(idGrup);
                    dgvUsu.DataSource = dtDgvUsu;
                    limpFrmUsu();
                }
                else
                {
                    MessageBox.Show("Ha Ocurrido el siguiente error: "+ rsGrdActUsu, "Verifique.");
                }
            }

        }
        }
    
    }


