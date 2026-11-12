using System;
using System.Data;
using System.Windows.Forms;
using Parcial3_Proyecto_DS4.CapaDatos;

namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    public partial class FrmBitacora : Form
    {
        private readonly BitacoraBD bitacoraBD = new BitacoraBD();

        public FrmBitacora()
        {
            InitializeComponent();
        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            if (!SesionUsuario.EsAdministrador)
            {
                Validador.Advertencia("Solo un administrador puede consultar la bitácora.");
                Close();
                return;
            }

            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;
            CargarBitacora(null, null, null);
        }

        private void CargarBitacora(DateTime? desde, DateTime? hasta, string texto)
        {
            try
            {
                DataTable dt = bitacoraBD.Listar(desde, hasta, texto);
                dgvBitacora.DataSource = dt;
                lblTotal.Text = "Registros: " + dt.Rows.Count;

                if (dgvBitacora.Columns.Contains("FechaHora"))
                    dgvBitacora.Columns["FechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la bitácora.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (!Validador.EsRangoFechasValido(dtpDesde, dtpHasta)) return;
            CargarBitacora(dtpDesde.Value, dtpHasta.Value, txtBuscar.Text);
        }

        private void btnVerTodo_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarBitacora(null, null, null);
        }
    }
}