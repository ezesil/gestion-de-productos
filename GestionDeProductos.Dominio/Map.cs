using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Domain
{
    public static class Map
    {
        public static ProductoTienda ToTiendaProducto(this ProductoDeposito e, int idTienda, int cantidad)
        {
            return new ProductoTienda()
            {
                IdProducto = e.IdProducto,
                IdTienda = idTienda,
                Cantidad = cantidad
            };
        }
    }
}
