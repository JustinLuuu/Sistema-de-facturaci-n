using Microsoft.Reporting.WinForms;
using Microsoft.Reporting.WinForms.Internal.Soap.ReportingServices2005.Execution;
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
    public partial class mostrarInforme : Form
    {
        private List<ReporteDatos> lista = new List<ReporteDatos>(); 

        public mostrarInforme(int idfactura, int idcliente, string nombre, string telefono, string email, string cedula, string descripcionproducto, decimal precio, int cantidad, int descuento, int impuesto, decimal total, string fecha, int idproducto)
        {
            InitializeComponent();

            ReporteDatos informe = new ReporteDatos();
            informe.IDFACTURA = idfactura;
            informe.IDCLIENTE = idcliente;
            informe.NOMBRE = nombre;
            informe.TELEFONO = telefono;
            informe.EMAIL = email;
            informe.CEDULA = cedula;
            informe.DESCRIPCIONPRODUCTO = descripcionproducto;
            informe.PRECIO = precio;
            informe.CANTIDAD = cantidad;
            informe.DESCUENTO = descuento;
            informe.IMPUESTO = impuesto;
            informe.TOTAL = total;
            informe.FECHA = fecha;
            informe.IDPRODUCTO = idproducto;

            lista.Add(informe);
        }
       
        private void mostrarInforme_Load(object sender, EventArgs e)
        {
           reportViewer1.LocalReport.DataSources.Clear();  // hacer reportes locales, o sea, sin un DATASET que establezca los datos de una base de datos, sino por medio de otra fuente que son las propiedades de un objeto
           reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("CamposFactura", lista));  // el primer argumento hace alusion al nombre de la fuente de objetos, y el segundo parametro hace alusion a la lista que es donde guardamos el objeto con la informacion
           this.reportViewer1.RefreshReport();              
        } 
     
     
    }
}
