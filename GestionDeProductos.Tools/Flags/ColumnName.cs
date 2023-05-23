using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Tools.Flags
{
    public class ColumnName : Attribute
    {
        /// <summary>
        /// Nombre utilizado en la base de datos.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Constructor por defecto que recibe un nombre utilizado en la base de datos.
        /// </summary>
        public ColumnName(string name)
        {
            Name = name;
        }
    }
}
