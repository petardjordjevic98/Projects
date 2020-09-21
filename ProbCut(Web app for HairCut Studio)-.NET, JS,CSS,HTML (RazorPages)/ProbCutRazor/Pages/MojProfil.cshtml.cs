using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProbCut.Models;

namespace ProbCut.Pages
{
    public class MojProfilModel : PageModel
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

        public MojProfilModel(SalonContext s)
        {
            db = s;
        }

        public void inicijalizujAtribute(string username = "")
        {
            // reading cookies
            lang = Request.Cookies["lang"];

            // reading from database
            pronadjiKorisnikaUBazi(username);
        }
        public void pronadjiKorisnikaUBazi(string user = "")
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
            if (Request.Cookies["username"] == null || username == "")
                return RedirectToPage("./Login");

            inicijalizujAtribute(username);

            if (vratiKorisnika() == null)
                return RedirectToPage("./Login");

            return null;
        }
        public async Task<JsonResult> OnGetDataAsync(string username = "")
        {
            inicijalizujAtribute(username);

            if (vratiKorisnika() == null)
                return new JsonResult(null);

            // gathering data from attributes

            string gender = vratiKorisnika().polFormatiran(lang);
            string datumRodjenja = vratiKorisnika().datumRodjenjaFormatiranShortDate;

            string genderToWorkWith = "";
            if (trenutniFrizer != null)
            {
                if (trenutniFrizer.polKojiSisa == 'M')
                    genderToWorkWith = LanguageController.Get(lang, "MyProfile", "GenderMale");
                else if (trenutniFrizer.polKojiSisa == 'Z')
                    genderToWorkWith = LanguageController.Get(lang, "MyProfile", "GenderFemale");
                else
                    genderToWorkWith = LanguageController.Get(lang, "MyProfile", "GenderBoth");
            }

            if (trenutnaMusterija != null)
            {
                return new JsonResult(new
                {
                    tipKorisnika = LanguageController.Get(lang, "MyProfile", "TypeOfUserM"),
                    korisnik = vratiKorisnika(),
                    stat1 = trenutnaMusterija.brojRealizovanihTermina,
                    stat1Opis = LanguageController.Get(lang, "MyProfile", "StatDescNumOfAppointments"),
                    stat2 = trenutnaMusterija.termin == null ? "/" : trenutnaMusterija.termin.vreme.ToShortDateString(),
                    stat2Opis = LanguageController.Get(lang, "MyProfile", "StatDescAppointment"),
                    pol = gender,
                    datum = datumRodjenja
                });
            }
            else if (trenutniFrizer != null)
            {
                return new JsonResult(new
                {
                    tipKorisnika = LanguageController.Get(lang, "MyProfile", "TypeOfUserF"),
                    korisnik = vratiKorisnika(),
                    stat1 = trenutniFrizer.brojRealizovanihTermina,
                    stat1Opis = LanguageController.Get(lang, "MyProfile", "StatDescNumOfAppointments"),
                    stat2 = trenutniFrizer.ProsecnaOcena(),
                    stat2Opis = LanguageController.Get(lang, "MyProfile", "StatDescRating"),
                    pol = gender,
                    polKojiSisa = genderToWorkWith,
                    datum = datumRodjenja
                });
            }
            else
            {
                return new JsonResult(new
                {
                    tipKorisnika = LanguageController.Get(lang, "MyProfile", "TypeOfUserV"),
                    korisnik = vratiKorisnika(),
                    stat1 = trenutniVlasnik.poslednjiPutUlogovan.ToShortDateString(),
                    stat1Opis = LanguageController.Get(lang, "MyProfile", "StatDescLastActivity"),
                    stat2 = db.Frizeri.Count(),
                    stat2Opis = LanguageController.Get(lang, "MyProfile", "StatDescNumOfBarbers"),
                    pol = gender,
                    datum = datumRodjenja
                });
            }
        }
        public async Task<JsonResult> OnGetCommentsAsync(string username)
        {
            inicijalizujAtribute(username);
            List<Komentar> komentari = trenutniFrizer.komentari.ToList();
            List<Object> data = new List<object>();
            foreach(Komentar k in komentari)
            {
                data.Add(new
                {
                    autor = k.autor,
                    sadrzaj = k.sadrzaj,
                    vreme = k.vreme.ToString("MM/dd/yyyy hh:mm:ss tt"),
                    id = k.id
                });
            }
            return new JsonResult(data);
        }
        public Korisnik vratiKorisnika(string user = null)
        {
            if (user == null)
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
                Vlasnik v = db.Vlasnici.Where(x => x.username == user).FirstOrDefault();
                if (v != null)
                    return v;

                Frizer f = db.Frizeri.Where(x => x.username == user).FirstOrDefault();
                if (f != null)
                    return f;

                Musterija m = db.Musterije.Where(x => x.username == user).FirstOrDefault();
                if (m != null)
                    return m;

                return null;
            }
        }
        public async Task<JsonResult> OnGetLangDataAsync(string resourceName, bool lang = false)
        {
            if (lang)
                return new JsonResult(Request.Cookies["lang"]);
            return new JsonResult(LanguageController.Get(Request.Cookies["lang"], "MyProfile", resourceName));
        }
        public async Task<JsonResult> OnGetVerifyOldPasswordAsync(string oldPass)
        {
            if (oldPass == "")
                return new JsonResult(false);

            Korisnik k;
            string username = Request.Cookies["username"];
            if (tipKorisnika == "vlasnik")
                k = (Korisnik)db.Vlasnici.Where(v => v.username == username).FirstOrDefault();
            else if (tipKorisnika == "frizer")
                k = (Korisnik)db.Frizeri.Where(v => v.username == username).FirstOrDefault();
            else
                k = (Korisnik)db.Musterije.Where(v => v.username == username).FirstOrDefault();

            return new JsonResult(BCrypt.Net.BCrypt.Verify(oldPass, k.password));
        }
        public async Task<JsonResult> OnGetValidatePasswordAsync(string newPass)
        {
            List<string> messages = new List<string>();

            // 1. checking if password is empty
            if (newPass == "")
                messages.Add(LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorNewPasswordEmpty"));

            // 2. checking if the password is at least 6 characters long
            if (newPass.Length < 6)
                messages.Add(LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorNewPasswordTooShort"));

            // 3. checking if the password is longer than 30 characters
            if (newPass.Length > 30)
                messages.Add(LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorNewPasswordTooLong"));

            if (messages.Count == 0)
            {
                // change password in database
                string newPassword = BCrypt.Net.BCrypt.HashPassword(newPass);
                pronadjiKorisnikaUBazi();
                vratiKorisnika().password = newPassword;
                db.SaveChanges();

                return new JsonResult(null);
            }
            return new JsonResult(messages);
        }
        public async Task<JsonResult> OnGetValidateNewDataAsync(string[] data)
        {
            string[] userData = data[0].Split(',');
            string dataFirstName = HttpUtility.UrlDecode(userData[0]);
            string dataLastName = HttpUtility.UrlDecode(userData[1]);
            string dataUsername = HttpUtility.UrlDecode(userData[2]);
            string dataGender = HttpUtility.UrlDecode(userData[3]);
            string dataGenderToWorkWith = null;
            string dataDateOfBirth;
            string dataPhoneNumber;

            if (vratiKorisnika(dataUsername).tipKorisnika == "f")
            {
                dataGenderToWorkWith = HttpUtility.UrlDecode(userData[4]);
                dataDateOfBirth = HttpUtility.UrlDecode(userData[5]);
                dataPhoneNumber = HttpUtility.UrlDecode(userData[6]);
            }
            else
            {
                dataDateOfBirth = HttpUtility.UrlDecode(userData[4]);
                dataPhoneNumber = HttpUtility.UrlDecode(userData[5]);
            }

            List<Object> result = new List<Object>();
            Object error;

            // 1. checking if the first name is empty
            if (dataFirstName == "")
            {
                error = new
                {
                    id = "rowFirstName",
                    text = LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorFirstNameEmpty")
                };
                result.Add(error);
            }

            // 2. checking if the first name is at least 2 characters long
            if (dataFirstName.Length < 2)
            {
                error = new
                {
                    id = "rowFirstName",
                    text = LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorFirstNameTooShort")
                };
                result.Add(error);
            }

            // 3. checking if the first name uses invalid characters
            string validCharactersFirstName = "abcčćdđefghijklmnopqrsštuvwxyzžABCČĆDĐEFGHIJKLMNOPQRSŠTUVWXYZŽ";
            foreach (char c in dataFirstName)
            {
                if (!validCharactersFirstName.Contains(c))
                {
                    error = new
                    {
                        id = "rowFirstName",
                        text = LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorFirstNameInvalidCharacter")
                    };
                    result.Add(error);
                    break;
                }
            }

            // _____________________________________________________________________________________
            // 1. checking if the last name is empty
            if (dataLastName == "")
            {
                error = new
                {
                    id = "rowLastName",
                    text = LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorLastNameEmpty")
                };
                result.Add(error);
            }

            // 2. checking if the last name is at least 2 characters long
            if (dataLastName.Length < 2)
            {
                error = new
                {
                    id = "rowLastName",
                    text = LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorLastNameTooShort")
                };
                result.Add(error);
            }

            // 3. checking if the last name uses invalid characters
            foreach (char c in dataLastName)
            {
                if (!validCharactersFirstName.Contains(c))
                {
                    error = new
                    {
                        id = "rowLastName",
                        text = LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorLastNameInvalidCharacter")
                    };
                    result.Add(error);
                    break;
                }
            }

            // _____________________________________________________________________________________
            // 1. checking if the username is empty
            if (dataUsername == "")
            {
                error = new
                {
                    id = "rowUsername",
                    text = LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorUsernameEmpty")
                };
                result.Add(error);
            }

            // 2. checking if the username is at least 3 characters long
            if (dataUsername.Length < 3)
            {
                error = new
                {
                    id = "rowUsername",
                    text = LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorUsernameTooShort")
                };
                result.Add(error);
            }

            // 3. checking if the username is longer than 30 characters
            if (dataUsername.Length > 30)
            {
                error = new
                {
                    id = "rowUsername",
                    text = LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorUsernameTooLong")
                };
                result.Add(error);
            }

            // 4. checking if the username uses invalid characters
            string validCharacters = "1234567890-_.abcčćdđefghijklmnopqrsštuvwxyzžABCČĆDĐEFGHIJKLMNOPQRSŠTUVWXYZŽ";
            foreach (char c in dataUsername)
            {
                if (!validCharacters.Contains(c))
                {
                    error = new
                    {
                        id = "rowUsername",
                        text = LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorUsernameInvalidCharacter")
                    };
                    result.Add(error);
                    break;
                }
            }

            // 5. checking if the username has consecutive dots or dashes
            for (int i = 0; i < dataUsername.Length - 1; i++)
            {
                bool consError = false;
                if (dataUsername[i] == '.')
                {
                    if (dataUsername[i + 1] == '.')
                        consError = true;
                }
                if (dataUsername[i] == '-')
                {
                    if (dataUsername[i + 1] == '-')
                        consError = true;
                }

                if (consError)
                {
                    error = new
                    {
                        id = "rowUsername",
                        text = LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorUsernameConsecutiveSymbols")
                    };
                    result.Add(error);
                    break;
                }
            }

            // 6. checking if the same username already exists in the database
            if (dataUsername != Request.Cookies["username"])
            {
                Musterija m = db.Musterije.Where(x => x.username == dataUsername).FirstOrDefault();
                Frizer f = db.Frizeri.Where(x => x.username == dataUsername).FirstOrDefault();
                Vlasnik v = db.Vlasnici.Where(x => x.username == dataUsername).FirstOrDefault();
                if (m != null || f != null || v != null)
                {
                    error = new
                    {
                        id = "rowUsername",
                        text = LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorUsernameAlreadyExists")
                    };
                    result.Add(error);
                }
            }

            // _____________________________________________________________________________________
            char? gender = null;
            if (dataGender == LanguageController.Get(Request.Cookies["lang"], "MyProfile", "GenderMale"))
                gender = 'M';
            else if (dataGender == LanguageController.Get(Request.Cookies["lang"], "MyProfile", "GenderFemale"))
                gender = 'Z';

            // _____________________________________________________________________________________
            char genderToWorkWith;
            if (dataGenderToWorkWith == LanguageController.Get(Request.Cookies["lang"], "MyProfile", "GenderMale"))
                genderToWorkWith = 'M';
            else if (dataGenderToWorkWith == LanguageController.Get(Request.Cookies["lang"], "MyProfile", "GenderFemale"))
                genderToWorkWith = 'Z';
            else
                genderToWorkWith = 'O';

            // _____________________________________________________________________________________
            // 1. checking if the date of birth is empty
            if (dataDateOfBirth == "")
            {
                error = new
                {
                    id = "rowDateOfBirth",
                    text = LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorDateOfBirthEmpty")
                };
                result.Add(error);
            }

            // _____________________________________________________________________________________
            // 1. checking if the phone number uses invalid characters
            string validCharactersNumber = "0123456789 ";
            foreach (char c in dataPhoneNumber)
            {
                if (!validCharactersNumber.Contains(c))
                {
                    error = new
                    {
                        id = "rowPhoneNumber",
                        text = LanguageController.Get(Request.Cookies["lang"], "MyProfile", "ErrorPhoneNumberInvalidCharacter")
                    };
                    result.Add(error);
                    break;
                }
            }

            // _____________________________________________________________________________________
            // saving changes to database
            if (result.Count == 0)
            {
                pronadjiKorisnikaUBazi();
                Korisnik k = vratiKorisnika(dataUsername);
                k.ime = dataFirstName;
                k.prezime = dataLastName;
                k.username = dataUsername;
                k.pol = gender;
                k.datumRodjenja = DateTime.ParseExact(dataDateOfBirth, "yyyy-MM-dd", CultureInfo.CurrentCulture);
                k.brojTelefona = dataPhoneNumber;

                if (k.tipKorisnika == "f")
                {
                    Frizer f = db.Frizeri.Where(x => x.username == k.username).FirstOrDefault();
                    f.polKojiSisa = genderToWorkWith;
                }

                db.SaveChanges();

                // updating cookie
                Response.Cookies.Append("username", dataUsername);
            }

            return new JsonResult(result);
        }
        public async Task<JsonResult> OnGetDeleteAccountAsync()
        {
            string username = Request.Cookies["username"];
            if (username == null)
                return new JsonResult(false);

            pronadjiKorisnikaUBazi();
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(-1);
            bool result = false;

            if (tipKorisnika == "musterija")
            {
                db.Musterije.Remove(db.Musterije.Where(x => x.username == username).FirstOrDefault());
                result = true;
            }
            else if (tipKorisnika == "frizer")
            {
                db.Frizeri.Remove(db.Frizeri.Where(x => x.username == username).FirstOrDefault());
                result = true;
            }
            else
            {
                db.Vlasnici.Remove(db.Vlasnici.Where(x => x.username == username).FirstOrDefault());
                result = true;
            }

            if (result)
            {
                Response.Cookies.Append("username", "", options);
                db.SaveChanges();
            }
            return new JsonResult(result);
        }
        public async Task<JsonResult> OnGetPostCommentAsync(string content, string barber)
        {
            inicijalizujAtribute();
            string c = HttpUtility.UrlDecode(content);
            string b = HttpUtility.UrlDecode(barber);
            Frizer f = db.Frizeri.Where(x => x.username == b).FirstOrDefault();

            if (f == null || c == "" || trenutnaMusterija == null)
                return new JsonResult(false);

            Komentar k = new Komentar
            {
                autor = trenutnaMusterija,
                frizer = f,
                sadrzaj = c,
                vreme = DateTime.Now
            };

            db.Komentari.Add(k);
            db.SaveChanges();

            return new JsonResult(true);
        }
        public async Task<JsonResult> OnGetDeleteCommentAsync(int id)
        {
            Komentar k = db.Komentari.Where(x => x.id == id).FirstOrDefault();

            if (k == null)
                return new JsonResult(false);

            db.Komentari.Remove(k);
            db.SaveChanges();

            return new JsonResult(true);
        }
        public async Task<JsonResult> OnGetRateBarberAsync(string user, string rating)
        {
            Frizer f = db.Frizeri.Where(x => x.username == user).FirstOrDefault();

            if (f == null)
                return new JsonResult(null);

            float ocena = Convert.ToSingle(rating);
            f.prosecnaOcena = (f.prosecnaOcena * f.brojOcena + ocena) / (f.brojOcena + 1);
            f.brojOcena++;

            db.SaveChanges();

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Append("rating", Request.Cookies["rating"] + ' ' + user, options);

            return new JsonResult(f.ProsecnaOcena());
        }
    }
}