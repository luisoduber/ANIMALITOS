namespace ventas_loteria
{
    partial class frm_menu_operaciones
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesarResultadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuadreGruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuadreTaquillasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anularTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticketTaquillasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarClaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearGruposUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impresoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSessiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.resultadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operacionesToolStripMenuItem,
            this.configuraciónToolStripMenuItem,
            this.cerrarSessiónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(864, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem,
            this.procesarResultadosToolStripMenuItem,
            this.cuadreGruposToolStripMenuItem,
            this.cuadreTaquillasToolStripMenuItem,
            this.anularTicketToolStripMenuItem,
            this.ticketTaquillasToolStripMenuItem,
            this.resultadosToolStripMenuItem});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(94, 21);
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.ventasToolStripMenuItem.Text = "Ventas";
            this.ventasToolStripMenuItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);
            // 
            // procesarResultadosToolStripMenuItem
            // 
            this.procesarResultadosToolStripMenuItem.Name = "procesarResultadosToolStripMenuItem";
            this.procesarResultadosToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.procesarResultadosToolStripMenuItem.Text = "Procesar Resultados";
            this.procesarResultadosToolStripMenuItem.Click += new System.EventHandler(this.procesarResultadosToolStripMenuItem_Click);
            // 
            // cuadreGruposToolStripMenuItem
            // 
            this.cuadreGruposToolStripMenuItem.Name = "cuadreGruposToolStripMenuItem";
            this.cuadreGruposToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.cuadreGruposToolStripMenuItem.Text = "Cuadre Grupos";
            this.cuadreGruposToolStripMenuItem.Click += new System.EventHandler(this.cuadreGruposToolStripMenuItem_Click);
            // 
            // cuadreTaquillasToolStripMenuItem
            // 
            this.cuadreTaquillasToolStripMenuItem.Name = "cuadreTaquillasToolStripMenuItem";
            this.cuadreTaquillasToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.cuadreTaquillasToolStripMenuItem.Text = "Cuadre Taquillas";
            this.cuadreTaquillasToolStripMenuItem.Click += new System.EventHandler(this.cuadreTaquillasToolStripMenuItem_Click);
            // 
            // anularTicketToolStripMenuItem
            // 
            this.anularTicketToolStripMenuItem.Name = "anularTicketToolStripMenuItem";
            this.anularTicketToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.anularTicketToolStripMenuItem.Text = "Anular ticket";
            this.anularTicketToolStripMenuItem.Click += new System.EventHandler(this.anularTicketToolStripMenuItem_Click);
            // 
            // ticketTaquillasToolStripMenuItem
            // 
            this.ticketTaquillasToolStripMenuItem.Name = "ticketTaquillasToolStripMenuItem";
            this.ticketTaquillasToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.ticketTaquillasToolStripMenuItem.Text = "Ticket taquillas";
            this.ticketTaquillasToolStripMenuItem.Click += new System.EventHandler(this.ticketTaquillasToolStripMenuItem_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarClaveToolStripMenuItem,
            this.crearGruposUsuariosToolStripMenuItem,
            this.impresoraToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(102, 21);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // cambiarClaveToolStripMenuItem
            // 
            this.cambiarClaveToolStripMenuItem.Name = "cambiarClaveToolStripMenuItem";
            this.cambiarClaveToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.cambiarClaveToolStripMenuItem.Text = "Cambiar Clave";
            this.cambiarClaveToolStripMenuItem.Click += new System.EventHandler(this.cambiarClaveToolStripMenuItem_Click);
            // 
            // crearGruposUsuariosToolStripMenuItem
            // 
            this.crearGruposUsuariosToolStripMenuItem.Name = "crearGruposUsuariosToolStripMenuItem";
            this.crearGruposUsuariosToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.crearGruposUsuariosToolStripMenuItem.Text = "Crear Grupos / Usuarios";
            this.crearGruposUsuariosToolStripMenuItem.Click += new System.EventHandler(this.crearGruposUsuariosToolStripMenuItem_Click);
            // 
            // impresoraToolStripMenuItem
            // 
            this.impresoraToolStripMenuItem.Name = "impresoraToolStripMenuItem";
            this.impresoraToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.impresoraToolStripMenuItem.Text = "Impresora";
            this.impresoraToolStripMenuItem.Click += new System.EventHandler(this.impresoraToolStripMenuItem_Click);
            // 
            // cerrarSessiónToolStripMenuItem
            // 
            this.cerrarSessiónToolStripMenuItem.Name = "cerrarSessiónToolStripMenuItem";
            this.cerrarSessiónToolStripMenuItem.Size = new System.Drawing.Size(107, 21);
            this.cerrarSessiónToolStripMenuItem.Text = "Cerrar Sessión";
            this.cerrarSessiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSessiónToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // resultadosToolStripMenuItem
            // 
            this.resultadosToolStripMenuItem.Name = "resultadosToolStripMenuItem";
            this.resultadosToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.resultadosToolStripMenuItem.Text = "Resultados";
            this.resultadosToolStripMenuItem.Click += new System.EventHandler(this.resultadosToolStripMenuItem_Click);
            // 
            // frm_menu_operaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(864, 592);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_menu_operaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_menu_operaciones";
            this.Load += new System.EventHandler(this.frm_menu_operaciones_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSessiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarClaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearGruposUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procesarResultadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuadreTaquillasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impresoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuadreGruposToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem anularTicketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ticketTaquillasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultadosToolStripMenuItem;
    }
}