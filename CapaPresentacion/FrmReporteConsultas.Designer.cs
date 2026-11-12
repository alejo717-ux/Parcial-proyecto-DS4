namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    partial class FrmReporteConsultas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.lblEstadoFiltro = new System.Windows.Forms.Label();
            this.cboEstadoFiltro = new System.Windows.Forms.ComboBox();
            this.chkUsarFechas = new System.Windows.Forms.CheckBox();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.lblResumen = new System.Windows.Forms.Label();
            this.lblTituloResumen = new System.Windows.Forms.Label();
            this.dgvResumen = new System.Windows.Forms.DataGridView();
            this.gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumen)).BeginInit();
            this.SuspendLayout();
            this.gbFiltros.Controls.Add(this.lblEstadoFiltro);
            this.gbFiltros.Controls.Add(this.cboEstadoFiltro);
            this.gbFiltros.Controls.Add(this.chkUsarFechas);
            this.gbFiltros.Controls.Add(this.dtpDesde);
            this.gbFiltros.Controls.Add(this.lblHasta);
            this.gbFiltros.Controls.Add(this.dtpHasta);
            this.gbFiltros.Controls.Add(this.lblBuscar);
            this.gbFiltros.Controls.Add(this.txtBuscar);
            this.gbFiltros.Controls.Add(this.btnConsultar);
            this.gbFiltros.Controls.Add(this.btnLimpiar);
            
            // gbFiltros
            this.gbFiltros.Location = new System.Drawing.Point(12, 12);
            this.gbFiltros.Size = new System.Drawing.Size(976, 105);
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros del reporte";
            this.gbFiltros.Name = "gbFiltros";
            
            // lblEstadoFiltro
            this.lblEstadoFiltro.AutoSize = true;
            this.lblEstadoFiltro.Location = new System.Drawing.Point(20, 34);
            this.lblEstadoFiltro.Text = "Estado:";
            this.lblEstadoFiltro.Name = "lblEstadoFiltro";
            
            // cboEstadoFiltro
            this.cboEstadoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoFiltro.Location = new System.Drawing.Point(80, 30);
            this.cboEstadoFiltro.Size = new System.Drawing.Size(130, 24);
            this.cboEstadoFiltro.TabIndex = 1;
            this.cboEstadoFiltro.Name = "cboEstadoFiltro";
            
            // chkUsarFechas
            this.chkUsarFechas.AutoSize = true;
            this.chkUsarFechas.Location = new System.Drawing.Point(230, 32);
            this.chkUsarFechas.TabIndex = 2;
            this.chkUsarFechas.Text = "Filtrar por fecha:";
            this.chkUsarFechas.UseVisualStyleBackColor = true;
            this.chkUsarFechas.Name = "chkUsarFechas";
            this.chkUsarFechas.CheckedChanged += new System.EventHandler(this.chkUsarFechas_CheckedChanged);
            
            // dtpDesde
            this.dtpDesde.Enabled = false;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(370, 30);
            this.dtpDesde.Size = new System.Drawing.Size(110, 22);
            this.dtpDesde.TabIndex = 3;
            this.dtpDesde.Name = "dtpDesde";
            
            // lblHasta
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(488, 34);
            this.lblHasta.Text = "a";
            this.lblHasta.Name = "lblHasta";
            
            // dtpHasta
            this.dtpHasta.Enabled = false;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(508, 30);
            this.dtpHasta.Size = new System.Drawing.Size(110, 22);
            this.dtpHasta.TabIndex = 4;
            this.dtpHasta.Name = "dtpHasta";

            // lblBuscar
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(640, 34);
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.Name = "lblBuscar";
            
            // txtBuscar
            this.txtBuscar.Location = new System.Drawing.Point(700, 30);
            this.txtBuscar.Size = new System.Drawing.Size(250, 22);
            this.txtBuscar.TabIndex = 5;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            
            // btnConsultar
            this.btnConsultar.Location = new System.Drawing.Point(20, 63);
            this.btnConsultar.Size = new System.Drawing.Size(110, 30);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            
            // btnLimpiar
            this.btnLimpiar.Location = new System.Drawing.Point(140, 63);
            this.btnLimpiar.Size = new System.Drawing.Size(110, 30);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            
            // dgvReporte
            this.dgvReporte.Location = new System.Drawing.Point(12, 125);
            this.dgvReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporte.Size = new System.Drawing.Size(976, 290);
            this.dgvReporte.TabIndex = 8;
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvReporte_DataBindingComplete);
            
            // lblResumen
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblResumen.Location = new System.Drawing.Point(12, 425);
            this.lblResumen.Text = "Órdenes listadas: 0";
            this.lblResumen.Name = "lblResumen";
            
            // lblTituloResumen
            this.lblTituloResumen.AutoSize = true;
            this.lblTituloResumen.Location = new System.Drawing.Point(12, 455);
            this.lblTituloResumen.Text = "Resumen por mecánico (LEFT JOIN + GROUP BY):";
            this.lblTituloResumen.Name = "lblTituloResumen";
            
            // dgvResumen
            this.dgvResumen.Location = new System.Drawing.Point(12, 478);
            this.dgvResumen.Size = new System.Drawing.Size(976, 150);
            this.dgvResumen.TabIndex = 9;
            this.dgvResumen.AllowUserToAddRows = false;
            this.dgvResumen.AllowUserToDeleteRows = false;
            this.dgvResumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResumen.ReadOnly = true;
            this.dgvResumen.Name = "dgvResumen";
            
            // FrmReporteConsultas
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.lblTituloResumen);
            this.Controls.Add(this.dgvResumen);
            this.Name = "FrmReporteConsultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte de Consultas (JOIN)";
            this.Load += new System.EventHandler(this.FrmReporteConsultas_Load);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Label lblEstadoFiltro;
        private System.Windows.Forms.ComboBox cboEstadoFiltro;
        private System.Windows.Forms.CheckBox chkUsarFechas;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Label lblTituloResumen;
        private System.Windows.Forms.DataGridView dgvResumen;
    }
}
