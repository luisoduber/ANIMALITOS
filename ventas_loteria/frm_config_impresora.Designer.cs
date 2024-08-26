namespace ventas_loteria
{
    partial class frm_config_impresora
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
            this.label25 = new System.Windows.Forms.Label();
            this.cboImp = new System.Windows.Forms.ComboBox();
            this.work_inicia_frm = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAnchTck = new System.Windows.Forms.ComboBox();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNumLetra = new System.Windows.Forms.ComboBox();
            this.btn_probar_imp = new System.Windows.Forms.Button();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(22, 17);
            this.label25.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(150, 22);
            this.label25.TabIndex = 208;
            this.label25.Text = "Elegir Impresora";
            // 
            // cboImp
            // 
            this.cboImp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboImp.FormattingEnabled = true;
            this.cboImp.Location = new System.Drawing.Point(14, 43);
            this.cboImp.Margin = new System.Windows.Forms.Padding(4);
            this.cboImp.Name = "cboImp";
            this.cboImp.Size = new System.Drawing.Size(260, 27);
            this.cboImp.TabIndex = 207;
            // 
            // work_inicia_frm
            // 
            this.work_inicia_frm.WorkerReportsProgress = true;
            this.work_inicia_frm.WorkerSupportsCancellation = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(22, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 22);
            this.label1.TabIndex = 213;
            this.label1.Text = "Ancho";
            // 
            // cboAnchTck
            // 
            this.cboAnchTck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnchTck.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAnchTck.FormattingEnabled = true;
            this.cboAnchTck.Location = new System.Drawing.Point(14, 100);
            this.cboAnchTck.Margin = new System.Windows.Forms.Padding(4);
            this.cboAnchTck.Name = "cboAnchTck";
            this.cboAnchTck.Size = new System.Drawing.Size(92, 27);
            this.cboAnchTck.TabIndex = 212;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.cboNumLetra);
            this.groupPanel1.Controls.Add(this.cboAnchTck);
            this.groupPanel1.Controls.Add(this.cboImp);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.label25);
            this.groupPanel1.Controls.Add(this.btn_probar_imp);
            this.groupPanel1.DrawTitleBox = false;
            this.groupPanel1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel1.Location = new System.Drawing.Point(13, 2);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(297, 171);
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
            this.groupPanel1.Text = "Configurar Impresión";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(117, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 22);
            this.label2.TabIndex = 215;
            this.label2.Text = "Letra";
            // 
            // cboNumLetra
            // 
            this.cboNumLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNumLetra.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNumLetra.FormattingEnabled = true;
            this.cboNumLetra.Location = new System.Drawing.Point(114, 100);
            this.cboNumLetra.Margin = new System.Windows.Forms.Padding(4);
            this.cboNumLetra.Name = "cboNumLetra";
            this.cboNumLetra.Size = new System.Drawing.Size(97, 27);
            this.cboNumLetra.TabIndex = 214;
            // 
            // btn_probar_imp
            // 
            this.btn_probar_imp.BackColor = System.Drawing.Color.Transparent;
            this.btn_probar_imp.BackgroundImage = global::ventas_loteria.Properties.Resources.impresora;
            this.btn_probar_imp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_probar_imp.FlatAppearance.BorderSize = 0;
            this.btn_probar_imp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_probar_imp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_probar_imp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_probar_imp.Location = new System.Drawing.Point(219, 78);
            this.btn_probar_imp.Margin = new System.Windows.Forms.Padding(4);
            this.btn_probar_imp.Name = "btn_probar_imp";
            this.btn_probar_imp.Size = new System.Drawing.Size(55, 55);
            this.btn_probar_imp.TabIndex = 209;
            this.btn_probar_imp.UseVisualStyleBackColor = false;
            this.btn_probar_imp.Click += new System.EventHandler(this.btn_probar_imp_Click);
            // 
            // frm_config_impresora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(315, 179);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_config_impresora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_config_impresora";
            this.Load += new System.EventHandler(this.frm_config_impresora_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_config_impresora_KeyPress);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cboImp;
        private System.Windows.Forms.Button btn_probar_imp;
        private System.ComponentModel.BackgroundWorker work_inicia_frm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAnchTck;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboNumLetra;
    }
}