using GestionDeProductos.DataAccess.Interfaces;
using GestionDeProductos.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.DataAccess.Repository.Sql
{
    public class OperacionRepository : SqlRepository<Operacion>
    {
        public OperacionRepository(IDbConnection connection) : base(connection)
        {
        }
    }
}