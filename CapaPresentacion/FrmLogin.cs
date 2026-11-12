using System;
using System.Windows.Forms;
using Parcial3_Proyecto_DS4.CapaDatos;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        private const int MaxIntentos = 3;
        private int intentos = 0;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            if (!Validador.CampoObligatorio(usuario, "usuario")) { txtUsuario.Focus(); return; }
            if (!Validador.CampoObligatorio(password, "contraseña")) { txtPassword.Focus(); return; }

            try
            {
                Usuario u = new UsuarioBD().Login(usuario, password);

                if (u == null)
                {
                    intentos++;
                    Validador.Advertencia("Usuario o contraseña incorrectos, o el usuario está inactivo.\nIntento " + intentos + " de " + MaxIntentos + ".");
                    txtPassword.Clear();
                    txtPassword.Focus();

                    if (intentos >= MaxIntentos)
                    {
                        MessageBox.Show("Demasiados intentos fallidos. La aplicación se cerrará.",
                            "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        DialogResult = DialogResult.Cancel;
                        Close();
                    }
                    return;
                }

                SesionUsuario.Iniciar(u);
                SesionUsuario.Registrar("Inicio de sesión");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos.\n\n" + ex.Message,
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}