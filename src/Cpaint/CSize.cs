using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint
{
    public struct CSize
    {
        private readonly int _rows;
        public int Rows
        {
            get { return _rows; }
        }

        private readonly int _cols;
        public int Cols
        {
            get { return _cols; }
        }

        public CSize(int rows, int cols)
        {
            _rows = rows;
            _cols = cols;
        }
    }
}
