using SkolaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkolaLibrary.DTOs
{
    public class RoditeljView
    {
        public int Id { get;  set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int BrojTelefona { get; set; }
        public UcenikView PripadaUceniku { get; set; }

        public RoditeljView()
        {

        }

        public RoditeljView(Roditelj r)
        {
            Id = r.Id;
            Ime = r.Ime;
            Prezime = r.Prezime;
            BrojTelefona = r.BrojTelefona;
            PripadaUceniku = new UcenikView(r.PripadaUceniku);
        }
    }
}
