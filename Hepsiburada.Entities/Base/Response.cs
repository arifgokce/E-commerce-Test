using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Entities.Base
{
    public class Response<T>
    {
        public string ResultCode { get; set; }
        public string Message { get; set; }
        public bool Successful { get; set; }
        public T Data { get; set; }
    }
}
