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
        }

        private void FrmGestionUsuarios_Load(object sender, EventArgs e)
        {
            // Solo el administrador puede gestionar usuarios.
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

        // Valida los campos. La contraseña solo es obligatoria al crear un usuario nuevo.
        private bool ValidarCampos(bool esNuevo)
        {
            string username = txtUsername.Text.Trim();

            if (username.Length < 3)
            {
                Advertir("El usuario debe tener al menos 3 caracteres.", txtUsername);
                return false;
            }
            if (username.Contains(" "))
            {
                Advertir("El usuario no puede contener espacios.", txtUsername);
                return false;
            }
            if (esNuevo && txtPassword.Text.Length < 4)
            {
                Advertir("La contraseña debe tener al menos 4 caracteres.", txtPassword);
                return false;
            }
            if (!esNuevo && txtPassword.Text.Length > 0 && txtPassword.Text.Length < 4)
            {
                Advertir("La nueva contraseña debe tener al menos 4 caracteres.", txtPassword);
                return false;
            }
            if (cboRol.SelectedItem == null)
            {
                Advertir("Seleccione un rol.", cboRol);
                return false;
            }
            if (cboEstado.SelectedItem == null)
            {
                Advertir("Seleccione un estado.", cboEstado);
                return false;
            }
            return true;
        }

        private void Advertir(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            // No se permiten espacios en el nombre de usuario.
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
                    Advertir("Ya existe un usuario con ese nombre.", txtUsername);
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
                MessageBox.Show("Seleccione un usuario de la tabla.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidarCampos(false)) return;

            string username = txtUsername.Text.Trim();
            string estado = cboEstado.SelectedItem.ToString();

            // Evita que el administrador se bloquee a sí mismo.
            if (idSeleccionado == SesionUsuario.IdUsuario &&
                (estado == "Inactivo" || cboRol.SelectedItem.ToString() != "Administrador"))
            {
                Advertir("No puede desactivarse ni quitarse el rol de administrador a sí mismo.", cboEstado);
                return;
            }

            try
            {
                if (usuarioBD.ExisteUsername(username, idSeleccionado))
                {
                    Advertir("Ya existe otro usuario con ese nombre.", txtUsername);
                    return;
                }

                Usuario u = new Usuario
                {
                    IdUsuario = idSeleccionado,
                    Username = username,
                    Password = txtPassword.Text, // vacío = conservar la actual
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
                MessageBox.Show("Seleccione un usuario de la tabla.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (idSeleccionado == SesionUsuario.IdUsuario)
            {
                MessageBox.Show("No puede desactivar su propio usuario.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
