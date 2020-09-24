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
        void Clear()
        {
            for (var i = 0; i < Size.Rows; i++)
            {
                Console.SetCursorPosition(TopLeft.X, TopLeft.Y + i);
                Console.Write(new string(' ', Size.Cols));
            }
        }
        void Draw();

        double? Area();

        void MoveTo(CPoint newTopLeft);

        void SetForeground(ConsoleColor color);
    }
}
