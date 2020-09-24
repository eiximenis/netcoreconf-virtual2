using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint.Figures
{
    public class Square : FigureBase
    {

        public Square(in CPoint pos, int rows, int cols)
        {
            TopLeft = pos;
            Size = new CSize(rows, cols);
        }

        public override void Draw()
        {
            Console.ForegroundColor = Color;

            var lines = Enumerable.Range(0, Size.Rows)
                .Select(i => (i == 0 || i == Size.Rows - 1) ?
                    new string('*', Size.Cols) :
                    $"*{new string(' ', Size.Cols - 2)}*");


            var offset = 0;
            foreach (var line in lines)
            {
                Console.SetCursorPosition(TopLeft.X, TopLeft.Y + offset);
                offset++;
                Console.Write(line);
            }

        }

        public override double? Area() => Size.Cols * Size.Rows;
    }
}
