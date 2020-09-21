using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Entiteti
{
    public abstract class Zaposleni
    {
        public virtual long JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string ImeRoditelja { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string TipZaposlenja { get; set; }
        public virtual IList<AdresaStanovanja> Adrese { get; set; }

        public Zaposleni()
        {
            Adrese = new List<AdresaStanovanja>();
        }

    }

    public class NastavnoOsoblje : Zaposleni
    {
        public virtual string PunaNorma { get; set; } //fleg
        public virtual string BezNorme { get; set; }
        public virtual IList<Angazovan> Predmeti { get; set; }
        public virtual IList<Skola> Skole { get; set; }
        public virtual int BrojCasova { get; set; }

        public NastavnoOsoblje ()
        {
            Predmeti = new List<Angazovan>();
            Skole = new List<Skola>();

        }

    }

    public class NenastavnoOsoblje : Zaposleni
    {
        public virtual string Sektor { get; set; }
        public virtual string StrucnaSprema { get; set; }
    }


}
