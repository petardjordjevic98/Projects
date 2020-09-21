using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace SkolaLibrary.Mapiranja
{
    public class OcenaMapiranje : ClassMap<Ocena>
    {
        public OcenaMapiranje()
        {
            //Mapiranje tabele
            Table("OCENA");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava.
            Map(x => x.NumVrednost, "NUM_VREDNOST");
            Map(x => x.TekstualniOpis, "TEKSTUALNI_OPIS");
            Map(x => x.DatumOcenjivanja, "DATUM_OCENJIVANJA");

           //mapiranje veze 1:N Ocena-Ucenik
            References(x => x.PripadaUceniku).Column("UPISNI_BROJ").LazyLoad();

            //mapiranje veze 1:N Ocena-Predmet
            References(x => x.PripadaPredmetu).Column("ID_PREDMETA").LazyLoad();
        }
    }
}
