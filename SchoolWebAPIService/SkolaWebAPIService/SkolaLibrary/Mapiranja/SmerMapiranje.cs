using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace SkolaLibrary.Mapiranja
{
    public class SmerMapiranje : ClassMap<Smer>
    {
        public SmerMapiranje()
        {
            //Mapiranje tabele
            Table("SMER");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity("S16697.SMER_ID_SEQ");

            //mapiranje svojstava.
            Map(x => x.Naziv, "NAZIV");
            Map(x => x.MaxBroj, "MAX_BROJ");

            //mapiranje veze 1:N Ucenik-Smer
            HasMany(x => x.Ucenici).KeyColumn("ID_SMERA").LazyLoad().Cascade.All().Inverse();

            //mapiranje veze M:N Smer-Premdet
            HasMany(x => x.Predmeti).KeyColumn("ID_SMERA").LazyLoad().Cascade.All();
        }
    }
}
