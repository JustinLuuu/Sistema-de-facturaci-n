using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final___Sistema_de_facturacion
{
    public partial class GestionProductos : Form
    {
        SqlConnection conect;

        public GestionProductos(SqlConnection conect)
        {
            InitializeComponent();
            this.conect = conect;
        }

        private void GestionProductos_Load(object sender, EventArgs e)
        {

            Productos loadForm = new Productos(conect);
             loadForm.Peticion(dgvListaProductos, "Select * from dbo.Producto");

            loadForm.LlenarCombo(cmbUpdate, "Select Nombre from dbo.Producto");
            loadForm.LlenarCombo(cmbEliminar, "Select Nombre from dbo.Producto");

            alternarColorFilas(dgvListaProductos);
        }


        private void cmbUpdate_Leave(object sender, EventArgs e)
        {
            if (cmbUpdate.Text == string.Empty || cmbUpdate.Text == "")
            {
                cmbUpdate.Text = "Seleccione producto a actualizar";
            }
        }


        private void cmbEliminar_Leave(object sender, EventArgs e)
        {
            if (cmbEliminar.Text == string.Empty || cmbEliminar.Text == "")
            {
                cmbEliminar.Text = "Seleccione producto a eliminar";
            }
        }

        private void cmbUpdate_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbUpdate.Text != "Seleccione producto a actualizar" && cmbUpdate.Text != "")
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Select Nombre, Precio, IdProducto from dbo.Producto where Nombre = @NombreProducto", conect);
                comando.Parameters.AddWithValue("@NombreProducto", cmbUpdate.Text);

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    txtNombre.Text = lector["Nombre"].ToString();    // llenar campos de datos recopilados luego de seleccionar un ID en comboBox Update
                    txtPrecio.Text = lector["Precio"].ToString();    // llenar campos de datos recopilados luego de seleccionar un ID en comboBox Update
                    txtID_EliminarOActualizar.Text = lector["IdProducto"].ToString();  // llenar el textbox que recibe el ID tanto para eliminar como para actualizar, en este caso actualizar
                }

                gboxInformacionProducto.Text = "Informacion recopilada a actualizar";   // al recuperar la informacion cambiamos el titulo del groupBox


                lector.Close();
                conect.Close();
            }
        }



        private void cmbEliminar_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbEliminar.Text != "Seleccione producto a eliminar" && cmbEliminar.Text != "")
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Select Nombre, Precio, IdProducto from dbo.Producto where Nombre = @NombreProducto", conect);
                comando.Parameters.AddWithValue("@NombreProducto", cmbEliminar.Text);

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    txtNombre.Text = lector["Nombre"].ToString();         // llenar campos de datos recopilados en comboBox eliminar
                    txtPrecio.Text = lector["Precio"].ToString();         // llenar campos de datos recopilados en comboBox eliminar
                    txtID_EliminarOActualizar.Text = lector["IdProducto"].ToString(); // llenar el textbox que recibe el ID tanto para eliminar como para actualizar, en este caso eliminar
                }

                gboxInformacionProducto.Text = "Informacion recopilada a eliminar";

                lector.Close();
                conect.Close();

            }
        }

        private void cmbUpdate_Click(object sender, EventArgs e)
        {
            if (cmbEliminar.Text != "Seleccione producto a eliminar")
                limpiarTodo.limpiar(this);
        }

        private void cmbEliminar_Click(object sender, EventArgs e)
        {
            if (cmbUpdate.Text != "Seleccione producto a actualizar")
                limpiarTodo.limpiar(this);
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtPrecio.Text == "")
            {
                MessageBox.Show("IMPOSIBLE AGREGAR PRODUCTO CON CAMPOS VACIOS !");
            }


            else
            {
                bool error1 = false;

                try { Convert.ToDecimal(txtPrecio.Text); } catch { error1 = true; MessageBox.Show("SOLO SE PERMITEN VALORES NUMERICOS EN EL CAMPO PRECIO"); txtPrecio.Text = ""; }

                if (error1 == false)
                {
                    if (txtPrecio.Text != "0")
                    {
                        Productos productos = new Productos(conect);

                        productos.NOMBRE = txtNombre.Text;
                        productos.PRECIO = Convert.ToDecimal(txtPrecio.Text);

                        productos.Agregar();

                        productos.Peticion(dgvListaProductos, "Select * from dbo.Producto");

                        limpiarTodo.limpiar(this);
                        productos.LlenarCombo(cmbUpdate, "Select Nombre from dbo.Producto");
                        productos.LlenarCombo(cmbEliminar, "Select Nombre from dbo.Producto");
                    }

                    else
                    {
                        MessageBox.Show("IMPOSIBLE INSERTAR UN PRODUCTO CON EL PRECIO DE 0");
                    }

                }
            }
        }



        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cmbUpdate.Text == "Seleccione producto a actualizar" || cmbUpdate.SelectedIndex == -1)
            {
                MessageBox.Show("IMPOSIBLE ACTUALIZAR SIN HABER SELECCIONADO EL NOMBRE DEL PRODUCTO");
            }

            else if (txtNombre.Text == string.Empty || txtPrecio.Text == string.Empty)
            {
                MessageBox.Show("IMPOSIBLE ACTUALIZAR PRODUCTO CON CAMPOS VACIOS");     
            }


            else
            {
                bool error1 = false;

                try { Convert.ToInt32(txtPrecio.Text); } catch { error1 = true; MessageBox.Show("SOLO SE PERMITEN VALORES NUMERICOS EN EL CAMPO PRECIO"); }


                if (error1 == false)
                {

                    if (txtPrecio.Text != "0")
                    {
                      
                       Productos update = new Productos(conect);
                       update.NOMBRE = txtNombre.Text;
                        update.PRECIO = Convert.ToDecimal(txtPrecio.Text);

                       update.Actualizar(Convert.ToInt32(txtID_EliminarOActualizar.Text));  // actualizar

                        update.Peticion(dgvListaProductos, "Select * from dbo.Producto");
                        limpiarTodo.limpiar(this);

                        update.LlenarCombo(cmbUpdate, "Select Nombre from dbo.Producto");
                        update.LlenarCombo(cmbEliminar, "Select Nombre from dbo.Producto");

                    }

                    else
                    {
                        MessageBox.Show("IMPOSIBLE INSERTAR UN PRODUCTO CON EL PRECIO DE 0");
                    }

                }
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbEliminar.Text == "Seleccione producto a eliminar" || cmbEliminar.Text == "" || cmbEliminar.Items.ToString() == "")
            {
                MessageBox.Show("IMPOSIBLE ELIMINAR SIN HABER SELECCIONADO EL NOMBRE DEL PRODUCTO");
            }

            else
            {
                DialogResult r = MessageBox.Show("Si elimina el producto " + "[ " + cmbEliminar.Text + " ]" + " se borrará todo lo concerniente \r\n\t\t ¿ Seguro que desea eliminarlo ?", "¿ Seguro ?", MessageBoxButtons.YesNo);

                if (r == DialogResult.No)
                {
                    MessageBox.Show("PROCESO CANCELADO !");

                    limpiarTodo.limpiar(this);      // limpiar form

                    gboxInformacionProducto.Text = "Informacion Del Producto";
                }

                else
                {
                    Productos eliminar = new Productos(conect);
                    eliminar.Eliminar(Convert.ToInt32(txtID_EliminarOActualizar.Text));  // eliminar

                    eliminar.Peticion(dgvListaProductos, "Select * from dbo.Producto");

                    limpiarTodo.limpiar(this);

                    eliminar.LlenarCombo(cmbUpdate, "Select Nombre from dbo.Producto");
                    eliminar.LlenarCombo(cmbEliminar, "Select Nombre from dbo.Producto");

                }

            }

        }


        private void cbmBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmBusqueda.SelectedIndex == 0)
            {
                txtBuscarNombre.Visible = false;
            }

            else if (cbmBusqueda.SelectedIndex == 1)
            {
                txtBuscarNombre.Visible = true;
            }
        }


        private void cbmBusqueda_Leave(object sender, EventArgs e)
        {
            if (cbmBusqueda.Text == string.Empty)
            {
                cbmBusqueda.Text = "Filtro de busqueda";
            }
        }





        private void txtBuscarNombre_Leave(object sender, EventArgs e)
        {
            txtBuscarNombre.Text = "Escriba el nombre del producto";
            txtBuscarNombre.Visible = false;
            txtBuscarNombre.ForeColor = Color.Gray;

            cbmBusqueda.Text = "Filtro de busqueda";

        }

        private void txtBuscarNombre_Enter(object sender, EventArgs e)
        {
            if(txtBuscarNombre.Text == "Escriba el nombre del producto")
            {
                txtBuscarNombre.Text = "";
                txtBuscarNombre.ForeColor = Color.Black;
            }
        }

        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            bool esNumerico = true;

            try { Convert.ToInt32(txtBuscarNombre.Text); MessageBox.Show("NO SE PERMITEN VALORES NUMERICOS EN LA BUSQUEDA"); txtBuscarNombre.Text = ""; } catch { esNumerico = false; }

            if (txtBuscarNombre.Text != "Escriba el nombre del producto" && esNumerico == false)
            {
                Productos buscarNombre = new Productos(conect);
                buscarNombre.Peticion(dgvListaProductos, $"Select * from dbo.Producto where Nombre like '%{txtBuscarNombre.Text}%'");
            }

            else if (txtBuscarNombre.Text == string.Empty)
            {
                Proveedores buscarTodo = new Proveedores(conect);
                buscarTodo.Peticion(dgvListaProductos, "Select * from dbo.Proveedor");
            }
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form1 volver = new Form1();
            this.Hide();
            volver.ShowDialog();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarTodo.limpiar(this);

            Productos show = new Productos(conect);
            show.Peticion(dgvListaProductos, "Select * from dbo.Producto");

            gboxInformacionProducto.Text = "Informacion Del Producto";
        }

        public void alternarColorFilas(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }


        // DESACTIVAR ESCRITURA EN COMBOBOX


        private void cbmBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbEliminar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

    }
}
