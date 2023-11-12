using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBubbleTeaProject.Moddle
{
    internal class Response
    {
        public int statusCode { get; set; }
        public string messageCode { get; set; }
        public Employee employee { get; set; }
        public List<Employee> employees { get; set; }
    }
}
