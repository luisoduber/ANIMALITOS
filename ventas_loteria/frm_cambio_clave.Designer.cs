namespace ventas_loteria
{
    partial class frm_cambio_clave
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
            this.gb_cambiar_clave = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtRepClav = new System.Windows.Forms.TextBox();
            this.txtClavNew = new System.Windows.Forms.TextBox();
            this.txtClavAct = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gb_cambiar_clave.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_cambiar_clave
            // 
            this.gb_cambiar_clave.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gb_cambiar_clave.Controls.Add(this.txtRepClav);
            this.gb_cambiar_clave.Controls.Add(this.txtClavNew);
            this.gb_cambiar_clave.Controls.Add(this.txtClavAct);
            this.gb_cambiar_clave.Controls.Add(this.label7);
            this.gb_cambiar_clave.Controls.Add(this.label3);
            this.gb_cambiar_clave.Controls.Add(this.label5);
            this.gb_cambiar_clave.DrawTitleBox = false;
            this.gb_cambiar_clave.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.gb_cambiar_clave.Location = new System.Drawing.Point(8, -1);
            this.gb_cambiar_clave.Name = "gb_cambiar_clave";
            this.gb_cambiar_clave.Size = new System.Drawing.Size(360, 159);
            // 
            // 
            // 
            this.gb_cambiar_clave.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gb_cambiar_clave.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.gb_cambiar_clave.Style.BackColorGradientAngle = 90;
            this.gb_cambiar_clave.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_cambiar_clave.Style.BorderBottomWidth = 3;
            this.gb_cambiar_clave.Style.BorderColor = System.Drawing.Color.White;
            this.gb_cambiar_clave.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_cambiar_clave.Style.BorderLeftWidth = 3;
            this.gb_cambiar_clave.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_cambiar_clave.Style.BorderRightWidth = 3;
            this.gb_cambiar_clave.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gb_cambiar_clave.Style.BorderTopWidth = 3;
            this.gb_cambiar_clave.Style.CornerDiameter = 4;
            this.gb_cambiar_clave.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gb_cambiar_clave.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_cambiar_clave.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.gb_cambiar_clave.Style.TextColor = System.Drawing.Color.Black;
            this.gb_cambiar_clave.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.gb_cambiar_clave.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gb_cambiar_clave.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gb_cambiar_clave.TabIndex = 35;
            this.gb_cambiar_clave.Text = "Cambiar Clave";
            // 
            // txtRepClav
            // 
            this.txtRepClav.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepClav.Location = new System.Drawing.Point(151, 93);
            this.txtRepClav.Margin = new System.Windows.Forms.Padding(5);
            this.txtRepClav.MaxLength = 20;
            this.txtRepClav.Name = "txtRepClav";
            this.txtRepClav.PasswordChar = '*';
            this.txtRepClav.Size = new System.Drawing.Size(193, 25);
            this.txtRepClav.TabIndex = 152;
            this.txtRepClav.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRepClav.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRepClav_KeyPress);
            // 
            // txtClavNew
            // 
            this.txtClavNew.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClavNew.Location = new System.Drawing.Point(151, 58);
            this.txtClavNew.Margin = new System.Windows.Forms.Padding(5);
            this.txtClavNew.MaxLength = 20;
            this.txtClavNew.Name = "txtClavNew";
            this.txtClavNew.PasswordChar = '*';
            this.txtClavNew.Size = new System.Drawing.Size(193, 25);
            this.txtClavNew.TabIndex = 151;
            this.txtClavNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClavNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClavNew_KeyPress);
            // 
            // txtClavAct
            // 
            this.txtClavAct.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClavAct.Location = new System.Drawing.Point(151, 23);
            this.txtClavAct.Margin = new System.Windows.Forms.Padding(5);
            this.txtClavAct.MaxLength = 20;
            this.txtClavAct.Name = "txtClavAct";
            this.txtClavAct.PasswordChar = '*';
            this.txtClavAct.Size = new System.Drawing.Size(193, 25);
            this.txtClavAct.TabIndex = 150;
            this.txtClavAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClavAct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClavAct_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(16, 94);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 22);
            this.label7.TabIndex = 23;
            this.label7.Text = "Repetir Clave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 22);
            this.label3.TabIndex = 21;
            this.label3.Text = "Clave Nueva";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(27, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 22);
            this.label5.TabIndex = 20;
            this.label5.Text = "Clave Actual";
            // 
            // frm_cambio_clave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(371, 163);
            this.ControlBox = false;
            this.Controls.Add(this.gb_cambiar_clave);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_cambio_clave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_cambio_clave";
            this.Activated += new System.EventHandler(this.frm_cambio_clave_Activated);
            this.Load += new System.EventHandler(this.frm_cambio_clave_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_cambio_clave_KeyPress);
            this.gb_cambiar_clave.ResumeLayout(false);
            this.gb_cambiar_clave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel gb_cambiar_clave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRepClav;
        private System.Windows.Forms.TextBox txtClavNew;
        private System.Windows.Forms.TextBox txtClavAct;
    }
}