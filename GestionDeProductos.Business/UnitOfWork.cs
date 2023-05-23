using GestionDeProductos.Business.Interfaces;
using GestionDeProductos.DataAccess.Interfaces;
using GestionDeProductos.DataAccess.Repository.Sql;
using GestionDeProductos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestionDeProductos.Business.Uow
{
    /// <summary>
    /// Clase de tipo Factory para los servicios de base.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Producto> Producto { get; }
        public IGenericRepository<Operacion> Operacion { get; }
        public IDepositoRepository Deposito { get; }
        public ITiendaRepository Tienda { get; }

        public UnitOfWork(
            IGenericRepository<Producto> productoRepository, 
            IGenericRepository<Operacion> operacionRepository,
            IDepositoRepository depositoRepository,
            ITiendaRepository tiendaRepository)
        {
            Producto = productoRepository;
            Operacion = operacionRepository;
            Deposito = depositoRepository;
            Tienda = tiendaRepository;
        }

    }
}
