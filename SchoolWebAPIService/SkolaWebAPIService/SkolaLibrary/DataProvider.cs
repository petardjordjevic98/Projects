using SkolaLibrary.DTOs;
using NHibernate;
using SkolaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Skola;

namespace SkolaLibrary
{
    public class DataProvider
    {

        #region Ucenik
        public static List<UcenikView> GetUcenike()
        {
            List<UcenikView> Ucenici = new List<UcenikView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Ucenik> ucenici = from o in s.Query<Ucenik>()
                                              select o;

                foreach (Ucenik o in ucenici)
                {
                    Ucenici.Add(new UcenikView(o));
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return Ucenici;
        }

        public static UcenikView GetUcenika(int id)
        {
            UcenikView ucenikPrikaz;

            try
            {
                ISession s = DataLayer.GetSession();

                Ucenik u = s.Load<Ucenik>(id);

                ucenikPrikaz = new UcenikView(u);
                ucenikPrikaz.Ocene = u.Ocene.Select(p => new OcenaView(p)).ToList();
                ucenikPrikaz.Roditelji = u.Roditelji.Select(p => new RoditeljView(p)).ToList();


                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return ucenikPrikaz;
        }

        public static void DodajUcenika(UcenikView u)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ucenik noviUcenik = new Ucenik
                {

                    Ime = u.Ime,
                    Prezime = u.Prezime,
                    Adresa = u.Adresa,
                    Razred = u.Razred,
                    DatumUpisa = u.DatumUpisa

                };

                s.SaveOrUpdate(noviUcenik);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void IzmeniUcenika(UcenikView ucenik)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ucenik o = s.Load<Ucenik>(ucenik.UpisniBroj);

                o.Adresa = ucenik.Adresa;
                o.DatumUpisa = ucenik.DatumUpisa;
                o.Ime = ucenik.Ime;
                o.Prezime = ucenik.Prezime;
                o.Razred = ucenik.Razred;


                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void IzbrisiUcenika(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ucenik ucenik = s.Load<Ucenik>(id);

                s.Delete(ucenik);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region Predmet

        public static List<PredmetView> GetPredmete()
        {
            List<PredmetView> Predmeti = new List<PredmetView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Predmet> predmeti = from o in s.Query<Predmet>()
                                                select o;

                foreach (Predmet u in predmeti)
                {
                    PredmetView predmetPrikaz;
                    predmetPrikaz = new PredmetView(u);
                    predmetPrikaz.Ocene = u.Ocene.Select(p => new OcenaView(p)).ToList();
                    predmetPrikaz.Godine = u.Godine.Select(p => new GodinaView(p)).ToList();
                    predmetPrikaz.Nastavnici = u.Nastavnici.Select(p => new AngazovanView(p)).ToList();
                    predmetPrikaz.Smerovi = u.Smerovi.Select(p => new PripadaView(p)).ToList();
                    Predmeti.Add(predmetPrikaz);
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return Predmeti;
        }

        public static PredmetView GetPredmet(int id)
        {
            PredmetView predmetPrikaz;

            try
            {
                ISession s = DataLayer.GetSession();

                Predmet u = s.Load<Predmet>(id);

                predmetPrikaz = new PredmetView(u);
                predmetPrikaz.Ocene = u.Ocene.Select(p => new OcenaView(p)).ToList();
                predmetPrikaz.Godine = u.Godine.Select(p => new GodinaView(p)).ToList();
                predmetPrikaz.Nastavnici = u.Nastavnici.Select(p => new AngazovanView(p)).ToList();
                predmetPrikaz.Smerovi = u.Smerovi.Select(p => new PripadaView(p)).ToList();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return predmetPrikaz;
        }

        public static void DodajPredmet(PredmetView u)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet noviPredmet = new Predmet
                {
                    Naziv = u.Naziv
               };

                s.SaveOrUpdate(noviPredmet);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void IzmeniPredmet(PredmetView predmet)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet o = s.Load<Predmet>(predmet.Id);

                o.Naziv = predmet.Naziv;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void IzbrisiPredmet(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet predmet = s.Load<Predmet>(id);

                s.Delete(predmet);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

        }
        #endregion

        #region Ocena

        public static List<OcenaView> GetOcene()
        {
            List<OcenaView> Ocene = new List<OcenaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Ocena> ocene = from o in s.Query<Ocena>()
                                                select o;

                foreach (Ocena u in ocene)
                {
                    OcenaView OcenaPrikaz;
                    OcenaPrikaz = new OcenaView(u);
                    Ocene.Add(OcenaPrikaz);
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return Ocene;
        }

        public static OcenaView GetOcena(int id)
        {
            OcenaView ocenaPrikaz;

            try
            {
                ISession s = DataLayer.GetSession();

                Ocena u = s.Load<Ocena>(id);

                ocenaPrikaz = new OcenaView(u);
            


                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return ocenaPrikaz;
        }

        public static void DodajOcenu(OcenaView u)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ocena noviOcena = new Ocena
                {

                    NumVrednost = u.NumVrednost,
                    TekstualniOpis=u.TekstualniOpis




                };

                s.SaveOrUpdate(noviOcena);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void IzmeniOcenu(OcenaView ocena)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ocena o = s.Load<Ocena>(ocena.Id);

                o.NumVrednost = ocena.NumVrednost;
                o.TekstualniOpis = ocena.TekstualniOpis;
                o.DatumOcenjivanja = ocena.DatumOcenjivanja;


                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void IzbrisiOcenu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ocena ocena = s.Load<Ocena>(id);

                s.Delete(ocena);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

        }
        #endregion

        #region Smer

        public static List<SmerView> GetSmerovi()
        {
            List<SmerView> Smerovi = new List<SmerView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Smer> smerovi = from o in s.Query<Smer>()
                                           select o;

                foreach (Smer u in smerovi)
                {
                    SmerView SmerPrikaz=new SmerView(u);
                    SmerPrikaz.Predmeti = u.Predmeti.Select(p => new PripadaView(p)).ToList();
                    SmerPrikaz.Ucenici = u.Ucenici.Select(p => new UcenikView(p)).ToList();
                   Smerovi.Add(SmerPrikaz);
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return Smerovi;
        }

        public static SmerView GetSmer(int id)
        {
            SmerView smerPrikaz;

            try
            {
                ISession s = DataLayer.GetSession();

                Smer u = s.Load<Smer>(id);

                smerPrikaz = new SmerView(u);
                smerPrikaz.Predmeti = u.Predmeti.Select(p => new PripadaView(p)).ToList();
                smerPrikaz.Ucenici = u.Ucenici.Select(p => new UcenikView(p)).ToList();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return smerPrikaz;
        }

        public static void DodajSmer(SmerView u)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Smer novaOcena = new Smer
                {                  
                    Naziv=u.Naziv,
                    MaxBroj = u.MaxBroj
                };

                s.SaveOrUpdate(novaOcena);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void IzmeniSmer(SmerView smer)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Smer o = s.Load<Smer>(smer.Id);
                o.Naziv = smer.Naziv;
                o.MaxBroj = smer.MaxBroj;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void IzbrisiSmer(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Smer smer = s.Load<Smer>(id);

                s.Delete(smer);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

        }
        #endregion

        #region Roditelj

        public static List<RoditeljView> GetRoditelji()
        {
            List<RoditeljView> Roditelji = new List<RoditeljView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Roditelj> roditelji = from o in s.Query<Roditelj>()
                                            select o;

                foreach (Roditelj u in roditelji)
                {
                    RoditeljView roditeljPrikaz = new RoditeljView(u);
                    Roditelji.Add(roditeljPrikaz);
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return Roditelji;
        }

        public static RoditeljView GetRoditelj(int id)
        {
            RoditeljView roditeljPrikaz;

            try
            {
                ISession s = DataLayer.GetSession();

                Roditelj u = s.Load<Roditelj>(id);

                roditeljPrikaz = new RoditeljView(u);
               

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return roditeljPrikaz;
        }

        public static void DodajRoditelja(RoditeljView u)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Ucenik ucenik= s.Load<Ucenik>(u.PripadaUceniku.UpisniBroj);

                Roditelj noviRoditelj = new Roditelj
                {

                    Ime = u.Ime,
                    Prezime = u.Prezime,
                    BrojTelefona = u.BrojTelefona,
                    PripadaUceniku = ucenik
                };

                s.SaveOrUpdate(noviRoditelj);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void IzmeniRoditelja(RoditeljView roditelj)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Roditelj o = s.Load<Roditelj>(roditelj.Id);
                o.Ime = roditelj.Ime;
                o.Prezime = roditelj.Prezime;
                o.BrojTelefona = roditelj.BrojTelefona;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static void IzbrisiRoditelja(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Roditelj roditelj = s.Load<Roditelj>(id);

                s.Delete(roditelj);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

        }
        #endregion

        #region Zaposleni
        public static List<NastavnoOsobljeView> GetNastavnoOsobljePunaNorma()
        {
            List<NastavnoOsobljeView> nastavnoOsobljePN = new List<NastavnoOsobljeView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<NastavnoOsoblje> punaNormaZaposleni = from o in s.Query<NastavnoOsoblje>()
                                                         where o.PunaNorma=="Da"
                                                  select o;

                foreach (NastavnoOsoblje u in punaNormaZaposleni)
                {
                    NastavnoOsobljeView zaposleniZaPrikaz = new NastavnoOsobljeView(u);
                    zaposleniZaPrikaz.Adrese = u.Adrese.Select(p => new AdresaStanovanjaView(p)).ToList();
                    zaposleniZaPrikaz.Predmeti = u.Predmeti.Select(p => new AngazovanView(p)).ToList();
                    zaposleniZaPrikaz.Skole = u.Skole.Select(p => new SkolaView(p)).ToList();
                    nastavnoOsobljePN.Add(zaposleniZaPrikaz);
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return nastavnoOsobljePN;
        }

        public static List<NastavnoOsobljeView> GetNastavnoOsobljeBezNorme()
        {
            List<NastavnoOsobljeView> nastavnoOsobljeBN = new List<NastavnoOsobljeView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<NastavnoOsoblje> bezNormaZaposleni = from o in s.Query<NastavnoOsoblje>()
                                                                  where o.BezNorme == "Da"
                                                                  select o;

                foreach (NastavnoOsoblje u in bezNormaZaposleni)
                {
                    NastavnoOsobljeView zaposleniZaPrikaz = new NastavnoOsobljeView(u);
                    zaposleniZaPrikaz.Adrese = u.Adrese.Select(p => new AdresaStanovanjaView(p)).ToList();
                    zaposleniZaPrikaz.Predmeti = u.Predmeti.Select(p => new AngazovanView(p)).ToList();
                    zaposleniZaPrikaz.Skole = u.Skole.Select(p => new SkolaView(p)).ToList();
                    nastavnoOsobljeBN.Add(zaposleniZaPrikaz);
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return nastavnoOsobljeBN;
        }

        public static List<NenastavnoOsobljeView> GetNenastavnoOsoblje()
        {
            List<NenastavnoOsobljeView> nenastavnoOsoblje = new List<NenastavnoOsobljeView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<NenastavnoOsoblje> NenastavnoZaposleni = from o in s.Query<NenastavnoOsoblje>()
                                                         //        where o.TipZaposlenja== "NENASTAVNO"
                                                                     select o;

                foreach (NenastavnoOsoblje u in NenastavnoZaposleni)
                {
                    NenastavnoOsobljeView zaposleniZaPrikaz = new NenastavnoOsobljeView(u);
                    zaposleniZaPrikaz.Adrese= u.Adrese.Select(p => new AdresaStanovanjaView(p)).ToList();
                    nenastavnoOsoblje.Add(zaposleniZaPrikaz);
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return nenastavnoOsoblje;
        }
        #endregion


    }
}