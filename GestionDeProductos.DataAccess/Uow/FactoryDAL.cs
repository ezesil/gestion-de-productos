using GestionDeProductos.DataAccess.Interfaces;
using GestionDeProductos.DataAccess.Repository.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestionDeProductos.DataAccess.Uow
{
    /// <summary>
    /// Clase de tipo Factory para los servicios de base.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public ProductoRepository ProductoRepository { get; }


        public UnitOfWork()
        {
            ProductoRepository = new ProductoRepository();
        }

    }
}
