using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProbCut.Models;

namespace ProbCut.Pages
{
    public class RegisterModel : PageModel
    {
        public SalonContext db { get; set; }
        [BindProperty]
        public Musterija  musterija { get; set; }
        [BindProperty]
        public string genderFormatted { set; get; }
        [BindProperty]
        public bool hasErrors { set; get; }
        public string errorMessages { get; set; }
        public string lang { get; set; }
        public RegisterModel (SalonContext s)
        {
            db = s;
        }

        public async void OnGetAsync()
        {
            lang = Request.Cookies["lang"];

            if (HttpContext.Session.Get("ErrorMessages") != null)
            {
                // run JS code to display error messages

                errorMessages = Encoding.Default.GetString(HttpContext.Session.Get("ErrorMessages"));
                HttpContext.Session.Remove("ErrorMessages");
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            lang = Request.Cookies["lang"];

            // formatting gender input into char
            if (genderFormatted == LanguageController.Get(lang, "Register", "GenderMale"))
                musterija.pol = 'M';
            else if (genderFormatted == LanguageController.Get(lang, "Register", "GenderFemale"))
                musterija.pol = 'Z';
            else
                musterija.pol = null;

            if (!hasErrors)
            {
                if (TryRegister())
                {
                    if (!ModelState.IsValid)
                        return RedirectToPage("/Index");

                    // validation successful

                    // password hashing (BCrypt)
                    musterija.password = BCrypt.Net.BCrypt.HashPassword(musterija.password);

                    // finding unique id in tables Vlasnici, Frizeri & Musterije
                    musterija.id = findNextID();

                    db.Musterije.Add(musterija);
                    db.SaveChanges();
                    return RedirectToPage("/Index", new { registered = true });
                }
            }

            return RedirectToPage("/Index");
        }

        private bool TryRegister()
        {
            string result = validate();
            if (result != null)
            {
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

            //      1. checking if the first name is empty
            if (musterija.ime == null)
                result += LanguageController.Get(lang, "Register", "ErrorFirstNameEmpty") + '`';

            //      2. checking if the first name is at least 2 characters long
            else if (musterija.ime.Length < 2)
                result += LanguageController.Get(lang, "Register", "ErrorFirstNameTooShort") + '`';

            //      3. checking if the first name uses invalid characters
            string validCharactersFirstName = "abcčćdđefghijklmnopqrsštuvwxyzžABCČĆDĐEFGHIJKLMNOPQRSŠTUVWXYZŽ";
            if (musterija.ime != null)
            {
                foreach (char c in musterija.ime)
                {
                    if (!validCharactersFirstName.Contains(c))
                    {
                        result += LanguageController.Get(lang, "Register", "ErrorFirstNameInvalidCharacter") + '`';
                        break;
                    }
                }
            }

            // _____________________________________________________________________________________
            //      1. checking if the last name is empty
            if (musterija.prezime == null)
                result += LanguageController.Get(lang, "Register", "ErrorLastNameEmpty") + '`';

            //      2. checking if the last name is at least 2 characters long
            else if (musterija.prezime.Length < 2)
                result += LanguageController.Get(lang, "Register", "ErrorLastNameTooShort") + '`';

            //      3. checking if the last name uses invalid characters
            if (musterija.prezime != null)
            {
                foreach (char c in musterija.prezime)
                {
                    if (!validCharactersFirstName.Contains(c))
                    {
                        result += LanguageController.Get(lang, "Register", "ErrorLastNameInvalidCharacter") + '`';
                        break;
                    }
                }
            }

            // _____________________________________________________________________________________
            //      1. checking if the username is empty
            if (musterija.username == null)
                result += LanguageController.Get(lang, "Register", "ErrorUsernameEmpty") + '`';

            //      2. checking if the username is at least 3 characters long
            else if (musterija.username.Length < 3)
                result += LanguageController.Get(lang, "Register", "ErrorUsernameTooShort") + '`';

            //      3. checking if the username has more than 30 characters
            else if (musterija.username.Length > 30)
                result += LanguageController.Get(lang, "Register", "ErrorUsernameTooLong") + '`';

            if (musterija.username != null)
            {
                //      4. checking if the username uses invalid characters
                string validCharacters = "1234567890-_.abcčćdđefghijklmnopqrsštuvwxyzžABCČĆDĐEFGHIJKLMNOPQRSŠTUVWXYZŽ";
                foreach (char c in musterija.username)
                {
                    if (!validCharacters.Contains(c))
                    {
                        result += LanguageController.Get(lang, "Register", "ErrorUsernameInvalidCharacter") + '`';
                        break;
                    }
                }

                //      5. checking if the username has consecutive dots or dashes
                for (int i = 0; i < musterija.username.Length - 1; i++)
                {
                    bool consError = false;
                    if (musterija.username[i] == '.')
                    {
                        if (musterija.username[i + 1] == '.')
                            consError = true;
                    }
                    if (musterija.username[i] == '-')
                    {
                        if (musterija.username[i + 1] == '-')
                            consError = true;
                    }

                    if (consError)
                    {
                        result += LanguageController.Get(lang, "Register", "ErrorUsernameConsecutiveSymbols") + '`';
                        break;
                    }
                }

                //      6. checking if a user with the same username already exists in the database
                Musterija m = db.Musterije.Where(x => x.username == musterija.username).FirstOrDefault();
                Frizer f = db.Frizeri.Where(x => x.username == musterija.username).FirstOrDefault();
                Vlasnik v = db.Vlasnici.Where(x => x.username == musterija.username).FirstOrDefault();
                if (m != null || f != null || v != null)
                    result += LanguageController.Get(lang, "Register", "ErrorUsernameAlreadyExists") + '`';
            }


            // _____________________________________________________________________________________
            //      1. checking if the password is empty
            if (musterija.password == null)
                result += LanguageController.Get(lang, "Register", "ErrorPasswordEmpty") + '`';

            //      2. checking if the password is at least 6 characters long
            else if (musterija.password.Length < 6)
                result += LanguageController.Get(lang, "Register", "ErrorPasswordTooShort") + '`';

            //      3. checking if the password has more than 30 characters
            else if (musterija.password.Length > 30)
                result += LanguageController.Get(lang, "Register", "ErrorPasswordTooLong") + '`';

            // _____________________________________________________________________________________
            //      1. checking if the date of birth is empty
            if (musterija.datumRodjenjaFormatiranShortDate == "1/1/0001")
                result += LanguageController.Get(lang, "Register", "ErrorDateOfBirthEmpty") + '`';

            // _____________________________________________________________________________________
            //      1. checking if the phone number uses invalid characters
            string validCharactersNumber = "0123456789 ";
            if (musterija.brojTelefona != null)
            {
                foreach (char c in musterija.brojTelefona)
                {
                    if (!validCharactersNumber.Contains(c))
                    {
                        result += LanguageController.Get(lang, "Register", "ErrorPhoneNumberInvalidCharacter");
                        break;
                    }
                }
            }

            return result;
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