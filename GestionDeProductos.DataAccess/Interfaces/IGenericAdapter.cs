using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.DataAccess.Interfaces
{
    /// <summary>
    /// Adaptador generico.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericAdapter<T> where T : class, new()
    {
        /// <summary>
        /// Adapta un objeto de tipo object[] en tipo T.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        T Adapt(object[] values);
    }
}
