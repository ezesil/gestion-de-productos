using GestionDeProductos.Business.Interfaces;
using GestionDeProductos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Business.Interfaces
{
    /// <summary>
    /// Interfaz de servicio de Tienda.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITiendaService : IGenericService<Tienda>
    {
        Task<ProductoTienda> GetTiendaProduct(int idTienda, int idProducto);
        Task<IEnumerable<ProductoTienda>> GetAllTiendaProduct(int idTienda);
        Task InsertTiendaProduct(ProductoTienda product);
        Task UpdateTiendaProduct(ProductoTienda product);
        Task DeleteTiendaProduct(int idTienda, int idProducto);
    }

}
