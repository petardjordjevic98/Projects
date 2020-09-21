using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProbCut.Models;

namespace ProbCut.Pages
{
    public class TerminiIdani
    {
        public string Dan { get; set; }
        public int DanUMesecu { get; set; }
        public IList<Termin> termini { get; set; }
        public DateTime Datum { get; set; }
    }
    public class LogovanFrizerModel : PageModel
    {
        public SalonContext db { get; set; }
        [BindProperty]
        public string lang { get; set; }
        public Frizer frizer { get; set; }
        public LogovanFrizerModel(SalonContext s)
        {
            db = s;
        }
        public async Task<JsonResult> OnGetLangDataAsync(string resourceName, bool lang = false)
        {
            if (lang)
                return new JsonResult(Request.Cookies["lang"]);
            return new JsonResult(LanguageController.Get(Request.Cookies["lang"], "LogovanFrizer", resourceName));
        }

        public async Task<IActionResult> OnGetAsync()
        {
            lang = Request.Cookies["lang"];
            string username = Request.Cookies["username"];
            frizer = db.Frizeri.Include(x => x.termini).Where(x => x.username == username).FirstOrDefault();
            if (frizer == null)
                return RedirectToPage("./Login");

            return null;
        }

        private void Check()
        {
            string username = Request.Cookies["username"];
            frizer = db.Frizeri.Include(x => x.termini).Where(x => x.username == username).FirstOrDefault();
            IQueryable<Termin> Termini1 = db.Termini.Where(x => x.frizer == frizer);
            IList<Termin> Termini = Termini1.ToList();
            foreach(Termin t in Termini)
            {
               
                if (t.vreme.AddMinutes(t.trajanjeUMinutima)<=DateTime.Now)
                {
                    Musterija m = db.Musterije.Where(x => x.termin == t).FirstOrDefault();

                    var t1 = t;
                    m.termin = null;
                    frizer.termini.Remove(t1);
                    db.Termini.Remove(t1);
                    db.SaveChanges();
                }
            }
        }
        public async Task<JsonResult> OnGetDanasAsync()
        {
            Check();
            string username = Request.Cookies["username"];
            frizer = db.Frizeri.Include(x => x.termini).Where(x => x.username == username).FirstOrDefault();
            int id = frizer.id;
            Frizer frizer1 = db.Frizeri.Include(x => x.termini).Where(x => x.id == id).FirstOrDefault();
            IQueryable<Termin> DanasnjiTermini = db.Termini.Where(x => x.frizer == frizer1 && x.vreme.DayOfYear==DateTime.Now.DayOfYear).Distinct();
            
            return new JsonResult(DanasnjiTermini);
        }
        public async Task<JsonResult> OnGetTerminiAsync()
        {
            string username = Request.Cookies["username"];
            frizer = db.Frizeri.Include(x => x.termini).Where(x => x.username == username).FirstOrDefault();
            int id = frizer.id;
            Frizer frizer1 = db.Frizeri.Include(x => x.termini).Where(x => x.id == id).FirstOrDefault();

            DateTime p = DateTime.Now.AddDays(14.0);
            IQueryable<Termin> Termini1 = db.Termini.Where(x => x.frizer == frizer1 && x.vreme <= DateTime.Now.AddDays(14.0) && x.vreme >= DateTime.Now).Distinct();


            List<TerminiIdani> r = new List<TerminiIdani>();
            DateTime t = DateTime.Now;
            DateTime time = t.AddDays(14.0);
            List<DateTime> Dani = new List<DateTime>();
            while (t < time)
            {
                t = t.AddDays(1.0);
                Dani.Add(t);
            }
            if (Termini1.Count() == 0)
            {
                foreach (DateTime timew in Dani)
                {
                    r.Add(new TerminiIdani { Dan = timew.DayOfWeek.ToString(), DanUMesecu = timew.Day, termini = null, Datum = timew }); ;
                }
            }
            else
            {
                foreach (DateTime d in Dani)
                {
                    TerminiIdani D = new TerminiIdani { Dan = d.DayOfWeek.ToString(), DanUMesecu = d.Day, termini = null, Datum = d };
                    D.termini = new List<Termin>();
                    foreach (Termin w in Termini1)
                    {
                        if (w.vreme.DayOfYear.Equals(d.DayOfYear))
                        {

                            D.termini.Add(w);

                        }
                    }

                    r.Add(D);
                }
            }
            return new JsonResult(r);
        }      
    }
}