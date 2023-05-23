using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Domain
{
    public class ProductoDeposito
    {
        public int IdDeposito { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
