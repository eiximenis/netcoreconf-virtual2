using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint
{
    public readonly struct FigureAddedOperation
    {
        public IFigure Figure { get; }
        public double Area { get; }

        public FigureAddedOperation(IFigure figure, double? area)
        {
            Figure = figure;
            Area = area ?? 0;
        }
    }
}
