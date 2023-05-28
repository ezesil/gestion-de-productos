using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Domain
{
    [DbTableName("Logs")]
    public class Log
    {
        [DbName("IdLog", true)]
        public int IdLog { get; set; }

        [DbName("Fecha")]
        public DateTime Fecha { get; set; }

        [DbName("Data")]
        public string Data { get; set; }
    }
}
