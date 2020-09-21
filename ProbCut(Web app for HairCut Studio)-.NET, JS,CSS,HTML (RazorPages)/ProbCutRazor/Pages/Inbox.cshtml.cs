using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProbCut.Models;

namespace ProbCut.Pages
{
    public class InboxModel : PageModel
    {
        public SalonContext db { get; set; }
        [BindProperty]
        public Vlasnik trenutniVlasnik { get; set; }
        [BindProperty]
        public Frizer trenutniFrizer { get; set; }
        [BindProperty]
        public Musterija trenutnaMusterija { get; set; }
        public string tipKorisnika { get; set; }
        public string lang { get; set; }


        public InboxModel(SalonContext s)
        {
            db = s;
        }
        private void inicijalizujAtribute(string username = "")
        {
            // reading cookies
            lang = Request.Cookies["lang"];

            // reading from database
            pronadjiKorisnikaUBazi(username);
        }
        private void pronadjiKorisnikaUBazi(string user = "")
        {
            string username;
            if (user == "")
                username = Request.Cookies["username"];
            else
                username = user;

            Vlasnik v = db.Vlasnici.Where(x => x.username == username).FirstOrDefault();
            if (v != null)
            {
                trenutniVlasnik = v;
                trenutniFrizer = null;
                trenutnaMusterija = null;
                tipKorisnika = "vlasnik";
                return;
            }

            Frizer f = db.Frizeri.Include(x => x.komentari).ThenInclude(x => x.autor).Where(x => x.username == username).FirstOrDefault();
            if (f != null)
            {
                trenutniFrizer = f;
                trenutniVlasnik = null;
                trenutnaMusterija = null;
                tipKorisnika = "frizer";
                return;
            }

            Musterija m = db.Musterije.Include(x => x.termin).Where(x => x.username == username).FirstOrDefault();
            if (m != null)
            {
                trenutnaMusterija = m;
                trenutniVlasnik = null;
                trenutniFrizer = null;
                tipKorisnika = "musterija";
                return;
            }
        }

