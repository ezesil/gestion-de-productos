using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Domain
{
    [DbTableName("DepositoXProducto")]
    public class ProductoDeposito
    {
        [DbName("IdDeposito", true)]
        public int IdDeposito { get; set; }

        [DbName("IdProducto", true)]
        public int IdProducto { get; set; }

        [DbName("Cantidad")]
        public int Cantidad { get; set; }
    }
}
