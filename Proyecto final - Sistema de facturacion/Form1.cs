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
    public partial class Form1 : Form
    {

        SqlConnection conect = new SqlConnection("server=localhost\\SQLEXPRESS; database=proyecto_SistemaFacturacion; integrated security=true");  // conexion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            picClientes.Visible = false;
            picProductos.Visible = false;
            picProveedores.Visible = false;
            picInventario.Visible = false;
            picVentas.Visible = false;
        }


        private void GestionClientes_Click(object sender, EventArgs e)      // CRUD DE CLIENTES
        {
            GestionClientes gestionClientes = new GestionClientes(conect);
            this.Hide();
            gestionClientes.ShowDialog();
        }

     
        private void GestionProveedores_Click(object sender, EventArgs e)   // CRUD DE PROVEEDORES
        {
            GestionProveedor gestionProveedor = new GestionProveedor(conect);
            this.Hide();
            gestionProveedor.ShowDialog();
        }


        private void GestionProductos_Click(object sender, EventArgs e)  // CRUD DE PRODUCTOS
        {
            GestionProductos gestionProductos = new GestionProductos(conect);
            this.Hide();
            gestionProductos.ShowDialog();
        }

     
        private void gestionInventario_Click(object sender, EventArgs e)   // GESTION DE INVENTARIO  Y ENTRADA DE PRODUCTOS
        {
            GestionInventario gestionInventario = new GestionInventario(conect);
            this.Hide();
            gestionInventario.ShowDialog();
        }

   


        private void GestionVentas_Click(object sender, EventArgs e)   // GESTION DE VENTAS Y FACTUACION
        {
            GestionVentas gestionVentas = new GestionVentas(conect);
            this.Hide();
            gestionVentas.ShowDialog();
        }



        private void pictureBox19_MouseHover(object sender, EventArgs e)
        {
            picProductos.Visible = true;
        }

        private void pictureBox19_MouseLeave(object sender, EventArgs e)
        {
            picProductos.Visible = false;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            picProveedores.Visible = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            picProveedores.Visible = false;
        }

        private void pictureBox20_MouseHover(object sender, EventArgs e)
        {
            picClientes.Visible = true;
        }

        private void pictureBox20_MouseLeave(object sender, EventArgs e)
        {
            picClientes.Visible = false; 
        }

        private void gestionInventario_MouseHover(object sender, EventArgs e)
        {
            picInventario.Visible = true;
        }

        private void gestionInventario_MouseLeave(object sender, EventArgs e)
        {
            picInventario.Visible = false;
        }

        private void GestionVentas_MouseHover(object sender, EventArgs e)
        {
            picVentas.Visible = true;
        }

        private void GestionVentas_MouseLeave(object sender, EventArgs e)
        {
            picVentas.Visible = false;
        }

      
    }
}
