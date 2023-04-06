using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson10
{
    public class Receipt:Entity
    {
       public List<Product> Products { get; set; }
        public string CustomerName {get; set;}
        public DateTime Date {get; set;}
        public decimal TotalPrice { get; set;}

    }
}
