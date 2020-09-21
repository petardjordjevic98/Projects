using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Entiteti
{
    public class Ucenik
    {
        public virtual int UpisniBroj { get; protected set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Adresa { get; set; }
        public virtual int Razred { get; set; }
        public virtual DateTime DatumUpisa { get; set; }
        public virtual IList<Ocena> Ocene { get; set; }
        public virtual IList<Roditelj> Roditelji { get; set; }

        public virtual Smer PripadaSmeru { get; set; }

        public Ucenik()
        {
            Ocene = new List<Ocena>();
            Roditelji = new List<Roditelj>();
        }
    }
}
