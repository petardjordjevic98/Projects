using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skola.Entiteti;
using FluentNHibernate.Mapping;

namespace Skola.Mapiranja
{
    public class SmerMapiranje : ClassMap<Smer>//izvedena iz ClassMap, spada u Generic class, Template klasa, predstavlja sablon 
        //gde se umetne odgovarajuci tip, 
    {
        public SmerMapiranje()
        {
            //Mapiranje tabele
            Table("SMER");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity("S16697.SMER_ID_SEQ");
            //propery Id se mapira na specijalan nacin jer je primarni kljuc, mapiramo Id na kolonu ID u tabeli, moramo da kazemo kako ce 
            //primarni kljuc da bude generisan, trigerrIdentity znaci da je za generisanje odgovoran trigger, a u ovo slucaju znaci da je Sequenca koja se ozve
            //ovako, moze da bude i Assigned gde mi sami postavljamo kao kod ZaposleniMapiranje.cs
            //mapiranje svojstava.
            Map(x => x.Naziv, "NAZIV");//mapiramo property naziv u Naziv....
            Map(x => x.MaxBroj, "MAX_BROJ");

            //mapiranje veze 1:N Ucenik-Smer
            HasMany(x => x.Ucenici).KeyColumn("ID_SMERA").LazyLoad().Cascade.All().Inverse();
            //Inverse() znaci da ce suprotna strana voditi racuna o stranom kljucu znaci ucenik ce da doda pripadaSmeru= ..., samo na jednu stranu
            //ovo Cascade() znaci da se kada se pozove save nad smerom da se i ucenici autoamtski save-uju, bez njihovog posebnog pamcenja
            //mapiranje veze M:N Smer-Premdet
            HasMany(x => x.Predmeti).KeyColumn("ID_SMERA").LazyLoad().Cascade.All();
        }
    }
}
//unit of work, odlaze maksimalno komunikaciju sa bazom ,zato se korisi flush