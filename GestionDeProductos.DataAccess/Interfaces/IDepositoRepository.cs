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
    public interface IDepositoRepository : IGenericRepository<Deposito>
    {
        Task<ProductoDeposito> GetDepositoProduct(int idDeposito, int idProducto);
        Task<IEnumerable<ProductoDeposito>> GetAllDepositoProduct(int idDeposito);
        Task InsertDepositoProduct(ProductoDeposito product);
        Task UpdateDepositoProduct(ProductoDeposito product);
        Task DeleteDepositoProduct(int idDeposito, int idProducto);
        Task UpdateDepositoProductId(ProductoDeposito product, int nuevoIdDeposito);
    }
}
