using FluentNHibernate.Mapping;
using Skola.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Mapiranja
{
    public class AdresaStanovanjaMapiranje : ClassMap<AdresaStanovanja>
    {
        public AdresaStanovanjaMapiranje()
        {
            Table("ADRESA_STANOVANJA");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity("S16697.ADRESA_ID_SEQ");

            //mapiranje svojstava.
            Map(x => x.Adresa, "ADRESA_STANOVANJA");

            References(x => x.Zaposleni).Column("JMBG_ZAPOSLENOG").LazyLoad();

        }
    }
}
