using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Skola.Entiteti;

namespace Skola.Mapiranja
{
    class PripadaMapiranje: ClassMap<Pripada>
    {
        public PripadaMapiranje()
        {
            Table("PRIPADA");

            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity("S16697.PRIPADA_ID_SEQ");

            References(x => x.ImaPredmet).Column("ID_SMERA");

            References(x => x.PripadaSmeru).Column("ID_PREDMETA");
        }
            
        }
}
