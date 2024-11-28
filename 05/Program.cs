using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    static class Calculator
    {
        public static dynamic Add(dynamic a, dynamic b) => a + b;
        public static dynamic Sub(dynamic a, dynamic b) => a - b;
        public static dynamic Mul(dynamic a, dynamic b) => a * b;
        public static dynamic Div(dynamic a, dynamic b) => (b == 0 ? throw new DivideByZeroException("Спроба поділу на нуль!") : a / b);
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine(@"1 + ""2"":" + Calculator.Add(1, "2"));
            Console.WriteLine(@"1 + 2 = " + Calculator.Sub(1, 2));
            Console.WriteLine(@"1 * 2 = " + Calculator.Mul(1, 2));
            Console.WriteLine("1 / 2 = "+ Calculator.Div(1d, 2));

            try
            {
                Console.Write("1 / 0 = ");
                Console.WriteLine(Calculator.Div(1, 0));
            }
            catch (DivideByZeroException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine("----");

            Console.ReadKey();
        }
    }
}
