using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectr
{
    public class Element
    {
        public int Number { get; set; }
        public double[] LinkValues { get; set; }

        public Element(int number, double[] linkValues)
        {
            Number = number;
            LinkValues = linkValues;
        }

        public Element()
        {
            
        }
    }
}
