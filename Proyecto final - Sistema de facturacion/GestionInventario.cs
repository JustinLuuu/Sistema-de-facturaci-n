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
    public partial class GestionInventario : Form
    {
        SqlConnection conect;

        public GestionInventario(SqlConnection conect)
        {
            InitializeComponent();
            this.conect = conect;
        }

        private void GestionInventario_Load(object sender, EventArgs e)
        {
            InventarioEntradas loadForm = new InventarioEntradas(conect);
            loadForm.Peticion(dgvInventario, "Select * from dbo.Inventario");  // LLENAR GRIDVIEW INVENTARIO
            agregarColumnaNombre(dgvInventario);  // AGREGAR UNA COLUMNA AL DATAGRIDVIEW PARA QUE MUESTRE LOS NOMBRES DE CADA ID DE PRODUCTO


            loadForm.Peticion(dgvEntradas, "Select * from Entradas order by IdProducto desc");    // LLENAR GRID VIEW ENTRADAS

            dgvEntradas.Columns[1].HeaderCell.Value = "Producto";   // cambiar nombres de campo
            dgvEntradas.Columns[2].HeaderCell.Value = "Cantidad ingresada"; // cambiar nombres de campo
            dgvEntradas.Columns[4].HeaderCell.Value = "Fecha Ingreso"; // cambiar nombres de campo

            agregarColumnaNombre(dgvEntradas);

            loadForm.LlenarCombo(cmbProducto, "Select IdProducto from dbo.Producto");  // llenar comboBox de productos
            loadForm.LlenarCombo(cmbProveedor, "Select Nombre from dbo.Proveedor");  // llenar comboBox de proveedor
            loadForm.LlenarCombo(cmbEliminar, "Select Producto.Nombre as ProductoNombre from Inventario inner join Producto on Inventario.IdProducto = Producto.IdProducto");  // llenar comboBox de eliminado pasandole una consulta de tipo join

            alternarColorFilasInventario(dgvInventario);
            alternarColorFilasEntradas(dgvEntradas);
            
        }



        private void cmbProducto_Leave(object sender, EventArgs e)
        {
            if (cmbProducto.Text == string.Empty || cmbProducto.Text == "")
            {  
                cmbProducto.Text = "Elija ID de producto";
            }
        }


        private void cmbProveedor_Leave(object sender, EventArgs e)
        {
            if (cmbProveedor.Text == string.Empty || cmbProveedor.Text == "")
            {
                cmbProveedor.Text = "Elija ID de proveedor";
            }
        }

        private void cmbProducto_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbProducto.Text != "Elija producto a ingresar" && cmbProducto.Text != "" && cmbProducto.Text != string.Empty)
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Select IdProducto from dbo.Producto where Nombre = @Nombre", conect);
                comando.Parameters.AddWithValue("@Nombre", cmbProducto.Text);

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    txtIdProductos.Text = lector["IdProducto"].ToString();               // llenar campos de datos recopilados luego de seleccionar un ID en comboBox Update
                }

                lector.Close();
                conect.Close();
            }
        }


        private void cmbProveedor_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbProveedor.Text != "Elija proveedor de producto" && cmbProveedor.Text != "" && cmbProveedor.Text != string.Empty)
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Select IdProveedor from dbo.Proveedor where Nombre = @Nombre", conect);
                comando.Parameters.AddWithValue("@Nombre", cmbProveedor.Text);

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    txtIdProveedor.Text = lector["IdProveedor"].ToString();                 // llenar campos de datos recopilados luego de seleccionar un ID en comboBox Update
                }

                lector.Close();
                conect.Close();
            }
        }



        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cmbProducto.Text == "Elija ID de producto" || cmbProveedor.Text == "Elija ID de proveedor" || txtCantidadProducto.Text == "" || txtCantidadProducto.Text == string.Empty)
            {
                MessageBox.Show("IMPOSIBLE AGREGAR PRODUCTO A INVENTARIO CON CAMPOS VACIOS !");
            }


            else
            {
                bool error1 = false;

                try { Convert.ToDecimal(txtCantidadProducto.Text); } catch { error1 = true; MessageBox.Show("SOLO SE PERMITEN VALORES NUMERICOS EN EL CAMPO CANTIDAD"); txtCantidadProducto.Text = ""; }

                if (error1 == false)
                {
                    if (txtCantidadProducto.Text != "0")
                    {
                        InventarioEntradas productos = new InventarioEntradas(conect);

                        productos.IDPRODUCTO = Convert.ToInt32(txtIdProductos.Text);
                        productos.PRODUCTONOMBRE = cmbProducto.Text;
                        productos.PROVEEDORID = Convert.ToInt32(txtIdProveedor.Text);
                        productos.CANTIDADPRODUCTO = Convert.ToInt32(txtCantidadProducto.Text);

                        productos.AgregarProducto(); // agregar producto

                        dgvInventario.Columns.Remove("Producto");  // borrar columna producto


                        productos.Peticion(dgvInventario, "Select * from dbo.Inventario");
                        agregarColumnaNombre(dgvInventario);

                        dgvEntradas.Columns.Remove("Proveedor");

                        productos.Peticion(dgvEntradas, "Select * from dbo.Entradas order by IdProducto desc ");
                        agregarColumnaNombre(dgvEntradas);

                        productos.LlenarCombo(cmbProducto, "Select IdProducto from dbo.Producto");
                        productos.LlenarCombo(cmbEliminar, "Select Producto.Nombre as ProductoNombre from Inventario inner join Producto on Inventario.IdProducto = Producto.IdProducto");
                        limpiarTodo.limpiar(this);
                    }

                    else
                    {
                        MessageBox.Show("IMPOSIBLE   COLOCAR 0 EN LA CANTIDAD A INSERTAR");
                    }

                }
            }
        }


        private void agregarColumnaNombre(DataGridView tablaLogica)   // PARA HACER VISIBLE LOS NOMBRES PERTENECIENTES A CADA ID DE PRODUCTO PARA EL USUARIO JEJE
        {
            SqlCommand comando;
            SqlDataReader lector;

            DataGridViewColumn columnaCreada = new DataGridViewColumn();  // CREAR OBJETO DE COLUMNA PARA AGREGARLO AL DATAGRIDVIEW
            columnaCreada.DataPropertyName = "Micolumna";   // AGREGARLE UN NOMBRE POR ETICA

            conect.Open();

            if (tablaLogica.Name == "dgvInventario")
            {
                columnaCreada.Name = "Producto";  // AGREGARLE EL TITULO CON EL CUAL SE MOSTRARA EN EL DATAGRIDVIEW
                columnaCreada.CellTemplate = new DataGridViewTextBoxCell();   // DEFINIR COLUMNA FORMATO DE TEXTO
                tablaLogica.Columns.Insert(1, columnaCreada);   // INSERTAR LA COLUMNA YA CREADA EN UNA POSICION EN ESPECIFICO, las posiciones de columnas se cuentan empezando del cero


                List<int> IdProducto = new List<int>(); // LISTA PARA RETENER LOS ID'S DEL INVENTARIO
                 comando = new SqlCommand("Select IdProducto from dbo.Inventario", conect); // QUERY PARA OBTENER IDS DE INVENTARIO
                 lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    IdProducto.Add((int)lector["IdProducto"]);  // LLENAR LISTA DE LOS ID'S QUE VA LEYENDO EL DATAREADER DEL QUERY 
                }

                lector.Close(); // CERRAR LECTOR

                if (IdProducto.Count != 0) // EN CASO DE QUE LISTA TENGA DATOS ENTRARA POR AQUI, DE LO CONTRARIO NO Y NO HARA NADA
                {
                    int acum = 0; // ACUMULADOR
                    foreach (int id in IdProducto)
                    {
                        string nombreProducto;
                        comando = new SqlCommand("Select Producto.Nombre from Inventario inner join Producto" +
                       $" on Inventario.IdProducto = Producto.IdProducto where Producto.IdProducto = {id}", conect);
                        nombreProducto = Convert.ToString(comando.ExecuteScalar());  // obtener nombre del producto
                        tablaLogica.Rows[acum].Cells["Producto"].Value = nombreProducto;  // agregar valores en la columna PRODUCTO iterando sus filas a la vez con el acumulador (ACUM)
                        acum++;
                    }
                }
            }


            else
            {
                columnaCreada.Name = "Proveedor";  // AGREGARLE EL TITULO CON EL CUAL SE MOSTRARA EN EL DATAGRIDVIEW
                columnaCreada.CellTemplate = new DataGridViewTextBoxCell();   // DEFINIR COLUMNA FORMATO DE TEXTO
                dgvEntradas.Columns.Remove("IdProveedor"); // eliminar columna en especifica por medio del nombre en el DATAGRIDVIEW
                tablaLogica.Columns.Insert(3, columnaCreada);   // INSERTAR LA COLUMNA YA CREADA EN UNA POSICION EN ESPECIFICO


                List<int> IdProveedor = new List<int>(); // LISTA PARA RETENER LOS ID'S DEL INVENTARIO
                 comando = new SqlCommand("Select * from dbo.Entradas order by IdProducto desc", conect); // QUERY PARA OBTENER IDS DE INVENTARIO
                 lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    IdProveedor.Add((int)lector["IdProveedor"]);  // LLENAR LISTA DE LOS ID'S QUE VA LEYENDO EL DATAREADER DEL QUERY
                }

                lector.Close(); // CERRAR LECTOR

                if (IdProveedor.Count != 0) // EN CASO DE QUE LISTA TENGA DATOS ENTRARA POR AQUI, DE LO CONTRARIO NO Y NO HARA NADA
                {
                    int acum = 0; // ACUMULADOR
                    foreach (int id in IdProveedor)
                    {
                        try
                        {
                            string nombreProveedor;
                            comando = new SqlCommand($"Select Nombre from Proveedor where IdProveedor = {id}", conect);
                            nombreProveedor = Convert.ToString(comando.ExecuteScalar());  // obtener nombre del producto
                            tablaLogica.Rows[acum].Cells["Proveedor"].Value = nombreProveedor;  // agregar valores en la columna PROVEEDOR iterando sus celdas a la vez con el acumulador (ACUM)
                            acum++;

                        }catch(Exception ll)
                        {
                            MessageBox.Show(ll.Message);
                        }

                    }
                }

            }

            conect.Close();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if( cmbEliminar.Text == "Seleccione Item a eliminar" || cmbEliminar.Text == "" || cmbEliminar.Text == string.Empty)
            {
                MessageBox.Show("IMPOSIBLE ELIMINAR ITEM DEL INVENTARIO SIN HABER SELECCIONADO NINGUNO");
            }

            else
            {
               
                conect.Open();
                 
                SqlCommand comando = new SqlCommand("Delete from dbo.Inventario where IdProducto = ( Select IdProducto from dbo.Producto where Nombre = @NombreProducto)", conect);  // ELIMINAR PRODUCTO DE INVENTARIO POR MEDIO DE UN SUBQUERY
                comando.Parameters.AddWithValue("@NombreProducto", cmbEliminar.Text.Trim());
                comando.ExecuteNonQuery();
               
                conect.Close();
               
                MessageBox.Show($"PRODUCTO [ {cmbEliminar.Text} ] ELIMINADO CON EXITO DEL INVENTARIO ");

                InventarioEntradas loadForm = new InventarioEntradas(conect);
                loadForm.Peticion(dgvInventario, "Select * from dbo.Inventario");  // LLENAR GRIDVIEW INVENTARIO
                dgvInventario.Columns.Remove("Producto");
                agregarColumnaNombre(dgvInventario);  // AGREGAR UNA COLUMNA AL DATAGRIDVIEW PARA QUE MUESTRE LOS NOMBRES DE CADA ID DE PRODUCTO


                loadForm.Peticion(dgvEntradas, "Select * from dbo.Entradas order by IdProducto desc");    // LLENAR GRID VIEW ENTRADAS
                dgvEntradas.Columns[1].HeaderCell.Value = "Producto";   // cambiar nombres de campo
                dgvEntradas.Columns[4].HeaderCell.Value = "Fecha Ingreso"; // cambiar nombres de campo
                  
                dgvEntradas.Columns.Remove("Proveedor"); 
                agregarColumnaNombre(dgvEntradas);
                dgvEntradas.Columns[0].HeaderCell.Value = "IdProducto";

                loadForm.LlenarCombo(cmbProducto, "Select IdProducto from dbo.Producto");  // llenar comboBox de productos
                loadForm.LlenarCombo(cmbProveedor, "Select Nombre from dbo.Proveedor");  // llenar comboBox de proveedor
                loadForm.LlenarCombo(cmbEliminar, "Select Producto.Nombre as ProductoNombre from Inventario inner join Producto on Inventario.IdProducto = Producto.IdProducto");  // llenar comboBox de eliminado pasandole una consulta de tipo join



                alternarColorFilasInventario(dgvInventario);
                alternarColorFilasEntradas(dgvEntradas);
                limpiarTodo.limpiar(this);
            }
        }



        private void cmbEliminar_Leave(object sender, EventArgs e)
        {
            if (cmbEliminar.Text == "" || cmbEliminar.Text == string.Empty)
            {
                limpiarTodo.limpiar(this);
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
        }

        public void alternarColorFilasInventario(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.LightGreen;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        public void alternarColorFilasEntradas(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.LightPink;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }



        // INHABILITAR ESCRITURA EN COMBOBOX

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtNombreProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtIdProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtIdProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvEntradas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

    }
}
