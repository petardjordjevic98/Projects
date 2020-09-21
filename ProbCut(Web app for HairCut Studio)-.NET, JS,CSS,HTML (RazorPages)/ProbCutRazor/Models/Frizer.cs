using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProbCut.Models
{
    public class Frizer : Korisnik
    {
        [Required]
        public float prosecnaOcena { get; set; }
        [Required]
        public int brojOcena { get; set; }
        [Required]
        public char polKojiSisa { get; set; }        // M (muski), Z (zenski), O (oba)
        [Required]
        public int brojRealizovanihTermina { get; set; }
        public IList<Komentar> komentari { get; set; }
        public IList<Termin> termini { get; set; }
        [NotMapped]
        public override string tipKorisnika { get { return "f";  } }
        public float ProsecnaOcena() { return Convert.ToSingle(Math.Round(prosecnaOcena, 1)); }
    }
}
