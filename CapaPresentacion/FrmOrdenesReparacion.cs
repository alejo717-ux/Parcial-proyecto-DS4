using System;
using System.Data;
using System.Windows.Forms;
using Parcial3_Proyecto_DS4.CapaDatos;
using Parcial3_Proyecto_DS4.CapaEntidad;

namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    public partial class FrmOrdenesReparacion : Form
    {
        private readonly OrdenReparacionBD ordenBD = new OrdenReparacionBD();
        private int idSeleccionado = 0;
        private string estadoSeleccionado = "";
        private bool cargando = false;

        public FrmOrdenesReparacion()
        {
            InitializeComponent();
        }

        private void FrmOrdenesReparacion_Load(object sender, EventArgs e)
        {
            try
            {
                cargando = true;
                CargarCombo(cboCliente, "Clientes");
                CargarCombo(cboMecanico, "Mecanicos");
                CargarCombo(cboServicio, "Servicios");
                cboEstado.Items.AddRange(OrdenReparacionBD.Estados);
                cargando = false;

                CargarOrdenes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                cargando = false;
                MessageBox.Show("No se pudo cargar la pantalla.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombo(ComboBox cbo, string tabla)
        {
            cbo.DisplayMember = "Nombre";
            cbo.ValueMember = "Id";
            cbo.DataSource = ordenBD.ObtenerCombo(tabla);
            cbo.SelectedIndex = -1;
        }

        private void CargarOrdenes()
        {
            try
            {
                dgvOrdenes.DataSource = ordenBD.ListarConJoin(null, txtBuscar.Text, null, null);

                foreach (string col in new[] { "IdCliente", "IdMecanico", "IdServicio" })
                    dgvOrdenes.Columns[col].Visible = false;

                dgvOrdenes.Columns["IdOrden"].HeaderText = "N.º";
                dgvOrdenes.Columns["FechaIngreso"].HeaderText = "Fecha ingreso";
                dgvOrdenes.Columns["FechaIngreso"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvOrdenes.Columns["Precio"].DefaultCellStyle.Format = "C2";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista de órdenes.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            DataRowView fila = cboServicio.SelectedItem as DataRowView;
            txtPrecio.Text = fila == null ? "" : Convert.ToDecimal(fila["Precio"]).ToString("N2");
        }

        private void dgvOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow f = dgvOrdenes.Rows[e.RowIndex];

            idSeleccionado = Convert.ToInt32(f.Cells["IdOrden"].Value);
            estadoSeleccionado = Convert.ToString(f.Cells["Estado"].Value);

            cboCliente.SelectedValue = f.Cells["IdCliente"].Value;
            cboMecanico.SelectedValue = f.Cells["IdMecanico"].Value;
            cboServicio.SelectedValue = f.Cells["IdServicio"].Value;
            cboEstado.SelectedItem = estadoSeleccionado;
            dtpFechaIngreso.Value = Convert.ToDateTime(f.Cells["FechaIngreso"].Value);

            btnGuardar.Enabled = false;
            btnActualizar.Enabled = btnEliminar.Enabled = btnAvanzarEstado.Enabled = true;
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                CargarOrdenes();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            try
            {
                if (ordenBD.Insertar(LeerOrden()))
                {
                    SesionUsuario.Registrar("Registró una orden de reparación para " + cboCliente.Text);
                    MessageBox.Show("Orden registrada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarOrdenes();
                    LimpiarCampos();
                }
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) { Validador.Advertencia("Seleccione una orden de la lista."); return; }
            if (estadoSeleccionado == "Completada")
            {
                Validador.Advertencia("Una orden completada no se puede modificar.");
                return;
            }
            if (!ValidarCampos()) return;

            try
            {
                OrdenReparacion o = LeerOrden();
                o.IdOrden = idSeleccionado;
                if (ordenBD.Actualizar(o))
                {
                    SesionUsuario.Registrar("Actualizó la orden #" + idSeleccionado);
                    MessageBox.Show("Orden actualizada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarOrdenes();
                    LimpiarCampos();
                }
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) { Validador.Advertencia("Seleccione una orden de la lista."); return; }
            if (estadoSeleccionado == "Completada")
            {
                Validador.Advertencia("No se puede eliminar una orden completada (queda como historial).");
                return;
            }

            DialogResult r = MessageBox.Show("¿Eliminar la orden #" + idSeleccionado + "?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                if (ordenBD.Eliminar(idSeleccionado))
                {
                    SesionUsuario.Registrar("Eliminó la orden #" + idSeleccionado);
                    CargarOrdenes();
                    LimpiarCampos();
                }
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        private void btnAvanzarEstado_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) { Validador.Advertencia("Seleccione una orden de la lista."); return; }

            string siguiente;
            if (estadoSeleccionado == "Pendiente")
                siguiente = "En proceso";
            else if (estadoSeleccionado == "En proceso")
                siguiente = "Completada";
            else
            {
                Validador.Advertencia("La orden está '" + estadoSeleccionado + "' y no puede avanzar.");
                return;
            }

            try
            {
                if (ordenBD.CambiarEstado(idSeleccionado, siguiente))
                {
                    SesionUsuario.Registrar("Orden #" + idSeleccionado + ": " + estadoSeleccionado + " -> " + siguiente);
                    CargarOrdenes();
                    LimpiarCampos();
                }
            }
            catch (Exception ex) { MostrarError(ex); }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarOrdenes();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            LimpiarCampos();
            CargarOrdenes();
        }

        private bool ValidarCampos()
        {
            if (!Validador.ComboSeleccionado(cboCliente, "cliente")) return false;
            if (!Validador.ComboSeleccionado(cboMecanico, "mecánico")) return false;
            if (!Validador.ComboSeleccionado(cboServicio, "servicio")) return false;
            if (!Validador.ComboSeleccionado(cboEstado, "estado")) return false;
            if (!Validador.EsFechaValidaNoFutura(dtpFechaIngreso)) return false;

            decimal precio;
            if (!Validador.EsDecimalPositivo(txtPrecio.Text, "Precio", out precio))
            {
                txtPrecio.Focus();
                return false;
            }
            return true;
        }

        private OrdenReparacion LeerOrden()
        {
            return new OrdenReparacion
            {
                FechaIngreso = dtpFechaIngreso.Value.Date,
                IdCliente = Convert.ToInt32(cboCliente.SelectedValue),
                IdMecanico = Convert.ToInt32(cboMecanico.SelectedValue),
                IdServicio = Convert.ToInt32(cboServicio.SelectedValue),
                EstadoOrden = cboEstado.SelectedItem.ToString()
            };
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            estadoSeleccionado = "";
            cboCliente.SelectedIndex = -1;
            cboMecanico.SelectedIndex = -1;
            cboServicio.SelectedIndex = -1;
            cboEstado.SelectedItem = "Pendiente";
            dtpFechaIngreso.Value = DateTime.Today;
            txtPrecio.Clear();
            dgvOrdenes.ClearSelection();

            btnGuardar.Enabled = true;
            btnActualizar.Enabled = btnEliminar.Enabled = btnAvanzarEstado.Enabled = false;
        }

        private void MostrarError(Exception ex)
        {
            MessageBox.Show("Ocurrió un error.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}