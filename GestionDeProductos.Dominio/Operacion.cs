using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Domain
{
    public class Operacion
    {
        public int IdOperacion {  get; set; }
        public int Origen { get; set; }
        public int Destino { get; set; }
        public bool EsDeposito { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Usuario { get; set; }
    }
}
