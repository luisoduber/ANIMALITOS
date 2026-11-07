namespace ventas_loteria
{
    partial class frm_verf_ticket_taq
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.work_inicia_frm = new System.ComponentModel.BackgroundWorker();
            this.gp_cant_jug = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvDetJug = new System.Windows.Forms.DataGridView();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTaq = new System.Windows.Forms.ComboBox();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboGrup = new System.Windows.Forms.ComboBox();
            this.btnRs = new System.Windows.Forms.Button();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gp_cant_jug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetJug)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // work_inicia_frm
            // 
            this.work_inicia_frm.WorkerReportsProgress = true;
            this.work_inicia_frm.WorkerSupportsCancellation = true;
            // 
            // gp_cant_jug
            // 
            this.gp_cant_jug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gp_cant_jug.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gp_cant_jug.Controls.Add(this.dgvDetJug);
            this.gp_cant_jug.DisabledBackColor = System.Drawing.Color.Empty;
            this.gp_cant_jug.DrawTitleBox = false;
            this.gp_cant_jug.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_cant_jug.Location = new System.Drawing.Point(6, 60);
            this.gp_cant_jug.Name = "gp_cant_jug";
            this.gp_cant_jug.Size = new System.Drawing.Size(598, 426);
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
            this.gp_cant_jug.Text = "Ticket Ganadores";
            // 
            // dgvDetJug
            // 
            this.dgvDetJug.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetJug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetJug.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetJug.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvDetJug.ColumnHeadersHeight = 35;
            this.dgvDetJug.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column3,
            this.Column12,
            this.Column2,
            this.Column4,
            this.Column1,
            this.Column9});
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetJug.DefaultCellStyle = dataGridViewCellStyle28;
            this.dgvDetJug.Location = new System.Drawing.Point(3, -2);
            this.dgvDetJug.Name = "dgvDetJug";
            this.dgvDetJug.RowTemplate.Height = 35;
            this.dgvDetJug.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetJug.Size = new System.Drawing.Size(586, 396);
            this.dgvDetJug.TabIndex = 194;
            this.dgvDetJug.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetJug_CellClick);
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Location = new System.Drawing.Point(378, 4);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(175, 29);
            this.dtp_fecha.TabIndex = 273;
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
            // cboTaq
            // 
            this.cboTaq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTaq.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTaq.FormattingEnabled = true;
            this.cboTaq.Location = new System.Drawing.Point(186, 4);
            this.cboTaq.Margin = new System.Windows.Forms.Padding(4);
            this.cboTaq.Name = "cboTaq";
            this.cboTaq.Size = new System.Drawing.Size(175, 27);
            this.cboTaq.TabIndex = 208;
            this.cboTaq.SelectionChangeCommitted += new System.EventHandler(this.cboTaq_SelectionChangeCommitted);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnRs);
            this.groupPanel1.Controls.Add(this.cboGrup);
            this.groupPanel1.Controls.Add(this.dtp_fecha);
            this.groupPanel1.Controls.Add(this.cboTaq);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.DrawTitleBox = false;
            this.groupPanel1.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.groupPanel1.Location = new System.Drawing.Point(6, -1);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(598, 69);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 3;
            this.groupPanel1.Style.BorderColor = System.Drawing.Color.White;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 3;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 3;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 3;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel1.Style.TextColor = System.Drawing.Color.Black;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 214;
            this.groupPanel1.Text = "Busqueda";
            // 
            // cboGrup
            // 
            this.cboGrup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrup.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGrup.FormattingEnabled = true;
            this.cboGrup.Location = new System.Drawing.Point(3, 4);
            this.cboGrup.Margin = new System.Windows.Forms.Padding(4);
            this.cboGrup.Name = "cboGrup";
            this.cboGrup.Size = new System.Drawing.Size(175, 27);
            this.cboGrup.TabIndex = 274;
            this.cboGrup.SelectionChangeCommitted += new System.EventHandler(this.cboGrup_SelectionChangeCommitted);
            // 
            // btnRs
            // 
            this.btnRs.BackColor = System.Drawing.Color.White;
            this.btnRs.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRs.ForeColor = System.Drawing.Color.Black;
            this.btnRs.Location = new System.Drawing.Point(559, 4);
            this.btnRs.Name = "btnRs";
            this.btnRs.Size = new System.Drawing.Size(30, 30);
            this.btnRs.TabIndex = 209;
            this.btnRs.Text = "R";
            this.btnRs.UseVisualStyleBackColor = false;
            this.btnRs.Click += new System.EventHandler(this.btnRs_Click);
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "nro_ticket";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle23;
            this.Column8.HeaderText = "Ticket";
            this.Column8.Name = "Column8";
            this.Column8.Width = 80;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "nro_serial";
            this.Column3.HeaderText = "Serial";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "nomb_usuario";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column12.DefaultCellStyle = dataGridViewCellStyle24;
            this.Column12.HeaderText = "Usuario";
            this.Column12.Name = "Column12";
            this.Column12.Width = 130;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "canJugGan";
            this.Column2.HeaderText = "Gan";
            this.Column2.Name = "Column2";
            this.Column2.Width = 40;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "monto_ticket";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.Format = "N2";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle25;
            this.Column4.HeaderText = "Monto";
            this.Column4.Name = "Column4";
            this.Column4.Width = 90;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "monto_pagado";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.Format = "N2";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle26;
            this.Column1.HeaderText = "Premio";
            this.Column1.Name = "Column1";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "nmb_status_ticket";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle27;
            this.Column9.HeaderText = "Status";
            this.Column9.Name = "Column9";
            this.Column9.Width = 125;
            // 
            // frm_verf_ticket_taq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(608, 490);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.gp_cant_jug);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_verf_ticket_taq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_proc_result_loteria";
            this.Load += new System.EventHandler(this.frm_verf_ticket_taq_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_verf_ticket_taq_KeyPress);
            this.gp_cant_jug.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetJug)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker work_inicia_frm;
        private DevComponents.DotNetBar.Controls.GroupPanel gp_cant_jug;
        private System.Windows.Forms.DataGridView dgvDetJug;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTaq;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Button btnRs;
        private System.Windows.Forms.ComboBox cboGrup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}