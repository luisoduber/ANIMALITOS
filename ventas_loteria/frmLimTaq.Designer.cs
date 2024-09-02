namespace ventas_loteria
{
    partial class frmLimTaq
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLimTaq));
            this.work_inicia_frm = new System.ComponentModel.BackgroundWorker();
            this.gpVentas = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvLimTaq = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnGrd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCupAn = new System.Windows.Forms.TextBox();
            this.cboTaq = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.work_proc_result = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.work_bus_result_lot = new System.ComponentModel.BackgroundWorker();
            this.gpVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLimTaq)).BeginInit();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // work_inicia_frm
            // 
            this.work_inicia_frm.WorkerReportsProgress = true;
            this.work_inicia_frm.WorkerSupportsCancellation = true;
            // 
            // gpVentas
            // 
            this.gpVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gpVentas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gpVentas.Controls.Add(this.dgvLimTaq);
            this.gpVentas.DrawTitleBox = false;
            this.gpVentas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpVentas.Location = new System.Drawing.Point(10, 84);
            this.gpVentas.Name = "gpVentas";
            this.gpVentas.Size = new System.Drawing.Size(439, 393);
            // 
            // 
            // 
            this.gpVentas.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gpVentas.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gpVentas.Style.BackColorGradientAngle = 90;
            this.gpVentas.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpVentas.Style.BorderBottomWidth = 3;
            this.gpVentas.Style.BorderColor = System.Drawing.Color.White;
            this.gpVentas.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpVentas.Style.BorderLeftWidth = 3;
            this.gpVentas.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpVentas.Style.BorderRightWidth = 3;
            this.gpVentas.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpVentas.Style.BorderTopWidth = 3;
            this.gpVentas.Style.CornerDiameter = 4;
            this.gpVentas.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gpVentas.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpVentas.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.gpVentas.Style.TextColor = System.Drawing.Color.Black;
            this.gpVentas.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.gpVentas.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gpVentas.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpVentas.TabIndex = 197;
            this.gpVentas.Text = "Limites Taquilla";
            // 
            // dgvLimTaq
            // 
            this.dgvLimTaq.BackgroundColor = System.Drawing.Color.White;
            this.dgvLimTaq.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLimTaq.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLimTaq.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLimTaq.ColumnHeadersHeight = 35;
            this.dgvLimTaq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLimTaq.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLimTaq.Location = new System.Drawing.Point(3, 3);
            this.dgvLimTaq.Name = "dgvLimTaq";
            this.dgvLimTaq.RowTemplate.Height = 35;
            this.dgvLimTaq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLimTaq.Size = new System.Drawing.Size(425, 357);
            this.dgvLimTaq.TabIndex = 194;
            this.dgvLimTaq.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLimTaq_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "idTaq";
            this.Column1.HeaderText = "idTaq";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "nick";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Taquilla";
            this.Column2.Name = "Column2";
            this.Column2.Width = 140;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "maxAn";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle3.Format = "N2";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "Cupo An.";
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "fechReg";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.HeaderText = "Fecha";
            this.Column4.Name = "Column4";
            this.Column4.Width = 90;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "horReg";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column5.HeaderText = "Hora";
            this.Column5.Name = "Column5";
            this.Column5.Width = 90;
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.btnGrd);
            this.groupPanel3.Controls.Add(this.label2);
            this.groupPanel3.Controls.Add(this.txtCupAn);
            this.groupPanel3.Controls.Add(this.cboTaq);
            this.groupPanel3.Controls.Add(this.label11);
            this.groupPanel3.Controls.Add(this.label1);
            this.groupPanel3.DrawTitleBox = false;
            this.groupPanel3.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.groupPanel3.Location = new System.Drawing.Point(12, -1);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(437, 85);
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
            this.groupPanel3.Text = "Registrar Limites";
            // 
            // btnGrd
            // 
            this.btnGrd.BackColor = System.Drawing.Color.Transparent;
            this.btnGrd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrd.BackgroundImage")));
            this.btnGrd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGrd.FlatAppearance.BorderSize = 0;
            this.btnGrd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGrd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGrd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrd.Location = new System.Drawing.Point(382, 7);
            this.btnGrd.Name = "btnGrd";
            this.btnGrd.Size = new System.Drawing.Size(44, 44);
            this.btnGrd.TabIndex = 213;
            this.btnGrd.UseVisualStyleBackColor = false;
            this.btnGrd.Click += new System.EventHandler(this.btnGrd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(200, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 22);
            this.label2.TabIndex = 212;
            this.label2.Text = "Cupo Animalito";
            // 
            // txtCupAn
            // 
            this.txtCupAn.Location = new System.Drawing.Point(195, 22);
            this.txtCupAn.MaxLength = 300;
            this.txtCupAn.Name = "txtCupAn";
            this.txtCupAn.Size = new System.Drawing.Size(181, 29);
            this.txtCupAn.TabIndex = 211;
            this.txtCupAn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCupAn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCupAn_KeyPress);
            // 
            // cboTaq
            // 
            this.cboTaq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTaq.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTaq.FormattingEnabled = true;
            this.cboTaq.Location = new System.Drawing.Point(12, 23);
            this.cboTaq.Margin = new System.Windows.Forms.Padding(4);
            this.cboTaq.Name = "cboTaq";
            this.cboTaq.Size = new System.Drawing.Size(176, 27);
            this.cboTaq.TabIndex = 208;
            this.cboTaq.SelectionChangeCommitted += new System.EventHandler(this.cboTaq_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(24, -3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 22);
            this.label11.TabIndex = 210;
            this.label11.Text = "Taquillas";
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
            // work_proc_result
            // 
            this.work_proc_result.WorkerReportsProgress = true;
            this.work_proc_result.WorkerSupportsCancellation = true;
            // 
            // work_bus_result_lot
            // 
            this.work_bus_result_lot.WorkerReportsProgress = true;
            this.work_bus_result_lot.WorkerSupportsCancellation = true;
            // 
            // frmLimTaq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(454, 484);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.gpVentas);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLimTaq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Limite Taquillas";
            this.Activated += new System.EventHandler(this.frmLimTaq_Activated);
            this.Load += new System.EventHandler(this.frmLimTaq_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmLimTaq_KeyPress);
            this.gpVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLimTaq)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker work_inicia_frm;
        private DevComponents.DotNetBar.Controls.GroupPanel gpVentas;
        private System.Windows.Forms.DataGridView dgvLimTaq;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker work_proc_result;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cboTaq;
        private System.ComponentModel.BackgroundWorker work_bus_result_lot;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCupAn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btnGrd;
    }
}