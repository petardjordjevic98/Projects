using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProbCut.Models;

namespace ProbCut.Pages
{
    public class DodajFrizeraModel : PageModel
    {
        public SalonContext db { get; set; }
        [BindProperty]
        public Frizer frizer { get; set; }
        [BindProperty]
        public Vlasnik vlasnik { get; set; }
        [BindProperty]
        public string genderToWorkWithFormatted { get; set; }
        [BindProperty]
        public string genderFormatted { get; set; }
        public string lang { get; set; }

        public DodajFrizeraModel(SalonContext s)
        {
            db = s;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            lang = Request.Cookies["lang"];
            string username = Request.Cookies["username"];
            vlasnik = db.Vlasnici.Where(x => x.username == username).FirstOrDefault();
            if (vlasnik == null)
                return RedirectToPage("./Index");
            return null;
        }

        public async Task<JsonResult> OnGetLangDataAsync(string resourceName)
        {
            return new JsonResult(LanguageController.Get(Request.Cookies["lang"], "Register", resourceName));
        }

        public async Task<JsonResult> OnGetAddBarberAsync(string[] data)
        {
            lang = Request.Cookies["lang"];

            string[] dataArray = data[0].Split(',');

            Frizer noviFrizer = new Frizer();
            noviFrizer.ime = dataArray[0];
            noviFrizer.prezime = dataArray[1];
            noviFrizer.username = dataArray[2];
            noviFrizer.password = dataArray[3];
            noviFrizer.datumRodjenja = Convert.ToDateTime(dataArray[6]);
            noviFrizer.brojTelefona = dataArray[7];

            noviFrizer.id = findNextID();
            noviFrizer.brojOcena = 0;
            noviFrizer.prosecnaOcena = 1;
            noviFrizer.brojRealizovanihTermina = 0;

            if (dataArray[4] == LanguageController.Get(lang, "Register", "GenderMale"))
                noviFrizer.pol = 'M';
            else if (dataArray[4] == LanguageController.Get(lang, "Register", "GenderFemale"))
                noviFrizer.pol = 'Z';

            if (dataArray[5] == LanguageController.Get(lang, "Register", "GenderMale"))
                noviFrizer.polKojiSisa = 'M';
            else if (dataArray[5] == LanguageController.Get(lang, "Register", "GenderFemale"))
                noviFrizer.polKojiSisa = 'Z';
            else
                noviFrizer.polKojiSisa = 'O';

            db.Frizeri.Add(noviFrizer);
            await db.SaveChangesAsync();
            return null;
        }

        private int findNextID()
        {
            int maxVlasnici = db.Vlasnici.Max(x => x.id);
            int maxFrizeri = db.Frizeri.Max(x => x.id);
            int maxMusterije = db.Musterije.Max(x => x.id);

            return Math.Max(Math.Max(maxVlasnici, maxFrizeri), maxMusterije) + 1;
        }
    }
}