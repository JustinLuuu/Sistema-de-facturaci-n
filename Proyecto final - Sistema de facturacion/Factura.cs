using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final___Sistema_de_facturacion
{
    class Factura : Gestiones, iPeticiones
    {
        SqlConnection conect;

        public Factura(SqlConnection conect)
        {
            this.conect = conect;
        }

        private const int itbis = 18; // variable constante
        private int idCliente;
        private int idProducto;
        private decimal precio;
        private int idProveedor;
        private decimal cantidad;
        private int descuento;
        private decimal total;

        public int IDCLIENTE
        {
            set => idCliente = value;
            get => idCliente;
        }

        public int IDPRODUCTO
        {
            set => idProducto = value;
            get => idProducto;
        }

        public decimal PRECIO
        {
            set => precio = value;
            get => precio;
        }

        public int IDPROVEEDOR
        {
            set => idProveedor = value;
            get => idProveedor;
        }

        public decimal CANTIDAD
        {
            set => cantidad = value;
            get => cantidad;
        }

        public int DESCUENTO
        {
            set => descuento = value;
            get => descuento;
        }

        public decimal TOTAL
        {
            set => total = value;
            get => total;
        }


        public override void Agregar()   //  UTIL
        {
            try
            {
                conect.Open();

                SqlCommand comando = new SqlCommand("Insert into Facturacion values ( GetDate() ,@IdCliente, @IdProducto, @IdProveedor, @CantidadProducto, @PrecioProducto, @Descuento, @Itbis, @Total)", conect);

                comando.Parameters.AddWithValue("@IdCliente", IDCLIENTE);
                comando.Parameters.AddWithValue("@IdProducto", IDPRODUCTO);
                comando.Parameters.AddWithValue("@IdProveedor", IDPROVEEDOR);
                comando.Parameters.AddWithValue("@CantidadProducto", CANTIDAD);
                comando.Parameters.AddWithValue("@PrecioProducto", PRECIO);
                comando.Parameters.AddWithValue("@Descuento", DESCUENTO);
                comando.Parameters.AddWithValue("@Itbis", itbis);
                comando.Parameters.AddWithValue("@Total", TOTAL);

                comando.ExecuteNonQuery();  // guardar en la tabla facturacion

                MessageBox.Show("FACTURA AGREGADA LISTA PARA IMPRIMIR");

                conect.Close();
            }
            catch (Exception err)
            {
                conect.Close();
                MessageBox.Show(err.Message);
            }
        }


        public override void Eliminar(int ID)   // NO UTIL
        {
        }


        public void Peticion(DataGridView pantallita, string query)  // UTIL
        {
            conect.Open();
            SqlCommand comando = new SqlCommand(query, conect);
            SqlDataAdapter adp = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adp.Fill(tabla);
            pantallita.DataSource = tabla;
            conect.Close();
        }


        public void LlenarCombo(ComboBox combo, string query)  // UTIL
        {
            conect.Open();

            combo.Items.Clear();  // BORRAR ITEMS DEL COMBO ANTES QUE TODO
            combo.Items.Add(""); // AGREGAR ESPACIO EN BLANCO TAMBIEN XD

            string campoTabla;

            string[] campo = query.Split(' ');
            campoTabla = campo[1];

            SqlCommand comando = new SqlCommand(query, conect);
            SqlDataReader lector = comando.ExecuteReader();


            if (campoTabla == "IdCliente")
            {                             
                 while (lector.Read())
                 {
                     combo.Items.Add("ID [ " + lector["IdCliente"].ToString() + " ]  " + lector["Nombre"].ToString());
                 }
                
            }

            else
            {
                while (lector.Read())
                {
                    combo.Items.Add(lector["Nombre"].ToString());   // exclusivamente para el comboBox de los Productos
                }
            }

            lector.Close();
            conect.Close();
        }


        public override void Actualizar(int ID)   // NO UTIL
        { }
    }
}