using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectr
{
    public static class SpectrManager
    {
        public static double max = 0;
        public static double C = 0;
        public static int elNum = 0;
        public static List<double> CX = new List<double>();
        public static List<Element> B;
        public static List<Element> Z;
        public static void GroupFirst()
        {
            
        }
        public static void GroupNext()
        {
            CX.Add(5);
            while (Z.Count > 0)
            {
                double newMax = 0;
                foreach (var j in Z)
                {
                    max = 0;
                    
                    foreach (var i in B)
                    {                                                             
                            max += i.LinkValues[j.Number];                       
                    }
                    if (max > newMax)
                    {
                        newMax = max;
                        elNum = j.Number;
                    }    
                }
                C = 1*newMax/B.Count;
                CX.Add(C);
                B.Add(Z.Find(x => x.Number == elNum));
                Z.Remove(Z.Find(x => x.Number == elNum));
            }                      
        }
    }
}
