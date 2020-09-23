using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Cpaint
{
    static class FigureExtensions
    {
        public static void SetNextColor(this IFigure figure)
        {
            var current = figure.Color;
            var nextColor = (ConsoleColor)(((int)current + 1) % 16);
            figure.SetForeground(nextColor);
        }
    }
}
