using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Proyecto_final___Sistema_de_facturacion
{
    class ReporteDatos 
    {
      
        private int idFactura;
        private int idCliente;
        private string nombre;
        private string telefono;
        private string email;
        private string cedula;
        private string descripcionProducto;
        private decimal precio;
        private int cantidad;
        private string fecha;
        private int descuento;
        private int idProducto;

        private int impuesto;


        private decimal total;

        public int IDFACTURA { get => idFactura; set => idFactura = value; }
        public int IDCLIENTE { get => idCliente; set => idCliente = value; }
        public string NOMBRE { get => nombre; set => nombre = value; }
        public string TELEFONO { get => telefono; set => telefono = value; }
        public string EMAIL { get => email; set => email = value; }
        public string CEDULA { get => cedula; set => cedula = value; }
        public  string DESCRIPCIONPRODUCTO { get => descripcionProducto; set => descripcionProducto = value; }
        public decimal PRECIO { get =>precio; set => precio = value; }
        public int CANTIDAD { get => cantidad; set => cantidad = value; }
        public int DESCUENTO { get => descuento; set => descuento = value; }
        public int IMPUESTO { get => impuesto; set => impuesto = value; }
        public decimal TOTAL { get => total; set => total = value; }
        public string FECHA { get => fecha; set => fecha = value; }
        public int IDPRODUCTO { get => idProducto; set => idProducto = value; }



    }
}
