using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaLibrary.Entiteti;

namespace SkolaLibrary.Mapiranja
{
    public class SkolaMapiranje : ClassMap<SkolaLibrary.Entiteti.Skola>
    {
        public SkolaMapiranje()
        { 
            Table("SKOLE");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity("S16697.SKOLE_ID_SEQ");

            //mapiranje svojstava.
            Map(x => x.skola, "SKOLE");

            References(x => x.Nastavnik).Column("JMBG_ZAPOSLENOG").LazyLoad();
        }
    }
}
