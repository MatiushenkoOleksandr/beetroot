using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson18
{
    public readonly struct Position
    {
        public int Top { get; }
        public int Left { get; }

        public Position(int top, int left)
        {
            Top = top;
            Left = left;
        }

        public Position RightBy(int n)
        {
            return new(Top, Left + n);
        }
        public Position DownBy(int n)
        {
            return new(Top + n, Left);
        }
    }
}
