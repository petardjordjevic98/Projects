using FluentNHibernate.Mapping;
using Skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Mapiranja
{
    public class GodinaMapiranje : ClassMap<Godina>
    {
        public GodinaMapiranje()
        {
            Table("GODINA");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity("S16697.GODINA_ID_SEQ");

            //mapiranje svojstava.
            Map(x => x.godina, "GODINA");

            References(x => x.Predmet).Column("ID_PREDMETA").LazyLoad();

        }
    }
}
