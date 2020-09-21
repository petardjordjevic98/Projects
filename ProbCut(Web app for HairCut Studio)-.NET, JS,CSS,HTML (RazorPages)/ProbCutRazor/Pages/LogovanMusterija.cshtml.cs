using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProbCut.Models;

namespace ProbCut.Pages
{
    public class TerminiFrizera
    {
        public string username { get; set; }
        public char? pol { get; set; }
        public IList<TerminiIdani> TerminiZaDveNedelje { get; set; }
        public IList<Termin> DanasnjiTermini { get; set; }
        public float prosecnaOcena { get; set; }
        public char polKojiSisa { get; set; }
    }
    public class LogovanMusterijaModel : PageModel
    {
        public SalonContext db { get; set; }
        [BindProperty]
        public Musterija musterija { get; set; }
        [BindProperty]
        public IList<Frizer> frizeri { get; set; }
        [BindProperty]
        public DateTime zakazanovreme { get; set; }
        public string lang { get; set; }

        public LogovanMusterijaModel(SalonContext s)
        {
            db = s;
        }
        public async Task<JsonResult> OnGetLangDataAsync(string resourceName, bool lang = false)
        {
            if (lang)
                return new JsonResult(Request.Cookies["lang"]);
            return new JsonResult(LanguageController.Get(Request.Cookies["lang"], "LogovanMusterija", resourceName));
        }
        public List<TerminiIdani> VratiTerminiUDveNedelje(Frizer f)
        {
            Frizer frizer1 = db.Frizeri.Include(x => x.termini).Where(x => x.id == f.id).FirstOrDefault();

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
            return r;
        }
        public async Task<JsonResult> OnGetFrizeriAsync()
        {
            IQueryable<Frizer> frizeriUSalonu = db.Frizeri.Include(x => x.termini);
            IList<TerminiFrizera> Lista = new List<TerminiFrizera>();
            foreach(Frizer f in frizeriUSalonu)
            {
                TerminiFrizera t = new TerminiFrizera();
                t.username = f.username;
                t.TerminiZaDveNedelje= VratiTerminiUDveNedelje(f);
                t.DanasnjiTermini = VratiOdDanas(f);
                t.pol = f.pol;
                t.prosecnaOcena = f.prosecnaOcena;
                t.polKojiSisa = f.polKojiSisa;
                Lista.Add(t);

            }
            return new JsonResult(Lista);
        }
        public void Check(Frizer frizer)
        {

            string username = Request.Cookies["username"];
            frizer = db.Frizeri.Include(x => x.termini).Where(x => x.username == username).FirstOrDefault();
            IQueryable<Termin> Termini1 = db.Termini.Where(x => x.frizer == frizer);
            IList<Termin> Termini = Termini1.ToList();
            foreach (Termin t in Termini)
            {

                if (t.vreme.AddMinutes(t.trajanjeUMinutima) <= DateTime.Now)
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
        public List<Termin> VratiOdDanas(Frizer frizer)
        {
            Check(frizer);
            
            IQueryable<Termin> DanasnjiTermini = db.Termini.Where(x => x.frizer == frizer && x.vreme.DayOfYear == DateTime.Now.DayOfYear).Distinct();
            List<Termin> t = DanasnjiTermini.ToList();
            return t;
        }
        public async Task<IActionResult> OnGetAsync()
         {
            lang = Request.Cookies["lang"];

            string username = Request.Cookies["username"];
            musterija = db.Musterije.Where(x => x.username == username).FirstOrDefault();
            if (musterija != null)
            { 
                    frizeri = db.Frizeri.Include(x => x.termini).ToList();
                return null;
            }
            else
            {
                Vlasnik v = db.Vlasnici.Where(x => x.username == username).FirstOrDefault();
                if (v != null)
                    return RedirectToPage("./LogovanVlasnik");
                else
                {
                    Frizer f = db.Frizeri.Where(x => x.username == username).FirstOrDefault();
                    if (f != null)
                        return RedirectToPage("./LogovanFrizer");
                }

                return RedirectToPage("./Login");
            }
        }
        public async Task<JsonResult> OnGetZakaziAsync(string username, string vreme, int trajanje, string vrsta)
        {
            Frizer f = db.Frizeri.Where(x => x.username == username).FirstOrDefault();

            Termin noviTermin = new Termin() { frizer = f, trajanjeUMinutima = trajanje, vreme = Convert.ToDateTime(vreme), vrstaUsluge = vrsta };
            Termin postojeci = db.Termini.Where(x => x.frizer.username == username && x.vreme.Equals(vreme)).FirstOrDefault();
            if (postojeci == null)
            {
                db.Termini.Add(noviTermin);
                f.termini.Add(noviTermin);
                string user = Request.Cookies["username"];
                Musterija m = db.Musterije.Where(x => x.username == user).FirstOrDefault();
                m.termin = noviTermin;
                await db.SaveChangesAsync();
            }

            return new JsonResult(true);
        }
    }
}