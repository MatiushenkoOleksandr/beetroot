using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace lesson18
{
    public class Snake
    {
        private readonly List<Position> _body;
        public Position Head => _body.First();
        public IEnumerable<Position> Body => _body.Skip(1);
        private int _growthRemaining;

        public static bool IsAlive => true;

        public Snake(Position location, int size = 1)
        {
            _body = new List<Position> {location};  
            _growthRemaining = Math.Max(0, size - 1);
        }
        public void Move (Direction direction)
        {

        }


    }
}
