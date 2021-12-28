namespace Proyecto_final___Sistema_de_facturacion
{
    partial class GestionProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionProveedor));
            this.cbmBusqueda = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbUpdate = new System.Windows.Forms.ComboBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.cmbEliminar = new System.Windows.Forms.ComboBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.gboxInformacionProveedor = new System.Windows.Forms.GroupBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.gbListaTitulo = new System.Windows.Forms.GroupBox();
            this.dgvListaProveedores = new System.Windows.Forms.DataGridView();
            this.panelProveedores2 = new System.Windows.Forms.Panel();
            this.txtBuscarProveedorEmail = new System.Windows.Forms.TextBox();
            this.txtBuscarProveedorName = new System.Windows.Forms.TextBox();
            this.panelProveedores1 = new System.Windows.Forms.Panel();
            this.gboxInformacionProveedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbListaTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProveedores)).BeginInit();
            this.panelProveedores2.SuspendLayout();
            this.panelProveedores1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbmBusqueda
            // 
            this.cbmBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmBusqueda.FormattingEnabled = true;
            this.cbmBusqueda.Items.AddRange(new object[] {
            "",
            "Por nombre",
            "Por email"});
            this.cbmBusqueda.Location = new System.Drawing.Point(21, 3);
            this.cbmBusqueda.Name = "cbmBusqueda";
            this.cbmBusqueda.Size = new System.Drawing.Size(125, 23);
            this.cbmBusqueda.TabIndex = 36;
            this.cbmBusqueda.Text = "Filtro de busqueda";
            this.cbmBusqueda.SelectedIndexChanged += new System.EventHandler(this.cbmBusqueda_SelectedIndexChanged);
            this.cbmBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbmBusqueda_KeyPress);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(39, 316);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(88, 38);
            this.btnLimpiar.TabIndex = 35;
            this.btnLimpiar.Text = "Restablecer todo";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(61, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 16);
            this.label8.TabIndex = 34;
            this.label8.Text = "Seleccionar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(61, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 33;
            this.label7.Text = "Seleccionar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(504, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 15);
            this.label6.TabIndex = 32;
            // 
            // cmbUpdate
            // 
            this.cmbUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUpdate.FormattingEnabled = true;
            this.cmbUpdate.Location = new System.Drawing.Point(0, 31);
            this.cmbUpdate.Name = "cmbUpdate";
            this.cmbUpdate.Size = new System.Drawing.Size(225, 23);
            this.cmbUpdate.TabIndex = 31;
            this.cmbUpdate.Text = "Seleccione ID proveedor a actualizar";
            this.cmbUpdate.SelectedValueChanged += new System.EventHandler(this.cmbUpdate_SelectedValueChanged);
            this.cmbUpdate.Click += new System.EventHandler(this.cmbUpdate_Click);
            this.cmbUpdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUpdate_KeyPress);
            this.cmbUpdate.Leave += new System.EventHandler(this.cmbUpdate_Leave);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(64, 60);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(104, 30);
            this.btnActualizar.TabIndex = 30;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // cmbEliminar
            // 
            this.cmbEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEliminar.FormattingEnabled = true;
            this.cmbEliminar.Location = new System.Drawing.Point(0, 129);
            this.cmbEliminar.Name = "cmbEliminar";
            this.cmbEliminar.Size = new System.Drawing.Size(225, 23);
            this.cmbEliminar.TabIndex = 29;
            this.cmbEliminar.Text = "Seleccione ID proveedor a eliminar";
            this.cmbEliminar.SelectedValueChanged += new System.EventHandler(this.cmbEliminar_SelectedValueChanged);
            this.cmbEliminar.Click += new System.EventHandler(this.cmbEliminar_Click);
            this.cmbEliminar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbEliminar_KeyPress);
            this.cmbEliminar.Leave += new System.EventHandler(this.cmbEliminar_Leave);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(39, 364);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(88, 30);
            this.btnVolver.TabIndex = 28;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(27, 277);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(125, 30);
            this.btnAgregar.TabIndex = 26;
            this.btnAgregar.Text = "Agregar proveedor";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(64, 158);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(104, 30);
            this.btnEliminar.TabIndex = 27;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // gboxInformacionProveedor
            // 
            this.gboxInformacionProveedor.Controls.Add(this.pictureBox5);
            this.gboxInformacionProveedor.Controls.Add(this.pictureBox3);
            this.gboxInformacionProveedor.Controls.Add(this.pictureBox2);
            this.gboxInformacionProveedor.Controls.Add(this.pictureBox1);
            this.gboxInformacionProveedor.Controls.Add(this.label4);
            this.gboxInformacionProveedor.Controls.Add(this.label3);
            this.gboxInformacionProveedor.Controls.Add(this.label2);
            this.gboxInformacionProveedor.Controls.Add(this.label1);
            this.gboxInformacionProveedor.Controls.Add(this.txtEmail);
            this.gboxInformacionProveedor.Controls.Add(this.txtCedula);
            this.gboxInformacionProveedor.Controls.Add(this.txtNombre);
            this.gboxInformacionProveedor.Controls.Add(this.txtTelefono);
            this.gboxInformacionProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxInformacionProveedor.Location = new System.Drawing.Point(205, 239);
            this.gboxInformacionProveedor.Name = "gboxInformacionProveedor";
            this.gboxInformacionProveedor.Size = new System.Drawing.Size(329, 152);
            this.gboxInformacionProveedor.TabIndex = 25;
            this.gboxInformacionProveedor.TabStop = false;
            this.gboxInformacionProveedor.Text = "Informacion Del Proveedor";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(298, 122);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(24, 19);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(246, 72);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 19);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(246, 97);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 19);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(246, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Telefono";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cedula";
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
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(110, 122);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(182, 22);
            this.txtEmail.TabIndex = 3;
            // 
            // txtCedula
            // 
            this.txtCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.Location = new System.Drawing.Point(110, 66);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(130, 22);
            this.txtCedula.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(110, 38);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(130, 22);
            this.txtNombre.TabIndex = 0;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(110, 94);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(130, 22);
            this.txtTelefono.TabIndex = 2;
            // 
            // gbListaTitulo
            // 
            this.gbListaTitulo.Controls.Add(this.dgvListaProveedores);
            this.gbListaTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbListaTitulo.Location = new System.Drawing.Point(12, 12);
            this.gbListaTitulo.Name = "gbListaTitulo";
            this.gbListaTitulo.Size = new System.Drawing.Size(765, 185);
            this.gbListaTitulo.TabIndex = 24;
            this.gbListaTitulo.TabStop = false;
            this.gbListaTitulo.Text = "Lista De Proveedores";
            // 
            // dgvListaProveedores
            // 
            this.dgvListaProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaProveedores.Location = new System.Drawing.Point(6, 22);
            this.dgvListaProveedores.Name = "dgvListaProveedores";
            this.dgvListaProveedores.Size = new System.Drawing.Size(753, 157);
            this.dgvListaProveedores.TabIndex = 0;
            // 
            // panelProveedores2
            // 
            this.panelProveedores2.Controls.Add(this.txtBuscarProveedorEmail);
            this.panelProveedores2.Controls.Add(this.txtBuscarProveedorName);
            this.panelProveedores2.Controls.Add(this.cbmBusqueda);
            this.panelProveedores2.Location = new System.Drawing.Point(12, 204);
            this.panelProveedores2.Name = "panelProveedores2";
            this.panelProveedores2.Size = new System.Drawing.Size(172, 57);
            this.panelProveedores2.TabIndex = 39;
            // 
            // txtBuscarProveedorEmail
            // 
            this.txtBuscarProveedorEmail.ForeColor = System.Drawing.Color.Gray;
            this.txtBuscarProveedorEmail.Location = new System.Drawing.Point(6, 32);
            this.txtBuscarProveedorEmail.Name = "txtBuscarProveedorEmail";
            this.txtBuscarProveedorEmail.Size = new System.Drawing.Size(163, 20);
            this.txtBuscarProveedorEmail.TabIndex = 41;
            this.txtBuscarProveedorEmail.Text = "Escriba el email de proveedor";
            this.txtBuscarProveedorEmail.Visible = false;
            this.txtBuscarProveedorEmail.TextChanged += new System.EventHandler(this.txtBuscarProveedorEmail_TextChanged);
            this.txtBuscarProveedorEmail.Enter += new System.EventHandler(this.txtBuscarProveedorEmail_Enter);
            // 
            // txtBuscarProveedorName
            // 
            this.txtBuscarProveedorName.ForeColor = System.Drawing.Color.Gray;
            this.txtBuscarProveedorName.Location = new System.Drawing.Point(9, 32);
            this.txtBuscarProveedorName.Name = "txtBuscarProveedorName";
            this.txtBuscarProveedorName.Size = new System.Drawing.Size(163, 20);
            this.txtBuscarProveedorName.TabIndex = 37;
            this.txtBuscarProveedorName.Text = "Escriba el nombre de proveedor";
            this.txtBuscarProveedorName.Visible = false;
            this.txtBuscarProveedorName.TextChanged += new System.EventHandler(this.txtBuscarProveedorName_TextChanged);
            this.txtBuscarProveedorName.Enter += new System.EventHandler(this.txtBuscarProveedorName_Enter);
            // 
            // panelProveedores1
            // 
            this.panelProveedores1.Controls.Add(this.label7);
            this.panelProveedores1.Controls.Add(this.btnEliminar);
            this.panelProveedores1.Controls.Add(this.cmbEliminar);
            this.panelProveedores1.Controls.Add(this.label8);
            this.panelProveedores1.Controls.Add(this.btnActualizar);
            this.panelProveedores1.Controls.Add(this.cmbUpdate);
            this.panelProveedores1.Location = new System.Drawing.Point(563, 221);
            this.panelProveedores1.Name = "panelProveedores1";
            this.panelProveedores1.Size = new System.Drawing.Size(236, 182);
            this.panelProveedores1.TabIndex = 40;
            // 
            // GestionProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(819, 415);
            this.Controls.Add(this.panelProveedores1);
            this.Controls.Add(this.panelProveedores2);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.gboxInformacionProveedor);
            this.Controls.Add(this.gbListaTitulo);
            this.MaximizeBox = false;
            this.Name = "GestionProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionProveedor";
            this.Load += new System.EventHandler(this.GestionProveedor_Load);
            this.gboxInformacionProveedor.ResumeLayout(false);
            this.gboxInformacionProveedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbListaTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProveedores)).EndInit();
            this.panelProveedores2.ResumeLayout(false);
            this.panelProveedores2.PerformLayout();
            this.panelProveedores1.ResumeLayout(false);
            this.panelProveedores1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbmBusqueda;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbUpdate;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ComboBox cmbEliminar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox gboxInformacionProveedor;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.GroupBox gbListaTitulo;
        private System.Windows.Forms.DataGridView dgvListaProveedores;
        private System.Windows.Forms.Panel panelProveedores2;
        private System.Windows.Forms.Panel panelProveedores1;
        private System.Windows.Forms.TextBox txtBuscarProveedorName;
        private System.Windows.Forms.TextBox txtBuscarProveedorEmail;
    }
}