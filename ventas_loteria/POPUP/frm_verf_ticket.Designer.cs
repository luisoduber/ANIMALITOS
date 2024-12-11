namespace ventas_loteria
{
    partial class frm_verf_ticket
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
            this.rtbMostTck = new System.Windows.Forms.RichTextBox();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.rtbMostTck);
            this.groupPanel3.DrawTitleBox = false;
            this.groupPanel3.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.groupPanel3.Location = new System.Drawing.Point(9, 0);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(288, 488);
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
            this.groupPanel3.Text = "Detalles Ticket";
            // 
            // rtbMostTck
            // 
            this.rtbMostTck.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMostTck.Location = new System.Drawing.Point(3, 3);
            this.rtbMostTck.Name = "rtbMostTck";
            this.rtbMostTck.ReadOnly = true;
            this.rtbMostTck.Size = new System.Drawing.Size(276, 449);
            this.rtbMostTck.TabIndex = 0;
            this.rtbMostTck.Text = "";
            // 
            // frm_verf_ticket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(301, 494);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel3);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frm_verf_ticket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_verf_ticket";
            this.Load += new System.EventHandler(this.frm_verf_ticket_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_verf_ticket_KeyPress);
            this.groupPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.RichTextBox rtbMostTck;
    }
}