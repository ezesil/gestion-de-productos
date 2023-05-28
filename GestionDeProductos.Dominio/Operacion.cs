using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Domain
{
    [DbName("Operacion")]
    public class Operacion
    {
        [DbName("IdOperacion", true)]
        public int IdOperacion {  get; set; }

        [DbName("Origen")]
        public int Origen { get; set; }

        [DbName("Destino")]
        public int Destino { get; set; }

        [DbName("EsDeposito")]
        public bool EsDeposito { get; set; }

        [DbName("Fecha")]
        public DateTime? Fecha { get; set; }

        [DbName("Usuario")]
        public string? Usuario { get; set; }
    }
}
