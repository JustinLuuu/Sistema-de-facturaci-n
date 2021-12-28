using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final___Sistema_de_facturacion
{
    abstract class Gestiones
    {
        public abstract void Agregar();
        public abstract void Actualizar(int ID);
        public abstract void Eliminar(int ID);

    }
}
