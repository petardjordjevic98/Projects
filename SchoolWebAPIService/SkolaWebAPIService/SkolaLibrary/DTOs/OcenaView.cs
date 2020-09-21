using SkolaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkolaLibrary.DTOs
{
    public class OcenaView
    {
        public int Id { get; protected set; }
        public int NumVrednost { get; set; }
        public string TekstualniOpis { get; set; }
        public DateTime DatumOcenjivanja { get; set; }
        public UcenikView PripadaUceniku { get; set; }
        public PredmetView PripadaPredmetu { get; set; }

        public OcenaView()
        {

        }

        public OcenaView(Ocena o)
        {
            Id = o.Id;
            NumVrednost = o.NumVrednost;
            TekstualniOpis = o.TekstualniOpis;
            DatumOcenjivanja = o.DatumOcenjivanja;
            PripadaUceniku = new UcenikView(o.PripadaUceniku);
            PripadaPredmetu = new PredmetView(o.PripadaPredmetu);
            
        }
    }
}
