using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace Cpaint
{
    public class FigureCollection : CollectionBase
    {
        public int Add(IFigure value)
        {
            return List.Add(value);
        }

        public void Remove(IFigure value)
        {
            List.Remove(value);
        }

        public IFigure this[int index]
        {
            get
            {
                return (IFigure)List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        public void Insert(int index, IFigure value)
        {
            List.Insert(index, value);
        }
    }
}
