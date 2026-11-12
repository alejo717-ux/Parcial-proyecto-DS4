namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    partial class FrmMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuCatalogos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMecanicos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServicios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOperaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrdenes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBitacora = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            
            // menuStrip1
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuCatalogos, this.mnuOperaciones, this.mnuSeguridad, this.mnuSesion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1100, 28);
            this.menuStrip1.TabIndex = 0;
            
            // mnuCatalogos
            this.mnuCatalogos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuClientes, this.mnuMecanicos, this.mnuServicios});
            this.mnuCatalogos.Name = "mnuCatalogos";
            this.mnuCatalogos.Text = "&Catálogos";
            this.mnuClientes.Name = "mnuClientes";
            this.mnuClientes.Text = "Clientes";
            this.mnuClientes.Click += new System.EventHandler(this.mnuClientes_Click);
            this.mnuMecanicos.Name = "mnuMecanicos";
            this.mnuMecanicos.Text = "Mecánicos";
            this.mnuMecanicos.Click += new System.EventHandler(this.mnuMecanicos_Click);
            this.mnuServicios.Name = "mnuServicios";
            this.mnuServicios.Text = "Servicios y categorías";
            this.mnuServicios.Click += new System.EventHandler(this.mnuServicios_Click);
            
            // mnuOperaciones
            this.mnuOperaciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuOrdenes, this.mnuReportes});
            this.mnuOperaciones.Name = "mnuOperaciones";
            this.mnuOperaciones.Text = "&Operaciones";
            this.mnuOrdenes.Name = "mnuOrdenes";
            this.mnuOrdenes.Text = "Órdenes de reparación";
            this.mnuOrdenes.Click += new System.EventHandler(this.mnuOrdenes_Click);
            this.mnuReportes.Name = "mnuReportes";
            this.mnuReportes.Text = "Reporte de consultas";
            this.mnuReportes.Click += new System.EventHandler(this.mnuReportes_Click);
            
            // mnuSeguridad
            this.mnuSeguridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuUsuarios, this.mnuBitacora});
            this.mnuSeguridad.Name = "mnuSeguridad";
            this.mnuSeguridad.Text = "&Seguridad";
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Text = "Gestión de usuarios";
            this.mnuUsuarios.Click += new System.EventHandler(this.mnuUsuarios_Click);
            this.mnuBitacora.Name = "mnuBitacora";
            this.mnuBitacora.Text = "Bitácora";
            this.mnuBitacora.Click += new System.EventHandler(this.mnuBitacora_Click);
            
            // mnuSesion
            this.mnuSesion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuCerrarSesion, this.mnuSalir});
            this.mnuSesion.Name = "mnuSesion";
            this.mnuSesion.Text = "S&esión";
            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Text = "Cerrar sesión";
            this.mnuCerrarSesion.Click += new System.EventHandler(this.mnuCerrarSesion_Click);
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            
            // statusStrip1
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tslUsuario });
            this.statusStrip1.Location = new System.Drawing.Point(0, 678);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1100, 26);
            this.statusStrip1.TabIndex = 1;
            this.tslUsuario.Name = "tslUsuario";
            this.tslUsuario.Text = "Usuario:";
            
            // FrmMenuPrincipal
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 704);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taller Mecánico - Menú Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenuPrincipal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMenuPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuCatalogos;
        private System.Windows.Forms.ToolStripMenuItem mnuClientes;
        private System.Windows.Forms.ToolStripMenuItem mnuMecanicos;
        private System.Windows.Forms.ToolStripMenuItem mnuServicios;
        private System.Windows.Forms.ToolStripMenuItem mnuOperaciones;
        private System.Windows.Forms.ToolStripMenuItem mnuOrdenes;
        private System.Windows.Forms.ToolStripMenuItem mnuReportes;
        private System.Windows.Forms.ToolStripMenuItem mnuSeguridad;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuBitacora;
        private System.Windows.Forms.ToolStripMenuItem mnuSesion;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslUsuario;
    }
}
