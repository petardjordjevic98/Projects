using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaLibrary.Entiteti
{
    public class Smer
    {
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual int MaxBroj { get; set; }
        public virtual IList<Ucenik> Ucenici { get; set; }
        public virtual IList<Pripada> Predmeti { get; set; }

        public Smer()
        {
            Predmeti = new List<Pripada>();
            Ucenici = new List<Ucenik>();
        }

    }
}
