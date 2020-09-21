using System;
using System.ComponentModel.DataAnnotations;

namespace ProbCut.Models
{
    public class Komentar
    {
        public int id { get; set; }
        [Required]
        public Musterija autor { get; set; }
        [Required]
        public Frizer frizer { get; set; }
        [Required]
        public string sadrzaj { get; set; }
        [Required]
        public DateTime vreme { get; set; }
    }
}
