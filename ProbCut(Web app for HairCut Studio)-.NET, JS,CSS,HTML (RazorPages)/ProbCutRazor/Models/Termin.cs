using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProbCut.Models
{
    public class Termin
    {
        public int id { get; set; }
        [Required]
        [JsonIgnore]
        public Frizer frizer { get; set; }
        [Required]
        public DateTime vreme { get; set; }
        [Required]
        public int trajanjeUMinutima { get; set; }
        [Required]
        public string vrstaUsluge { get; set; }
    }
}
