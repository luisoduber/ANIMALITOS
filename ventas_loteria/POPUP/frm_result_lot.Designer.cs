﻿namespace ventas_loteria
{
    partial class frm_result_lot
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gp_filtro_result_lot = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLot = new System.Windows.Forms.ComboBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvResultLot = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.work_inicia_frm = new System.ComponentModel.BackgroundWorker();
            this.gp_filtro_result_lot.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultLot)).BeginInit();
            this.SuspendLayout();
            // 
            // gp_filtro_result_lot
            // 
            this.gp_filtro_result_lot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gp_filtro_result_lot.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gp_filtro_result_lot.Controls.Add(this.label1);
            this.gp_filtro_result_lot.Controls.Add(this.cboLot);
            this.gp_filtro_result_lot.Controls.Add(this.btn_buscar);
            this.gp_filtro_result_lot.Controls.Add(this.dtp_fecha);
            this.gp_filtro_result_lot.Controls.Add(this.label10);
            this.gp_filtro_result_lot.DrawTitleBox = false;
            this.gp_filtro_result_lot.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.gp_filtro_result_lot.Location = new System.Drawing.Point(12, 2);
            this.gp_filtro_result_lot.Name = "gp_filtro_result_lot";
            this.gp_filtro_result_lot.Size = new System.Drawing.Size(457, 90);
            // 
            // 
            // 
            this.gp_filtro_result_lot.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gp_filtro_result_lot.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gp_filtro_result_lot.Style.BackColorGradientAngle = 90;
            this.gp_filtro_result_lot.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_filtro_result_lot.Style.BorderBottomWidth = 3;
            this.gp_filtro_result_lot.Style.BorderColor = System.Drawing.Color.White;
            this.gp_filtro_result_lot.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_filtro_result_lot.Style.BorderLeftWidth = 3;
            this.gp_filtro_result_lot.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_filtro_result_lot.Style.BorderRightWidth = 3;
            this.gp_filtro_result_lot.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp_filtro_result_lot.Style.BorderTopWidth = 3;
            this.gp_filtro_result_lot.Style.CornerDiameter = 4;
            this.gp_filtro_result_lot.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gp_filtro_result_lot.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_filtro_result_lot.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.gp_filtro_result_lot.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.gp_filtro_result_lot.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gp_filtro_result_lot.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gp_filtro_result_lot.TabIndex = 199;
            this.gp_filtro_result_lot.Text = "Busqueda Resultados";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 22);
            this.label1.TabIndex = 216;
            this.label1.Text = "Loteria";
            // 
            // cboLot
            // 
            this.cboLot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLot.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLot.FormattingEnabled = true;
            this.cboLot.Location = new System.Drawing.Point(6, 26);
            this.cboLot.Name = "cboLot";
            this.cboLot.Size = new System.Drawing.Size(149, 27);
            this.cboLot.TabIndex = 215;
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.White;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.Location = new System.Drawing.Point(299, 20);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(78, 32);
            this.btn_buscar.TabIndex = 5;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fecha.Location = new System.Drawing.Point(161, 26);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(123, 26);
            this.dtp_fecha.TabIndex = 178;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(170, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 22);
            this.label10.TabIndex = 1;
            this.label10.Text = "Fecha ";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dgvResultLot);
            this.groupPanel2.DrawTitleBox = false;
            this.groupPanel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel2.Location = new System.Drawing.Point(12, 98);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(457, 378);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel2.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.TopLeft;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 3;
            this.groupPanel2.Style.BorderColor = System.Drawing.Color.White;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 3;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 3;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopColor = System.Drawing.Color.Transparent;
            this.groupPanel2.Style.BorderTopWidth = 3;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel2.Style.TextColor = System.Drawing.Color.Black;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel2.Style.TextShadowColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 200;
            this.groupPanel2.Text = "Resultados";
            // 
            // dgvResultLot
            // 
            this.dgvResultLot.BackgroundColor = System.Drawing.Color.White;
            this.dgvResultLot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResultLot.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResultLot.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResultLot.ColumnHeadersHeight = 35;
            this.dgvResultLot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(135)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResultLot.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvResultLot.Location = new System.Drawing.Point(6, 3);
            this.dgvResultLot.Name = "dgvResultLot";
            this.dgvResultLot.RowTemplate.Height = 35;
            this.dgvResultLot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultLot.Size = new System.Drawing.Size(435, 339);
            this.dgvResultLot.TabIndex = 194;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "nomb_loteria";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Loteria";
            this.Column1.Name = "Column1";
            this.Column1.Width = 130;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "nomb_sorteo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "Sorteo";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "cod_result";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "Codigo";
            this.Column3.Name = "Column3";
            this.Column3.Width = 70;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "nomb_product";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column4.HeaderText = "Producto";
            this.Column4.Name = "Column4";
            this.Column4.Width = 110;
            // 
            // work_inicia_frm
            // 
            this.work_inicia_frm.WorkerReportsProgress = true;
            this.work_inicia_frm.WorkerSupportsCancellation = true;
            // 
            // frm_result_lot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(475, 480);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.gp_filtro_result_lot);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frm_result_lot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_result_lot";
            this.Load += new System.EventHandler(this.frm_result_lot_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_result_lot_KeyPress);
            this.gp_filtro_result_lot.ResumeLayout(false);
            this.gp_filtro_result_lot.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultLot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel gp_filtro_result_lot;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.DataGridView dgvResultLot;
        private System.ComponentModel.BackgroundWorker work_inicia_frm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}