using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Domain
{
    public class BaseResponse
    {
        public object Data { get; set; }

        public int Status { get; set; }

        public string StatusMessage { get; set; }

        public bool IsSuccess { get; set; }

        public string ResponseTime { get; set; }

        public BaseResponse() { }
    }
}
