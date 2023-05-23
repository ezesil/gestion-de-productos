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
    public class TiendaRepository : SqlRepository, ITiendaRepository
    {

        /// <summary>
        /// Constructor por defecto sin parametros.
        /// </summary>
        public TiendaRepository()
        {
        }

        #region Tienda
        public async Task Insert(Tienda obj)
        {
            var query = "INSERT INTO [dbo].[Tienda] ([IdTienda], [Nombre], [Provincia], [Localidad]) VALUES (@IdTienda, @Nombre, @Provincia, @Localidad)";
            await Query(query, obj);
        }

        public async Task Update(Tienda obj)
        {
            var query = "UPDATE [dbo].[Tienda] SET [Nombre] = @Nombre, [Provincia] = @Provincia, [Localidad] = @Localidad WHERE [IdTienda] = @IdTienda";
            await Query(query, obj);
        }

        public async Task<IEnumerable<Tienda>> GetAll()
        {
            var query = "SELECT [IdTienda], [Nombre], [Provincia], [Localidad] FROM [dbo].[Tienda]";
            return await QueryMultiple<Tienda>(query);
        }

        public async Task<Tienda> GetOne(int idTienda)
        {
            var query = "SELECT [IdTienda], [Nombre], [Provincia], [Localidad] FROM [dbo].[Tienda] WHERE [IdTienda] = @IdTienda";
            return await QuerySingle<Tienda>(query, new { idTienda });
        }

        public async Task Delete(int idTienda)
        {
            var query = "DELETE FROM [dbo].[Tienda] WHERE [IdTienda] = @IdTienda;";
            await Query(query, new { idTienda });
        }
        #endregion


        #region Productos de Tiendas
        public async Task<ProductoTienda> GetTiendaProduct(int idTienda, int idProducto)
        {
            var query = "SELECT [IdTienda], [IdProducto], [Cantidad] FROM [dbo].[TiendaXProducto] WHERE [IdTienda] = @IdTienda AND [IdProducto] = @IdProducto;";
            return await QuerySingle<ProductoTienda>(query, new { idTienda, idProducto });
        }

        public async Task<IEnumerable<ProductoTienda>> GetAllTiendaProduct(int idTienda)
        {
            var query = "SELECT [IdTienda], [IdProducto], [Cantidad] FROM [dbo].[TiendaXProducto] where IdTienda = @IdTienda";
            return await QueryMultiple<ProductoTienda>(query, new { idTienda });
        }

        public async Task InsertTiendaProduct(ProductoTienda product)
        {
            var query = "INSERT INTO [dbo].[TiendaXProducto] ([IdTienda], [IdProducto], [Cantidad]) VALUES (@IdTienda, @IdProducto, @Cantidad);";
            await Query(query, product);
        }

        public async Task UpdateTiendaProduct(ProductoTienda product)
        {
            var query = "INSERT INTO [dbo].[TiendaXProducto] ([IdTienda], [IdProducto], [Cantidad]) VALUES (@IdTienda, @IdProducto, @Cantidad);";
            await Query(query, product);
        }

        public async Task DeleteTiendaProduct(int idTienda, int idProducto)
        {
            var query = "DELETE FROM [dbo].[TiendaXProducto] WHERE [IdTienda] = @IdTienda AND [IdProducto] = @IdProducto;";
            await Query(query, new { idTienda, idProducto });
        }

        #endregion

    }
}