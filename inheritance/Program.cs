using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OROKLES
{
    internal class Program
    {
        class Szemely
        {
            private string nev;
            private string lakcim;
            public int[] szuletesiDatum;

            public string Nev
            {
                get { return nev; }
            }

            public string Lakcim
            {
                get { return lakcim; }
                set { lakcim = value; }
            }

            public Szemely(string nev)
            {
                this.nev = nev;
                szuletesiDatum = new int[3];
            }

            public Szemely(string nev, string lakcim)
            {
                this.nev = nev;
                Lakcim = lakcim;
            }

            public Szemely(string nev, int[] datum)
            {
                this.nev = nev;
                if (datum.Length != 3)
                {
                    throw new ArgumentException("A születési dátumnak 3 elemből kell állnia (év, hónap, nap).");
                }
                szuletesiDatum = datum;
            }

            public Szemely(string nev, string lakcim, int[] datum)
            {
                this.nev = nev;
                Lakcim = lakcim;
                if (datum.Length != 3)
                {
                    throw new ArgumentException("A születési dátumnak 3 elemből kell állnia (év, hónap, nap).");
                }
                szuletesiDatum = datum;
            }

            public string this[string parameter]
            {
                get
                {
                    switch (parameter.ToLower())
                    {
                        case "ev":
                            return szuletesiDatum[0].ToString();
                        case "honap":
                            return szuletesiDatum[1].ToString();
                        case "nap":
                            return szuletesiDatum[2].ToString();
                        default:
                            throw new ArgumentException("Nem létező paraméter: " + parameter);
                    }
                }
            }

            public override string ToString()
            {
                return $"Név: {Nev}, Lakcím: {Lakcim}, Születési dátum: {szuletesiDatum[0]}/{szuletesiDatum[1]}/{szuletesiDatum[2]}";
            }

            public virtual int Kor()
            {
                var szuletesiEv = szuletesiDatum[0];
                var aktualisEv = DateTime.Now.Year;
                return aktualisEv - szuletesiEv;
            }
        }

        class Alkalmazott : Szemely
        {
            private string beosztas;
            private double fizetes;


            public string Beosztas
            {
                get { return beosztas; }
            }

            public double Fizetes
            {
                get { return fizetes; }
                set { fizetes = value; }
            }

            public Alkalmazott(string nev) : base(nev)
            {
            }

            public Alkalmazott(string nev, string beosztas, double fizetes) : base(nev)
            {
                this.beosztas = beosztas;
                this.fizetes = fizetes;
            }

            public void FizetesEmel(double osszeg)
            {
                fizetes += osszeg;
            }

            public override string ToString()
            {
                return $"{base.ToString()}, Beosztás: {beosztas}, Fizetés: {fizetes} Ft";
            }

            public new int Kor()
            {
                if (fizetes > 300000)
                {
                    return base.Kor() - 10;
                }
                return base.Kor();
            }
            public string Nev
            {
                get { return $"{base.Nev} ({beosztas})"; }
            }
        }

        class Vallalat
        {
            public Dictionary<string, List<Alkalmazott>> Osztalyok { get; } = new Dictionary<string, List<Alkalmazott>>();

            public void HozzaadAlkalmazott(string osztalyKod, Alkalmazott alkalmazott)
            {
                if (!Osztalyok.ContainsKey(osztalyKod))
                {
                    Osztalyok[osztalyKod] = new List<Alkalmazott>();
                }
                Osztalyok[osztalyKod].Add(alkalmazott);
            }
        }
        static void Main(string[] args)
        {
            Vallalat vallalat = new Vallalat();

            Console.WriteLine("Személy adatok:");

            Console.Write("Név: ");
            string nev = Console.ReadLine();

            Console.Write("Lakcím: ");
            string lakcim = Console.ReadLine();

            Console.Write("Születési év: ");
            int ev = int.Parse(Console.ReadLine());

            Console.Write("Születési hónap: ");
            int honap = int.Parse(Console.ReadLine());

            Console.Write("Születési nap: ");
            int nap = int.Parse(Console.ReadLine());

            Console.Write("Beosztás: ");
            string beosztas = Console.ReadLine();

            Console.Write("Fizetés: ");
            double fizetes = double.Parse(Console.ReadLine());

            int[] szuletesiDatum = { ev, honap, nap };

            Console.Write("Osztály kódja: ");
            string osztalyKod = Console.ReadLine();

            Szemely szemely = new Szemely(nev, lakcim, szuletesiDatum);
            Console.WriteLine(szemely);
            Console.WriteLine(szemely.Kor());

            Alkalmazott alkalmazott1 = new Alkalmazott(nev, beosztas, fizetes);
            alkalmazott1.szuletesiDatum = szuletesiDatum;

            Console.WriteLine("\nSzemély 1 adatai:");
            Console.WriteLine(szemely.ToString());
            Console.WriteLine($"Kor: {szemely.Kor()} év");

            Console.WriteLine("\nAlkalmazott 1 adatai:");
            Console.WriteLine(alkalmazott1.ToString());
            Console.WriteLine($"Kor: {alkalmazott1.Kor()} év");
            Console.WriteLine($"Név: {alkalmazott1.Nev}");

            Console.Read();
        }
    }
}
