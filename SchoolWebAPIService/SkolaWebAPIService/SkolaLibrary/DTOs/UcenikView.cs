using SkolaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkolaLibrary.DTOs
{
    public class UcenikView
    {
        public int UpisniBroj { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public int Razred { get; set; }
        public  DateTime DatumUpisa { get; set; }
        public IList<OcenaView> Ocene { get; set; }
        public IList<RoditeljView> Roditelji { get; set; }
        public SmerView PripadaSmeru { get; set; }

        public UcenikView()
        {
            Ocene = new List<OcenaView>();
           Roditelji = new List<RoditeljView>();
        }
            
        public UcenikView(Ucenik u)
        {
            UpisniBroj = u.UpisniBroj;
            Ime = u.Ime;
            Prezime = u.Prezime;
            Adresa = u.Adresa;
            Razred = u.Razred;
            DatumUpisa = u.DatumUpisa;
            PripadaSmeru = new SmerView(u.PripadaSmeru);
        }
    }
}
