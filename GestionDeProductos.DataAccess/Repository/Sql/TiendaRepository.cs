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
    public class TiendaRepository : SqlRepository<Tienda>
    {
        public TiendaRepository(IDbConnection connection) : base(connection)
        {
        }
    }
}