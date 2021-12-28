using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final___Sistema_de_facturacion
{
    class Regular : iClienteCategoria
    {
        private const double itbis = 0.18;  // variable constante
        private decimal total;
        private decimal sub;
        private decimal subdelsub;


        public void checkCategoria(CheckBox checkbxPremium, CheckBox checkbxRegular)
        {
            checkbxRegular.Checked = true;
            checkbxPremium.Checked = false;
        }

        public decimal calcularTotal(decimal descuento, decimal precio, decimal cantidad)
        {
            sub = precio * cantidad;
            subdelsub = sub * Convert.ToDecimal(itbis);

            total = sub + subdelsub;

            return total;
        }

    }
}
