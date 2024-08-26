namespace ventas_loteria
{
    partial class frm_cuadre_taq_gral
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_cuadre_taq_gral));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_totales_venta = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgv_cuadre_taq = new System.Windows.Forms.DataGridView();
            this.gp_filtro_mov_venta = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_grupos = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cbo_taquilla = new System.Windows.Forms.ComboBox();
            this.btn_salir = new System.Windows.Forms.Button();
            this.dtp_fecha_fin = new System.Windows.Forms.DateTimePicker();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.dtp_fecha_ini = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.work_inicia_frm = new System.ComponentModel.BackgroundWorker();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_totales_venta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cuadre_taq)).BeginInit();
            this.gp_filtro_mov_venta.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_totales_venta
            // 
            this.gb_totales_venta.BackColor = System.Drawing.Color.Black;
            this.gb_totales_venta.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gb_totales_venta.Controls.Add(this.dgv_cuadre_taq);
            this.gb_totales_venta.DrawTitleBox = false;
            this.gb_totales_venta.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_totales_venta.Location = new System.Drawing.Point(13, 113);
            this.gb_totales_venta.Margin = new System.Windows.Forms.Padding(4);
            this.gb_totales_venta.Name = "gb_totales_venta";
            this.gb_totales_venta.Size = new System.Drawing.Size(835, 431);
            // 
            // 
            // 
            this.gb_totales_venta.Style.BackColor = System.Drawing.Color.Transparent;
            this.gb_totales_venta.Style.BackColor2 = System.Drawing.Color.Transparent;
            this.gb_totales_venta.Style.BackColorGradientAngle = 90;
            this.gb_totales_venta.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_totales_venta.Style.BorderBottomWidth = 3;
            this.gb_totales_venta.Style.BorderColor = System.Drawing.Color.Gold;
            this.gb_totales_venta.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_totales_venta.Style.BorderLeftWidth = 3;
            this.gb_totales_venta.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_totales_venta.Style.BorderRightWidth = 3;
            this.gb_totales_venta.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_totales_venta.Style.BorderTopWidth = 3;
            this.gb_totales_venta.Style.CornerDiameter = 4;
            this.gb_totales_venta.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gb_totales_venta.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_totales_venta.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.gb_totales_venta.Style.TextColor = System.Drawing.Color.LightGray;
            this.gb_totales_venta.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.gb_totales_venta.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gb_totales_venta.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gb_totales_venta.TabIndex = 205;
            this.gb_totales_venta.Text = "Detalles Cuadre Taquillas";
            // 
            // dgv_cuadre_taq
            // 
            this.dgv_cuadre_taq.BackgroundColor = System.Drawing.Color.Gold;
            this.dgv_cuadre_taq.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_cuadre_taq.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_cuadre_taq.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_cuadre_taq.ColumnHeadersHeight = 35;
            this.dgv_cuadre_taq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column3,
            this.Column4,
            this.Column1,
            this.Column2});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(135)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_cuadre_taq.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_cuadre_taq.Location = new System.Drawing.Point(4, 4);
            this.dgv_cuadre_taq.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_cuadre_taq.Name = "dgv_cuadre_taq";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_cuadre_taq.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_cuadre_taq.RowTemplate.Height = 35;
            this.dgv_cuadre_taq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_cuadre_taq.Size = new System.Drawing.Size(818, 390);
            this.dgv_cuadre_taq.TabIndex = 193;
            // 
            // gp_filtro_mov_venta
            // 
            this.gp_filtro_mov_venta.BackColor = System.Drawing.Color.Black;
            this.gp_filtro_mov_venta.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gp_filtro_mov_venta.Controls.Add(this.label1);
            this.gp_filtro_mov_venta.Controls.Add(this.cbo_grupos);
            this.gp_filtro_mov_venta.Controls.Add(this.label25);
            this.gp_filtro_mov_venta.Controls.Add(this.cbo_taquilla);
            this.gp_filtro_mov_venta.Controls.Add(this.btn_salir);
            this.gp_filtro_mov_venta.Controls.Add(this.dtp_fecha_fin);
            this.gp_filtro_mov_venta.Controls.Add(this.btn_buscar);
            this.gp_filtro_mov_venta.Controls.Add(this.dtp_fecha_ini);
            this.gp_filtro_mov_venta.Controls.Add(this.label8);
            this.gp_filtro_mov_venta.Controls.Add(this.label10);
            this.gp_filtro_mov_venta.DrawTitleBox = false;
            this.gp_filtro_mov_venta.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_filtro_mov_venta.Location = new System.Drawing.Point(13, 4);
            this.gp_filtro_mov_venta.Margin = new System.Windows.Forms.Padding(4);
            this.gp_filtro_mov_venta.Name = "gp_filtro_mov_venta";
            this.gp_filtro_mov_venta.Size = new System.Drawing.Size(835, 101);
            // 
            // 
            // 
            this.gp_filtro_mov_venta.Style.BackColor = System.Drawing.Color.Transparent;
            this.gp_filtro_mov_venta.Style.BackColor2 = System.Drawing.Color.Transparent;
            this.gp_filtro_mov_venta.Style.BackColorGradientAngle = 90;
            this.gp_filtro_mov_venta.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_filtro_mov_venta.Style.BorderBottomWidth = 3;
            this.gp_filtro_mov_venta.Style.BorderColor = System.Drawing.Color.Gold;
            this.gp_filtro_mov_venta.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_filtro_mov_venta.Style.BorderLeftWidth = 3;
            this.gp_filtro_mov_venta.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_filtro_mov_venta.Style.BorderRightWidth = 3;
            this.gp_filtro_mov_venta.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_filtro_mov_venta.Style.BorderTopWidth = 3;
            this.gp_filtro_mov_venta.Style.CornerDiameter = 4;
            this.gp_filtro_mov_venta.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gp_filtro_mov_venta.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_filtro_mov_venta.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.gp_filtro_mov_venta.Style.TextColor = System.Drawing.Color.LightGray;
            this.gp_filtro_mov_venta.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.gp_filtro_mov_venta.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gp_filtro_mov_venta.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gp_filtro_mov_venta.TabIndex = 204;
            this.gp_filtro_mov_venta.Text = "Totales Ventas ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(273, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 210;
            this.label1.Text = "Grupos";
            // 
            // cbo_grupos
            // 
            this.cbo_grupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_grupos.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_grupos.FormattingEnabled = true;
            this.cbo_grupos.Location = new System.Drawing.Point(267, 32);
            this.cbo_grupos.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_grupos.Name = "cbo_grupos";
            this.cbo_grupos.Size = new System.Drawing.Size(142, 27);
            this.cbo_grupos.TabIndex = 209;
            this.cbo_grupos.SelectionChangeCommitted += new System.EventHandler(this.cbo_grupos_SelectionChangeCommitted);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.LightGray;
            this.label25.Location = new System.Drawing.Point(427, 4);
            this.label25.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 21);
            this.label25.TabIndex = 208;
            this.label25.Text = "Taquilla";
            // 
            // cbo_taquilla
            // 
            this.cbo_taquilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_taquilla.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_taquilla.FormattingEnabled = true;
            this.cbo_taquilla.Location = new System.Drawing.Point(417, 32);
            this.cbo_taquilla.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_taquilla.Name = "cbo_taquilla";
            this.cbo_taquilla.Size = new System.Drawing.Size(142, 27);
            this.cbo_taquilla.TabIndex = 207;
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.Transparent;
            this.btn_salir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_salir.BackgroundImage")));
            this.btn_salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_salir.FlatAppearance.BorderSize = 0;
            this.btn_salir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_salir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.btn_salir.Location = new System.Drawing.Point(672, 12);
            this.btn_salir.Margin = new System.Windows.Forms.Padding(9);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(50, 50);
            this.btn_salir.TabIndex = 201;
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // dtp_fecha_fin
            // 
            this.dtp_fecha_fin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fecha_fin.Location = new System.Drawing.Point(144, 33);
            this.dtp_fecha_fin.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_fecha_fin.Name = "dtp_fecha_fin";
            this.dtp_fecha_fin.Size = new System.Drawing.Size(115, 26);
            this.dtp_fecha_fin.TabIndex = 179;
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.Teal;
            this.btn_buscar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.Location = new System.Drawing.Point(578, 7);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(81, 55);
            this.btn_buscar.TabIndex = 5;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // dtp_fecha_ini
            // 
            this.dtp_fecha_ini.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fecha_ini.Location = new System.Drawing.Point(20, 33);
            this.dtp_fecha_ini.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_fecha_ini.Name = "dtp_fecha_ini";
            this.dtp_fecha_ini.Size = new System.Drawing.Size(116, 26);
            this.dtp_fecha_ini.TabIndex = 178;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LightGray;
            this.label8.Location = new System.Drawing.Point(140, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 21);
            this.label8.TabIndex = 3;
            this.label8.Text = "Fecha Final";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.LightGray;
            this.label10.Location = new System.Drawing.Point(28, 4);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 21);
            this.label10.TabIndex = 1;
            this.label10.Text = "Fecha Inicial";
            // 
            // work_inicia_frm
            // 
            this.work_inicia_frm.WorkerReportsProgress = true;
            this.work_inicia_frm.WorkerSupportsCancellation = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "porc_taq";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "N2";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column2.HeaderText = "Comisión";
            this.Column2.Name = "Column2";
            this.Column2.Width = 130;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "balance";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N2";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column1.HeaderText = "Balance";
            this.Column1.Name = "Column1";
            this.Column1.Width = 130;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "monto_salida";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.HeaderText = "Premios";
            this.Column4.Name = "Column4";
            this.Column4.Width = 130;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "monto_entrada";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N2";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "Venta";
            this.Column3.Name = "Column3";
            this.Column3.Width = 130;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "nick";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column6.HeaderText = "Taquilla";
            this.Column6.Name = "Column6";
            this.Column6.Width = 270;
            // 
            // frm_cuadre_taq_gral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(855, 549);
            this.Controls.Add(this.gb_totales_venta);
            this.Controls.Add(this.gp_filtro_mov_venta);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_cuadre_taq_gral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_cuadre_taq_gral";
            this.Load += new System.EventHandler(this.frm_cuadre_taq_gral_Load);
            this.gb_totales_venta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cuadre_taq)).EndInit();
            this.gp_filtro_mov_venta.ResumeLayout(false);
            this.gp_filtro_mov_venta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel gb_totales_venta;
        private System.Windows.Forms.DataGridView dgv_cuadre_taq;
        private DevComponents.DotNetBar.Controls.GroupPanel gp_filtro_mov_venta;
        private System.Windows.Forms.DateTimePicker dtp_fecha_fin;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.DateTimePicker dtp_fecha_ini;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.ComponentModel.BackgroundWorker work_inicia_frm;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cbo_taquilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_grupos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}