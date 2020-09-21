using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProbCut.Models;

namespace ProbCut.Pages
{
    public class LogovanVlasnikModel : PageModel
    {
        public SalonContext db { get; set; }

        public Vlasnik vlasnik { get; set; }

        public IList<Frizer> frizeri { get; set; }
        public string lang { get; set; }

        public LogovanVlasnikModel(SalonContext s)
        {
            db = s;
        }
        public async Task OnGetAsync()
        {
            // reading cookies
            lang = Request.Cookies["lang"];
            string username = Request.Cookies["username"];
            Vlasnik v = db.Vlasnici.Where(x => x.username == username).FirstOrDefault();
            if (v != null)
            {
                vlasnik = v;
                frizeri = db.Frizeri.Include(x => x.termini).ToList();
                return;
            }
            else
            {
                RedirectToPage("./Index");
                return;
            }
        }

        public async Task<IActionResult> OnPostDodajFrizera()
        {
            return RedirectToPage("./DodajFrizera");
        }

        public async Task<JsonResult> OnGetLangDataAsync(string resourceName)
        {
            return new JsonResult(LanguageController.Get(Request.Cookies["lang"], "LogovanVlasnik", resourceName));
        }

        public async Task<JsonResult> OnGetDeleteBarberAsync(int id)
        {
            Frizer frizer = db.Frizeri.Where(f => f.id == id).Include(t => t.termini).FirstOrDefault();
            if (frizer == null)
                return null;

            // brisanje svih termina frizera
            foreach (Termin t in frizer.termini)
            {
                Musterija musterija = db.Musterije.Include(x => x.termin).Where(x => x.termin.id == t.id).SingleOrDefault();
                musterija.termin = null;
            }

            // brisanje frizera
            db.Frizeri.Remove(frizer);
            await db.SaveChangesAsync();

            return null;
        }
    }
}