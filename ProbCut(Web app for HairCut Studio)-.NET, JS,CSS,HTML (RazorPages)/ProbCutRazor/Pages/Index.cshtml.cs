using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProbCut.Models;

namespace ProbCut.Pages
{
    public class IndexModel : PageModel
    {
        
        public  string lang { get; set; }
        public IndexModel()
        {
            
        }

        public async Task OnGetAsync(bool logout = false)
        {
            lang = Request.Cookies["lang"];

            if (logout)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Append("username", "", options);
                Response.Redirect(Request.Path+ "?loggedout");
            }
           
        }
        public async Task<JsonResult> OnGetLangDataAsync(string resourceName)
        {
            return new JsonResult(LanguageController.Get(Request.Cookies["lang"], "Index", resourceName));
        }
    }
}
