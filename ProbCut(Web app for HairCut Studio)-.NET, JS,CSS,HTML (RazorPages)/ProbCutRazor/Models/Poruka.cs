using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProbCut.Models
{
    public class Poruka
    {
        
        public int id { get; set; }
        [Required]
        public string sadrzaj { get; set; }
        [Required]
        public DateTime vreme { get; set; }

        
        [Required]
        public int idPrimaoca { get; set; }
        [Required]
        public int idPosiljaoca { get; set; }
        //[JsonIgnore]
        //public Musterija Posiljalac { get; set; }
        //[Required]
        //[JsonIgnore]
        //public Frizer Primalac { get; set; }
    }
}
