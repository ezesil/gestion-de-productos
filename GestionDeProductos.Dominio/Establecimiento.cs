using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Domain
{
    public class Establecimiento : Entity
    {
        public string? Nombre { get; set; }
        public string? Provincia { get; set; }
        public string? Localidad { get; set; }
    }
}
