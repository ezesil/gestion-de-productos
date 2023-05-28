using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Domain
{
    [DbTableName("TiendaXProducto")]
    public class ProductoTienda
    {
        [DbName("IdTienda", true)]
        public int IdTienda { get; set; }
        [DbName("IdProducto", true)]
        public int IdProducto { get; set; }
        [DbName("Cantidad")]
        public int Cantidad { get; set; }
    }
}
