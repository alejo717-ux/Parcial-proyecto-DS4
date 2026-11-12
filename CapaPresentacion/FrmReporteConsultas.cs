using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Parcial3_Proyecto_DS4.CapaDatos;

namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    
    // (cliente + mecánico + servicio + categoría) y un resumen por mecánico (LEFT JOIN + GROUP BY).
    public partial class FrmReporteConsultas : Form
    {
        private readonly OrdenReparacionBD ordenBD = new OrdenReparacionBD();

        public FrmReporteConsultas()
        {
            InitializeComponent();
        }

        private void FrmReporteConsultas_Load(object sender, EventArgs e)
        {
            cboEstadoFiltro.Items.Add("Todos");
            cboEstadoFiltro.Items.AddRange(OrdenReparacionBD.Estados);
            cboEstadoFiltro.SelectedIndex = 0;

            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;
            Consultar();
        }

        private void Consultar()
        {
            string estado = cboEstadoFiltro.SelectedIndex <= 0 ? null : cboEstadoFiltro.SelectedItem.ToString();
            DateTime? desde = null, hasta = null;

            if (chkUsarFechas.Checked)
            {
                if (dtpDesde.Value.Date > dtpHasta.Value.Date)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpDesde.Focus();
                    return;
                }
                desde = dtpDesde.Value.Date;
                hasta = dtpHasta.Value.Date;
            }

            try
            {
                DataTable dt = ordenBD.ListarConJoin(estado, txtBuscar.Text, desde, hasta);
                dgvReporte.DataSource = dt;
                FormatearReporte();
                MostrarTotales(dt);

                dgvResumen.DataSource = ordenBD.ResumenPorMecanico();
                dgvResumen.Columns["TotalFacturado"].HeaderText = "Total facturado";
                dgvResumen.Columns["TotalFacturado"].DefaultCellStyle.Format = "C2";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar el reporte.\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearReporte()
        {
            foreach (string col in new[] { "IdCliente", "IdMecanico", "IdServicio" })
                dgvReporte.Columns[col].Visible = false;

            dgvReporte.Columns["IdOrden"].HeaderText = "N.º";
            dgvReporte.Columns["FechaIngreso"].HeaderText = "Fecha ingreso";
            dgvReporte.Columns["FechaIngreso"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvReporte.Columns["Precio"].DefaultCellStyle.Format = "C2";
        }

        private void MostrarTotales(DataTable dt)
        {
            // Compute devuelve DBNull si no hay filas: se valida antes de convertir.
            object suma = dt.Compute("SUM(Precio)", "Estado <> 'Cancelada'");
            decimal total = suma == DBNull.Value ? 0m : Convert.ToDecimal(suma);
            lblResumen.Text = "Órdenes listadas: " + dt.Rows.Count + "    |    Total facturable (sin canceladas): " + total.ToString("C2");
        }

        // Colorea la celda de Estado para leer el reporte de un vistazo.
        private void dgvReporte_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow fila in dgvReporte.Rows)
            {
                string estado = Convert.ToString(fila.Cells["Estado"].Value);
                Color c = Color.White;
                if (estado == "Pendiente") c = Color.LightGoldenrodYellow;
                else if (estado == "En proceso") c = Color.LightSkyBlue;
                else if (estado == "Completada") c = Color.LightGreen;
                else if (estado == "Cancelada") c = Color.LightCoral;
                fila.Cells["Estado"].Style.BackColor = c;
            }
        }

        private void chkUsarFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Enabled = dtpHasta.Enabled = chkUsarFechas.Checked;
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Consultar();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cboEstadoFiltro.SelectedIndex = 0;
            chkUsarFechas.Checked = false;
            txtBuscar.Clear();
            Consultar();
        }
    }
}
