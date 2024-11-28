using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            //dynamic[] slovnik = {
            var slovnik = new [] {
                new { ukr="сонце", eng = "sun"},
                new { ukr="карандаш", eng = "pencil"},
                new { ukr="стіл", eng = "table"},
                new { ukr="магазин", eng = "shop"},
                new { ukr="смартфон", eng = "smartfon"},
                new { ukr="гугл", eng = "google"},
                new { ukr="гра", eng = "game"},
                new { ukr="коректор", eng = "corector"},
                new { ukr="диск", eng = "disk"},
                new { ukr="клавіатура", eng = "keybord"},
            };

            foreach (dynamic d in slovnik)
            {
                Console.WriteLine(d.ukr + " - " + d.eng);
            }


            Console.ReadKey();
        }
    }
}
