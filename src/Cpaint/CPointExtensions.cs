using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint
{
    static class CPointExtensions
    {
        public static CPoint Displace(this CPoint point, int rows = 0, int cols = 0) => point with {  X = point.X + cols, Y = point.Y + rows };
    }
}
