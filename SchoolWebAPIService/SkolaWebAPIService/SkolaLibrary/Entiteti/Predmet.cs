using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaLibrary.Entiteti
{
    public class Predmet
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }

        public virtual IList<Ocena> Ocene { get; set; }

        public virtual IList<Pripada> Smerovi { get; set; }

        public virtual IList<Angazovan> Nastavnici { get; set; }

        public virtual IList<Godina> Godine { get; set; }

        public Predmet()
        {
            Godine = new List<Godina>();
            Nastavnici = new List<Angazovan>();
            Smerovi = new List<Pripada>();
            Ocene = new List<Ocena>();
        }

    }
}
