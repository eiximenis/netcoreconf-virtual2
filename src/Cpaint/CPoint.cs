using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint
{
    public struct CPoint
    {
        public int X { get; }
        public int Y { get; }

        public CPoint(int x, int y)
        {
            X = x >= 0 ? x : throw new ArgumentException($"Invalid column {x}");
            Y = y >= 0 ? y : throw new ArgumentException($"Invalid row {y}");
        }

    }
}
