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
            private string osztalyKod;

            public string OsztalyKod
            {
                get { return osztalyKod; }
                set { osztalyKod = value; }
            }

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
            public Alkalmazott(string nev, string beosztas, double fizetes, string osztalyKod) : base(nev)
            {
                this.beosztas = beosztas;
                this.fizetes = fizetes;
                this.osztalyKod = osztalyKod;
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

        class Vállalat
        {
            public string OsztályKód { get; set; }
            public string OsztályNeve { get; set; }
            public List<Alkalmazott> Alkalmazottak = new List<Alkalmazott>();

            public Dictionary<string, List<Alkalmazott>> Csoportbontás;

            public Vállalat(string osztályKód, string osztályNeve)
            {
                OsztályKód = osztályKód;
                OsztályNeve = osztályNeve;
            }
            public void Belep(Alkalmazott alkalmazott)
            {
                string osztalyKod = alkalmazott.OsztalyKod;
                if (!Csoportbontás.ContainsKey(osztalyKod))
                {
                    Csoportbontás[osztalyKod] = new List<Alkalmazott>();
                }
                Csoportbontás[osztalyKod].Add(alkalmazott);
                Alkalmazottak.Add(alkalmazott);
            }

            public void Kilep(Alkalmazott alkalmazott)
            {
                string osztalyKod = alkalmazott.OsztalyKod;
                if (Csoportbontás.ContainsKey(osztalyKod))
                {
                    Csoportbontás[osztalyKod].Remove(alkalmazott);
                }
                Alkalmazottak.Remove(alkalmazott);
            }
            public void Modosit(Alkalmazott alkalmazott, int osszeg)
            {
                alkalmazott.Fizetes = osszeg;
            }

            public void ListazAlkalmazottak(string osztalyKod)
            {   
                if (Csoportbontás.ContainsKey(osztalyKod))
                {
                    Console.WriteLine($"Alkalmazottak az osztályban ({osztalyKod}):");
                    if (Csoportbontás[osztalyKod].Count() == 0)
                    {
                        Console.WriteLine($"Nincsenek alkalmazottak az osztályban.");
                    }
                    else
                    {
                        foreach (var alkalmazott in Csoportbontás[osztalyKod])
                        {
                            Console.WriteLine(alkalmazott.ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Nincsenek alkalmazottak az osztályban ({osztalyKod}).");
                }
            }

            public override string ToString()
            {
                return $"Osztálykód: {OsztályKód}, Osztálynév: {OsztályNeve}";
            }
        }
        static void Main(string[] args)
        {
            // Személy példányok létrehozása és tesztelése
            Szemely szemely1 = new Szemely("John Doe");
            szemely1.Lakcim = "Budapest, Kossuth utca 5.";
            int[] szuletesiDatum1 = { 1990, 5, 15 };
            szemely1.szuletesiDatum = szuletesiDatum1;

            Szemely szemely2 = new Szemely("Jane Smith", "New York, 123 Main St");
            int[] szuletesiDatum2 = { 1985, 8, 25 };
            szemely2.szuletesiDatum = szuletesiDatum2;

            Console.WriteLine("Személy 1 adatai:");
            Console.WriteLine(szemely1.ToString());
            Console.WriteLine($"Kor: {szemely1.Kor()} év");
            Console.WriteLine($"Születési év: {szemely1["ev"]}");

            Console.WriteLine("\nSzemély 2 adatai:");
            Console.WriteLine(szemely2.ToString());
            Console.WriteLine($"Kor: {szemely2.Kor()} év");
            Console.WriteLine($"Születési év: {szemely2["ev"]}");

            // Alkalmazott példányok létrehozása és tesztelése
            Alkalmazott alkalmazott1 = new Alkalmazott("John Doe", "Programozó", 40000, "A123");
            alkalmazott1.Lakcim = "Budapest, Kossuth utca 5.";
            int[] alkalmazottSzuletesiDatum1 = { 1990, 5, 15 };
            alkalmazott1.szuletesiDatum = alkalmazottSzuletesiDatum1;

            Alkalmazott alkalmazott2 = new Alkalmazott("Jane Smith", "Tesztelő", 35000, "B456");
            alkalmazott2.Lakcim = "New York, 123 Main St";
            int[] alkalmazottSzuletesiDatum2 = { 1985, 8, 25 };
            alkalmazott2.szuletesiDatum = alkalmazottSzuletesiDatum2;

            Console.WriteLine("\nAlkalmazott 1 adatai:");
            Console.WriteLine(alkalmazott1.ToString());
            Console.WriteLine($"Kor: {alkalmazott1.Kor()} év");
            Console.WriteLine($"Név és beosztás: {alkalmazott1.Nev}");

            Console.WriteLine("\nAlkalmazott 2 adatai:");
            Console.WriteLine(alkalmazott2.ToString());
            Console.WriteLine($"Kor: {alkalmazott2.Kor()} év");
            Console.WriteLine($"Név és beosztás: {alkalmazott2.Nev}");

            // Vállalat példány létrehozása és alkalmazottak hozzáadása
            Vállalat vallalat = new Vállalat("V123", "IT Részleg");
            vallalat.Csoportbontás = new Dictionary<string, List<Alkalmazott>>();

            vallalat.Belep(alkalmazott1);
            vallalat.Belep(alkalmazott2);

            Console.WriteLine("\nVállalat adatai:");
            Console.WriteLine(vallalat.ToString());

            Console.WriteLine("\nAlkalmazottak listázása:");
            vallalat.ListazAlkalmazottak("A123");
            vallalat.ListazAlkalmazottak("B456");

            vallalat.Kilep(alkalmazott1);

            Console.WriteLine("\nVállalat adatai:");
            Console.WriteLine(vallalat.ToString());

            Console.WriteLine("\nAlkalmazottak listázása:");
            vallalat.ListazAlkalmazottak("A123");
            vallalat.ListazAlkalmazottak("B456");

            vallalat.Modosit(alkalmazott2, 100000);
            Console.WriteLine("\nVállalat adatai:");
            Console.WriteLine(vallalat.ToString());

            Console.WriteLine("\nAlkalmazottak listázása:");
            vallalat.ListazAlkalmazottak("A123");
            vallalat.ListazAlkalmazottak("B456");

            Console.ReadLine();
        }
    }
}
