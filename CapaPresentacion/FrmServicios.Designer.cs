namespace Parcial3_Proyecto_DS4.CapaPresentacion
{
    partial class FrmServicios
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            this.btnCategorias = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombreServicio
            // 
            this.txtNombreServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtNombreServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreServicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombreServicio.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtNombreServicio.Location = new System.Drawing.Point(28, 50);
            this.txtNombreServicio.Name = "txtNombreServicio";
            this.txtNombreServicio.Size = new System.Drawing.Size(220, 25);
            this.txtNombreServicio.TabIndex = 0;
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblServicio.Location = new System.Drawing.Point(28, 28);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(55, 17);
            this.lblServicio.TabIndex = 1;
            this.lblServicio.Text = "Servicio";
            // 
            // txtPrecioBase
            // 
            this.txtPrecioBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtPrecioBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioBase.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecioBase.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtPrecioBase.Location = new System.Drawing.Point(28, 105);
            this.txtPrecioBase.Name = "txtPrecioBase";
            this.txtPrecioBase.Size = new System.Drawing.Size(220, 25);
            this.txtPrecioBase.TabIndex = 2;
            // 
            // lblPrecioBase
            // 
            this.lblPrecioBase.AutoSize = true;
            this.lblPrecioBase.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPrecioBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblPrecioBase.Location = new System.Drawing.Point(28, 83);
            this.lblPrecioBase.Name = "lblPrecioBase";
            this.lblPrecioBase.Size = new System.Drawing.Size(78, 17);
            this.lblPrecioBase.TabIndex = 3;
            this.lblPrecioBase.Text = "Precio base";
            // 
            // cboCategoria
            // 
            this.cboCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategoria.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(28, 160);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(220, 25);
            this.cboCategoria.TabIndex = 4;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblCategoria.Location = new System.Drawing.Point(28, 138);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(70, 17);
            this.lblCategoria.TabIndex = 5;
            this.lblCategoria.Text = "Categoría";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(28, 250);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(105, 34);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnActualizar.Location = new System.Drawing.Point(143, 250);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(105, 34);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(28, 295);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(105, 34);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLimpiar.Location = new System.Drawing.Point(143, 295);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(105, 34);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.AllowUserToDeleteRows = false;
            this.dgvServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.dgvServicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvServicios.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.dgvServicios.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.dgvServicios.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicios.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.dgvServicios.DefaultCellStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServicios.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.dgvServicios.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvServicios.EnableHeadersVisualStyles = false;
            this.dgvServicios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.dgvServicios.Location = new System.Drawing.Point(280, 28);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            this.dgvServicios.RowHeadersVisible = false;
            this.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicios.Size = new System.Drawing.Size(490, 360);
            this.dgvServicios.TabIndex = 10;
            // 
            // btnCategorias
            // 
            this.btnCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            this.btnCategorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategorias.FlatAppearance.BorderSize = 0;
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCategorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnCategorias.Location = new System.Drawing.Point(28, 200);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(220, 30);
            this.btnCategorias.TabIndex = 11;
            this.btnCategorias.Text = "Gestionar Categorías";
            this.btnCategorias.UseVisualStyleBackColor = false;
            // 
            // FrmServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCategorias);
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
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestión de Servicios - Taller Mecánico";
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
        private System.Windows.Forms.Button btnCategorias;
    }
}
