using GestionDeProductos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Business.Interfaces
{
    /// <summary>
    /// Interfaz de servicio de deposito.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDepositoService : IGenericService<Deposito>
    {
        Task<ProductoDeposito> GetDepositoProduct(int idDeposito, int idProducto);
        Task<IEnumerable<ProductoDeposito>> GetAllDepositoProduct(int idDeposito);
        Task InsertDepositoProduct(ProductoDeposito product);
        Task UpdateDepositoProduct(ProductoDeposito product);
        Task DeleteDepositoProduct(int idDeposito, int idProducto);
        void TransferProductoADeposito(ProductoDeposito product, int IdDeposito, int cantidad);
        void TransferProductoATienda(ProductoDeposito product, int idTienda, int cantidad);
        void AgregarProducto(ProductoDeposito product);

    }
}
