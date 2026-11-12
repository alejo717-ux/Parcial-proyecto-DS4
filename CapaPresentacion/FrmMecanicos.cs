using System;
using System.Windows.Forms;
using MySqlConnector;
using Parcial3_Proyecto_DS4.CapaDatos;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    public partial class FrmMecanicos : Form
    {
        private readonly MecanicoBD mecanicoBD = new MecanicoBD();
        private int idSeleccionado = 0;   // 0 = ningún mecánico seleccionado

        public FrmMecanicos()
        {
            InitializeComponent();

            // Eventos conectados por código (no hagas doble clic en los botones del diseñador)
            Load += FrmMecanicos_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            dgvMecanicos.CellClick += dgvMecanicos_CellClick;
            txtNombre.KeyPress += (s, e) => Validador.SoloLetras(e);
            txtTelefono.KeyPress += (s, e) => Validador.SoloTelefono(e);
        }

        private void FrmMecanicos_Load(object sender, EventArgs e)
        {
            // Límites iguales a los de la tabla Mecanicos
            txtNombre.MaxLength = 80;
            txtEspecialidad.MaxLength = 50;
            txtTelefono.MaxLength = 20;

            // Configuración de la tabla
            dgvMecanicos.ReadOnly = true;
            dgvMecanicos.AllowUserToAddRows = false;
            dgvMecanicos.MultiSelect = false;
            dgvMecanicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMecanicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            CargarGrid();
            Limpiar();
        }

        // ---------- Métodos de apoyo ----------
        private void CargarGrid()
        {
            try
            {
                dgvMecanicos.DataSource = mecanicoBD.Listar();
                if (dgvMecanicos.Columns["IdMecanico"] != null)
                    dgvMecanicos.Columns["IdMecanico"].HeaderText = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista de mecánicos.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            txtNombre.Clear();
            txtEspecialidad.Clear();
            txtTelefono.Clear();
            dgvMecanicos.ClearSelection();
            txtNombre.Focus();
        }

        // Valida los campos y arma el objeto Mecanico
        private bool TryObtenerMecanico(out Mecanico mecanico)
        {
            mecanico = null;

            if (!Validador.CampoObligatorio(txtNombre.Text, "Nombre")) { txtNombre.Focus(); return false; }
            if (!Validador.EsTelefonoValido(txtTelefono.Text)) { txtTelefono.Focus(); return false; }

            mecanico = new Mecanico
            {
                IdMecanico = idSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                Especialidad = txtEspecialidad.Text.Trim(),
                Telefono = txtTelefono.Text.Trim()
            };
            return true;
        }

        // ---------- Eventos ----------
        private void dgvMecanicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // clic en el encabezado

            DataGridViewRow fila = dgvMecanicos.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells["IdMecanico"].Value);
            txtNombre.Text = Convert.ToString(fila.Cells["Nombre"].Value);
            txtEspecialidad.Text = Convert.ToString(fila.Cells["Especialidad"].Value);
            txtTelefono.Text = Convert.ToString(fila.Cells["Telefono"].Value);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado != 0)
            {
                Validador.Advertencia("Hay un mecánico seleccionado. Use Actualizar, o pulse Limpiar para registrar uno nuevo.");
                return;
            }

            Mecanico m;
            if (!TryObtenerMecanico(out m)) return;

            try
            {
                if (mecanicoBD.Insertar(m))
                {
                    MessageBox.Show("Mecánico registrado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el mecánico.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Validador.Advertencia("Seleccione un mecánico de la tabla para actualizarlo.");
                return;
            }

            Mecanico m;
            if (!TryObtenerMecanico(out m)) return;

            try
            {
                if (mecanicoBD.Actualizar(m))
                {
                    MessageBox.Show("Mecánico actualizado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el mecánico.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Validador.Advertencia("Seleccione un mecánico de la tabla para eliminarlo.");
                return;
            }

            DialogResult r = MessageBox.Show("¿Seguro que desea eliminar este mecánico?", "Confirmar",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                if (mecanicoBD.Eliminar(idSeleccionado))
                {
                    MessageBox.Show("Mecánico eliminado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                    Limpiar();
                }
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                // 1451 = no se puede borrar porque otra tabla lo referencia
                Validador.Advertencia("No se puede eliminar este mecánico porque tiene órdenes de reparación asociadas.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el mecánico.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
