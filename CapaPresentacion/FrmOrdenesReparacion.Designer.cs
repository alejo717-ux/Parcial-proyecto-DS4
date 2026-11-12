namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    partial class FrmOrdenesReparacion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblMecanico = new System.Windows.Forms.Label();
            this.cboMecanico = new System.Windows.Forms.ComboBox();
            this.lblServicio = new System.Windows.Forms.Label();
            this.cboServicio = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAvanzarEstado = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.SuspendLayout();
            this.gbDatos.Controls.Add(this.lblCliente);
            this.gbDatos.Controls.Add(this.cboCliente);
            this.gbDatos.Controls.Add(this.lblMecanico);
            this.gbDatos.Controls.Add(this.cboMecanico);
            this.gbDatos.Controls.Add(this.lblServicio);
            this.gbDatos.Controls.Add(this.cboServicio);
            this.gbDatos.Controls.Add(this.lblEstado);
            this.gbDatos.Controls.Add(this.cboEstado);
            this.gbDatos.Controls.Add(this.lblFecha);
            this.gbDatos.Controls.Add(this.dtpFechaIngreso);
            this.gbDatos.Controls.Add(this.lblPrecio);
            this.gbDatos.Controls.Add(this.txtPrecio);
            
       
            //gbDatos
            this.gbDatos.Location = new System.Drawing.Point(12, 12);
            this.gbDatos.Size = new System.Drawing.Size(976, 150);
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de la orden de reparación";
            this.gbDatos.Name = "gbDatos";
            
            // lblCliente
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(20, 30);
            this.lblCliente.Text = "Cliente:";
            this.lblCliente.Name = "lblCliente";
            
            // cboCliente
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.Location = new System.Drawing.Point(110, 27);
            this.cboCliente.Size = new System.Drawing.Size(300, 24);
            this.cboCliente.TabIndex = 1;
            this.cboCliente.Name = "cboCliente";
            
            // lblMecanico
            this.lblMecanico.AutoSize = true;
            this.lblMecanico.Location = new System.Drawing.Point(500, 30);
            this.lblMecanico.Text = "Mecánico:";
            this.lblMecanico.Name = "lblMecanico";
          
            // cboMecanico
            this.cboMecanico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMecanico.Location = new System.Drawing.Point(590, 27);
            this.cboMecanico.Size = new System.Drawing.Size(300, 24);
            this.cboMecanico.TabIndex = 2;
            this.cboMecanico.Name = "cboMecanico";
            
            // lblServicio
            this.lblServicio.AutoSize = true;
            this.lblServicio.Location = new System.Drawing.Point(20, 68);
            this.lblServicio.Text = "Servicio:";
            this.lblServicio.Name = "lblServicio";
            
            // cboServicio
            this.cboServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServicio.Location = new System.Drawing.Point(110, 65);
            this.cboServicio.Size = new System.Drawing.Size(300, 24);
            this.cboServicio.TabIndex = 3;
            this.cboServicio.Name = "cboServicio";
            this.cboServicio.SelectedIndexChanged += new System.EventHandler(this.cboServicio_SelectedIndexChanged);
            
            // lblEstado
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(500, 68);
            this.lblEstado.Text = "Estado:";
            this.lblEstado.Name = "lblEstado";
           
            // cboEstado
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Location = new System.Drawing.Point(590, 65);
            this.cboEstado.Size = new System.Drawing.Size(200, 24);
            this.cboEstado.TabIndex = 4;
            this.cboEstado.Name = "cboEstado";
            
            // lblFecha
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(20, 106);
            this.lblFecha.Text = "Fecha ingreso:";
            this.lblFecha.Name = "lblFecha";
            
            // dtpFechaIngreso
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(110, 103);
            this.dtpFechaIngreso.Size = new System.Drawing.Size(130, 22);
            this.dtpFechaIngreso.TabIndex = 5;
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            
            // lblPrecio
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(500, 106);
            this.lblPrecio.Text = "Precio (B/.):";
            this.lblPrecio.Name = "lblPrecio";
            
            // txtPrecio
            this.txtPrecio.Location = new System.Drawing.Point(590, 103);
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(120, 22);
            this.txtPrecio.TabStop = false;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecio.Name = "txtPrecio";
            
            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(12, 172);
            this.btnGuardar.Size = new System.Drawing.Size(110, 32);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            
            // btnActualizar
            this.btnActualizar.Location = new System.Drawing.Point(128, 172);
            this.btnActualizar.Size = new System.Drawing.Size(110, 32);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            
            // btnEliminar
            this.btnEliminar.Location = new System.Drawing.Point(244, 172);
            this.btnEliminar.Size = new System.Drawing.Size(110, 32);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
           
            // btnAvanzarEstado
            this.btnAvanzarEstado.Location = new System.Drawing.Point(360, 172);
            this.btnAvanzarEstado.Size = new System.Drawing.Size(150, 32);
            this.btnAvanzarEstado.TabIndex = 9;
            this.btnAvanzarEstado.Text = "Avanzar estado";
            this.btnAvanzarEstado.UseVisualStyleBackColor = true;
            this.btnAvanzarEstado.Name = "btnAvanzarEstado";
            this.btnAvanzarEstado.Click += new System.EventHandler(this.btnAvanzarEstado_Click);
            
            // btnLimpiar
            this.btnLimpiar.Location = new System.Drawing.Point(516, 172);
            this.btnLimpiar.Size = new System.Drawing.Size(110, 32);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            
            // lblBuscar
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(650, 181);
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.Name = "lblBuscar";
            
            // txtBuscar
            this.txtBuscar.Location = new System.Drawing.Point(705, 178);
            this.txtBuscar.Size = new System.Drawing.Size(185, 22);
            this.txtBuscar.TabIndex = 11;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            
            // btnBuscar
            this.btnBuscar.Location = new System.Drawing.Point(898, 172);
            this.btnBuscar.Size = new System.Drawing.Size(90, 32);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            
            // dgvOrdenes
            this.dgvOrdenes.AllowUserToAddRows = false;
            this.dgvOrdenes.AllowUserToDeleteRows = false;
            this.dgvOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location = new System.Drawing.Point(12, 216);
            this.dgvOrdenes.MultiSelect = false;
            this.dgvOrdenes.ReadOnly = true;
            this.dgvOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenes.Size = new System.Drawing.Size(976, 390);
            this.dgvOrdenes.TabIndex = 13;
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenes_CellClick);
            
            // FrmOrdenesReparacion
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAvanzarEstado);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvOrdenes);
            this.Name = "FrmOrdenesReparacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Órdenes de Reparación";
            this.Load += new System.EventHandler(this.FrmOrdenesReparacion_Load);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblMecanico;
        private System.Windows.Forms.ComboBox cboMecanico;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.ComboBox cboServicio;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAvanzarEstado;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvOrdenes;
    }
}
