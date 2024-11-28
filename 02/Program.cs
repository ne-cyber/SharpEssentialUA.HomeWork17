using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    internal class Program
    {
        class MyAuto
        {
            public string Marka { get; internal set; }
            public string Model { get; internal set; }
            public int Rik { get; internal set; }
            public string Colir { get; internal set; }
        }

        class MyAutoVlasnik
        {
            public string Model { get; internal set; }
            public string Pokypec { get; internal set; }
            public string Contact { get; internal set; }
        }
        static void Main(string[] args)
        {            

            var autos = new List<MyAuto>
            {
                new MyAuto { Marka = "Vovlvo", Model = "a11", Rik = 1999, Colir = "blue"},
                new MyAuto { Marka = "Vovlvo", Model = "a2", Rik = 1999, Colir = "blue"},
                new MyAuto { Marka = "Vovlvo", Model = "b1", Rik = 1999, Colir = "blue"},
                new MyAuto { Marka = "Vovlvo", Model = "z", Rik = 1999, Colir = "red"},
            };

            var vlasniki = new List<MyAutoVlasnik>
            {
                new MyAutoVlasnik {Model = "a2", Pokypec = "Anton",  Contact = "+1 23 45 767"},
                new MyAutoVlasnik {Model = "z", Pokypec = "Vova",  Contact = "+1 23 45 767"},
                new MyAutoVlasnik {Model = "b1", Pokypec = "Vova",  Contact = "+1 23 45 767"},
            };

            var query = from v in vlasniki
                        join a in autos
                        on v.Model equals a.Model
                        let pokypec = v.Pokypec
                        where pokypec == "Vova"
                        //group new { Model = v.Model, Marka = a.Marka, Rik = a.Rik, Colir = a.Colir } by new { Pokypec = v.Pokypec }
                        select new { Marka = a.Marka, Model = v.Model, Rik = a.Rik, Colir = a.Colir, Pokypec = pokypec, Contact = v.Contact }
                        ;


            foreach (var v in query)
            {
                Console.Write("Покупець: ");
                Console.Write(v.Pokypec);
                Console.WriteLine("({0})", v.Contact);

                Console.WriteLine("Marka: {0}, Model: {1}, Rik: {2}, Colir: {3}", v.Marka, v.Model, v.Rik, v.Colir);

                Console.WriteLine(new string('-', 30));
            }


            Console.ReadKey();
        }
    }
}
