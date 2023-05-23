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
    public class ProductoRepository : SqlRepository<Producto>, IGenericRepository<Producto>
    {    
        public override string DeleteQuery
        { get => "DELETE FROM [CinemaDB].[dbo].[Sesion] where [guid_sesion] = @Id"; }
        public override string SelectAllQuery
        { get => "SELECT [guid_sesion],[fecha],[guid_pelicula],[guid_sala] FROM [CinemaDB].[dbo].[Sesiones]"; }
        public override string SelectQuery
        { get => "SELECT [guid_sesion],[fecha],[guid_pelicula],[guid_sala] FROM [CinemaDB].[dbo].[Sesiones] where [guid_sesion] = @Id"; }
        public override string InsertQuery
        { get => "INSERT INTO [CinemaDB].[dbo].[Sesiones] ([guid_sesion],[fecha],[guid_pelicula],[guid_sala]) values (@Id, @Date, @MovieId, @RoomId)"; }
        public override string UpdateQuery
        { get => "UPDATE [CinemaDB].[dbo].[Sesiones] SET [fecha] = @Date,[guid_pelicula] = @MovieId,[guid_sala] = @RoomId where [guid_sesion] = @Id"; }

        /// <summary>
        /// Constructor por defecto sin parametros.
        /// </summary>
        public ProductoRepository()
        { 
        }

        public async Task Insert(Producto obj)
        {
            await base.Insert(obj);
        }

        public async Task Update(Producto obj)
        {
            await base.Update(obj);
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await base.GetAll();
        }

        public async Task<Producto> GetOne(Guid guid)
        {
            return await base.GetOne(guid);
        }

        public async Task Delete(Guid guid)
        {
            await base.Delete(guid);
        }
    }
}

