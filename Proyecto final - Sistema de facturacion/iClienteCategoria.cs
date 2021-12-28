using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final___Sistema_de_facturacion
{
    interface iClienteCategoria
    {
        void checkCategoria(CheckBox checkboxPremium, CheckBox checkboxRegular);
        decimal calcularTotal(decimal descuento, decimal precio, decimal cantidad); 
    }
}
