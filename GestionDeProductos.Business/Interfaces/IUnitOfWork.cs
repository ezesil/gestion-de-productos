using GestionDeProductos.DataAccess.Interfaces;
using GestionDeProductos.Domain;

namespace GestionDeProductos.Business.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Producto> Producto { get; }
        public IGenericRepository<Operacion> Operacion { get; }
        public IDepositoRepository Deposito { get; }
        public ITiendaRepository Tienda { get; }
    }
}
