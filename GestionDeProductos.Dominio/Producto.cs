using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionDeProductos.Domain
{
    [DbTableName("Producto")]
    public class Producto
    {
        [DbName("IdProducto")]
        public int IdProducto { get; set; }

        [DbName("Nombre")]
        public string? Nombre { get; set; }

        [DbName("Descripcion")]
        public string? Descripcion { get; set; }

        [DbName("Precio")]
        public double Precio { get; set; }
    }
}
