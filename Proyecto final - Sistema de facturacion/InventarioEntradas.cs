using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;
using System.Drawing.Design;

namespace Proyecto_final___Sistema_de_facturacion
{
    class InventarioEntradas : iPeticiones
    {
        SqlConnection conect;

        public InventarioEntradas(SqlConnection conect)
        {
            this.conect = conect;
        }
       
        private int idProducto;    // INVENTARIO Y ENTRADAS
        private string nombreProducto;  // ENTRADAS
        private int idProveedor; // ENTRADAS
        private int cantidad; // INVENTARIO Y ENTRADAS
        
         
        public int IDPRODUCTO
        {          
            set => idProducto = value;
            get => idProducto;
        }

        public string PRODUCTONOMBRE
        {
            set => nombreProducto = value;
            get => nombreProducto;
        }


        public int PROVEEDORID
        {
            set => idProveedor = value;
            get => idProveedor;
        }

      
        public int CANTIDADPRODUCTO
        {
            set => cantidad = value;
            get => cantidad;
        }


         
        public void AgregarProducto()
        {
            try
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Insert into dbo.Entradas values ( @IdProducto, @NombreProducto, @cantidad, @IdProveedor, GETDATE() )", conect);
                comando.Parameters.AddWithValue("@IdProducto", IDPRODUCTO);
                comando.Parameters.AddWithValue("@NombreProducto", PRODUCTONOMBRE);
                comando.Parameters.AddWithValue("@cantidad", CANTIDADPRODUCTO);
                comando.Parameters.AddWithValue("@IdProveedor", PROVEEDORID);

                comando.ExecuteNonQuery();

                MessageBox.Show("PRODUCTO AÑADIDO EXITOSAMENTE !");
                conect.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                conect.Close();
            }
            
        }

        public void LlenarCombo(ComboBox combo, string query)
        {
            conect.Open();

            SqlCommand comando;
            SqlDataReader lector;

            string[] verificarCampo = query.Split(' ');   // separamos por medio de un array el query para obtener el campo, ya que dice como "SELECT [COLUMNA] "  la columna dada despues del select es con la cual se sabra de que tabla viene y se decidira que hacer con ella
            string campo = verificarCampo[1];   // obtenemos el campo  

            if (campo == "IdProducto")    // CONTROL PARA SABER SI UN PRODUCTO YA ESTA DENTRO DEL INVENTARIO O NO, SI NO ESTA DENTRO LO AGREGA; SI ESTA ADENTRO ENTONCES NO TIENE POR QUÉ AGREGARLO PORQUE YA EXISTE
            {
                int posicion = 0;
                int filasAfectadasExe;
                string productoNombre;

                comando = new SqlCommand($"Select {campo} from dbo.Producto", conect);
                filasAfectadasExe = Convert.ToInt32(comando.ExecuteScalar());
                object[] idsProducto = new object[filasAfectadasExe];
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    idsProducto[posicion] = lector[campo];
                    posicion++;
                }

                lector.Close();
                combo.Items.Clear(); // limpiar comboBox
                combo.Items.Add(""); // agregar espacio en blanco en caso de no elegir ninguna opcion

                for (int i = 0; i < idsProducto.Length; i++)
                {
                    comando = new SqlCommand($"Select Producto.IdProducto from Inventario inner join Producto on Inventario.IdProducto = Producto.IdProducto where Producto.IdProducto = {Convert.ToInt32(idsProducto[i])}", conect);
                    filasAfectadasExe = Convert.ToInt32(comando.ExecuteScalar());

                    if (filasAfectadasExe == 0) // si es igual a 0 es porque no hubo coincidencias 
                    {
                        comando = new SqlCommand($"Select Nombre from Producto where IdProducto = {Convert.ToInt32(idsProducto[i])}", conect);  // Seleccionar el nombre del producto con el ID con el que no hubo coincidencias
                        productoNombre = Convert.ToString(comando.ExecuteScalar());

                        if (productoNombre != "")
                        {
                            combo.Items.Add(productoNombre); // en caso de que las filas sean igual a 0 entonces es porque no hubo coincidencias en el inventario y por eso se agrega el nombre del producto
                        }
                    }

                }

            }


            else if (campo == "Nombre")    // llenar comboBox del campo IdProveedor
            {
                combo.Items.Clear(); // limpiar siemre
                combo.Items.Add("");  // agregar espacio en blanco en caso de no elegir ninguna opcion

                comando = new SqlCommand($"Select {campo} from dbo.Proveedor", conect);
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    combo.Items.Add(lector[campo].ToString());  // llenar comboBox del campo IdProveedor
                }

                lector.Close();
            }

            else
            {
                comando = new SqlCommand(query, conect);
                lector = comando.ExecuteReader();

                combo.Items.Clear(); // limpiar para que no añada productos repetidos o extras
                combo.Items.Add(""); // agregar espacio en blanco antes que todo XD

                while (lector.Read())
                {
                    combo.Items.Add(lector["ProductoNombre"].ToString());  // la columna que lee es una columna que creamos por el alias 'AS' ya que la consulta no lo hace en una tabla en especifica sino mas bien hace una combinacion y por eso creamos un nombre a esa columna incognita que genera
                }
                lector.Close();
            }

            conect.Close(); 
        }


        public void Peticion(DataGridView pantallita, string query)
        {
            SqlCommand comando = new SqlCommand(query, conect);
            SqlDataAdapter adp = new SqlDataAdapter(comando);

            DataTable tabla = new DataTable();
            adp.Fill(tabla);

            pantallita.DataSource = tabla;

        }

    }
}
