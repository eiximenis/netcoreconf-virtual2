using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint.Figures
{
    public abstract class FigureBase : IFigure
    {
        public ConsoleColor Color
        {
            get; protected set;
        }

        public CPoint TopLeft
        {
            get; protected set;
        }

        public CSize Size
        {
            get; protected set;
        }

        public abstract void Draw();

        public void MoveTo(CPoint newTopLeft)
        {
            TopLeft = newTopLeft;
        }

        public void SetForeground(ConsoleColor color)
        {
            if (Color != color)
            {
                Color = color;
                Draw();
            }
        }

        public abstract double? Area();

    }
}
