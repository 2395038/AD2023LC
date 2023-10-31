using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Models
{
    internal class Response
    {
        public int statusCode { get; set; }
        public string messageCode { get; set; }
        public Product product { get; set; }
        public List<Product> products { get; set; }
    }
}
