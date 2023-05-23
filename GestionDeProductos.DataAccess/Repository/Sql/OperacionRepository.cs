using GestionDeProductos.DataAccess.Interfaces;
using GestionDeProductos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.DataAccess.Repository.Sql
{
    /// <summary>
    /// Repositorio de sesiones.
    /// </summary>
    public class OperacionRepository : SqlRepository, IGenericRepository<Operacion>
    {
        /// <summary>
        /// Constructor por defecto sin parametros.
        /// </summary>
        public OperacionRepository()
        {
        }

        #region Operacion
        public async Task Insert(Operacion obj)
        {
            var query = "INSERT INTO [dbo].[Operacion] ([IdOperacion], [Origen], [Destino], [Fecha], [Usuario]) VALUES (@IdOperacion, @Origen, @Destino, @Fecha, @Usuario)";
            await Query(query, obj);
        }

        public async Task Update(Operacion obj)
        {
            var query = "UPDATE [dbo].[Operacion] SET [Origen] = @Origen, [Destino] = @Destino, [Fecha] = @Fecha, [Usuario] = @Usuario WHERE [IdOperacion] = @IdOperacion";
            await Query(query, obj);
        }

        public async Task<IEnumerable<Operacion>> GetAll()
        {
            var query = "SELECT [IdOperacion], [Origen], [Destino], [Fecha], [Usuario] FROM [dbo].[Operacion]";
            return await QueryMultiple<Operacion>(query);
        }

        public async Task<Operacion> GetOne(int idOperacion)
        {
            var query = "SELECT [IdOperacion], [Origen], [Destino], [Fecha], [Usuario] FROM [dbo].[Operacion] WHERE [IdOperacion] = @IdOperacion";
            return await QuerySingle<Operacion>(query, new { idOperacion });
        }

        public async Task Delete(int idOperacion)
        {
            var query = "DELETE FROM [dbo].[Operacion] WHERE [IdOperacion] = @IdOperacion";
            await Query(query, new { idOperacion });
        }
        #endregion
    }
}