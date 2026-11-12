using System;
using System.Windows.Forms;
using MySqlConnector;
using Parcial3_Proyecto_DS4.CapaDatos;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    public partial class FrmServicios : Form
    {
        private readonly ServicioBD servicioBD = new ServicioBD();
        private readonly CategoriaServicioBD categoriaBD = new CategoriaServicioBD();
        private int idSeleccionado = 0;   // 0 = ningún servicio seleccionado

        public FrmServicios()
        {
            InitializeComponent();

            // Eventos conectados por código (no hagas doble clic en los botones del diseñador)
            Load += FrmServicios_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnCategorias.Click += btnCategorias_Click;
            dgvServicios.CellClick += dgvServicios_CellClick;
            txtPrecioBase.KeyPress += (s, e) => Validador.SoloDecimal(e, txtPrecioBase);
        }

        private void FrmServicios_Load(object sender, EventArgs e)
        {
            // Límite igual al de la tabla Servicios
            txtNombreServicio.MaxLength = 80;

            // Configuración de la tabla
            dgvServicios.ReadOnly = true;
            dgvServicios.AllowUserToAddRows = false;
            dgvServicios.MultiSelect = false;
            dgvServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            CargarCategorias();
            CargarGrid();
            Limpiar();
        }

        // ---------- Métodos de apoyo ----------
        private void CargarCategorias()
        {
            try
            {
                cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
                cboCategoria.DisplayMember = "NombreCategoria";
                cboCategoria.ValueMember = "IdCategoria";
                cboCategoria.DataSource = categoriaBD.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las categorías.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrid()
        {
            try
            {
                dgvServicios.DataSource = servicioBD.Listar();

                if (dgvServicios.Columns["IdServicio"] != null)
                    dgvServicios.Columns["IdServicio"].HeaderText = "ID";
                if (dgvServicios.Columns["NombreServicio"] != null)
                    dgvServicios.Columns["NombreServicio"].HeaderText = "Servicio";
                if (dgvServicios.Columns["PrecioBase"] != null)
                {
                    dgvServicios.Columns["PrecioBase"].HeaderText = "Precio base";
                    dgvServicios.Columns["PrecioBase"].DefaultCellStyle.Format = "N2";
                }
                if (dgvServicios.Columns["NombreCategoria"] != null)
                    dgvServicios.Columns["NombreCategoria"].HeaderText = "Categoría";
                if (dgvServicios.Columns["IdCategoria"] != null)
                    dgvServicios.Columns["IdCategoria"].Visible = false;   // se usa internamente
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista de servicios.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            txtNombreServicio.Clear();
            txtPrecioBase.Clear();
            cboCategoria.SelectedIndex = -1;
            dgvServicios.ClearSelection();
            txtNombreServicio.Focus();
        }

        // Valida los campos y arma el objeto Servicio
        private bool TryObtenerServicio(out Servicio servicio)
        {
            servicio = null;

            if (!Validador.CampoObligatorio(txtNombreServicio.Text, "Nombre del servicio")) { txtNombreServicio.Focus(); return false; }
            if (!Validador.CampoObligatorio(txtPrecioBase.Text, "Precio base")) { txtPrecioBase.Focus(); return false; }

            decimal precio;
            if (!Validador.EsDecimalPositivo(txtPrecioBase.Text, "Precio base", out precio)) { txtPrecioBase.Focus(); return false; }

            if (cboCategoria.SelectedValue == null)
            {
                Validador.Advertencia("Seleccione una categoría.");
                cboCategoria.Focus();
                return false;
            }

            servicio = new Servicio
            {
                IdServicio = idSeleccionado,
                NombreServicio = txtNombreServicio.Text.Trim(),
                PrecioBase = precio,
                IdCategoria = Convert.ToInt32(cboCategoria.SelectedValue)
            };
            return true;
        }

        // ---------- Eventos ----------
        private void dgvServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // clic en el encabezado

            DataGridViewRow fila = dgvServicios.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells["IdServicio"].Value);
            txtNombreServicio.Text = Convert.ToString(fila.Cells["NombreServicio"].Value);
            txtPrecioBase.Text = Convert.ToDecimal(fila.Cells["PrecioBase"].Value).ToString("0.00");
            cboCategoria.SelectedValue = Convert.ToInt32(fila.Cells["IdCategoria"].Value);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado != 0)
            {
                Validador.Advertencia("Hay un servicio seleccionado. Use Actualizar, o pulse Limpiar para registrar uno nuevo.");
                return;
            }

            Servicio s;
            if (!TryObtenerServicio(out s)) return;

            try
            {
                if (servicioBD.Insertar(s))
                {
                    MessageBox.Show("Servicio registrado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el servicio.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Validador.Advertencia("Seleccione un servicio de la tabla para actualizarlo.");
                return;
            }

            Servicio s;
            if (!TryObtenerServicio(out s)) return;

            try
            {
                if (servicioBD.Actualizar(s))
                {
                    MessageBox.Show("Servicio actualizado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el servicio.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Validador.Advertencia("Seleccione un servicio de la tabla para eliminarlo.");
                return;
            }

            DialogResult r = MessageBox.Show("¿Seguro que desea eliminar este servicio?", "Confirmar",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                if (servicioBD.Eliminar(idSeleccionado))
                {
                    MessageBox.Show("Servicio eliminado correctamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                    Limpiar();
                }
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                // 1451 = no se puede borrar porque otra tabla lo referencia
                Validador.Advertencia("No se puede eliminar este servicio porque tiene órdenes de reparación asociadas.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el servicio.\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            using (FrmCategorias frm = new FrmCategorias())
            {
                frm.ShowDialog();
            }

            // Recargar por si se agregaron, cambiaron o eliminaron categorías
            CargarCategorias();
            CargarGrid();
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}