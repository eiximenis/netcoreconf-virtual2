using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint.Figures
{
    public abstract class FigureBase : IFigure
    {
        private ConsoleColor _color;

        public ConsoleColor Color
        {
            get { return _color; }
            protected set { _color = value; }
        }

        private CPoint _topLeft;

        public CPoint TopLeft
        {
            get
            {
                return _topLeft;
            }
            protected set
            {
                _topLeft = value;
            }
        }

        private CSize _size;

        public CSize Size
        {
            get
            {
                return _size;
            }
            protected set
            {
                _size = value;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < _size.Rows; i++)
            {
                Console.SetCursorPosition(_topLeft.X, _topLeft.Y + i);
                Console.Write(new string(' ', _size.Cols));
            }
        }

        public abstract void Draw();

        public void MoveTo(CPoint newTopLeft)
        {
            _topLeft = newTopLeft;
        }


        public void SetForeground(ConsoleColor color)
        {
            if (_color != color)
            {
                _color = color;
                Draw();
            }
        }

        public abstract double? Area();

    }
}
