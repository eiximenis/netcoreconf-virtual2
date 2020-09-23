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
            TopLeft = position;
            _text = text;
            Size = new CSize(rows: 1, cols: text.Length);
        }

        public override void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(TopLeft.X, TopLeft.Y);
            Console.Write(_text);
        }

        public override double? Area()
        {
            return null;
        }
    }
}
