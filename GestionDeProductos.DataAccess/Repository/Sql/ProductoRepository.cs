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
    public class ProductoRepository : SqlRepository, IGenericRepository<Producto>
    {    
        /// <summary>
        /// Constructor por defecto sin parametros.
        /// </summary>
        public ProductoRepository()
        { 
        }

        #region Producto
        public async Task<IEnumerable<Producto>> GetAll()
        {
            var query = "SELECT [IdProducto], [Nombre], [Descripcion], [Precio] FROM [dbo].[Producto]";
            return await QueryMultiple<Producto>(query);
        }

        public async Task Insert(Producto obj)
        {
            var query = "INSERT INTO [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [Precio]) VALUES (@IdProducto, @Nombre, @Descripcion, @Precio)";
            await Query(query, obj);
        }

        public async Task Update(Producto obj)
        {
            var query = "UPDATE [dbo].[Producto] SET [Nombre] = @Nombre, [Descripcion] = @Descripcion, [Precio] = @Precio WHERE [IdProducto] = @IdProducto";
            await Query(query, obj);
        }

        public async Task Delete(int idProducto)
        {
            var query = "DELETE FROM [dbo].[Producto] WHERE [IdProducto] = @IdProducto";
            await Query(query, new { idProducto });
        }

        public async Task<Producto> GetOne(int idProducto)
        {
            var query = "SELECT [IdProducto], [Nombre], [Provincia], [Localidad] FROM [dbo].[Producto] WHERE [IdProducto] = @IdProducto";
            return await QuerySingle<Producto>(query, new { idProducto });
        }

        #endregion

    }
}

