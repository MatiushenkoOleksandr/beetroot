using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson18
{
    public class Apple
    {
        public Position Position { get; }
        public Apple(Position position) => Position = position;
    }
}
