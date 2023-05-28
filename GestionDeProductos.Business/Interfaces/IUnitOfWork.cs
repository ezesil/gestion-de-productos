using GestionDeProductos.DataAccess.Interfaces;
using GestionDeProductos.DataAccess.Repository.Sql;
using GestionDeProductos.Domain;

namespace GestionDeProductos.Business.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Producto> Producto { get; }
        public IRepository<Operacion> Operacion { get; }
        public IRepository<Deposito> Deposito { get; }
        public IRepository<Tienda> Tienda { get; }
        public IRepository<ProductoDeposito> ProductoDeposito { get; }
        public IRepository<ProductoTienda> ProductoTienda { get; }
        public IRepository<Log> Log { get; }
    }
}
