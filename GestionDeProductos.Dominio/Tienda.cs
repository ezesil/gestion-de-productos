using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Domain
{
    [DbTableName("Tienda")]
    public class Tienda
    {
        [DbName("Idtienda", true)]
        public int Idtienda { get; set; }

        [DbName("Nombre")]
        public string? Nombre { get; set; }

        [DbName("Provincia")]
        public string? Provincia { get; set; }

        [DbName("Localidad")]
        public string? Localidad { get; set; }
    }
}
