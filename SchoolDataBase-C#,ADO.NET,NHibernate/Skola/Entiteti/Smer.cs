using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Entiteti
{
    public class Smer//bitno je da bude public class-a, da bi bila vidljiva van ovog namespace-a Skola.Entiteti, svaku klasu koju dodajemo proglasavamoo
        //za public
    {//svi properitji su virtual, mogu se overrideovati, NHibernate ce da override-uje ove property-je, negde u pozadini, svaki property ima tip
        //koji odgovara tipu koji je u tabeli
        public virtual int Id { get; protected set; }
        public virtual string Naziv { get; set; }
        public virtual int MaxBroj { get; set; }

        public virtual IList<Ucenik> Ucenici { get; set; }

        public virtual IList<Pripada> Predmeti { get; set; }

        public Smer()//dodamo constructor, 
        {
            Predmeti = new List<Pripada>();
            Ucenici = new List<Ucenik>();
        }

    }
}
