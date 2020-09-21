using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skola.Entiteti;
using FluentNHibernate.Mapping;

namespace Skola.Mapiranja
{
    public class ZaposleniMapiranje : ClassMap<Zaposleni>
    { 
        public ZaposleniMapiranje()
        {
            //Mapiranje tabele
            Table("ZAPOSLENI");

            //mapiranje primarnog kljuca
            Id(x => x.JMBG, "JMBG").GeneratedBy.Assigned();

            DiscriminateSubClassesOnColumn("TIP_ZAPOSLENJA");
            //DiscriminateSubClassesOnColumn("FBEZ_NORME");
            //DiscriminateSubClassesOnColumn("FPUNA_NORMA");

            //mapiranje svojstava.
            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.ImeRoditelja, "IME_RODITELJA");
            Map(x => x.DatumRodjenja, "DATUM_RODJENJA");
        }

    }
    public class NastavnoOsobljeMapiranje : SubclassMap<NastavnoOsoblje>

    {
        public NastavnoOsobljeMapiranje()
        {
            DiscriminatorValue("NASTAVNO");
            //DiscriminatorValue("Da");
            //DiscriminatorValue("Ne");

            Map(x => x.BezNorme,"FBEZ_NORME");
           

            // Map(x => x.BezNorme, "FBEZ_NORME");
            Map(x => x.PunaNorma, "FPUNA_NORMA");
            Map(x => x.BrojCasova, "BROJ_CASOVA");
            HasMany(x => x.Predmeti).KeyColumn("JMBG_ZAPOSLENOG").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Skole).KeyColumn("JMBG_ZAPOSLENOG").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Adrese).KeyColumn("JMBG_ZAPOSLENOG").LazyLoad().Cascade.All().Inverse();
        }
    }


    class NenastavnoOsobljeMapiranje : SubclassMap<NenastavnoOsoblje>
    {
        public NenastavnoOsobljeMapiranje()
        {
            DiscriminatorValue("NENASTAVNO");
            Map(x => x.Sektor, "SEKTOR");
            Map(x => x.StrucnaSprema, "STRUCNA_SPREMA");

        }
    }
}