        public async Task<IActionResult> OnGetAsync(string username)
        {
            string u = Request.Cookies["username"];
            inicijalizujAtribute(u);

            if (vratiKorisnika() == null)
                return RedirectToPage("./Login");

            return null;
        }
        public async Task<JsonResult> OnGetDataAsync(string username = "")
        {
            string u = Request.Cookies["username"];
            inicijalizujAtribute(u);

            if (vratiKorisnika() == null)
                return new JsonResult(null);

            // gathering data from attributes

          

            if (trenutnaMusterija != null)
            {
                return new JsonResult(new
                {
                    tipKorisnika = LanguageController.Get(lang, "MyProfile", "TypeOfUserM"),
                    korisnik = vratiKorisnika(),
                  
                });
            }
            else if (trenutniFrizer != null)
            {
                return new JsonResult(new
                {
                    tipKorisnika = LanguageController.Get(lang, "MyProfile", "TypeOfUserF"),
                   
                });
            }
            else
            {
                return new JsonResult(new
                {
                    tipKorisnika = LanguageController.Get(lang, "MyProfile", "TypeOfUserV"),
                    korisnik = vratiKorisnika(),
                   
                });
            }
        }
        public  async Task<JsonResult> OnGetSendersAsync()
        {
            inicijalizujAtribute(Request.Cookies["username"]);
            Korisnik trenutniKorisnik = vratiKorisnika();

            List<Poruka> poslatePoruke = db.Poruke.Where(p => p.idPosiljaoca == trenutniKorisnik.id).ToList();
            List<Poruka> primljenePoruke = db.Poruke.Where(p => p.idPrimaoca == trenutniKorisnik.id).ToList();
            List<Korisnik> saucesniciUKonverzaciji = new List<Korisnik>();

            foreach (Poruka p in poslatePoruke)
                saucesniciUKonverzaciji.Add(vratiKorisnika(p.idPrimaoca));
            foreach (Poruka p in primljenePoruke)
                saucesniciUKonverzaciji.Add(vratiKorisnika(p.idPosiljaoca));

            saucesniciUKonverzaciji = saucesniciUKonverzaciji.Distinct().ToList();

            List<object> data = new List<object>();
            foreach (Korisnik k in saucesniciUKonverzaciji)
            {
                data.Add(new
                {
                    username = k.username,
                    id = k.id,
                    tip = formatiranTipKorisnika(k.tipKorisnika)
                });
            }
            return new JsonResult(data);
        }
        private string formatiranTipKorisnika(string tip)
        {
            if (tip == "v")
                return LanguageController.Get(Request.Cookies["lang"], "MyProfile", "TypeOfUserV");
            else if (tip == "f")
                return LanguageController.Get(Request.Cookies["lang"], "MyProfile", "TypeOfUserF");
            else
                return LanguageController.Get(Request.Cookies["lang"], "MyProfile", "TypeOfUserM");
        }
        private Korisnik VratiPosiljaoca(string s)
        {
            Vlasnik v = db.Vlasnici.Where(x => x.username == s).FirstOrDefault();
            if (v != null)
                return v ;

            Frizer f = db.Frizeri.Where(x => x.username == s).FirstOrDefault();
            if (f != null)
                return f;

            Musterija m = db.Musterije.Where(x => x.username == s).FirstOrDefault();
            if (m != null)
                return m;

            return null;
        }
        private Korisnik vratiKorisnika(int id = 0)
        {
            if (id == 0)
            {
                if (tipKorisnika == "vlasnik")
                    return (Korisnik)trenutniVlasnik;
                else if (tipKorisnika == "frizer")
                    return (Korisnik)trenutniFrizer;
                else
                    return (Korisnik)trenutnaMusterija;
            }
            else
            {
                Vlasnik v = db.Vlasnici.Where(x => x.id == id).FirstOrDefault();
                if (v != null)
                    return v;

                Frizer f = db.Frizeri.Where(x => x.id == id).FirstOrDefault();
                if (f != null)
                    return f;

                Musterija m = db.Musterije.Where(x => x.id == id).FirstOrDefault();
                if (m != null)
                    return m;

                return null;
            }
        }
        public async Task<JsonResult> OnGetPorukeAsync(string odKoga)
        {
            string username = Request.Cookies["username"];
            inicijalizujAtribute(username);

            int idKorisnika = vratiKorisnika().id;

            IQueryable<Poruka> poruke = db.Poruke.Where(x =>(x.idPrimaoca == idKorisnika && x.idPosiljaoca == VratiPosiljaoca(odKoga).id )
                                                        ||( x.idPosiljaoca==idKorisnika && x.idPrimaoca==VratiPosiljaoca(odKoga).id));
            List<Object> data = new List<object>();
            foreach (Poruka k in poruke)
            {
                string cijaJe;
                if (idKorisnika == k.idPosiljaoca)
                    cijaJe = "poslata";
                else
                    cijaJe = "primljena";
                data.Add(new
                {
                    sadrzaj = k.sadrzaj,
                    vreme = k.vreme.ToString("MM/dd/yyyy hh:mm:ss tt"),
                    tip = cijaJe,
                }) ;
                
            }
            return new JsonResult(data);
        }
        public async Task<JsonResult> OnGetPosaljiAsync(string message,string primalac)
        {
            string p = HttpUtility.UrlDecode(primalac);
            string m = HttpUtility.UrlDecode(message);
            int idPrimaoca1 = VratiPosiljaoca(p).id;
            string username = Request.Cookies["username"];
            inicijalizujAtribute(username);
            int idPosiljaoca1 = vratiKorisnika().id;
            Poruka nova = new Poruka
            {
                sadrzaj = m,
                vreme = DateTime.Now,
                idPosiljaoca = idPosiljaoca1,
                idPrimaoca = idPrimaoca1,



            };
            db.Poruke.Add(nova);
            db.SaveChanges();
            return new JsonResult(true);
        }
        public async Task<JsonResult> OnGetLangDataAsync(string resourceName, bool lang = false)
        {
            if (lang)
                return new JsonResult(Request.Cookies["lang"]);
            return new JsonResult(LanguageController.Get(Request.Cookies["lang"], "Inbox", resourceName));
        }
        public async Task<JsonResult> OnGetUserAsync(string username)
        {
            Korisnik k = VratiPosiljaoca(username);
            if (k == null)
                return null;
            return new JsonResult(new
            {
                username = k.username,
                tip = formatiranTipKorisnika(k.tipKorisnika)
            });
        }
    }
}