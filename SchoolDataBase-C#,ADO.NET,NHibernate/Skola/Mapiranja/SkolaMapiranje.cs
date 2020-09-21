using FluentNHibernate.Mapping;//mora da se doda podrska iz FluentNhibernate-a
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skola.Entiteti;

namespace Skola.Mapiranja
{
    public class SkolaMapiranje : ClassMap<Skola.Entiteti.Skola>/
    {
        public SkolaMapiranje()
        { //prvo se definise ime tabele, postoje implicitna mapiranja, ukoliko se zovu isto tabela i class-a
            Table("SKOLE");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity("S16697.SKOLE_ID_SEQ");

            //mapiranje svojstava.
            Map(x => x.skola, "SKOLE");

            References(x => x.Nastavnik).Column("JMBG_ZAPOSLENOG").LazyLoad();
        }
    }
}
