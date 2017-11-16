using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static public double funcEuler(double x, double y)
        {
            return (Math.Pow(Math.Cos(x), 2.0) + y * Math.Tan(x));
        }
        static public double funcExact(double x)
        {
            double C = -(Math.Pow(2.0, 0.5) / 6.0);
            return (C / Math.Cos(x) + 3.0 / 4.0 * Math.Tan(x) + 1.0 / 12.0 * (Math.Sin(3.0 * x) / Math.Cos(x)));
        }
        static void Main(string[] args)
        {
            double h = 0.05;
            double x0 = Math.PI / 4.0;
            double y0 = 0.5;
            const double xLimit = Math.PI / 2.0;           
            double x = x0;
            double y = y0;
            double f;
            double hf;
            double exactY;
            Console.WriteLine("Шаг = 0.1");     
            while (x<=xLimit)
            {
                f = funcEuler(x, y);
                hf = h * f;
                exactY = funcExact(x);
                Console.WriteLine(String.Format("x = {0:0.###}, y = {1:0.###}, yExact = {4:0.###}, delta = {5:0.###}, f(x,y) = {2:0.###}, hf(x,y) = {3:0.###}", x, y, f, hf, exactY, exactY - y));
                x = x + h;
                y = y + hf;
            }
            h = 0.1;
            x = x0;
            y = y0;
            Console.WriteLine("Шаг = 0.2");
            while (x <= xLimit)
            {
                f = funcEuler(x, y);
                hf = h * f;
                exactY = funcExact(x);
                Console.WriteLine(String.Format("x = {0:0.###}, y = {1:0.###}, yExact = {4:0.###}, delta = {5:0.###}, f(x,y) = {2:0.###}, hf(x,y) = {3:0.###}", x, y, f, hf, exactY, exactY - y));
                x = x + h;
                y = y + hf;
            }
            Console.ReadKey();
        }
    }
}
