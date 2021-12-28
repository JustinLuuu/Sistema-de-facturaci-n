namespace Proyecto_final___Sistema_de_facturacion
{
    partial class GestionProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionProductos));
            this.panelProductos2 = new System.Windows.Forms.Panel();
            this.cbmBusqueda = new System.Windows.Forms.ComboBox();
            this.txtBuscarNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cmbEliminar = new System.Windows.Forms.ComboBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.cmbUpdate = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gboxInformacionProducto = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.gbListaTitulo = new System.Windows.Forms.GroupBox();
            this.dgvListaProductos = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panelProductos1 = new System.Windows.Forms.Panel();
            this.txtID_EliminarOActualizar = new System.Windows.Forms.TextBox();
            this.panelProductos2.SuspendLayout();
            this.gboxInformacionProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbListaTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProductos)).BeginInit();
            this.panelProductos1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelProductos2
            // 
            this.panelProductos2.Controls.Add(this.cbmBusqueda);
            this.panelProductos2.Controls.Add(this.txtBuscarNombre);
            this.panelProductos2.Location = new System.Drawing.Point(2, 223);
            this.panelProductos2.Name = "panelProductos2";
            this.panelProductos2.Size = new System.Drawing.Size(166, 80);
            this.panelProductos2.TabIndex = 34;
            // 
            // cbmBusqueda
            // 
            this.cbmBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmBusqueda.FormattingEnabled = true;
            this.cbmBusqueda.Items.AddRange(new object[] {
            "",
            "Por nombre"});
            this.cbmBusqueda.Location = new System.Drawing.Point(17, 14);
            this.cbmBusqueda.Name = "cbmBusqueda";
            this.cbmBusqueda.Size = new System.Drawing.Size(125, 23);
            this.cbmBusqueda.TabIndex = 24;
            this.cbmBusqueda.Text = "Filtro de busqueda";
            this.cbmBusqueda.SelectedIndexChanged += new System.EventHandler(this.cbmBusqueda_SelectedIndexChanged);
            this.cbmBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbmBusqueda_KeyPress);
            this.cbmBusqueda.Leave += new System.EventHandler(this.cbmBusqueda_Leave);
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarNombre.ForeColor = System.Drawing.Color.Gray;
            this.txtBuscarNombre.Location = new System.Drawing.Point(9, 47);
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(154, 20);
            this.txtBuscarNombre.TabIndex = 25;
            this.txtBuscarNombre.Text = "Escriba el nombre del producto";
            this.txtBuscarNombre.Visible = false;
            this.txtBuscarNombre.TextChanged += new System.EventHandler(this.txtBuscarNombre_TextChanged);
            this.txtBuscarNombre.Enter += new System.EventHandler(this.txtBuscarNombre_Enter);
            this.txtBuscarNombre.Leave += new System.EventHandler(this.txtBuscarNombre_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(65, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 43;
            this.label7.Text = "Seleccionar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(319, 58);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(88, 30);
            this.btnEliminar.TabIndex = 39;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cmbEliminar
            // 
            this.cmbEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEliminar.FormattingEnabled = true;
            this.cmbEliminar.Location = new System.Drawing.Point(262, 29);
            this.cmbEliminar.Name = "cmbEliminar";
            this.cmbEliminar.Size = new System.Drawing.Size(193, 23);
            this.cmbEliminar.TabIndex = 40;
            this.cmbEliminar.Text = "Seleccione producto a eliminar";
            this.cmbEliminar.SelectedValueChanged += new System.EventHandler(this.cmbEliminar_SelectedValueChanged);
            this.cmbEliminar.Click += new System.EventHandler(this.cmbEliminar_Click);
            this.cmbEliminar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbEliminar_KeyPress);
            this.cmbEliminar.Leave += new System.EventHandler(this.cmbEliminar_Leave);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(59, 60);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(88, 30);
            this.btnActualizar.TabIndex = 41;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // cmbUpdate
            // 
            this.cmbUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUpdate.FormattingEnabled = true;
            this.cmbUpdate.Location = new System.Drawing.Point(13, 31);
            this.cmbUpdate.Name = "cmbUpdate";
            this.cmbUpdate.Size = new System.Drawing.Size(203, 23);
            this.cmbUpdate.TabIndex = 42;
            this.cmbUpdate.Text = "Seleccione producto a actualizar";
            this.cmbUpdate.SelectedValueChanged += new System.EventHandler(this.cmbUpdate_SelectedValueChanged);
            this.cmbUpdate.Click += new System.EventHandler(this.cmbUpdate_Click);
            this.cmbUpdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUpdate_KeyPress);
            this.cmbUpdate.Leave += new System.EventHandler(this.cmbUpdate_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(316, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 16);
            this.label8.TabIndex = 44;
            this.label8.Text = "Seleccionar";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(32, 359);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(88, 38);
            this.btnLimpiar.TabIndex = 32;
            this.btnLimpiar.Text = "Restablecer todo";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(504, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 15);
            this.label6.TabIndex = 31;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(18, 320);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(115, 30);
            this.btnAgregar.TabIndex = 30;
            this.btnAgregar.Text = "Agregar producto";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gboxInformacionProducto
            // 
            this.gboxInformacionProducto.Controls.Add(this.pictureBox3);
            this.gboxInformacionProducto.Controls.Add(this.pictureBox1);
            this.gboxInformacionProducto.Controls.Add(this.label2);
            this.gboxInformacionProducto.Controls.Add(this.label1);
            this.gboxInformacionProducto.Controls.Add(this.txtPrecio);
            this.gboxInformacionProducto.Controls.Add(this.txtNombre);
            this.gboxInformacionProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxInformacionProducto.Location = new System.Drawing.Point(218, 221);
            this.gboxInformacionProducto.Name = "gboxInformacionProducto";
            this.gboxInformacionProducto.Size = new System.Drawing.Size(346, 114);
            this.gboxInformacionProducto.TabIndex = 29;
            this.gboxInformacionProducto.TabStop = false;
            this.gboxInformacionProducto.Text = "Informacion Del Producto";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(246, 69);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 19);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(248, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Precio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(110, 66);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(130, 22);
            this.txtPrecio.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(110, 38);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(132, 22);
            this.txtNombre.TabIndex = 0;
            // 
            // gbListaTitulo
            // 
            this.gbListaTitulo.Controls.Add(this.dgvListaProductos);
            this.gbListaTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbListaTitulo.Location = new System.Drawing.Point(12, 12);
            this.gbListaTitulo.Name = "gbListaTitulo";
            this.gbListaTitulo.Size = new System.Drawing.Size(629, 190);
            this.gbListaTitulo.TabIndex = 28;
            this.gbListaTitulo.TabStop = false;
            this.gbListaTitulo.Text = "Lista De Productos";
            // 
            // dgvListaProductos
            // 
            this.dgvListaProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaProductos.Location = new System.Drawing.Point(6, 22);
            this.dgvListaProductos.Name = "dgvListaProductos";
            this.dgvListaProductos.Size = new System.Drawing.Size(615, 162);
            this.dgvListaProductos.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(32, 403);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(88, 30);
            this.btnVolver.TabIndex = 45;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // panelProductos1
            // 
            this.panelProductos1.Controls.Add(this.txtID_EliminarOActualizar);
            this.panelProductos1.Controls.Add(this.label7);
            this.panelProductos1.Controls.Add(this.cmbUpdate);
            this.panelProductos1.Controls.Add(this.btnEliminar);
            this.panelProductos1.Controls.Add(this.btnActualizar);
            this.panelProductos1.Controls.Add(this.cmbEliminar);
            this.panelProductos1.Controls.Add(this.label8);
            this.panelProductos1.Location = new System.Drawing.Point(159, 351);
            this.panelProductos1.Name = "panelProductos1";
            this.panelProductos1.Size = new System.Drawing.Size(482, 91);
            this.panelProductos1.TabIndex = 46;
            // 
            // txtID_EliminarOActualizar
            // 
            this.txtID_EliminarOActualizar.Location = new System.Drawing.Point(214, 62);
            this.txtID_EliminarOActualizar.Name = "txtID_EliminarOActualizar";
            this.txtID_EliminarOActualizar.Size = new System.Drawing.Size(56, 20);
            this.txtID_EliminarOActualizar.TabIndex = 45;
            this.txtID_EliminarOActualizar.Visible = false;
            // 
            // GestionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(650, 455);
            this.Controls.Add(this.panelProductos1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.panelProductos2);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.gboxInformacionProducto);
            this.Controls.Add(this.gbListaTitulo);
            this.MaximizeBox = false;
            this.Name = "GestionProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionProductos";
            this.Load += new System.EventHandler(this.GestionProductos_Load);
            this.panelProductos2.ResumeLayout(false);
            this.panelProductos2.PerformLayout();
            this.gboxInformacionProducto.ResumeLayout(false);
            this.gboxInformacionProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbListaTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProductos)).EndInit();
            this.panelProductos1.ResumeLayout(false);
            this.panelProductos1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelProductos2;
        private System.Windows.Forms.ComboBox cbmBusqueda;
        private System.Windows.Forms.TextBox txtBuscarNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cmbEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ComboBox cmbUpdate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox gboxInformacionProducto;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox gbListaTitulo;
        private System.Windows.Forms.DataGridView dgvListaProductos;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Panel panelProductos1;
        private System.Windows.Forms.TextBox txtID_EliminarOActualizar;
    }
}