using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance
{
    public class Alkalmazott : Szemelyek
    {
        private string Beosztas { get; set; }
        public int Fizetes { get; set; }

        public string[] Nev
        {
            get
            {
                return new []{ $"{base.Nev}", $"{Beosztas}"};
            }
        }
        public Alkalmazott(string nev, string beosztas, int fizetes) : base(nev, new []{0,0,0})
        {
            Beosztas = beosztas;
            Fizetes = fizetes;
        }

        // TODO fix szuletesiDatum should not be needed
        public Alkalmazott(string nev): base(nev, new []{0,0,0}) 
        {

        }
        
        public void FizetesEmeles(int fizetes) => Fizetes = fizetes;

        public override void Kor()
        {
            if (Fizetes > 300000)
            {
                SzuletesiDatum[0] += 10;
            }
        }
    }
}
