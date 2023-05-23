using GestionDeProductos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.DataAccess.Interfaces
{
    /// <summary>
    /// Repositorio generico.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITiendaRepository : IGenericRepository<Tienda>
    {
        Task<ProductoTienda> GetTiendaProduct(int idTienda, int idProducto);
        Task<IEnumerable<ProductoTienda>> GetAllTiendaProduct(int idTienda);
        Task InsertTiendaProduct(ProductoTienda product);
        Task UpdateTiendaProduct(ProductoTienda product);
        Task DeleteTiendaProduct(int idTienda, int idProducto);
    }
    
}
