using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Models
{
    internal class Product
    {
        // this class will help us to get the structure from the database,which is going to be 
        //encrypted inside the Response the server is sending
        public string product_name { get; set; }
        public int product_id { get; set; }
        public double product_amount { get; set; }
        public double product_price { get; set; }

   
    }
}
