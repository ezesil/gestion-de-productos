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
        public IRepository<Producto> Producto { get; }
        public IRepository<Operacion> Operacion { get; }
        public IRepository<Deposito> Deposito { get; }
        public IRepository<Tienda> Tienda { get; }
        public IRepository<ProductoDeposito> ProductoDeposito { get; }
        public IRepository<ProductoTienda> ProductoTienda { get; }
        public IRepository<Log> Log { get; }


        public UnitOfWork(
            IRepository<Producto> productoRepository,
            IRepository<Operacion> operacionRepository,
            IRepository<Deposito> depositoRepository,
            IRepository<Tienda> tiendaRepository,
            IRepository<ProductoDeposito> productoDeposito,
            IRepository<ProductoTienda> productoTienda,
            IRepository<Log> log)
        {
            Producto = productoRepository;
            Operacion = operacionRepository;
            Deposito = depositoRepository;
            Tienda = tiendaRepository;
            ProductoDeposito = productoDeposito;
            ProductoTienda = productoTienda;
            Log = log;          
        }

    }
}
