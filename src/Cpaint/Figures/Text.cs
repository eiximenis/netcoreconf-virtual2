using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint.Figures
{
    public class Text : FigureBase
    {
        private readonly string _text;

        public Text(CPoint position, string text)
        {
            _topLeft = position;
            _text = text;
            _size = new CSize(1, text.Length);
        }

        public override void Draw()
        {
            Console.ForegroundColor = _color;
            Console.SetCursorPosition(_topLeft.X, _topLeft.Y);
            Console.Write(_text);
        }

        public override double Area()
        {
            return _size.Cols * _size.Rows;
        }
    }
}
