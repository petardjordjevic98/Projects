using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaLibrary.Entiteti
{
    public class Ocena
    {
        public virtual int Id { get; protected set; }
        public virtual int NumVrednost { get; set; }
        public virtual string TekstualniOpis { get; set; }
        public virtual DateTime DatumOcenjivanja { get; set; }
        public virtual Ucenik PripadaUceniku { get; set; }
        public virtual Predmet PripadaPredmetu { get; set; }
    }
}
