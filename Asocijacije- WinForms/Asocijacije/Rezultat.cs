using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asocijacije
{
    public class Rezultat
    {
        public string Ime { get; set; }
        public int vreme { get; set; }
        public DateTime termin { get; set; }
        public string resenje { get; set; }
        public Rezultat (string Ime,int vreme, DateTime t,string r)
        {
            this.Ime = Ime;
            this.vreme = vreme;
            termin = t;
            resenje = r;
        }
    }
}
