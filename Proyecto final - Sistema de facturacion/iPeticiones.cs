using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final___Sistema_de_facturacion
{
    interface iPeticiones // interfaz
    {
         void Peticion(DataGridView pantallita, string query);  // interfaz para llenar datagridview
         
        void LlenarCombo(ComboBox combo, string query);     // interfaz para llenar comboBox de datos
    }
}
