using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using Skola.Entiteti;

namespace Skola
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdPrikazivanjeUcenika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();//identity map zivi od ovog krerianja ili otvaranja sesije pa sve do s.Close(); tu krece Unit of Wok

                //Nhibernate koristi lazy load, podaci se ucitavaju u trenutnu kada su nam neophodni, to znaci da se tek kada pristupimo
                //sa u.Ime onda je on generisao upit, tada se aktivira Lazy Load, Unit of Work, Identity Map i Lazy Load!!!
                Ucenik u = s.Load<Ucenik>(4);

                MessageBox.Show(u.Ime + " " + u.Prezime);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjeUcenika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ucenik u = new Entiteti.Ucenik();

                u.Ime = "Janko";
                u.Prezime = "Jankovic";
                u.Razred = 2;
                u.Adresa = "Knjazevacka 24";
                u.DatumUpisa = new DateTime(2018, 08, 05);

                //s.Save(p);
                s.SaveOrUpdate(u);//ovde se poziva insert naredba, sve naredbe koje poziva NHibernate su parametrizovane

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdPrikazivanjeOcene_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Ocena o = s.Load<Ocena>(4);

                MessageBox.Show(o.NumVrednost + " " + o.TekstualniOpis + " " + o.DatumOcenjivanja.ToShortDateString().ToString());

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdOneToManyUcenikOcena_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o uceniku sa zadatim brojem
                Ucenik u = s.Load<Ucenik>(1);

                foreach (Ocena o in u.Ocene)
                {
                    MessageBox.Show(o.NumVrednost + " " + o.TekstualniOpis + " " + o.DatumOcenjivanja);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToOneUcenikOcena_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o oceni
                Ocena o = s.Load<Ocena>(5);

                MessageBox.Show(o.PripadaUceniku.Ime);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjeSmera_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Smer sm = new Smer();

                //p = s.Load<Entiteti.Prodavnica>(81);

                sm.Naziv = "Opsti";
                sm.MaxBroj = 30;


                //s.Save(p);
                s.SaveOrUpdate(sm);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdPrikazivanjePredmeta_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Predmet o = s.Load<Predmet>(4);

                MessageBox.Show(o.Naziv);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToOneUcenikSmer_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o oceni
                Ucenik o = s.Load<Ucenik>(5);

                MessageBox.Show(o.PripadaSmeru.Naziv);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjeUcenikaNaSmer_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ucenik u = new Entiteti.Ucenik();

                u.Ime = "Marijana";
                u.Prezime = "Marinkovic";
                u.Razred = 3;
                u.Adresa = "Knjazevacka 50";
                u.DatumUpisa = new DateTime(2017, 08, 15);

                //Smer sm = s.Load<Smer>(2);

                Smer sm = new Smer();
                sm.Naziv = "Bilingvalno-francuski jezik";
                sm.MaxBroj = 15;
                sm.Ucenici.Add(u);

                u.PripadaSmeru = sm;

                s.SaveOrUpdate(sm);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdOneToManyPredmetOcene_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o predmetu sa zadatim brojem
                Predmet u = s.Load<Predmet>(1);

                foreach (Ocena o in u.Ocene)
                {
                    MessageBox.Show(o.NumVrednost + " " + o.TekstualniOpis + " " + o.DatumOcenjivanja);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjeRoditelja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Roditelj u = new Roditelj();

                u.Ime = "Marijana";
                u.Prezime = "Zivkovic";
                u.BrojTelefona = 0625668423;

                Ucenik uc = s.Load<Ucenik>(2);
                uc.Roditelji.Add(u);
                u.PripadaUceniku = uc;

                s.SaveOrUpdate(uc);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmd_ManyToManyPredmetSmer_Click(object sender, EventArgs e)
        {
            try

            {
                ISession s = DataLayer.GetSession();

                Smer s1 = s.Load<Smer>(1);

                foreach (Pripada p1 in s1.Predmeti)
                {
                    MessageBox.Show(p1.PripadaSmeru.Naziv);
                }


                Predmet p2 = s.Load<Predmet>(4);

                foreach (Pripada r2 in p2.Smerovi)
                {
                    MessageBox.Show(r2.ImaPredmet.Naziv);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdPrikaziZaposlenog_Click(object sender, EventArgs e)
        {
            try

            {
                ISession s = DataLayer.GetSession();

                NastavnoOsoblje z = s.Load<NastavnoOsoblje>(1612998730022);
                MessageBox.Show(z.Ime);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToManyNastavnikPredmet_Click(object sender, EventArgs e)
        {
            try

            {
                ISession s = DataLayer.GetSession();

                Predmet s1 = s.Load<Predmet>(1);

                foreach (Angazovan p1 in s1.Nastavnici)
                {
                    MessageBox.Show(p1.Nastavnik.Ime);
                }


                NastavnoOsoblje p2 = s.Load<NastavnoOsoblje>(2402981735061);

                foreach (Angazovan r2 in p2.Predmeti)
                {
                    MessageBox.Show(r2.Predmet.Naziv);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void Godine_Click(object sender, EventArgs e)
        {
            try

            {
                ISession s = DataLayer.GetSession();

                Predmet s1 = s.Load<Predmet>(1);

                foreach (Godina p1 in s1.Godine)
                {
                    MessageBox.Show(p1.godina.ToString());
                }


                Godina p2 = s.Load<Godina>(1);

                MessageBox.Show(p2.Predmet.Naziv);


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdBrisanjeUcenika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ucenik u = s.Load<Ucenik>(25);

                s.Delete(u);
                s.Flush();



                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
                MessageBox.Show(ec.Message);

            }
        }

        private void cmdAzuriranjeUcenika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ucenik u = s.Load<Ucenik>(21);
                Smer smer = s.Load<Smer>(2);


                u.PripadaSmeru = smer;

                s.Update(u);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);

            }

        }

        private void cmdOneToManyUcenikSmer_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Smer smer = s.Load<Smer>(1);

                foreach (Ucenik o in smer.Ucenici)
                {
                    MessageBox.Show(o.Ime + " " + o.Prezime);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdVisevrednosniSkole_Click(object sender, EventArgs e)
        {
            try

            {
                ISession s = DataLayer.GetSession();

                NastavnoOsoblje s1 = s.Load<NastavnoOsoblje>(910971715065);

                foreach (Skola.Entiteti.Skola p1 in s1.Skole)
                {
                    MessageBox.Show(p1.skola.ToString());
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdVisevrednosniAdresa_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                NastavnoOsoblje s1 = s.Load<NastavnoOsoblje>(910971715065);

                foreach (AdresaStanovanja p1 in s1.Adrese)
                {
                    MessageBox.Show(p1.Adresa);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjeOcene_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ocena o = new Ocena();

                o.NumVrednost = 5;
                o.TekstualniOpis = "Odlican";
                o.DatumOcenjivanja = DateTime.Now;

                Predmet p = s.Load<Predmet>(1);
                o.PripadaPredmetu = p;

                Ucenik u = s.Load<Ucenik>(1);
                o.PripadaUceniku = u;

                s.Save(o);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdBrisanjeOcene_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ocena o = s.Load<Ocena>(41);

                s.Delete(o);

                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void cmdAzuriranjeOcene_Click(object sender, EventArgs e)
        {
            try
            {
                    ISession s = DataLayer.GetSession();

                Ocena o = s.Load<Ocena>(21);

                Predmet p = s.Load<Predmet>(2);

                o.NumVrednost = 1;
                o.TekstualniOpis = "Nedovoljan";
                o.PripadaPredmetu = p;

                s.Update(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToOnePredmetOcene_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ocena o = s.Load<Ocena>(5);

                MessageBox.Show(o.PripadaPredmetu.Naziv);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdPrikazivanjeSmera_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Smer smer = s.Load<Smer>(2);

                MessageBox.Show(smer.Naziv + " " + smer.MaxBroj);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdBrisanjeSmera_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Smer o = s.Load<Smer>(101);

                s.Delete(o);

                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzuriranjeSmera_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Smer smer = s.Load<Smer>(1);
                smer.MaxBroj = 93;

                s.Update(smer);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjeOceneUceniku_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ucenik u = s.Load<Ucenik>(2);

                Predmet p = s.Load<Predmet>(4);

                Ocena o = new Ocena();
                o.NumVrednost = 2;
                o.TekstualniOpis = "Dovoljan";
                o.PripadaUceniku = u;
                o.PripadaPredmetu = p;

                u.Ocene.Add(o);

                s.Update(u);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjePredmeta_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet o = new Predmet();

                o.Naziv = "Muzicka kultura";
             
                s.Save(o);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdBrisanjePredmeta_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet o = s.Load<Predmet>(21);

                s.Delete(o);

                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzuriranjePredmeta_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Predmet p = s.Load<Predmet>(7);


                p.Naziv = "Informatika i racunarstvo";

                s.Update(p);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjeOcenePredmetu_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                Ocena o = new Ocena();
                o.NumVrednost = 5;
                o.TekstualniOpis = "Odlican";

                Predmet p = s.Load<Predmet>(7);
                Ucenik u = s.Load<Ucenik>(1);
                p.Ocene.Add(o);
                o.PripadaPredmetu = p;
                o.PripadaUceniku = u;
                //Cascade example
                s.Update(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdPrikazivanjeRoditelja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Roditelj r = s.Load<Roditelj>(2);

                MessageBox.Show(r.Ime+" "+r.Prezime+" "+r.PripadaUceniku.Ime);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdBrisanjeRoditelja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Roditelj o = s.Load<Roditelj>(101);

                s.Delete(o);

                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzuriranjeRoditelja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Roditelj p = s.Load<Roditelj>(3);


                p.BrojTelefona = 0691612198;

                s.Update(p);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjeNenastavnog_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                NenastavnoOsoblje u = new NenastavnoOsoblje();

                u.JMBG = 1612972730022;
                u.Ime = "Jovan";
                u.Prezime = "Stojkovic";
                u.ImeRoditelja = "Rade";
                u.Sektor = "Administracija";
                u.StrucnaSprema = "Srednja";
                u.DatumRodjenja = new DateTime(1972, 12, 16);

                s.SaveOrUpdate(u);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjeNastavnogPN_Click_1(object sender, EventArgs e)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                NastavnoOsoblje u = new NastavnoOsoblje();

                u.JMBG = 1512983730022;
                u.Ime = "Jelena";
                u.Prezime = "Stanic";
                u.ImeRoditelja = "Mirko";
                u.PunaNorma = "Da";
                u.DatumRodjenja = new DateTime(1983, 12, 15);

                //s.Save(p);
                s.SaveOrUpdate(u);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodavanjeNastavnogBN_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                NastavnoOsoblje u = new NastavnoOsoblje();

                u.JMBG = 1506983730022;
                u.Ime = "Jelena";
                u.Prezime = "Jovic";
                u.ImeRoditelja = "Miroslav";
                u.BezNorme = "Da";
                u.BrojCasova = 100;
                u.DatumRodjenja = new DateTime(1983, 06, 15);

                s.SaveOrUpdate(u);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdBrisanjeZaposlenog_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zaposleni o = s.Load<Zaposleni>(1612998730022);

                s.Delete(o);

                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
