namespace ventas_loteria
{
    partial class frm_proc_result_loteria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_loteria = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvSort = new System.Windows.Forms.DataGridView();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wkIniFrm = new System.ComponentModel.BackgroundWorker();
            this.gp_cant_jug = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvJug = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbInfProcRs = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pbInfProcRs = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cboTipProc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.wkProcRsMan = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblMsjInf = new System.Windows.Forms.Label();
            this.wkProcRsAut = new System.ComponentModel.BackgroundWorker();
            this.gpReult = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnRs = new System.Windows.Forms.Button();
            this.cboLot = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gpMsjErr = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblMsjErr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.wkProcJugAut = new System.ComponentModel.BackgroundWorker();
            this.gb_loteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSort)).BeginInit();
            this.gp_cant_jug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJug)).BeginInit();
            this.gbInfProcRs.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.gpReult.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.gpMsjErr.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_loteria
            // 
            this.gb_loteria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gb_loteria.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gb_loteria.Controls.Add(this.dgvSort);
            this.gb_loteria.DrawTitleBox = false;
            this.gb_loteria.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_loteria.Location = new System.Drawing.Point(8, 133);
            this.gb_loteria.Name = "gb_loteria";
            this.gb_loteria.Size = new System.Drawing.Size(236, 380);
            // 
            // 
            // 
            this.gb_loteria.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gb_loteria.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gb_loteria.Style.BackColorGradientAngle = 90;
            this.gb_loteria.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_loteria.Style.BorderBottomWidth = 3;
            this.gb_loteria.Style.BorderColor = System.Drawing.Color.White;
            this.gb_loteria.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_loteria.Style.BorderLeftWidth = 3;
            this.gb_loteria.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_loteria.Style.BorderRightWidth = 3;
            this.gb_loteria.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_loteria.Style.BorderTopWidth = 3;
            this.gb_loteria.Style.CornerDiameter = 4;
            this.gb_loteria.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gb_loteria.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_loteria.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.gb_loteria.Style.TextColor = System.Drawing.Color.Black;
            this.gb_loteria.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.gb_loteria.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gb_loteria.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gb_loteria.TabIndex = 195;
            this.gb_loteria.Text = "Sorteos";
            // 
            // dgvSort
            // 
            this.dgvSort.BackgroundColor = System.Drawing.Color.White;
            this.dgvSort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSort.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSort.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSort.ColumnHeadersHeight = 35;
            this.dgvSort.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column16,
            this.Column7,
            this.Column1,
            this.Column10,
            this.Column11});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSort.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSort.Location = new System.Drawing.Point(3, 3);
            this.dgvSort.Name = "dgvSort";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSort.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSort.RowTemplate.Height = 35;
            this.dgvSort.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSort.Size = new System.Drawing.Size(224, 342);
            this.dgvSort.TabIndex = 193;
            this.dgvSort.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSort_CellClick);
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "id_loteria";
            this.Column15.HeaderText = "id_loteria";
            this.Column15.Name = "Column15";
            this.Column15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column15.Visible = false;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "nomb_loteria";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.Column16.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column16.HeaderText = "Loteria";
            this.Column16.Name = "Column16";
            this.Column16.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column16.Width = 205;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "codig_max_product";
            this.Column7.HeaderText = "codig_max_product";
            this.Column7.Name = "Column7";
            this.Column7.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id_sorteo";
            this.Column1.HeaderText = "id_sorteo";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "hora_sorteo";
            this.Column10.HeaderText = "hora_sorteo";
            this.Column10.Name = "Column10";
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "nomb_sorteo";
            this.Column11.HeaderText = "nomb_sorteo";
            this.Column11.Name = "Column11";
            this.Column11.Visible = false;
            this.Column11.Width = 160;
            // 
            // wkIniFrm
            // 
            this.wkIniFrm.WorkerReportsProgress = true;
            this.wkIniFrm.WorkerSupportsCancellation = true;
            // 
            // gp_cant_jug
            // 
            this.gp_cant_jug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gp_cant_jug.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gp_cant_jug.Controls.Add(this.dgvJug);
            this.gp_cant_jug.DrawTitleBox = false;
            this.gp_cant_jug.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_cant_jug.Location = new System.Drawing.Point(251, 130);
            this.gp_cant_jug.Name = "gp_cant_jug";
            this.gp_cant_jug.Size = new System.Drawing.Size(679, 383);
            // 
            // 
            // 
            this.gp_cant_jug.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gp_cant_jug.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gp_cant_jug.Style.BackColorGradientAngle = 90;
            this.gp_cant_jug.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_cant_jug.Style.BorderBottomWidth = 3;
            this.gp_cant_jug.Style.BorderColor = System.Drawing.Color.White;
            this.gp_cant_jug.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_cant_jug.Style.BorderLeftWidth = 3;
            this.gp_cant_jug.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_cant_jug.Style.BorderRightWidth = 3;
            this.gp_cant_jug.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_cant_jug.Style.BorderTopWidth = 3;
            this.gp_cant_jug.Style.CornerDiameter = 4;
            this.gp_cant_jug.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gp_cant_jug.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_cant_jug.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.gp_cant_jug.Style.TextColor = System.Drawing.Color.Black;
            this.gp_cant_jug.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.gp_cant_jug.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gp_cant_jug.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gp_cant_jug.TabIndex = 197;
            this.gp_cant_jug.Text = "Jugadas";
            // 
            // dgvJug
            // 
            this.dgvJug.BackgroundColor = System.Drawing.Color.White;
            this.dgvJug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvJug.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJug.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvJug.ColumnHeadersHeight = 35;
            this.dgvJug.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column17,
            this.Column18,
            this.Column8,
            this.Column12,
            this.dataGridViewTextBoxColumn4,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column9,
            this.Column14,
            this.Column13});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvJug.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvJug.Location = new System.Drawing.Point(7, 3);
            this.dgvJug.Name = "dgvJug";
            this.dgvJug.RowTemplate.Height = 35;
            this.dgvJug.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJug.Size = new System.Drawing.Size(661, 347);
            this.dgvJug.TabIndex = 194;
            this.dgvJug.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvJug_CellFormatting);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "id_det_jug";
            this.Column6.HeaderText = "id_det_jug";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "id_loteria";
            this.Column17.HeaderText = "id_loteria";
            this.Column17.Name = "Column17";
            this.Column17.Visible = false;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "id_sorteo";
            this.Column18.HeaderText = "id_sorteo";
            this.Column18.Name = "Column18";
            this.Column18.Visible = false;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "nro_ticket";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column8.HeaderText = "Ticket";
            this.Column8.Name = "Column8";
            this.Column8.Width = 70;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "nomb_usuario";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column12.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column12.HeaderText = "Usuario";
            this.Column12.Name = "Column12";
            this.Column12.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "abrev_loteria";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn4.HeaderText = "nomb_loteria";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 40;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "nomb_sorteo";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column5.HeaderText = "Sorteo";
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "codigo_jugada";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column2.HeaderText = "codigo_jugada";
            this.Column2.Name = "Column2";
            this.Column2.Width = 30;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "nomb_product";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column3.HeaderText = "nomb_product";
            this.Column3.Name = "Column3";
            this.Column3.Width = 90;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "monto";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Format = "N2";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column4.HeaderText = "Monto";
            this.Column4.Name = "Column4";
            this.Column4.Width = 80;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "nmb_status_ticket";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column9.HeaderText = "Status";
            this.Column9.Name = "Column9";
            this.Column9.Width = 130;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "error";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column14.DefaultCellStyle = dataGridViewCellStyle14;
            this.Column14.HeaderText = "error";
            this.Column14.Name = "Column14";
            this.Column14.Visible = false;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "cod_result";
            this.Column13.HeaderText = "cod_result";
            this.Column13.Name = "Column13";
            this.Column13.Visible = false;
            // 
            // gbInfProcRs
            // 
            this.gbInfProcRs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gbInfProcRs.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gbInfProcRs.Controls.Add(this.pbInfProcRs);
            this.gbInfProcRs.DrawTitleBox = false;
            this.gbInfProcRs.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.gbInfProcRs.Location = new System.Drawing.Point(369, -1);
            this.gbInfProcRs.Name = "gbInfProcRs";
            this.gbInfProcRs.Size = new System.Drawing.Size(250, 67);
            // 
            // 
            // 
            this.gbInfProcRs.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gbInfProcRs.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gbInfProcRs.Style.BackColorGradientAngle = 90;
            this.gbInfProcRs.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbInfProcRs.Style.BorderBottomWidth = 3;
            this.gbInfProcRs.Style.BorderColor = System.Drawing.Color.White;
            this.gbInfProcRs.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbInfProcRs.Style.BorderLeftWidth = 3;
            this.gbInfProcRs.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbInfProcRs.Style.BorderRightWidth = 3;
            this.gbInfProcRs.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbInfProcRs.Style.BorderTopWidth = 3;
            this.gbInfProcRs.Style.CornerDiameter = 4;
            this.gbInfProcRs.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gbInfProcRs.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInfProcRs.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.gbInfProcRs.Style.TextColor = System.Drawing.Color.Black;
            this.gbInfProcRs.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.gbInfProcRs.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gbInfProcRs.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gbInfProcRs.TabIndex = 196;
            this.gbInfProcRs.Text = "Jug:0. Gand:0. Perd:0.";
            // 
            // pbInfProcRs
            // 
            // 
            // 
            // 
            this.pbInfProcRs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pbInfProcRs.Location = new System.Drawing.Point(3, 5);
            this.pbInfProcRs.Name = "pbInfProcRs";
            this.pbInfProcRs.Size = new System.Drawing.Size(238, 27);
            this.pbInfProcRs.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.pbInfProcRs.TabIndex = 193;
            this.pbInfProcRs.Text = "pb";
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.dtpFecha);
            this.groupPanel3.Controls.Add(this.cboTipProc);
            this.groupPanel3.Controls.Add(this.label1);
            this.groupPanel3.Controls.Add(this.txtCod);
            this.groupPanel3.DrawTitleBox = false;
            this.groupPanel3.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.groupPanel3.Location = new System.Drawing.Point(8, -1);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(355, 67);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel3.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 3;
            this.groupPanel3.Style.BorderColor = System.Drawing.Color.White;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 3;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 3;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 3;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel3.Style.TextColor = System.Drawing.Color.Black;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 212;
            this.groupPanel3.Text = "Resultado";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(148, 3);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(123, 29);
            this.dtpFecha.TabIndex = 273;
            // 
            // cboTipProc
            // 
            this.cboTipProc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipProc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipProc.FormattingEnabled = true;
            this.cboTipProc.Location = new System.Drawing.Point(4, 5);
            this.cboTipProc.Margin = new System.Windows.Forms.Padding(4);
            this.cboTipProc.Name = "cboTipProc";
            this.cboTipProc.Size = new System.Drawing.Size(137, 27);
            this.cboTipProc.TabIndex = 208;
            this.cboTipProc.SelectionChangeCommitted += new System.EventHandler(this.cboTipProc_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(27, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 21);
            this.label1.TabIndex = 1;
            // 
            // txtCod
            // 
            this.txtCod.Location = new System.Drawing.Point(277, 3);
            this.txtCod.MaxLength = 2;
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(69, 29);
            this.txtCod.TabIndex = 0;
            this.txtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCod_KeyPress);
            // 
            // wkProcRsMan
            // 
            this.wkProcRsMan.WorkerReportsProgress = true;
            this.wkProcRsMan.WorkerSupportsCancellation = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblMsjInf
            // 
            this.lblMsjInf.AutoSize = true;
            this.lblMsjInf.BackColor = System.Drawing.Color.Transparent;
            this.lblMsjInf.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsjInf.ForeColor = System.Drawing.Color.Black;
            this.lblMsjInf.Location = new System.Drawing.Point(5, 3);
            this.lblMsjInf.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMsjInf.Name = "lblMsjInf";
            this.lblMsjInf.Size = new System.Drawing.Size(80, 22);
            this.lblMsjInf.TabIndex = 215;
            this.lblMsjInf.Text = "msj_info";
            // 
            // wkProcRsAut
            // 
            this.wkProcRsAut.WorkerReportsProgress = true;
            this.wkProcRsAut.WorkerSupportsCancellation = true;
            // 
            // gpReult
            // 
            this.gpReult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gpReult.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gpReult.Controls.Add(this.lblMsjInf);
            this.gpReult.DrawTitleBox = false;
            this.gpReult.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.gpReult.Location = new System.Drawing.Point(625, -1);
            this.gpReult.Name = "gpReult";
            this.gpReult.Size = new System.Drawing.Size(305, 67);
            // 
            // 
            // 
            this.gpReult.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gpReult.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gpReult.Style.BackColorGradientAngle = 90;
            this.gpReult.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpReult.Style.BorderBottomWidth = 3;
            this.gpReult.Style.BorderColor = System.Drawing.Color.White;
            this.gpReult.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpReult.Style.BorderLeftWidth = 3;
            this.gpReult.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpReult.Style.BorderRightWidth = 3;
            this.gpReult.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpReult.Style.BorderTopWidth = 3;
            this.gpReult.Style.CornerDiameter = 4;
            this.gpReult.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gpReult.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpReult.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.gpReult.Style.TextColor = System.Drawing.Color.Black;
            this.gpReult.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.gpReult.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gpReult.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpReult.TabIndex = 197;
            this.gpReult.Text = "Loteria:";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnRs);
            this.groupPanel2.Controls.Add(this.cboLot);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.DrawTitleBox = false;
            this.groupPanel2.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.groupPanel2.Location = new System.Drawing.Point(8, 65);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(236, 67);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel2.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 3;
            this.groupPanel2.Style.BorderColor = System.Drawing.Color.White;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 3;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 3;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 3;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel2.Style.TextColor = System.Drawing.Color.Black;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 215;
            this.groupPanel2.Text = "Loterias";
            // 
            // btnRs
            // 
            this.btnRs.BackColor = System.Drawing.Color.White;
            this.btnRs.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRs.ForeColor = System.Drawing.Color.Black;
            this.btnRs.Location = new System.Drawing.Point(197, 3);
            this.btnRs.Name = "btnRs";
            this.btnRs.Size = new System.Drawing.Size(30, 30);
            this.btnRs.TabIndex = 209;
            this.btnRs.Text = "R";
            this.btnRs.UseVisualStyleBackColor = false;
            this.btnRs.Click += new System.EventHandler(this.btnRs_Click);
            // 
            // cboLot
            // 
            this.cboLot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLot.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLot.FormattingEnabled = true;
            this.cboLot.Location = new System.Drawing.Point(4, 4);
            this.cboLot.Margin = new System.Windows.Forms.Padding(4);
            this.cboLot.Name = "cboLot";
            this.cboLot.Size = new System.Drawing.Size(190, 27);
            this.cboLot.TabIndex = 208;
            this.cboLot.SelectionChangeCommitted += new System.EventHandler(this.cboLot_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(27, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 21);
            this.label2.TabIndex = 1;
            // 
            // gpMsjErr
            // 
            this.gpMsjErr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gpMsjErr.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gpMsjErr.Controls.Add(this.lblMsjErr);
            this.gpMsjErr.Controls.Add(this.label3);
            this.gpMsjErr.DrawTitleBox = false;
            this.gpMsjErr.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.gpMsjErr.Location = new System.Drawing.Point(251, 65);
            this.gpMsjErr.Name = "gpMsjErr";
            this.gpMsjErr.Size = new System.Drawing.Size(679, 67);
            // 
            // 
            // 
            this.gpMsjErr.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gpMsjErr.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gpMsjErr.Style.BackColorGradientAngle = 90;
            this.gpMsjErr.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpMsjErr.Style.BorderBottomWidth = 3;
            this.gpMsjErr.Style.BorderColor = System.Drawing.Color.White;
            this.gpMsjErr.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpMsjErr.Style.BorderLeftWidth = 3;
            this.gpMsjErr.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpMsjErr.Style.BorderRightWidth = 3;
            this.gpMsjErr.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpMsjErr.Style.BorderTopWidth = 3;
            this.gpMsjErr.Style.CornerDiameter = 4;
            this.gpMsjErr.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gpMsjErr.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpMsjErr.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.gpMsjErr.Style.TextColor = System.Drawing.Color.Black;
            this.gpMsjErr.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.gpMsjErr.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gpMsjErr.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpMsjErr.TabIndex = 216;
            this.gpMsjErr.Text = "¡ Verifique !";
            // 
            // lblMsjErr
            // 
            this.lblMsjErr.AutoSize = true;
            this.lblMsjErr.BackColor = System.Drawing.Color.Transparent;
            this.lblMsjErr.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsjErr.ForeColor = System.Drawing.Color.Black;
            this.lblMsjErr.Location = new System.Drawing.Point(5, 5);
            this.lblMsjErr.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMsjErr.Name = "lblMsjErr";
            this.lblMsjErr.Size = new System.Drawing.Size(80, 22);
            this.lblMsjErr.TabIndex = 216;
            this.lblMsjErr.Text = "msj_info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(27, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 21);
            this.label3.TabIndex = 1;
            // 
            // wkProcJugAut
            // 
            this.wkProcJugAut.WorkerReportsProgress = true;
            this.wkProcJugAut.WorkerSupportsCancellation = true;
            // 
            // frm_proc_result_loteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(934, 517);
            this.ControlBox = false;
            this.Controls.Add(this.gpMsjErr);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.gpReult);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.gbInfProcRs);
            this.Controls.Add(this.gp_cant_jug);
            this.Controls.Add(this.gb_loteria);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_proc_result_loteria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_proc_result_loteria";
            this.Load += new System.EventHandler(this.frm_proc_result_loteria_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_proc_result_loteria_KeyPress);
            this.gb_loteria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSort)).EndInit();
            this.gp_cant_jug.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJug)).EndInit();
            this.gbInfProcRs.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.gpReult.ResumeLayout(false);
            this.gpReult.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.gpMsjErr.ResumeLayout(false);
            this.gpMsjErr.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel gb_loteria;
        private System.Windows.Forms.DataGridView dgvSort;
        private System.ComponentModel.BackgroundWorker wkIniFrm;
        private DevComponents.DotNetBar.Controls.GroupPanel gp_cant_jug;
        private System.Windows.Forms.DataGridView dgvJug;
        private DevComponents.DotNetBar.Controls.GroupPanel gbInfProcRs;
        private DevComponents.DotNetBar.Controls.ProgressBarX pbInfProcRs;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCod;
        private System.ComponentModel.BackgroundWorker wkProcRsMan;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cboTipProc;
        private System.Windows.Forms.Label lblMsjInf;
        private System.ComponentModel.BackgroundWorker wkProcRsAut;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private DevComponents.DotNetBar.Controls.GroupPanel gpReult;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.ComboBox cboLot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private DevComponents.DotNetBar.Controls.GroupPanel gpMsjErr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMsjErr;
        private System.ComponentModel.BackgroundWorker wkProcJugAut;
    }
}