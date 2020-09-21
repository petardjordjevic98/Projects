using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skola.Entiteti;
using FluentNHibernate.Mapping;

namespace Skola.Mapiranja
{
    class PredmetMapiranje : ClassMap<Predmet>
    {
        public PredmetMapiranje()
        {
            //Mapiranje tabele
            Table("PREDMET");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava.
            Map(x => x.Naziv, "NAZIV");

            //mapiranje veze 1:N Predmet-Ocena
            HasMany(x => x.Ocene).KeyColumn("ID_PREDMETA").LazyLoad().Cascade.All().Inverse();
            //mapiranje veze M:N Smer-Premdet
            HasMany(x => x.Smerovi).KeyColumn("ID_PREDMETA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Nastavnici).KeyColumn("ID_PREDMETA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Godine).KeyColumn("ID_PREDMETA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
