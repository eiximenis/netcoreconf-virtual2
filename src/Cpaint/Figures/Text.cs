using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint.Figures
{
    public class Text : FigureBase
    {
        public string Content { get; }

        public Text(in CPoint position, string text) : base (position)
        {
            Content = text ?? throw new ArgumentException("Can't create empty text");
            Size = new CSize(rows: 1, cols: text.Length);
        }

        public override void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(TopLeft.X, TopLeft.Y);
            Console.Write(Content);
        }

        public override double? Area() => null;
    }
}
