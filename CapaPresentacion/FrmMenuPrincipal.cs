using System;
using System.Windows.Forms;

namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    
    // Evita abrir dos veces la misma ventana y captura errores para que la aplicación no se caiga.
    public partial class FrmMenuPrincipal : Form
    {
        // Program.cs la consulta: si es true, vuelve a mostrar el Login en lugar de cerrar la aplicación.
        public bool CerrarSesionSolicitada { 
            get; private set; }

        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            tslUsuario.Text = "Usuario: " + SesionUsuario.Username + "  |  Rol: " + SesionUsuario.Rol;

            // Seguridad: solo el administrador ve las opciones de usuarios y bitácora.
            mnuSeguridad.Visible = SesionUsuario.EsAdministrador;
        }

        

        private void mnuOrdenes_Click(object sender, EventArgs e) { 
            AbrirHijo<FrmOrdenesReparacion>(); }
        private void mnuReportes_Click(object sender, EventArgs e) { 
            AbrirHijo<FrmReporteConsultas>(); }
        private void mnuUsuarios_Click(object sender, EventArgs e) { 
            AbrirHijo<FrmGestionUsuarios>(); }
        private void mnuBitacora_Click(object sender, EventArgs e) { 
            AbrirHijo<FrmBitacora>(); }

        
        private void mnuClientes_Click(object sender, EventArgs e) { 
            AbrirPorNombre("FrmClientes"); }
        private void mnuMecanicos_Click(object sender, EventArgs e) { 
            AbrirPorNombre("FrmMecanicos"); }
        private void mnuServicios_Click(object sender, EventArgs e) { 
            AbrirPorNombre("FrmServicios"); }

        private void AbrirHijo<T>() where T : Form, new()
        {
            foreach (Form hijo in MdiChildren)
            {
                if (hijo is T) { Reutilizar(hijo); 
                    return; }
            }

            try
            {
                T frm = new T();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la ventana.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirPorNombre(string nombreForm)
        {
            Type tipo = Type.GetType("Parcial3_Proyecto_DS4.CapaPresentacion." + nombreForm);
            if (tipo == null)
            {
                MessageBox.Show("El módulo '" + nombreForm + "' aún no está integrado en el proyecto.", "Módulo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (Form hijo in MdiChildren)
            {
                if (hijo.GetType() == tipo) { 
                    Reutilizar(hijo); return; }
            }

            try
            {
                Form frm = (Form)Activator.CreateInstance(tipo);
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la ventana.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reutilizar(Form hijo)
        {
            if (hijo.WindowState == FormWindowState.Minimized) hijo.WindowState = FormWindowState.Normal;
            hijo.Activate();
        }

        

        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Cerrar la sesión actual?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            CerrarSesionSolicitada = true;
            Close();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CerrarSesionSolicitada) 
                return;   // ya se confirmó en mnuCerrarSesion

            DialogResult r = MessageBox.Show("¿Desea salir del sistema?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) 
                e.Cancel = true;
        }

        private void FrmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            SesionUsuario.Registrar(CerrarSesionSolicitada ? "Cierre de sesión" : "Salida del sistema");
        }
    }
}
