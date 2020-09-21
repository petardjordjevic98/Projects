using SkolaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkolaLibrary.DTOs
{
    public class AngazovanView
    {
        public int Id { get; set; }
        public NastavnoOsobljeView Nastavnik { get; set; }
        public PredmetView Predmet { get; set; }
        public DateTime DatumAngazovanja { get; set; }

        public AngazovanView()
        {

        }

        public AngazovanView(Angazovan a)
        {
            Id = a.Id;
            DatumAngazovanja = a.DatumAngazovanja;
            Nastavnik = new NastavnoOsobljeView(a.Nastavnik);
            Predmet = new PredmetView(a.Predmet);
        }
    }
}
