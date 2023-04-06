using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson10
{
    public class Customer:Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public List<Receipt> Receipts { get; set; }
        public Customer()
        {
            Receipts = new List<Receipt>();
        }
    }
}
