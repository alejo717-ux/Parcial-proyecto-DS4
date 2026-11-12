using System;
using System.Windows.Forms;
using MySqlConnector;
using Parcial3_Proyecto_DS4.CapaDatos;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    public partial class FrmClientes : Form
    {
        private readonly ClienteBD clienteBD = new ClienteBD();
        private int idSeleccionado = 0;   // 0 = ningún cliente seleccionado

        public FrmClientes()
        {
            InitializeComponent();

            // Eventos conectados por código (no hagas doble clic en los botones del diseñador)
            Load += FrmClientes_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            dgvClientes.CellClick += dgvClientes_CellClick;
            txtNombre.KeyPress += (s, e) => Validador.SoloLetras(e);
            txtTelefono.KeyPress += (s, e) => Validador.SoloTelefono(e);
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            // Límites iguales a los de la tabla Clientes
            txtNombre.MaxLength = 80;
            txtTelefono.MaxLength = 20;
            txtCorreo.MaxLength = 100;
            txtDireccion.MaxLength = 150;

            // Configuración de la tabla
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.MultiSelect = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            CargarGrid();
            Limpiar();
        }

        // ---------- Métodos de apoyo ----------
        private void CargarGrid()
        {
            try
            {
                dgvClientes.DataSource = clienteBD.Listar();
                if (dgvClientes.Columns["IdCliente"] != null)
                    dgvClientes.Columns["IdCliente"].HeaderText = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista de clientes.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            dgvClientes.ClearSelection();
            txtNombre.Focus();
        }

        // Valida los campos y arma el objeto Cliente
        private bool TryObtenerCliente(out Cliente cliente)
        {
            cliente = null;

            if (!Validador.CampoObligatorio(txtNombre.Text, "Nombre")) { txtNombre.Focus(); return false; }
            if (!Validador.EsTelefonoValido(txtTelefono.Text)) { txtTelefono.Focus(); return false; }
            if (!Validador.EsCorreoValido(txtCorreo.Text)) { txtCorreo.Focus(); return false; }

            cliente = new Cliente
            {
                IdCliente = idSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Direccion = txtDireccion.Text.Trim()
            };
            return true;
        }

        // ---------- Eventos ----------
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // clic en el encabezado

            DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells["IdCliente"].Value);
            txtNombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
            txtTelefono.Text = Convert.ToString(fila.Cells["Telefono"].Value);
            txtCorreo.Text = Convert.ToString(fila.Cells["Correo"].Value);
            txtDireccion.Text = Convert.ToString(fila.Cells["Direccion"].Value);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado != 0)
            {
                Validador.Advertencia("Hay un cliente seleccionado. Use Actualizar, o pulse Limpiar para registrar uno nuevo.");
                return;
            }

            Cliente c;
            if (!TryObtenerCliente(out c)) return;

            try
            {
                if (clienteBD.Insertar(c))
                {
                    MessageBox.Show("Cliente registrado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el cliente.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Validador.Advertencia("Seleccione un cliente de la tabla para actualizarlo.");
                return;
            }

            Cliente c;
            if (!TryObtenerCliente(out c)) return;

            try
            {
                if (clienteBD.Actualizar(c))
                {
                    MessageBox.Show("Cliente actualizado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el cliente.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Validador.Advertencia("Seleccione un cliente de la tabla para eliminarlo.");
                return;
            }

            DialogResult r = MessageBox.Show("¿Seguro que desea eliminar este cliente?", "Confirmar",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                if (clienteBD.Eliminar(idSeleccionado))
                {
                    MessageBox.Show("Cliente eliminado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                    Limpiar();
                }
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                // 1451 = no se puede borrar porque otra tabla lo referencia
                Validador.Advertencia("No se puede eliminar este cliente porque tiene órdenes de reparación asociadas.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el cliente.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
