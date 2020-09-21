using SkolaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkolaLibrary.DTOs
{
    public class NastavnoOsobljeView : ZaposleniView
    {
        public string PunaNorma { get; set; } //fleg
        public string BezNorme { get; set; }
        public IList<AngazovanView> Predmeti { get; set; }
        public IList<SkolaView> Skole { get; set; }
        public int BrojCasova { get; set; }

        public NastavnoOsobljeView()
        {
            Predmeti = new List<AngazovanView>();
            Skole = new List<SkolaView>();
        }

        public NastavnoOsobljeView(NastavnoOsoblje n)
         : base(n)

        { 
            PunaNorma = n.PunaNorma;
            BezNorme = n.BezNorme;
            BrojCasova = n.BrojCasova;
        }

    }
}
