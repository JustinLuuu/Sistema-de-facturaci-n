using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Proyecto_final___Sistema_de_facturacion
{
    class Proveedores : Gestiones, iPeticiones
    {
        SqlConnection conect;

        public Proveedores(SqlConnection conect)
        {
            this.conect = conect;
        }

        private string cedula;
        private string nombre;
        private string telefono;
        private string email;


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

      
        public override void Agregar()
        {
            try
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Insert into dbo.Proveedor values (@Cedula, @Nombre, @Telefono, @Email)", conect);
                comando.Parameters.AddWithValue("@Cedula", CEDULA.ToUpper());
                comando.Parameters.AddWithValue("@Nombre", NOMBRE.ToUpper());
                comando.Parameters.AddWithValue("@Telefono", TELEFONO.ToUpper());
                comando.Parameters.AddWithValue("@Email", EMAIL.ToUpper());

                comando.ExecuteNonQuery();

                conect.Close();

                MessageBox.Show("PROVEEDOR AGREGADO DE FORMA EXITOSA !");

            }
            catch
            {
                conect.Close();
                MessageBox.Show("YA EXISTE UN PROVEEDOR CON ESE NUMERO DE CEDULA !");
            }
        }

        public override void Actualizar(int ID)
        {
            try
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Update Proveedor set Nombre = @Nombre, Cedula = @Cedula, Telefono = @Telefono, Email = @Email where IdProveedor = @ID", conect);
                comando.Parameters.AddWithValue("@ID", ID);
                comando.Parameters.AddWithValue("@Nombre", NOMBRE.ToUpper());
                comando.Parameters.AddWithValue("@Cedula", CEDULA.ToUpper());
                comando.Parameters.AddWithValue("@Telefono", TELEFONO);
                comando.Parameters.AddWithValue("@Email", EMAIL.ToUpper());

                comando.ExecuteNonQuery();

                MessageBox.Show("PROVEEDOR ACTUALIZADO DE FORMA EXITOSA ! ");

                conect.Close();

            }
            catch
            {
                conect.Close();
                MessageBox.Show("YA EXISTE UN PROVEEDOR CON ESE NUMERO DE CEDULA");
            }

        }

        public override void Eliminar(int ID)
        {
            try
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Delete from dbo.Proveedor where IdProveedor = @ID", conect);
                comando.Parameters.AddWithValue("@ID", ID);

                comando.ExecuteNonQuery();

                MessageBox.Show("PROVEEDOR ELIMINADO DE FORMA EXITOSA ! ");

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

            combo.Items.Clear();
            combo.Items.Add("");

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
