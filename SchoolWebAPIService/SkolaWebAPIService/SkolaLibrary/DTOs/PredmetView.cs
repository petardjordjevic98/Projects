using SkolaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkolaLibrary.DTOs
{
    public class PredmetView
    {
        public int Id { get;  set; }
        public string Naziv { get; set; }
        public IList<OcenaView> Ocene { get; set; }
        public IList<PripadaView> Smerovi { get; set; }
        public IList<AngazovanView> Nastavnici { get; set; }
        public IList<GodinaView> Godine { get; set; }

        public PredmetView()
        {
            Godine = new List<GodinaView>();
            Nastavnici = new List<AngazovanView>();
            Smerovi = new List<PripadaView>();
            Ocene = new List<OcenaView>();
        }

        public PredmetView(Predmet p)
        {
            Id = p.Id;
            Naziv = p.Naziv;

        }
    }
}
