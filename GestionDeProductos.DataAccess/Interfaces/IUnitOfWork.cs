using GestionDeProductos.DataAccess.Repository.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        ProductoRepository ProductoRepository { get; }
    }
}
