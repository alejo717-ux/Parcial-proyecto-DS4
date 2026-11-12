using System;
using System.Windows.Forms;
using MySqlConnector;
using Parcial3_Proyecto_DS4.CapaDatos;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    public partial class FrmCategorias : Form
    {
        private readonly CategoriaServicioBD categoriaBD = new CategoriaServicioBD();
        private int idSeleccionado = 0;   // 0 = ninguna categoría seleccionada

        public FrmCategorias()
        {
            InitializeComponent();

            // Eventos conectados por código (no hagas doble clic en los botones del diseñador)
            Load += FrmCategorias_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            dgvCategorias.CellClick += dgvCategorias_CellClick;
            txtNombreCategoria.KeyPress += (s, e) => Validador.SoloLetras(e);
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            // Límites iguales a los de la tabla CategoriasServicio
            txtNombreCategoria.MaxLength = 50;
            txtDescripcion.MaxLength = 200;

            // Configuración de la tabla
            dgvCategorias.ReadOnly = true;
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.MultiSelect = false;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            CargarGrid();
            Limpiar();
        }

        // ---------- Métodos de apoyo ----------
        private void CargarGrid()
        {
            try
            {
                dgvCategorias.DataSource = categoriaBD.Listar();

                if (dgvCategorias.Columns["IdCategoria"] != null)
                    dgvCategorias.Columns["IdCategoria"].HeaderText = "ID";
                if (dgvCategorias.Columns["NombreCategoria"] != null)
                    dgvCategorias.Columns["NombreCategoria"].HeaderText = "Categoría";
                if (dgvCategorias.Columns["Descripcion"] != null)
                    dgvCategorias.Columns["Descripcion"].HeaderText = "Descripción";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista de categorías.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            txtNombreCategoria.Clear();
            txtDescripcion.Clear();
            dgvCategorias.ClearSelection();
            txtNombreCategoria.Focus();
        }

        // Valida los campos y arma el objeto CategoriaServicio
        private bool TryObtenerCategoria(out CategoriaServicio categoria)
        {
            categoria = null;

            if (!Validador.CampoObligatorio(txtNombreCategoria.Text, "Nombre de la categoría"))
            {
                txtNombreCategoria.Focus();
                return false;
            }

            categoria = new CategoriaServicio
            {
                IdCategoria = idSeleccionado,
                NombreCategoria = txtNombreCategoria.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim()
            };
            return true;
        }

        // ---------- Eventos ----------
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // clic en el encabezado

            DataGridViewRow fila = dgvCategorias.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells["IdCategoria"].Value);
            txtNombreCategoria.Text = Convert.ToString(fila.Cells["NombreCategoria"].Value);
            txtDescripcion.Text = Convert.ToString(fila.Cells["Descripcion"].Value);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado != 0)
            {
                Validador.Advertencia("Hay una categoría seleccionada. Use Actualizar, o pulse Limpiar para registrar una nueva.");
                return;
            }

            CategoriaServicio c;
            if (!TryObtenerCategoria(out c)) return;

            try
            {
                if (categoriaBD.Insertar(c))
                {
                    MessageBox.Show("Categoría registrada correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la categoría.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Validador.Advertencia("Seleccione una categoría de la tabla para actualizarla.");
                return;
            }

            CategoriaServicio c;
            if (!TryObtenerCategoria(out c)) return;

            try
            {
                if (categoriaBD.Actualizar(c))
                {
                    MessageBox.Show("Categoría actualizada correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar la categoría.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Validador.Advertencia("Seleccione una categoría de la tabla para eliminarla.");
                return;
            }

            DialogResult r = MessageBox.Show("¿Seguro que desea eliminar esta categoría?", "Confirmar",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                if (categoriaBD.Eliminar(idSeleccionado))
                {
                    MessageBox.Show("Categoría eliminada correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                    Limpiar();
                }
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                // 1451 = no se puede borrar porque otra tabla lo referencia
                Validador.Advertencia("No se puede eliminar esta categoría porque tiene servicios asociados.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar la categoría.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
