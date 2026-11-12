using System;
using System.Windows.Forms;
using Parcial3_Proyecto_DS4.CapaDatos;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    public partial class FrmGestionUsuarios : Form
    {
        private readonly UsuarioBD usuarioBD = new UsuarioBD();
        private int idSeleccionado = 0;

        public FrmGestionUsuarios()
        {
            InitializeComponent();
            txtUsername.KeyPress += Validador.PrevenirEspaciosEnBlanco;
        }

        private void FrmGestionUsuarios_Load(object sender, EventArgs e)
        {
            if (!SesionUsuario.EsAdministrador)
            {
                MessageBox.Show("Solo un administrador puede gestionar usuarios.", "Acceso restringido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            cboRol.Items.AddRange(new object[] { "Administrador", "Recepcionista", "Mecanico" });
            cboEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            CargarUsuarios();
            LimpiarCampos();
        }

        private void CargarUsuarios()
        {
            try
            {
                dgvUsuarios.DataSource = usuarioBD.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista de usuarios.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            txtUsername.Clear();
            txtPassword.Clear();
            cboRol.SelectedIndex = 1;
            cboEstado.SelectedIndex = 0;
            dgvUsuarios.ClearSelection();
            txtUsername.Focus();
        }

        private bool ValidarCampos(bool esNuevo)
        {
            string username = txtUsername.Text.Trim();

            if (!Validador.EsUsernameValido(username)) { txtUsername.Focus(); return false; }
            if (!Validador.EsPasswordValido(txtPassword.Text, esNuevo)) { txtPassword.Focus(); return false; }
            if (!Validador.ComboSeleccionado(cboRol, "rol")) return false;
            if (!Validador.ComboSeleccionado(cboEstado, "estado")) return false;

            return true;
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells["IdUsuario"].Value);
            txtUsername.Text = fila.Cells["Username"].Value.ToString();
            txtPassword.Clear();
            cboRol.SelectedItem = fila.Cells["Rol"].Value.ToString();
            cboEstado.SelectedItem = fila.Cells["Estado"].Value.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(true)) return;

            string username = txtUsername.Text.Trim();
            try
            {
                if (usuarioBD.ExisteUsername(username))
                {
                    Validador.Advertencia("Ya existe un usuario con ese nombre.");
                    txtUsername.Focus();
                    return;
                }

                Usuario u = new Usuario
                {
                    Username = username,
                    Password = txtPassword.Text,
                    Rol = cboRol.SelectedItem.ToString(),
                    Estado = cboEstado.SelectedItem.ToString()
                };

                if (usuarioBD.Insertar(u))
                {
                    SesionUsuario.Registrar("Creó el usuario '" + u.Username + "' con rol " + u.Rol);
                    MessageBox.Show("Usuario creado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el usuario.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Validador.Advertencia("Seleccione un usuario de la tabla.");
                return;
            }
            if (!ValidarCampos(false)) return;

            string username = txtUsername.Text.Trim();
            string estado = cboEstado.SelectedItem.ToString();

            if (idSeleccionado == SesionUsuario.IdUsuario &&
                (estado == "Inactivo" || cboRol.SelectedItem.ToString() != "Administrador"))
            {
                Validador.Advertencia("No puede desactivarse ni quitarse el rol de administrador a sí mismo.");
                cboEstado.Focus();
                return;
            }

            try
            {
                if (usuarioBD.ExisteUsername(username, idSeleccionado))
                {
                    Validador.Advertencia("Ya existe otro usuario con ese nombre.");
                    txtUsername.Focus();
                    return;
                }

                Usuario u = new Usuario
                {
                    IdUsuario = idSeleccionado,
                    Username = username,
                    Password = txtPassword.Text,
                    Rol = cboRol.SelectedItem.ToString(),
                    Estado = estado
                };

                if (usuarioBD.Actualizar(u))
                {
                    string detalle = "Modificó el usuario '" + u.Username + "' (rol " + u.Rol + ", estado " + u.Estado + ")";
                    if (u.Password.Length > 0) detalle += " y cambió su contraseña";
                    SesionUsuario.Registrar(detalle);
                    MessageBox.Show("Usuario actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el usuario.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Validador.Advertencia("Seleccione un usuario de la tabla.");
                return;
            }
            if (idSeleccionado == SesionUsuario.IdUsuario)
            {
                Validador.Advertencia("No puede desactivar su propio usuario.");
                return;
            }

            string username = txtUsername.Text.Trim();
            DialogResult r = MessageBox.Show("¿Desactivar al usuario '" + username + "'?\n" +
                "Ya no podrá iniciar sesión, pero su historial se conserva.", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                if (usuarioBD.Eliminar(idSeleccionado))
                {
                    SesionUsuario.Registrar("Desactivó el usuario '" + username + "'");
                    CargarUsuarios();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo desactivar el usuario.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}