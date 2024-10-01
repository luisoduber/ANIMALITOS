namespace ventas_loteria
{
    partial class frm_anular_ticket
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
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnBusTck = new System.Windows.Forms.Button();
            this.btnAnTck = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_nro_ticket = new System.Windows.Forms.TextBox();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rtbMostTck = new System.Windows.Forms.RichTextBox();
            this.groupPanel3.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.btnBusTck);
            this.groupPanel3.Controls.Add(this.btnAnTck);
            this.groupPanel3.Controls.Add(this.label10);
            this.groupPanel3.Controls.Add(this.txt_nro_ticket);
            this.groupPanel3.DrawTitleBox = false;
            this.groupPanel3.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.groupPanel3.Location = new System.Drawing.Point(281, 4);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(181, 153);
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
            this.groupPanel3.TabIndex = 198;
            this.groupPanel3.Text = "Verificar";
            // 
            // btnBusTck
            // 
            this.btnBusTck.BackColor = System.Drawing.Color.White;
            this.btnBusTck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusTck.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusTck.Location = new System.Drawing.Point(13, 79);
            this.btnBusTck.Name = "btnBusTck";
            this.btnBusTck.Size = new System.Drawing.Size(75, 33);
            this.btnBusTck.TabIndex = 201;
            this.btnBusTck.Text = "Buscar";
            this.btnBusTck.UseVisualStyleBackColor = false;
            this.btnBusTck.Click += new System.EventHandler(this.btnBusTck_Click);
            // 
            // btnAnTck
            // 
            this.btnAnTck.BackColor = System.Drawing.Color.White;
            this.btnAnTck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnTck.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnTck.Location = new System.Drawing.Point(94, 79);
            this.btnAnTck.Name = "btnAnTck";
            this.btnAnTck.Size = new System.Drawing.Size(76, 33);
            this.btnAnTck.TabIndex = 5;
            this.btnAnTck.Text = "Anular";
            this.btnAnTck.UseVisualStyleBackColor = false;
            this.btnAnTck.Click += new System.EventHandler(this.btnAnTck_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(18, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 22);
            this.label10.TabIndex = 1;
            this.label10.Text = "Nro. Ticket";
            // 
            // txt_nro_ticket
            // 
            this.txt_nro_ticket.Location = new System.Drawing.Point(13, 30);
            this.txt_nro_ticket.MaxLength = 33333;
            this.txt_nro_ticket.Name = "txt_nro_ticket";
            this.txt_nro_ticket.Size = new System.Drawing.Size(157, 29);
            this.txt_nro_ticket.TabIndex = 0;
            this.txt_nro_ticket.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_nro_ticket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nro_ticket_KeyPress);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.rtbMostTck);
            this.groupPanel1.DrawTitleBox = false;
            this.groupPanel1.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.groupPanel1.Location = new System.Drawing.Point(7, 4);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(268, 491);
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
            this.groupPanel1.TabIndex = 199;
            this.groupPanel1.Text = "Detalle Ticket";
            // 
            // rtbMostTck
            // 
            this.rtbMostTck.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMostTck.Location = new System.Drawing.Point(3, 3);
            this.rtbMostTck.Name = "rtbMostTck";
            this.rtbMostTck.ReadOnly = true;
            this.rtbMostTck.Size = new System.Drawing.Size(248, 449);
            this.rtbMostTck.TabIndex = 0;
            this.rtbMostTck.Text = "";
            // 
            // frm_anular_ticket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(470, 507);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.groupPanel3);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_anular_ticket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_anular_ticket";
            this.Load += new System.EventHandler(this.frm_anular_ticket_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_anular_ticket_KeyPress);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.Button btnAnTck;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_nro_ticket;
        private System.Windows.Forms.Button btnBusTck;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.RichTextBox rtbMostTck;
    }
}