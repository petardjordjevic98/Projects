using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProbCut.Models;

namespace ProbCut.Pages
{
    public class CenovnikModel : PageModel
    {
        public SalonContext db { get; set; }
        public string lang { get; set; }
        public Dictionary<string, string> cene { get; set; }

        public CenovnikModel(SalonContext s)
        {
            db = s;
        }
        public async Task OnGetAsync()
        {
            lang = Request.Cookies["lang"];
            cene = LanguageController.GetPricingData();
        }

        public async Task<JsonResult> OnGetLangDataAsync(string resourceName)
        {
            return new JsonResult(LanguageController.Get(Request.Cookies["lang"], "Pricing", resourceName));
        }

        public async Task<JsonResult> OnGetSaveChangesAsync(List<List<string>> data)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string[] rawStrings = data[0][0].Split(',');
            for(int i=0; i<rawStrings.Length; i+=2)
                result.Add(rawStrings[i], rawStrings[i + 1]);
            
            LanguageController.WritePricingData(result);
            return null;
        }

        public async Task<JsonResult> OnGetUserTypeAsync()
        {
            string username = Request.Cookies["username"];

            Vlasnik v = db.Vlasnici.Where(x => x.username == username).FirstOrDefault();
            if (v != null)
                return new JsonResult("vlasnik");

            Frizer f = db.Frizeri.Where(x => x.username == username).FirstOrDefault();
            if (f != null)
                return new JsonResult("frizer");

            Musterija m = db.Musterije.Where(x => x.username == username).FirstOrDefault();
            if (m != null)
                return new JsonResult("musterija");

            return null;
        }
    }
}