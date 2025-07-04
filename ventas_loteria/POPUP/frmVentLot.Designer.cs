namespace ventas_loteria
{
    partial class frmVentLot
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
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dtpFechFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechIni = new System.Windows.Forms.DateTimePicker();
            this.cboLot = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrem = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblVent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wkIniFrm = new System.ComponentModel.BackgroundWorker();
            this.cboGrup = new System.Windows.Forms.ComboBox();
            this.cboTaq = new System.Windows.Forms.ComboBox();
            this.groupPanel4.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel4
            // 
            this.groupPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.cboTaq);
            this.groupPanel4.Controls.Add(this.cboGrup);
            this.groupPanel4.Controls.Add(this.dtpFechFin);
            this.groupPanel4.Controls.Add(this.dtpFechIni);
            this.groupPanel4.Controls.Add(this.cboLot);
            this.groupPanel4.Controls.Add(this.label3);
            this.groupPanel4.DrawTitleBox = false;
            this.groupPanel4.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.groupPanel4.Location = new System.Drawing.Point(8, 0);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(241, 173);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel4.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 3;
            this.groupPanel4.Style.BorderColor = System.Drawing.Color.White;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 3;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 3;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 3;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel4.Style.TextColor = System.Drawing.Color.Black;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 217;
            this.groupPanel4.Text = "Loterias";
            // 
            // dtpFechFin
            // 
            this.dtpFechFin.Location = new System.Drawing.Point(115, 108);
            this.dtpFechFin.Name = "dtpFechFin";
            this.dtpFechFin.Size = new System.Drawing.Size(113, 29);
            this.dtpFechFin.TabIndex = 275;
            // 
            // dtpFechIni
            // 
            this.dtpFechIni.Location = new System.Drawing.Point(4, 108);
            this.dtpFechIni.Name = "dtpFechIni";
            this.dtpFechIni.Size = new System.Drawing.Size(105, 29);
            this.dtpFechIni.TabIndex = 274;
            // 
            // cboLot
            // 
            this.cboLot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLot.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLot.FormattingEnabled = true;
            this.cboLot.Location = new System.Drawing.Point(4, 74);
            this.cboLot.Margin = new System.Windows.Forms.Padding(4);
            this.cboLot.Name = "cboLot";
            this.cboLot.Size = new System.Drawing.Size(224, 27);
            this.cboLot.TabIndex = 208;
            this.cboLot.SelectionChangeCommitted += new System.EventHandler(this.cboLot_SelectionChangeCommitted);
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
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.lblUt);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.lblAn);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.lblPrem);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.Controls.Add(this.lblVent);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.DrawTitleBox = false;
            this.groupPanel1.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.groupPanel1.Location = new System.Drawing.Point(8, 175);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(241, 154);
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
            this.groupPanel1.TabIndex = 218;
            this.groupPanel1.Text = "Cuadre";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(126, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 22);
            this.label7.TabIndex = 244;
            this.label7.Text = "Utilidad";
            // 
            // lblUt
            // 
            this.lblUt.BackColor = System.Drawing.Color.White;
            this.lblUt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUt.ForeColor = System.Drawing.Color.Black;
            this.lblUt.Location = new System.Drawing.Point(123, 87);
            this.lblUt.Name = "lblUt";
            this.lblUt.Size = new System.Drawing.Size(105, 30);
            this.lblUt.TabIndex = 243;
            this.lblUt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(17, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 22);
            this.label5.TabIndex = 242;
            this.label5.Text = "Anulados";
            // 
            // lblAn
            // 
            this.lblAn.BackColor = System.Drawing.Color.White;
            this.lblAn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAn.ForeColor = System.Drawing.Color.Black;
            this.lblAn.Location = new System.Drawing.Point(8, 87);
            this.lblAn.Name = "lblAn";
            this.lblAn.Size = new System.Drawing.Size(109, 30);
            this.lblAn.TabIndex = 241;
            this.lblAn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(123, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 22);
            this.label2.TabIndex = 240;
            this.label2.Text = "Premios";
            // 
            // lblPrem
            // 
            this.lblPrem.BackColor = System.Drawing.Color.White;
            this.lblPrem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrem.ForeColor = System.Drawing.Color.Black;
            this.lblPrem.Location = new System.Drawing.Point(123, 25);
            this.lblPrem.Name = "lblPrem";
            this.lblPrem.Size = new System.Drawing.Size(105, 30);
            this.lblPrem.TabIndex = 239;
            this.lblPrem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(17, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 22);
            this.label10.TabIndex = 238;
            this.label10.Text = "Ventas";
            // 
            // lblVent
            // 
            this.lblVent.BackColor = System.Drawing.Color.White;
            this.lblVent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVent.ForeColor = System.Drawing.Color.Black;
            this.lblVent.Location = new System.Drawing.Point(12, 25);
            this.lblVent.Name = "lblVent";
            this.lblVent.Size = new System.Drawing.Size(105, 30);
            this.lblVent.TabIndex = 237;
            this.lblVent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // wkIniFrm
            // 
            this.wkIniFrm.WorkerReportsProgress = true;
            this.wkIniFrm.WorkerSupportsCancellation = true;
            // 
            // cboGrup
            // 
            this.cboGrup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrup.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGrup.FormattingEnabled = true;
            this.cboGrup.Location = new System.Drawing.Point(4, 4);
            this.cboGrup.Margin = new System.Windows.Forms.Padding(4);
            this.cboGrup.Name = "cboGrup";
            this.cboGrup.Size = new System.Drawing.Size(224, 27);
            this.cboGrup.TabIndex = 219;
            // 
            // cboTaq
            // 
            this.cboTaq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTaq.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTaq.FormattingEnabled = true;
            this.cboTaq.Location = new System.Drawing.Point(4, 39);
            this.cboTaq.Margin = new System.Windows.Forms.Padding(4);
            this.cboTaq.Name = "cboTaq";
            this.cboTaq.Size = new System.Drawing.Size(224, 27);
            this.cboTaq.TabIndex = 276;
            // 
            // frmVentLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(185)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(256, 333);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.groupPanel4);
            this.KeyPreview = true;
            this.Name = "frmVentLot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVentLot";
            this.Load += new System.EventHandler(this.frmVentLot_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmVentLot_KeyPress);
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel4.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private System.Windows.Forms.ComboBox cboLot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechFin;
        private System.Windows.Forms.DateTimePicker dtpFechIni;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblUt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrem;
        private System.Windows.Forms.Label label10;
        private System.ComponentModel.BackgroundWorker wkIniFrm;
        private System.Windows.Forms.ComboBox cboGrup;
        private System.Windows.Forms.ComboBox cboTaq;
    }
}