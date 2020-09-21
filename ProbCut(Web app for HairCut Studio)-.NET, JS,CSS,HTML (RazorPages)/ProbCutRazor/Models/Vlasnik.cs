using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProbCut.Models
{
    public class Vlasnik : Korisnik
    {
        [Required]
        public DateTime poslednjiPutUlogovan { get; set; }
        [NotMapped]
        public override string tipKorisnika { get { return "v"; } }
    }
}
