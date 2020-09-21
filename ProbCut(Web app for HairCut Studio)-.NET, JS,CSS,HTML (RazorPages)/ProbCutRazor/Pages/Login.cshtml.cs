using System;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProbCut.Models;

namespace ProbCut.Pages
{
    public class LoginModel : PageModel
    {   
        public SalonContext db { get; set; }
        [BindProperty]
        public string username { set; get; }
        [BindProperty]
        public string password { set; get; }
        [BindProperty]
        public bool hasErrors { set; get; }
        public string errorMessages { get; set; }
        public string lang { get; set; }

        public LoginModel (SalonContext s)
        {
            db = s;
        }

        public async void OnGetAsync()
        {
            lang = HttpContext.Request.Cookies["lang"];

            if (HttpContext.Session.Get("ErrorMessages") != null)
            {
                // run JS code to display error messages

                errorMessages = Encoding.Default.GetString(HttpContext.Session.Get("ErrorMessages"));
                HttpContext.Session.Remove("ErrorMessages");
            }
        }
        public async void OnPostAsync()
        {
            if (!hasErrors)
            {
                if (TryLogin())
                {
                    // azuriranje poslednje aktivnosti vlasnika
                    Vlasnik v = db.Vlasnici.Where(x => x.username == username).FirstOrDefault();
                    if (v != null)
                    {
                        v.poslednjiPutUlogovan = DateTime.Now;
                        db.SaveChanges();
                    }

                    // resetovanje cookie vrednosti za rating
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Append("rating", "", options);


                    Response.Redirect("./Index?loggedin");
                }
            }
        }
        public bool TryLogin()
        {
            string result = validate();
            if (result != null)
            {
                HttpContext.Session.Set("ErrorMessages", Encoding.Default.GetBytes(result));
                Response.Redirect(Request.Path);
                return false;
            }

            if (!ModelState.IsValid)
                return false;

            // validation successful

            // writing cookies
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);

            // checking each database & de-hashing passwords (BCrypt)
            bool wrongPassword = false;
            Vlasnik v = db.Vlasnici.Where(x => x.username == username).FirstOrDefault();
            if (v != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, v.password))
                    Response.Cookies.Append("username", v.username, options);
                else
                    wrongPassword = true;
            }
            Frizer f = db.Frizeri.Where(x => x.username == username).FirstOrDefault();
            if (f != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, f.password))
                    Response.Cookies.Append("username", f.username, options);
                else
                    wrongPassword = true;
            }
            Musterija m =  db.Musterije.Where(x => x.username == username).FirstOrDefault();
            if (m != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, m.password))
                    Response.Cookies.Append("username", m.username, options);
                else
                    wrongPassword = true;
            }

            if (v == null && f == null && m == null)
            {
                result += LanguageController.Get(lang, "Login", "ErrorUsernameWrong");
                HttpContext.Session.Set("ErrorMessages", Encoding.Default.GetBytes(result));
                Response.Redirect(Request.Path);
                return false;
            }
            else if (wrongPassword)
            {
                result += LanguageController.Get(lang, "Login", "ErrorPasswordWrong");
                HttpContext.Session.Set("ErrorMessages", Encoding.Default.GetBytes(result));
                Response.Redirect(Request.Path);
                return false;
            }

            return true;
        }
        private string validate()
        {
            // server-side data validation
            string result = null;

            //      1. checking if the username is empty
            if (username == null)
                result += LanguageController.Get(lang, "Login", "ErrorUsernameEmpty") + '`';

            //      2. checking if the username is at least 3 characters long
            else if (username.Length < 3)
                result += LanguageController.Get(lang, "Login", "ErrorUsernameTooShort") + '`';

            //      3. checking if the username has more than 30 characters
            else if (username.Length > 30)
                result += LanguageController.Get(lang, "Login", "ErrorUsernameTooLong") + '`';

            if (username != null)
            {
                //      4. checking if the username uses invalid characters
                string validCharacters = "1234567890-_.abcčćdđefghijklmnopqrsštuvwxyzžABCČĆDĐEFGHIJKLMNOPQRSŠTUVWXYZŽ";
                foreach (char c in username)
                {
                    if (!validCharacters.Contains(c))
                    {
                        result += LanguageController.Get(lang, "Login", "ErrorUsernameInvalidCharacter") + '`';
                        break;
                    }
                }

                //      5. checking if the username has consecutive dots or dashes
                for (int i = 0; i < username.Length - 1; i++)
                {
                    bool consError = false;
                    if (username[i] == '.')
                    {
                        if (username[i + 1] == '.')
                            consError = true;
                    }
                    if (username[i] == '-')
                    {
                        if (username[i + 1] == '-')
                            consError = true;
                    }

                    if (consError)
                    {
                        result += LanguageController.Get(lang, "Login", "ErrorUsernameConsecutiveSymbols") + '`';
                        break;
                    }
                }
            }            

            // _____________________________________________________________________________________
            //      1. checking if the password is empty
            if (password == null)
                result += LanguageController.Get(lang, "Login", "ErrorPasswordEmpty") + '`';

            //      2. checking if the password is at least 6 characters long
            else if (password.Length < 6)
                result += LanguageController.Get(lang, "Login", "ErrorPasswordTooShort") + '`';

            //      3. checking if the password has more than 30 characters
            else if (password.Length > 30)
                result += LanguageController.Get(lang, "Login", "ErrorPasswordTooLong") + '`';

            return result;
        }
    }
}