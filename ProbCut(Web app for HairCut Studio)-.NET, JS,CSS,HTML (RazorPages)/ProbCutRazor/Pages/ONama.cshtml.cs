using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProbCut.Pages
{
    public class ONamaModel : PageModel
    {
        public string lang { get; set; }
        public void OnGet()
        {
            lang = HttpContext.Request.Cookies["lang"];
        }
    }
}