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
        public string? Origen { get; set; }
        public string? Destino { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Usuario { get; set; }
    }
}
