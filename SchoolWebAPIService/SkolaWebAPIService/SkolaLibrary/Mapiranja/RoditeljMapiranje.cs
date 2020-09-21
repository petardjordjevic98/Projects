using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace SkolaLibrary.Mapiranja
{
    class RoditeljMapiranje : ClassMap<Roditelj>
    {
        public RoditeljMapiranje()
        {
            //Mapiranje tabele
            Table("RODITELJ");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity("S16697.RODITELJI_ID_SEQ");

            //mapiranje svojstava.
            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.BrojTelefona, "BROJ_TELEFONA");

            //mapiranje veze 1:N Ucenik-Roditelj
            References(x => x.PripadaUceniku).Column("UPISNI_BROJ").LazyLoad();
        }
    }
}
