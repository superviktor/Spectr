using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Spectr;

namespace SpectrVisual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Spectr_Click(object sender, RoutedEventArgs e)
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
                double[] linkValues = new double[resultArray.GetLength(1)];
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


            resusltCanvas.Children.Add(new Line()
            {
                X1 = 4,
                Y1 = 4,
                X2 = 4,
                Y2 = 700,
                Stroke = Brushes.Black
            });

            resusltCanvas.Children.Add(new Line()
            {
                X1 = 0,
                Y1 = 400,
                X2 = 700,
                Y2 = 400,
                Stroke = Brushes.Black
            });

            for (int k = 0; k < (SpectrManager.CX).Count; k++)
            {
                TextBox tb = new TextBox();
                tb.Text = SpectrManager.B[k].Number.ToString();
                tb.Background = Brushes.Aqua;
                Canvas.SetLeft(tb, k * 50);
                Canvas.SetTop(tb,400);
                resusltCanvas.Children.Add(tb);
            }
            
            for (int y = 0; y < (SpectrManager.CX).Count; y++)
            {
                TextBox tb = new TextBox();
                
                tb.Text = SpectrManager.CX[y].ToString().Substring(0,1);
                Canvas.SetLeft(tb, y*50-7+15);
                Canvas.SetTop(tb, 500 -SpectrManager.CX[y]*50-7);
                resusltCanvas.Children.Add(tb);
                


                Ellipse elipse = new Ellipse();
                elipse.Fill = new SolidColorBrush(Colors.Red);
                elipse.StrokeThickness = 1;
                elipse.Stroke = Brushes.Black;
                elipse.Width = 15;
                elipse.Height = 15; 
                Canvas.SetLeft(elipse,y*50-7);
                Canvas.SetTop(elipse,500 -SpectrManager.CX[y]*50-7);
                resusltCanvas.Children.Add(elipse);

            }
            for (int k = 1; k < (SpectrManager.CX).Count; k++)
            {

                resusltCanvas.Children.Add(new Line()
                {
                    X1 = k*50,
                    Y1 = 500+ -SpectrManager.CX[k]*50,
                    X2 = (k - 1)*50,
                    Y2 = 500 -SpectrManager.CX[k - 1]*50,
                    Stroke = Brushes.Red
                });

            }
           
        }
    }
}
