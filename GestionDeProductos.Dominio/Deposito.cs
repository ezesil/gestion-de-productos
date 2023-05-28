using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Domain
{
    [DbTableName("Deposito")]
    public class Deposito
    {
        [DbName("IdDeposito", true)]
        public int IdDeposito { get; set; }

        [DbName("Nombre")]
        public string? Nombre { get; set; }

        [DbName("Provincia")]
        public string? Provincia { get; set; }

        [DbName("Localidad")]
        public string? Localidad { get; set; }
    }
}
