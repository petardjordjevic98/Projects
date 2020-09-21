using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Cfg;//ovo je ono sto ce da koristimoo
using FluentNHibernate.Cfg.Db;
using Skola.Mapiranja;

namespace Skola
{//Table first approcah, znaci vec imamo gotoovu tabelu tj bazu zatim pisemo kod
    class DataLayer
    {
        private static ISessionFactory _factory = null;//da bismo obezbdili jednu instancu IsessionFactory-ja, iskoristicemo Singlteon
        private static object objLock = new object();


        //funkcija na zahtev otvara sesiju
        //ovaj ISession se koristi za rad sa sesijama, obezbedjuju metode za osnovne CRUD operacije, obezbedjuje perzisentciju objekata,
        //mozemo da ih snimimo u Relacionu Bazu Podataka,
        //trajanje Unity of Work odgovara sesiji, tj trajanju sesije, a unutar sesije se cuva IDentity Map, svi objekti koji se ucitaju u okviru sesije se 
        //cuvaju u IDentity map, ako nam treba neki sa istim Id-om onda se on ne ucitava opet vec se nalazi u Identity Map strukturi
        public static ISession GetSession()
        {
            //ukoliko session factory nije kreiran
            if (_factory == null)//ako je factory null, treba ga kreirati, treba da radi u vise niti, koristi se thread safe verzija singltona
                //imamo objekat objLock on ce nam sluziti kao mutex, sluze da se implementria kiriticna sekcija
            {
                lock (objLock)//ako je null treba da se zakljuca ovaj objekat, ukoliko uspe da zakljuca objekat, ako nije kreiran onda se poziva C
                //CreateSessionFactory
                {
                    if (_factory == null)
                        _factory = CreateSessionFactory();
                }
            }

            return _factory.OpenSession();
        }

        //konfiguracija i kreiranje session factory
        private static ISessionFactory CreateSessionFactory()//ovaj interfejs obezbedjuje metode za kreiranje Isession-a, u aplikaciji se kreira samo
            //jedna instanca ovog interfejsa jer je zahtevan, jedan ISessionFactory pozivamo da bismo kreirali sesije, za svaku bazu podataka poseban
            //ISession-a, Obezbedjuje kesiranje drugog nivoa, tj da kod njega definisemo mehanizam za kesiranje, mogu da prezive gasenje sesije...
        {
            try
            {
                var cfg = OracleManagedDataClientConfiguration.Oracle10
                .ConnectionString(c =>
                    c.Is("DATA SOURCE=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;PERSIST SECURITY INFO=True;USER ID=S16697;Password=sanja2404"));

                return Fluently.Configure()
                    .Database(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UcenikMapiranje>())
                    //.ExposeConfiguration(BuildSchema)
                    .BuildSessionFactory();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
                return null;
            }
        }
    }
}
