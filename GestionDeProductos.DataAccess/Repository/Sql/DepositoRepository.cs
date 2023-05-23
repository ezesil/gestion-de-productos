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
    public class DepositoRepository : SqlRepository, IDepositoRepository
    {
        /// <summary>
        /// Constructor por defecto sin parametros.
        /// </summary>
        public DepositoRepository()
        {
        }

        #region Deposito
        public async Task Insert(Deposito obj)
        {
            var query = "INSERT INTO [dbo].[Deposito] ([IdDeposito], [Nombre], [Provincia], [Localidad]) VALUES (@IdDeposito, @Nombre, @Provincia, @Localidad)";
            await Query(query, obj);
        }

        public async Task Update(Deposito obj)
        {
            var query = "UPDATE [dbo].[Deposito] SET [Nombre] = @Nombre, [Provincia] = @Provincia, [Localidad] = @Localidad WHERE [IdDeposito] = @IdDeposito";
            await Query(query, obj);
        }

        public async Task<IEnumerable<Deposito>> GetAll()
        {
            var query = "SELECT [IdDeposito], [Nombre], [Provincia], [Localidad] FROM [dbo].[Deposito]";
            return await QueryMultiple<Deposito>(query);
        }

        public async Task<Deposito> GetOne(int idDeposito)
        {
            var query = "SELECT [IdDeposito], [Nombre], [Provincia], [Localidad] FROM [dbo].[Deposito] WHERE [IdDeposito] = @IdDeposito";
            return await QuerySingle<Deposito>(query, new { idDeposito });
        }

        public async Task Delete(int idDeposito)
        {
            var query = "DELETE FROM [dbo].[Deposito] WHERE [IdDeposito] = @IdDeposito;";
            await Query(query, new { idDeposito });
        }
        #endregion


        #region Productos de Depositos
        public async Task<ProductoDeposito> GetDepositoProduct(int idDeposito, int idProducto)
        {
            var query = "SELECT [IdDeposito], [IdProducto], [Cantidad] FROM [dbo].[DepositoXProducto] WHERE [IdDeposito] = @IdDeposito AND [IdProducto] = @IdProducto;";
            return await QuerySingle<ProductoDeposito>(query, new { idDeposito, idProducto });
        }

        public async Task<IEnumerable<ProductoDeposito>> GetAllDepositoProduct(int idDeposito)
        {
            var query = "SELECT [IdDeposito], [IdProducto], [Cantidad] FROM [dbo].[DepositoXProducto] where IdDeposito = @IdDeposito";
            return await QueryMultiple<ProductoDeposito>(query, new { idDeposito });
        }

        public async Task InsertDepositoProduct(ProductoDeposito product)
        {
            var query = "INSERT INTO [dbo].[DepositoXProducto] ([IdDeposito], [IdProducto], [Cantidad]) VALUES (@IdDeposito, @IdProducto, @Cantidad);";
            await Query(query, product);
        }

        public async Task UpdateDepositoProduct(ProductoDeposito product)
        {
            var query = "UPDATE [dbo].[DepositoXProducto] SET [Cantidad] = @Cantidad WHERE [IdDeposito] = @IdDeposito AND [IdProducto] = @IdProducto";
            await Query(query, product);
        }

        public async Task UpdateDepositoProductId(ProductoDeposito product, int nuevoIdDeposito)
        {
            var query = "UPDATE [dbo].[DepositoXProducto] SET [Cantidad] = @Cantidad WHERE [IdDeposito] = @IdDeposito AND [IdProducto] = @IdProducto";
            await Query(query, new { nuevoIdDeposito, product.IdDeposito, product.IdProducto, product.Cantidad });
        }

        public async Task DeleteDepositoProduct(int idDeposito, int idProducto)
        {
            var query = "DELETE FROM [dbo].[DepositoXProducto] WHERE [IdDeposito] = @IdDeposito AND [IdProducto] = @IdProducto";
            await Query(query, new { idDeposito, idProducto });
        }

        #endregion








    }
}
