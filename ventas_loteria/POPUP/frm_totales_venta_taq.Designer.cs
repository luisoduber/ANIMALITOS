namespace ventas_loteria
{
    partial class frm_totales_venta_taq
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_totales_venta = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvTotVentas = new System.Windows.Forms.DataGridView();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gp_filtro_mov_venta = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.dtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.work_inicia_frm = new System.ComponentModel.BackgroundWorker();
            this.gp_cuadre_caja = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMontoBal = new System.Windows.Forms.Label();
            this.lblMontoSal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMontoEnt = new System.Windows.Forms.Label();
            this.lblMontoTaq = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.gb_totales_venta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotVentas)).BeginInit();
            this.gp_filtro_mov_venta.SuspendLayout();
            this.gp_cuadre_caja.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_totales_venta
            // 
            this.gb_totales_venta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gb_totales_venta.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gb_totales_venta.Controls.Add(this.dgvTotVentas);
            this.gb_totales_venta.DrawTitleBox = false;
            this.gb_totales_venta.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.gb_totales_venta.Location = new System.Drawing.Point(12, 3);
            this.gb_totales_venta.Name = "gb_totales_venta";
            this.gb_totales_venta.Size = new System.Drawing.Size(725, 474);
            // 
            // 
            // 
            this.gb_totales_venta.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gb_totales_venta.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gb_totales_venta.Style.BackColorGradientAngle = 90;
            this.gb_totales_venta.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_totales_venta.Style.BorderBottomWidth = 3;
            this.gb_totales_venta.Style.BorderColor = System.Drawing.Color.White;
            this.gb_totales_venta.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_totales_venta.Style.BorderLeftWidth = 3;
            this.gb_totales_venta.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_totales_venta.Style.BorderRightWidth = 3;
            this.gb_totales_venta.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_totales_venta.Style.BorderTopWidth = 3;
            this.gb_totales_venta.Style.CornerDiameter = 4;
            this.gb_totales_venta.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gb_totales_venta.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_totales_venta.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.gb_totales_venta.Style.TextColor = System.Drawing.Color.Black;
            this.gb_totales_venta.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.gb_totales_venta.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gb_totales_venta.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gb_totales_venta.TabIndex = 203;
            this.gb_totales_venta.Text = "Totalizado Ventas";
            // 
            // dgvTotVentas
            // 
            this.dgvTotVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvTotVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTotVentas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTotVentas.ColumnHeadersHeight = 35;
            this.dgvTotVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column5,
            this.Column3,
            this.Column4,
            this.Column2,
            this.Column1});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTotVentas.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTotVentas.Location = new System.Drawing.Point(3, 3);
            this.dgvTotVentas.Name = "dgvTotVentas";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotVentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvTotVentas.RowTemplate.Height = 35;
            this.dgvTotVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTotVentas.Size = new System.Drawing.Size(710, 437);
            this.dgvTotVentas.TabIndex = 193;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "fecha";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column15.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column15.HeaderText = "Fecha";
            this.Column15.Name = "Column15";
            this.Column15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "nomb_dia";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column5.HeaderText = "Dia";
            this.Column5.Name = "Column5";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "monto_entrada";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "Ventas";
            this.Column3.Name = "Column3";
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "monto_salida";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N2";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column4.HeaderText = "Premios";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "monto_taq";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "N2";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column2.HeaderText = "Comision";
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "monto_utilidad";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N2";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column1.HeaderText = "Utilidad";
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // gp_filtro_mov_venta
            // 
            this.gp_filtro_mov_venta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gp_filtro_mov_venta.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gp_filtro_mov_venta.Controls.Add(this.dtpFechaFin);
            this.gp_filtro_mov_venta.Controls.Add(this.btn_buscar);
            this.gp_filtro_mov_venta.Controls.Add(this.dtpFechaIni);
            this.gp_filtro_mov_venta.Controls.Add(this.label8);
            this.gp_filtro_mov_venta.Controls.Add(this.label10);
            this.gp_filtro_mov_venta.DrawTitleBox = false;
            this.gp_filtro_mov_venta.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.gp_filtro_mov_venta.Location = new System.Drawing.Point(743, 3);
            this.gp_filtro_mov_venta.Name = "gp_filtro_mov_venta";
            this.gp_filtro_mov_venta.Size = new System.Drawing.Size(155, 197);
            // 
            // 
            // 
            this.gp_filtro_mov_venta.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gp_filtro_mov_venta.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gp_filtro_mov_venta.Style.BackColorGradientAngle = 90;
            this.gp_filtro_mov_venta.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_filtro_mov_venta.Style.BorderBottomWidth = 3;
            this.gp_filtro_mov_venta.Style.BorderColor = System.Drawing.Color.White;
            this.gp_filtro_mov_venta.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_filtro_mov_venta.Style.BorderLeftWidth = 3;
            this.gp_filtro_mov_venta.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_filtro_mov_venta.Style.BorderRightWidth = 3;
            this.gp_filtro_mov_venta.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_filtro_mov_venta.Style.BorderTopWidth = 3;
            this.gp_filtro_mov_venta.Style.CornerDiameter = 4;
            this.gp_filtro_mov_venta.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gp_filtro_mov_venta.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_filtro_mov_venta.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.gp_filtro_mov_venta.Style.TextColor = System.Drawing.Color.Black;
            this.gp_filtro_mov_venta.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.gp_filtro_mov_venta.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gp_filtro_mov_venta.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gp_filtro_mov_venta.TabIndex = 202;
            this.gp_filtro_mov_venta.Text = "Ventas Diarias";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Location = new System.Drawing.Point(13, 89);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(123, 26);
            this.dtpFechaFin.TabIndex = 179;
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.White;
            this.btn_buscar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.Location = new System.Drawing.Point(13, 123);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(122, 29);
            this.btn_buscar.TabIndex = 5;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaIni.Location = new System.Drawing.Point(13, 30);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(123, 26);
            this.dtpFechaIni.TabIndex = 178;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(13, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 22);
            this.label8.TabIndex = 3;
            this.label8.Text = "Fecha Final";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(19, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 22);
            this.label10.TabIndex = 1;
            this.label10.Text = "Fecha Inicial";
            // 
            // work_inicia_frm
            // 
            this.work_inicia_frm.WorkerReportsProgress = true;
            this.work_inicia_frm.WorkerSupportsCancellation = true;
            // 
            // gp_cuadre_caja
            // 
            this.gp_cuadre_caja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gp_cuadre_caja.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gp_cuadre_caja.Controls.Add(this.label4);
            this.gp_cuadre_caja.Controls.Add(this.lblMontoBal);
            this.gp_cuadre_caja.Controls.Add(this.lblMontoSal);
            this.gp_cuadre_caja.Controls.Add(this.label3);
            this.gp_cuadre_caja.Controls.Add(this.lblMontoEnt);
            this.gp_cuadre_caja.Controls.Add(this.lblMontoTaq);
            this.gp_cuadre_caja.Controls.Add(this.label1);
            this.gp_cuadre_caja.Controls.Add(this.lbl);
            this.gp_cuadre_caja.DrawTitleBox = false;
            this.gp_cuadre_caja.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.gp_cuadre_caja.Location = new System.Drawing.Point(743, 206);
            this.gp_cuadre_caja.Name = "gp_cuadre_caja";
            this.gp_cuadre_caja.Size = new System.Drawing.Size(155, 271);
            // 
            // 
            // 
            this.gp_cuadre_caja.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gp_cuadre_caja.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gp_cuadre_caja.Style.BackColorGradientAngle = 90;
            this.gp_cuadre_caja.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_cuadre_caja.Style.BorderBottomWidth = 3;
            this.gp_cuadre_caja.Style.BorderColor = System.Drawing.Color.White;
            this.gp_cuadre_caja.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_cuadre_caja.Style.BorderLeftWidth = 3;
            this.gp_cuadre_caja.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_cuadre_caja.Style.BorderRightWidth = 3;
            this.gp_cuadre_caja.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_cuadre_caja.Style.BorderTopWidth = 3;
            this.gp_cuadre_caja.Style.CornerDiameter = 4;
            this.gp_cuadre_caja.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gp_cuadre_caja.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_cuadre_caja.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.gp_cuadre_caja.Style.TextColor = System.Drawing.Color.Black;
            this.gp_cuadre_caja.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.gp_cuadre_caja.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gp_cuadre_caja.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gp_cuadre_caja.TabIndex = 204;
            this.gp_cuadre_caja.Text = "Cuadre Ventas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 127);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 22);
            this.label4.TabIndex = 212;
            this.label4.Text = "Comisión";
            // 
            // lblMontoBal
            // 
            this.lblMontoBal.BackColor = System.Drawing.Color.White;
            this.lblMontoBal.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoBal.ForeColor = System.Drawing.Color.Black;
            this.lblMontoBal.Location = new System.Drawing.Point(9, 149);
            this.lblMontoBal.Name = "lblMontoBal";
            this.lblMontoBal.Size = new System.Drawing.Size(124, 25);
            this.lblMontoBal.TabIndex = 211;
            this.lblMontoBal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMontoSal
            // 
            this.lblMontoSal.BackColor = System.Drawing.Color.White;
            this.lblMontoSal.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoSal.ForeColor = System.Drawing.Color.Black;
            this.lblMontoSal.Location = new System.Drawing.Point(13, 97);
            this.lblMontoSal.Name = "lblMontoSal";
            this.lblMontoSal.Size = new System.Drawing.Size(124, 25);
            this.lblMontoSal.TabIndex = 210;
            this.lblMontoSal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 22);
            this.label3.TabIndex = 209;
            this.label3.Text = "Premios";
            // 
            // lblMontoEnt
            // 
            this.lblMontoEnt.BackColor = System.Drawing.Color.White;
            this.lblMontoEnt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoEnt.ForeColor = System.Drawing.Color.Black;
            this.lblMontoEnt.Location = new System.Drawing.Point(13, 41);
            this.lblMontoEnt.Name = "lblMontoEnt";
            this.lblMontoEnt.Size = new System.Drawing.Size(124, 25);
            this.lblMontoEnt.TabIndex = 208;
            this.lblMontoEnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMontoTaq
            // 
            this.lblMontoTaq.BackColor = System.Drawing.Color.White;
            this.lblMontoTaq.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTaq.ForeColor = System.Drawing.Color.Black;
            this.lblMontoTaq.Location = new System.Drawing.Point(9, 202);
            this.lblMontoTaq.Name = "lblMontoTaq";
            this.lblMontoTaq.Size = new System.Drawing.Size(124, 25);
            this.lblMontoTaq.TabIndex = 207;
            this.lblMontoTaq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 22);
            this.label1.TabIndex = 206;
            this.label1.Text = "Ventas";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Black;
            this.lbl.Location = new System.Drawing.Point(12, 181);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(74, 22);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Utilidad";
            // 
            // frm_totales_venta_taq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(904, 482);
            this.ControlBox = false;
            this.Controls.Add(this.gp_cuadre_caja);
            this.Controls.Add(this.gb_totales_venta);
            this.Controls.Add(this.gp_filtro_mov_venta);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_totales_venta_taq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_totales_venta_taq";
            this.Load += new System.EventHandler(this.frm_totales_venta_taq_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_totales_venta_taq_KeyPress);
            this.gb_totales_venta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotVentas)).EndInit();
            this.gp_filtro_mov_venta.ResumeLayout(false);
            this.gp_filtro_mov_venta.PerformLayout();
            this.gp_cuadre_caja.ResumeLayout(false);
            this.gp_cuadre_caja.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel gb_totales_venta;
        private System.Windows.Forms.DataGridView dgvTotVentas;
        private DevComponents.DotNetBar.Controls.GroupPanel gp_filtro_mov_venta;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.DateTimePicker dtpFechaIni;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.ComponentModel.BackgroundWorker work_inicia_frm;
        private DevComponents.DotNetBar.Controls.GroupPanel gp_cuadre_caja;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMontoBal;
        private System.Windows.Forms.Label lblMontoSal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMontoEnt;
        private System.Windows.Forms.Label lblMontoTaq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}