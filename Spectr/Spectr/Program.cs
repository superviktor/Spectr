using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectr
{
    class Program
    {
        static void Main(string[] args)
        {
           
            String input = File.ReadAllText("inputText.txt");
            int i = 0;
            int j = 0;
            double[,] resultArray = new double[15, 15];
            foreach (string row in input.Split('\n'))
            {
                j = 0;
                foreach (string col in row.Trim().Split(','))
                {
                    resultArray[i, j] = Double.Parse(col, CultureInfo.InvariantCulture);
                    j++;
                }
                i++;
            }
            
            List<Element> B = new List<Element>();
            
            List<Element> Z = new List<Element>();

            for (int k = 0; k < resultArray.GetLength(0); k++)
            {
                double [] linkValues = new double[resultArray.GetLength(1)];
                for (int l = 0; l < resultArray.GetLength(1); l++)
                {                  
                    linkValues[l] = resultArray[k, l];                                      
                }
                if (k == 0)
                {
                    B.Add(new Element(k, linkValues));
                }
                else
                {
                    Z.Add(new Element(k, linkValues));
                }
               
            }
          
            

           
            SpectrManager.B = B;
            SpectrManager.Z = Z;
            SpectrManager.GroupNext();
            Console.WriteLine("\tB:");
            foreach (var m in SpectrManager.B)
            {
                Console.WriteLine(m.Number+1);
            }
            Console.WriteLine(new string('*',10));
            Console.WriteLine("\tC:");
            foreach (var m in SpectrManager.CX)
            {
                Console.WriteLine(m);
            }
        }
    }
}
