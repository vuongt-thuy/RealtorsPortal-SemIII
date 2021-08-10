using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.Entities
{
    public class ResponeJSON<T>
    {
        public int statusCode { get; set; }
        public string msg { get; set; }
        public T data { get; set; }
    }
}
