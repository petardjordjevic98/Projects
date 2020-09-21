﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace SkolaLibrary.Mapiranja
{
    public class UcenikMapiranje : ClassMap<Ucenik>
    {
        public UcenikMapiranje()
        {
            //Mapiranje tabele
            Table("UCENIK");

            //mapiranje primarnog kljuca
            Id(x => x.UpisniBroj, "UPISNI_BROJ").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava.
            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Adresa, "ADRESA");
            Map(x => x.Razred, "RAZRED");
            Map(x => x.DatumUpisa, "DATUM_UPISA");

            //mapiranje veze 1:N Ucenik-Ocena
            HasMany(x => x.Ocene).KeyColumn("UPISNI_BROJ").LazyLoad().Cascade.All().Inverse();

            //mapiranje veze 1:N Ucenik-Smer
            References(x => x.PripadaSmeru).Column("ID_SMERA").LazyLoad();

            //mapiranje veze 1:N Ucenik-Roditelj
            HasMany(x => x.Roditelji).KeyColumn("UPISNI_BROJ").LazyLoad().Cascade.All().Inverse();
        }
    }
}