using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProbCut.Models
{
    public class Musterija : Korisnik
    {
        public Termin termin { get; set; }
        public int brojRealizovanihTermina { get; set; }
        [NotMapped]
        public override string tipKorisnika { get { return "m"; } }
     //   public IList<Poruka> Poslate { get; set; }
    }
}
