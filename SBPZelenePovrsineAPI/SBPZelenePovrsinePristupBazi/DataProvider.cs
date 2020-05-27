using NHibernate;
using SBPZelenePovrsinePristupBazi.DTOs;
using SBPZelenePovrsinePristupBazi.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBPZelenePovrsinePristupBazi
{
    public class DataProvider
    {
        #region ZelenePovrsine
        public static List<ZelenaPovrsinaView> VratiZelenePovrsine()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<ZelenaPovrsina> zelenePovrsine = s.QueryOver<ZelenaPovrsina>()
                                                        .OrderBy(x => x.Id)
                                                        .Asc.List<ZelenaPovrsina>();

                List<ZelenaPovrsinaView> returnValue = new List<ZelenaPovrsinaView>();

                foreach (ZelenaPovrsina zp in zelenePovrsine)
                {
                    ZelenaPovrsinaView zelenaPovrsina = new ZelenaPovrsinaView(zp);
                    returnValue.Add(zelenaPovrsina);
                }

                s.Close();

                return returnValue;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return new List<ZelenaPovrsinaView>();
            }
        }
        #region Drvoredi
        public static void ObrisiDrvored(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Drvored d = s.Get<Drvored>(id);

                s.Delete(d);
                s.Flush();

                s.Close();
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void IzmeniDrvored(DrvoredView drvored)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Drvored d = s.Get<Drvored>(drvored.Id);

                d.Ulica = drvored.Ulica;
                d.Duzina = drvored.Duzina;
                d.BrojStabala = drvored.BrojStabala;
                d.VrstaDrveta = drvored.VrstaDrveta;

                s.SaveOrUpdate(d);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void SacuvajDrvored(DrvoredView drvored)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Drvored d = new Drvored();

                d.Ulica = drvored.Ulica;
                d.Duzina = drvored.Duzina;
                d.BrojStabala = drvored.BrojStabala;
                d.VrstaDrveta = drvored.VrstaDrveta;
                d.ZonaUgrozenosti = drvored.ZonaUgrozenosti;
                d.TipPovrsine = drvored.TipPovrsine;
                d.Opstina = drvored.Opstina;

                s.Save(d);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static DrvoredView VratiDrvored(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Drvored d = s.Get<Drvored>(id);

                DrvoredView drvored = new DrvoredView(d);

                s.Close();

                return drvored;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static List<DrvoredView> VratiDrvorede()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Drvored> drvoredi = s.QueryOver<Drvored>()
                                           .OrderBy(x => x.Id).Asc
                                           .List<Drvored>();

                List<DrvoredView> returnValue = new List<DrvoredView>();

                foreach(Drvored d in drvoredi)
                {
                    DrvoredView drvored = new DrvoredView(d);
                    returnValue.Add(drvored);
                }

                s.Close();

                return returnValue;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }
        #endregion

        #region Travnjaci
        public static void ObrisiTravnjak(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Travnjak t = s.Get<Travnjak>(id);

                s.Delete(t);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void IzmeniTravnjak(TravnjakView travnjak)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Travnjak t = s.Get<Travnjak>(travnjak.Id);

                t.AdresaZgrade = travnjak.AdresaZgrade;
                t.Povrsina = travnjak.Povrsina;

                s.SaveOrUpdate(t);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void SacuvajTravnjak(TravnjakView travnjak)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Travnjak t = new Travnjak();

                t.AdresaZgrade = travnjak.AdresaZgrade;
                t.Povrsina = travnjak.Povrsina;
                t.ZonaUgrozenosti = travnjak.ZonaUgrozenosti;
                t.Opstina = travnjak.Opstina;
                t.TipPovrsine = travnjak.TipPovrsine;

                s.Save(t);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static TravnjakView VratiTravnjak(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Travnjak t = s.Get<Travnjak>(id);

                TravnjakView travnjak = new TravnjakView(t);

                s.Close();

                return travnjak;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static List<TravnjakView> VratiTravnjake()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Travnjak> travnjaci = s.QueryOver<Travnjak>()
                                           .OrderBy(x => x.Id).Asc
                                           .List<Travnjak>();

                List<TravnjakView> returnValue = new List<TravnjakView>();

                foreach (Travnjak t in travnjaci)
                {
                    TravnjakView travnjak = new TravnjakView(t);
                    returnValue.Add(travnjak);
                }

                s.Close();

                return returnValue;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }
        #endregion
        #endregion

        #region Radnici

        public static List<RadnikView> VratiRadnike()
        {
            List<RadnikView> returnValue = new List<RadnikView>();

            try
            {
                ISession s = DataLayer.GetSession();
                IList<Radnik> radnici = s.QueryOver<Radnik>().List<Radnik>();

                foreach (Radnik r in radnici)
                {
                    RadnikView rv = new RadnikView(r);
                    returnValue.Add(rv);
                }

                s.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return returnValue;
        }

        public static RadnikView VratiOdredjenogRadnika(string brKnjizice)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Radnik radnik = s.Get<Radnik>(brKnjizice);
                RadnikView radnikView = new RadnikView(radnik);

                s.Close();

                return radnikView;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void ObrisiRadnika(string brKnjizice)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Radnik radnik = s.Get<Radnik>(brKnjizice);
                s.Delete(radnik);
                s.Flush();
                s.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #region RadniciOdrzavanjeZelenila

        public static List<RadnikOdrzavanjeZelenilaView> VratiRadnikeOdrzavanjeZelenila()
        {
            List<RadnikOdrzavanjeZelenilaView> returnValue = new List<RadnikOdrzavanjeZelenilaView>();

            try
            {
                ISession s = DataLayer.GetSession();
                ISQLQuery sqlQuery = s.CreateSQLQuery("SELECT * FROM RADNIK WHERE TIP_ANGAZOVANJA = 'Održavanje zelenila'");
                sqlQuery.AddEntity(typeof(RadnikOdrzavanjeZelenila));
                IList<RadnikOdrzavanjeZelenila> radnici = sqlQuery.List<RadnikOdrzavanjeZelenila>();

                foreach (RadnikOdrzavanjeZelenila r in radnici)
                {
                    RadnikOdrzavanjeZelenilaView rv = new RadnikOdrzavanjeZelenilaView(r);
                    returnValue.Add(rv);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return returnValue;
        }

        public static RadnikOdrzavanjeZelenilaView VratiOdredjenogRadnikaOdrzavanjeZelenila(string brKnjizice)
        {
            
            try
            {
                ISession s = DataLayer.GetSession();

                ISQLQuery sqlQuery = s.CreateSQLQuery("SELECT * FROM RADNIK WHERE BR_RADNE_KNJIZICE = ? AND TIP_ANGAZOVANJA = ?");
                sqlQuery.SetParameter(0, brKnjizice);
                sqlQuery.SetParameter(1, "Održavanje zelenila");
                sqlQuery.AddEntity(typeof(RadnikOdrzavanjeZelenila));

                RadnikOdrzavanjeZelenila radnik = sqlQuery.UniqueResult<RadnikOdrzavanjeZelenila>();

                RadnikOdrzavanjeZelenilaView radnikView = new RadnikOdrzavanjeZelenilaView(radnik);

                s.Close();

                return radnikView;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void SacuvajRadnikaOdrzavanjeZelenila(RadnikOdrzavanjeZelenilaView radnikView)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadnikOdrzavanjeZelenila radnik = new RadnikOdrzavanjeZelenila();
                radnik.BrRadneKnjizice = radnikView.BrRadneKnjizice;
                radnik.MBr = radnikView.MBr;
                radnik.Ime = radnikView.Ime;
                radnik.ImeRoditelja = radnikView.ImeRoditelja;
                radnik.Prezime = radnikView.Prezime;
                radnik.Adresa = radnikView.Adresa;
                radnik.DatumRodjenja = radnikView.DatumRodjenja;
                radnik.StrucnaSprema = radnikView.StrucnaSprema;

                s.Save(radnik);
                s.Flush();

                s.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void IzmeniRadnikaOdrzavanjeZelenila(RadnikOdrzavanjeZelenilaView radnikView)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadnikOdrzavanjeZelenila radnik = s.Load<RadnikOdrzavanjeZelenila>(radnikView.BrRadneKnjizice);
                radnik.MBr = radnikView.MBr;
                radnik.Ime = radnikView.Ime;
                radnik.ImeRoditelja = radnikView.ImeRoditelja;
                radnik.Prezime = radnikView.Prezime;
                radnik.Adresa = radnikView.Adresa;
                radnik.DatumRodjenja = radnikView.DatumRodjenja;
                radnik.StrucnaSprema = radnikView.StrucnaSprema;

                s.SaveOrUpdate(radnik);
                s.Flush();
                s.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion
        #endregion
    }
}
