using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint
{
    public struct CSize
    {
        public int Rows { get; }
        public int Cols { get; }

        public CSize(int rows, int cols)
        {
            Rows = rows > 0 ? rows : throw new ArgumentException($"Invalid rows {rows}");
            Cols = cols > 0 ? cols : throw new ArgumentException($"Invalid cols {cols}");
        }
    }
}
