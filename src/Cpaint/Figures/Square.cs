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

        public Square(CPoint pos, int rows, int cols)
        {
            TopLeft = pos;
            Size = new CSize(rows, cols);
        }

        public override void Draw()
        {
            Console.ForegroundColor = Color;

            for (int line = 0; line < Size.Rows; line++)
            {
                Console.SetCursorPosition(TopLeft.X, TopLeft.Y + line);
                if (line == 0 || line == Size.Rows - 1)
                {
                    Console.Write(new string('*', Size.Cols));
                }
                else
                {
                    Console.Write('*');
                    if (Size.Cols > 2)
                    {
                        Console.Write(new string(' ', Size.Cols - 2));
                    }
                    Console.Write('*');
                }
            }
        }

        public override double? Area()
        {
            return Size.Cols * Size.Rows;
        }
    }
}
