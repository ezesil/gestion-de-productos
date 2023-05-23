using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Tools.Flags
{
    public static class FlagTools
    {
        /// <summary>
        /// Metodo de extension de PropertyInfo. Obtiene el flag especificado en el tipo generico.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        public static T? GetFlag<T>(this PropertyInfo e) where T : Attribute
        {
            Object[] attributes = e.GetCustomAttributes(typeof(T), false);

            if (attributes.Length > 0)
            {
                return (T)attributes[0];
            }

            return null;
        }
    }
}
