using FluentNHibernate.Mapping;
using SkolaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaLibrary.Mapiranja
{
   public class AngazovanMapiranje : ClassMap<Angazovan>
    {
        
            public AngazovanMapiranje()
            {
                //Mapiranje tabele
                Table("ANGAZOVAN");

                //mapiranje primarnog kljuca
                Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity("S16697.ANGAZOVAN_ID_SEQ");

                //mapiranje svojstava.
                Map(x => x.DatumAngazovanja, "DATUM_ANGAZOVANJA");

                //mapiranje veza
                References(x => x.Nastavnik).Column("JMBG_ZAPOSLENOG");
                References(x => x.Predmet).Column("ID_PREDMETA");
            }
        }
}
