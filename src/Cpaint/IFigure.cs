using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint
{
    public interface IFigure
    {
        ConsoleColor  Color { get; }
        CPoint TopLeft { get; }
        CSize Size { get; } 
        void Clear();
        void Draw();

        double Area();

        void MoveTo(CPoint newTopLeft);

        void SetForeground(ConsoleColor color);
    }
}
