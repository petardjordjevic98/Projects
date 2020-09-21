using System;
using System.Collections.Generic;
using System.Text;
using SkolaLibrary.Entiteti;

namespace SkolaLibrary.DTOs
{
    public class SkolaView
    {
        public int Id { get; set; }
        public NastavnoOsobljeView Nastavnik { get; set; }
        public String skola { get; set; }

        public SkolaView()
        {

        }

        public SkolaView(Entiteti.Skola s)
        {
            Id = s.Id;
            skola = s.skola;
            Nastavnik = new NastavnoOsobljeView(s.Nastavnik);
        }
    }
}
