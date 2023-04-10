using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson13
{
    public class Vehicle
    {
        public string Name { get; set; }
        public int Id{ get; set; }
        public int AutoServiceId { get; set; }
        public List<Wheel> Wheels { get; set; }
        public Engine Engine { get; set; }
        public List<Suspention> Suspentions { get; set; }



    }
}
