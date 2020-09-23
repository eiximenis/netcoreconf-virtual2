using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint
{
    public struct CPoint
    {
        private readonly int _x;
        public int X
        {
            get { return _x; }
        }

        private readonly int _y;
        public int Y
        {
            get { return _y; }
        }

        public CPoint(int x, int y)
        {
            _x = x;
            _y = y;
        }

    }
}
