using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final___Sistema_de_facturacion
{
    class Productos : Gestiones, iPeticiones
    {
        SqlConnection conect;

        public Productos(SqlConnection conect)
        {
            this.conect = conect;
        }

        public Productos()
        {

        }

        private string nombre;
        private decimal precio;


        public string NOMBRE
        {
           set => nombre = value;
           get => nombre;
        }

       public decimal PRECIO
       {
          set => precio = value;
          get => precio;
       }



        public override void Agregar()
        {
            try
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Insert into dbo.Producto values (@Nombre, @Precio)", conect);
                comando.Parameters.AddWithValue("@Nombre", NOMBRE.ToUpper());
                comando.Parameters.AddWithValue("@Precio", PRECIO);
           
                comando.ExecuteNonQuery();

                conect.Close();

                MessageBox.Show("PRODUCTO AGREGADO DE FORMA EXITOSA !");

            }
            catch
            {
                conect.Close();
                MessageBox.Show("YA EXISTE UN PRODUCTO CON ESE NOMBRE ASIGNADO !");
            }
        }

        public override void Actualizar(int ID)
        {
            try
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Update Producto set Nombre = @Nombre, Precio = @Precio where IdProducto = @ID", conect);
                comando.Parameters.AddWithValue("@ID", ID);
                comando.Parameters.AddWithValue("@Nombre", NOMBRE.ToUpper());
                comando.Parameters.AddWithValue("@Precio", PRECIO);
             

                comando.ExecuteNonQuery();

                MessageBox.Show("PRODUCTO ACTUALIZADO DE FORMA EXITOSA ! ");

                conect.Close();

            }
            catch
            {
                conect.Close();
                MessageBox.Show("YA EXISTE UN PRODUCTO CON ESE NOMBRE ASIGNADO !");
            }

        }

        public override void Eliminar(int ID)
        {
            try
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Delete from dbo.Producto where IdProducto = @ID", conect);
                comando.Parameters.AddWithValue("@ID", ID);

                comando.ExecuteNonQuery();

                MessageBox.Show("PRODUCTO ELIMINADO DE FORMA EXITOSA ! ");

                conect.Close();

            }
            catch (Exception e)
            {
                conect.Close();
                MessageBox.Show(e.Message);
            }
        }


        public void Peticion(DataGridView pantallita, string query)    // peticion de busqueda               
        {
            SqlCommand comando = new SqlCommand(query, conect);
            SqlDataAdapter adp = new SqlDataAdapter(comando);

            DataTable tabla = new DataTable();
            adp.Fill(tabla);

            pantallita.DataSource = tabla;
        }


        public void LlenarCombo(ComboBox combo, string query)  // para llenar comboBox que cruce a este metodo
        {
            conect.Open();

            combo.Items.Clear();  // BORRAR ITEMS DEL COMBO ANTES QUE TODO
            combo.Items.Add(""); // AGREGAR ESPACIO EN BLANCO TAMBIEN XD

            string campoTabla;

            string[] campo = query.Split(' ');
            campoTabla = campo[1];

            SqlCommand comando = new SqlCommand(query, conect);
            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                combo.Items.Add(lector[campoTabla].ToString());    // se llena el comboBox
            }

            conect.Close();

        }

    }
}
