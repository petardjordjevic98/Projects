using SkolaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkolaLibrary.DTOs
{
    public class SmerView
    {
        public int Id { get;  set; }
        public string Naziv { get; set; }
        public int MaxBroj { get; set; }
        public virtual IList<UcenikView> Ucenici { get; set; }
        public virtual IList<PripadaView> Predmeti { get; set; }
        
        public SmerView()
        {
            Predmeti = new List<PripadaView>();
            Ucenici = new List<UcenikView>();
        }

        public SmerView(Smer s)
        {
            Id = s.Id;
            Naziv = s.Naziv;
            MaxBroj = s.MaxBroj;
        }
    }
}
