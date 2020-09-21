using SkolaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkolaLibrary.DTOs
{
    public class ZaposleniView
    {
        public long JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string ImeRoditelja { get; set; }
        public DateTime DatumRodjenja { get; set; }
     //   public string TipZaposlenja { get; set; }
        public IList<AdresaStanovanjaView> Adrese { get; set; }

        public ZaposleniView()
        {
            Adrese = new List<AdresaStanovanjaView>();
        }

        public ZaposleniView(Zaposleni z)
        {
            JMBG = z.JMBG;
            Ime = z.Ime;
            Prezime = z.Prezime;
            ImeRoditelja = z.ImeRoditelja;
            DatumRodjenja = z.DatumRodjenja;
         //   TipZaposlenja = z.TipZaposlenja;
        }
    }
}
