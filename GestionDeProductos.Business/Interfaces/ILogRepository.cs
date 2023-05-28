using GestionDeProductos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Business.Interfaces
{
    public interface ILogService
    {
        /// <summary>
        /// Inserta un objeto en el repositorio.
        /// </summary>
        /// <param name="obj"></param>
        Task Insert(Log obj);

        /// <summary>
        /// Actualiza un registro en el repositorio.
        /// </summary>
        /// <param name="obj"></param>
        Task Update(Log obj);

        /// <summary>
        /// Obtiene todos los registros del repositorio.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Log>> GetAll();

        /// <summary>
        /// Obtiene un registro del repositorio.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<Log> GetOne(int guid);
    }
}
