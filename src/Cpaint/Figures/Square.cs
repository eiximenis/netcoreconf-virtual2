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
            _topLeft = pos;
            _size = new CSize(rows, cols);
        }

        public override void Draw()
        {
            Console.ForegroundColor = _color;

            for (int line = 0; line < _size.Rows; line++)
            {
                Console.SetCursorPosition(_topLeft.X, TopLeft.Y + line);
                if (line == 0 || line == _size.Rows - 1)
                {
                    Console.Write(new string('*', _size.Cols));
                }
                else
                {
                    Console.Write('*');
                    if (_size.Cols > 2)
                    {
                        Console.Write(new string(' ', _size.Cols - 2));
                    }
                    Console.Write('*');
                }
            }
        }

        public override double Area()
        {
            return _size.Cols * _size.Rows;
        }
    }
}
