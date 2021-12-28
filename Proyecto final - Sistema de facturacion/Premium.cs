using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final___Sistema_de_facturacion
{
    class Premium : iClienteCategoria
    {
        private const double itbis = 0.18;  // variable constante
        private  decimal total;
        private decimal subdelsub;
        private decimal sub;
        private decimal aux;
        private decimal casi;

        public void checkCategoria(CheckBox checkbxPremium, CheckBox checkbxRegular)
        {
            checkbxPremium.Checked = true;
            checkbxRegular.Checked = false;   
        }


        public decimal calcularTotal(decimal descuento, decimal precio, decimal cantidad)
        {
            descuento = Convert.ToDecimal(0.05);

           aux = cantidad * precio;

            subdelsub = aux * descuento;

            sub = aux - subdelsub;

            casi = sub * Convert.ToDecimal(itbis);

            total = casi + sub;

            return total;
        }

    }
}
