using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final___Sistema_de_facturacion
{
    class Clientes : Gestiones, iPeticiones
    {
        SqlConnection conect;

        public Clientes(SqlConnection conect)
        {
            this.conect = conect;
        }

        
        private string cedula;
        private string nombre;
        private string telefono;
        private string email;
        private string categoria;

       
        public string CEDULA
        {
            set => cedula = value;
            get => cedula;
        }

        public string NOMBRE
        {
            set => nombre = value;
            get => nombre;
        }

        public string TELEFONO
        {
            set => telefono = value;
            get => telefono;
        }

        public string EMAIL
        {
            set => email = value;
            get => email;
        }

        public string CATEGORIA
        {
            set => categoria = value;
            get => categoria;
        }

        public override void Agregar()
        {
            try
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Insert into dbo.Cliente values (@Cedula, @Nombre, @Telefono, @Email, @Categoria )", conect);
                comando.Parameters.AddWithValue("@Cedula", CEDULA.ToUpper());
                comando.Parameters.AddWithValue("@Nombre", NOMBRE.ToUpper());
                comando.Parameters.AddWithValue("@Telefono", TELEFONO.ToUpper());
                comando.Parameters.AddWithValue("@Email", EMAIL.ToUpper());
                comando.Parameters.AddWithValue("@Categoria", CATEGORIA.ToUpper());

                comando.ExecuteNonQuery();

                conect.Close();

                MessageBox.Show("CLIENTE AGREGADO DE FORMA EXITOSA !");
              
            }
            catch
            {
                conect.Close();
                MessageBox.Show("YA EXISTE UN USUARIO CON ESE NUMERO DE CEDULA !");
            }
            
        }


        public override void Actualizar(int ID)
        {
            try
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Update Cliente set Nombre = @Nombre, Cedula = @Cedula, Telefono = @Telefono, Email = @Email, Categoria = @Categoria where IdCliente = @ID", conect);
                comando.Parameters.AddWithValue("@ID", ID);
                comando.Parameters.AddWithValue("@Nombre", NOMBRE.ToUpper());
                comando.Parameters.AddWithValue("@Cedula", CEDULA.ToUpper());
                comando.Parameters.AddWithValue("@Telefono", TELEFONO);
                comando.Parameters.AddWithValue("@Email", EMAIL.ToUpper());
                comando.Parameters.AddWithValue("@Categoria", CATEGORIA.ToUpper());

                comando.ExecuteNonQuery();

                MessageBox.Show("CLIENTE ACTUALIZADO DE FORMA EXITOSA ! ");

                conect.Close();

            }
            catch
            {
                conect.Close(); 
                MessageBox.Show("YA EXISTE UN CLIENTE CON ESE NUMERO DE CEDULA");
            }


        }

        public override void Eliminar(int ID)
        {
            try
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Delete from dbo.Cliente where IdCliente = @ID", conect);
                comando.Parameters.AddWithValue("@ID", ID);
            
                comando.ExecuteNonQuery();

                MessageBox.Show("CLIENTE ELIMINADO DE FORMA EXITOSA ! ");

                conect.Close();

            }
            catch(Exception e)
            {
                conect.Close();
                MessageBox.Show(e.Message);
            }
        }


        public void Peticion(DataGridView pantallita, string query)   // implementando interfaz
        {
            SqlCommand comando = new SqlCommand(query, conect);
            SqlDataAdapter adp = new SqlDataAdapter(comando);

            DataTable tabla = new DataTable();
            adp.Fill(tabla);

            pantallita.DataSource = tabla;   // mostrar la pantalla
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
