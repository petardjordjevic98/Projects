using SkolaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkolaLibrary.DTOs
{
    public class AdresaStanovanjaView
    {
        public int Id { get; set; }
        public ZaposleniView Zaposleni { get; set; }
        public virtual String Adresa { get; set; }

        public AdresaStanovanjaView()
        {

        }

        public AdresaStanovanjaView(AdresaStanovanja a)
        {
            Id = a.Id;
            Adresa = a.Adresa;
            Zaposleni = new ZaposleniView(a.Zaposleni);
        }
    }
}
