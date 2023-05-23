using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Business.Interfaces
{
    /// <summary>
    /// Repositorio generico.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericService<T> where T : class, new()
    {
        /// <summary>
        /// Inserta un objeto en el repositorio.
        /// </summary>
        /// <param name="obj"></param>
        Task Insert(T obj);

        /// <summary>
        /// Actualiza un registro en el repositorio.
        /// </summary>
        /// <param name="obj"></param>
        Task Update(T obj);

        /// <summary>
        /// Obtiene todos los registros del repositorio.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Obtiene un registro del repositorio.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<T> GetOne(int guid);

        /// <summary>
        /// Elimina un registro del repositorio.
        /// </summary>
        /// <param name="guid"></param>
        Task Delete(int guid);
    }
}
