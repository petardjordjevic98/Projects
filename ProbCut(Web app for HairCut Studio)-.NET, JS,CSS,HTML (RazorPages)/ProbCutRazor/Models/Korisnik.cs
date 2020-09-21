using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProbCut.Models
{
    public  class Korisnik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string ime { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string prezime { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public DateTime datumRodjenja { get; set; }
        public char? pol { get; set; }
        public string brojTelefona { get; set; }
        [NotMapped]
        public string datumRodjenjaFormatiranISO { get { return datumRodjenja.ToString("yyyy-MM-dd"); } }
        [NotMapped]
        public string datumRodjenjaFormatiranShortDate { get { return datumRodjenja.ToShortDateString(); } }
        [NotMapped]
        public virtual string tipKorisnika { get; }
        
      

        public string polFormatiran(string lang)
        {
            switch (pol)
            {
                case 'M':
                    return LanguageController.Get(lang, "MyProfile", "GenderMale");

                case 'Z':
                    return LanguageController.Get(lang, "MyProfile", "GenderFemale");

                default:
                    return LanguageController.Get(lang, "MyProfile", "GenderNone");
            }
        }
    }
}
