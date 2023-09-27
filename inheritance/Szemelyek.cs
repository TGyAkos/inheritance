using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace inheritance
{
    public class Szemelyek
    {
        public string Nev { get; }
        public string Lakcim { get; set; }
        public int[] SzuletesiDatum;

        public int this[string index]
        {
            get
            {
                switch (index)
                {
                    case "ev":
                        return SzuletesiDatum[0];
                    case "honap":
                        return SzuletesiDatum[1];
                    case "nap":
                        return SzuletesiDatum[2];
                    default:
                        return 1;
                }
            }
        }

        // TODO actually implement it according to specs
        public Szemelyek(string nev, int[] szuletesiDatum, string lakcim = "Nincs megadva")
        {
            Nev = nev;
            SzuletesiDatum = szuletesiDatum;
            Lakcim = lakcim;
        }

        public override string ToString()
        {
            return string.Format("Nev: {0}, Lakcim: {1}, Szuletesi datum: {2}.{3}.{4}", Nev, Lakcim, SzuletesiDatum[0], SzuletesiDatum[1], SzuletesiDatum[2]);
        }

        public virtual void Kor()
        {
           
        }
    }
}