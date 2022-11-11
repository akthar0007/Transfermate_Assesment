using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranserMateAsssment.Core.Common
{
    public class Responce<T>
    {
        

        public T Data { get; set; }
        public string Message { get;  set; }
        public string Statuscode { get;  set; }
    }
    
}
