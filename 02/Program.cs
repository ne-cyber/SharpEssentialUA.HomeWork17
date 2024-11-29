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
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            var autos = new List<MyAuto>
            {
                new MyAuto { Marka = "Vovlvo", Model = "Vovlvo a11", Rik = 1999, Colir = "blue"},
                new MyAuto { Marka = "Vovlvo", Model = "Vovlvo a2", Rik = 1999, Colir = "blue"},
                new MyAuto { Marka = "Vovlvo", Model = "Vovlvo b1", Rik = 1999, Colir = "blue"},
                new MyAuto { Marka = "Vovlvo", Model = "Vovlvo z", Rik = 1999, Colir = "red"},
            };

            var vlasniki = new List<MyAutoVlasnik>
            {
                new MyAutoVlasnik {Model = "Vovlvo a2", Pokypec = "Anton",  Contact = "+1 23 45 767"},
                new MyAutoVlasnik {Model = "Vovlvo z", Pokypec = "Vova",  Contact = "+1 23 45 767"},
                new MyAutoVlasnik {Model = "Vovlvo b1", Pokypec = "Vova",  Contact = "+1 23 45 767"},

                new MyAutoVlasnik {Model = "Vovlvo b1", Pokypec = "Vova",  Contact = "+30974567890"},

            };

            var query = from v in vlasniki
                        join a in autos
                        on v.Model equals a.Model
                        let pokypec = v.Pokypec
                        let contact = v.Contact
                        //where pokypec == "Vova" && contact == "+1 23 45 767"
                        group new { Model = v.Model, Marka = a.Marka, Rik = a.Rik, Colir = a.Colir } by new { Pokypec = v.Pokypec, Contact = v.Contact }
                        //select new { Marka = a.Marka, Model = v.Model, Rik = a.Rik, Colir = a.Colir, Pokypec = pokypec, Contact = contact }
                        ;

            foreach (var pokypec in query)
            {
                Console.WriteLine("Покупець {0} ({1})", pokypec.Key.Pokypec, pokypec.Key.Contact);

                foreach (var auto in pokypec)
                {

                    Console.WriteLine("     Марка: {0}, модель: {1}, рік {2} {3}", auto.Model, auto.Marka, auto.Rik, auto.Colir);
                }

                Console.WriteLine(new string('-', 30));
            }


            //foreach (var v in query)
            //{
            //    Console.Write("Покупець: ");
            //    Console.Write(v.Pokypec);
            //    Console.WriteLine("({0})", v.Contact);

            //    Console.WriteLine("Marka: {0}, Model: {1}, Rik: {2}, Colir: {3}", v.Marka, v.Model, v.Rik, v.Colir);

            //    Console.WriteLine(new string('-', 30));
            //}



            Console.ReadKey();
        }
    }
}
