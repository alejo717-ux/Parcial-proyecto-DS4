namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    partial class FrmServicios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNombreServicio = new System.Windows.Forms.TextBox();
            this.lblServicio = new System.Windows.Forms.Label();
            this.txtPrecioBase = new System.Windows.Forms.TextBox();
            this.lblPrecioBase = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombreServicio
            // 
            this.txtNombreServicio.Location = new System.Drawing.Point(47, 76);
            this.txtNombreServicio.Name = "txtNombreServicio";
            this.txtNombreServicio.Size = new System.Drawing.Size(100, 20);
            this.txtNombreServicio.TabIndex = 0;
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Location = new System.Drawing.Point(44, 60);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(45, 13);
            this.lblServicio.TabIndex = 1;
            this.lblServicio.Text = "Servicio";
            // 
            // txtPrecioBase
            // 
            this.txtPrecioBase.Location = new System.Drawing.Point(47, 127);
            this.txtPrecioBase.Name = "txtPrecioBase";
            this.txtPrecioBase.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioBase.TabIndex = 2;
            // 
            // lblPrecioBase
            // 
            this.lblPrecioBase.AutoSize = true;
            this.lblPrecioBase.Location = new System.Drawing.Point(46, 111);
            this.lblPrecioBase.Name = "lblPrecioBase";
            this.lblPrecioBase.Size = new System.Drawing.Size(63, 13);
            this.lblPrecioBase.TabIndex = 3;
            this.lblPrecioBase.Text = "Precio base";
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(47, 186);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(121, 21);
            this.cboCategoria.TabIndex = 4;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(45, 166);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblCategoria.TabIndex = 5;
            this.lblCategoria.Text = "Categoria";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(46, 243);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(132, 243);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(46, 282);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(132, 282);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // dgvServicios
            // 
            this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicios.Location = new System.Drawing.Point(242, 60);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.Size = new System.Drawing.Size(518, 276);
            this.dgvServicios.TabIndex = 10;
            // 
            // FrmServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvServicios);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.lblPrecioBase);
            this.Controls.Add(this.txtPrecioBase);
            this.Controls.Add(this.lblServicio);
            this.Controls.Add(this.txtNombreServicio);
            this.Name = "FrmServicios";
            this.Text = "FrmServicios";
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreServicio;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.TextBox txtPrecioBase;
        private System.Windows.Forms.Label lblPrecioBase;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvServicios;
    }
}