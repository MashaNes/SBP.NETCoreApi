using NHibernate;
using SBPZelenePovrsinePristupBazi.DTOs;
using SBPZelenePovrsinePristupBazi.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static ZelenaPovrsinaView VratiZelenuPovrsinu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZelenaPovrsina zp = s.Get<ZelenaPovrsina>(id);

                if(zp.GetType() == typeof(Drvored))
                {
                    Drvored d = zp as Drvored;
                    DrvoredView drvored = new DrvoredView(d);
                    s.Close();
                    return drvored;
                }
                else if(zp.GetType() == typeof(Travnjak))
                {
                    Travnjak t = zp as Travnjak;
                    TravnjakView travnjak = new TravnjakView(t);
                    s.Close();
                    return travnjak;
                }
                else if (zp.GetType() == typeof(Park))
                {
                    Park p = zp as Park;
                    ParkView park = new ParkView(p);

                    foreach (RadiU ru in p.Radnici)
                    {
                        RadiUView ruv = new RadiUView(ru);
                        ruv.Park = null;
                        park.Radnici.Add(ruv);
                    }

                    foreach (JeSef js in p.Sefovi)
                    {
                        JeSefView jsv = new JeSefView(js);
                        jsv.Park = null;
                        park.Sefovi.Add(jsv);
                    }

                    park.Objekti = p.Objekti.Select(x => new ObjekatView(x)).ToList();
                    
                    /*foreach(Objekat o in p.Objekti)
                    {
                        if(o.GetType() == typeof(Spomenik))
                        {
                            Spomenik sp = o as Spomenik;
                            SpomenikView spv = new SpomenikView(sp);
                            if (sp.Zasticen != null)
                                spv.Zasticen = new ZasticenView(sp.Zasticen);
                            park.Objekti.Add(spv);
                        }
                        else if (o.GetType() == typeof(Skulptura))
                        {
                            Skulptura sk = o as Skulptura;
                            SkulpturaView skv = new SkulpturaView(sk);
                            if (sk.Zasticen != null)
                                skv.Zasticen = new ZasticenView(sk.Zasticen);
                            park.Objekti.Add(skv);
                        }
                        else if (o.GetType() == typeof(Fontana))
                        {
                            Fontana f = o as Fontana;
                            park.Objekti.Add(new FontanaView(f));
                        }
                        else if (o.GetType() == typeof(Klupa))
                        {
                            Klupa k = o as Klupa;
                            park.Objekti.Add(new KlupaView(k));
                        }
                        else if (o.GetType() == typeof(Svetiljka))
                        {
                            Svetiljka sv = o as Svetiljka;
                            park.Objekti.Add(new SvetiljkaView(sv));
                        }
                        else if (o.GetType() == typeof(Igraliste))
                        {
                            Igraliste i = (Igraliste)o;
                            park.Objekti.Add(new IgralisteView(i));
                        }
                        else
                        {
                            Drvo d = o as Drvo;
                            DrvoView dv = new DrvoView(d);
                            if (d.Zasticen != null)
                                dv.Zasticen = new ZasticenView(d.Zasticen);
                            park.Objekti.Add(dv);
                        }
                    }*/

                    s.Close();
                    return park;
                }

                ZelenaPovrsinaView zelenaPovrsina = new ZelenaPovrsinaView(zp);

                s.Close();

                return zelenaPovrsina;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void ObrisiZelenuPovrsinu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                ZelenaPovrsina zp = s.Get<ZelenaPovrsina>(id);

                s.Delete(zp);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
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

        #region Parkovi
        public static void ObrisiPark(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Park p = s.Get<Park>(id);

                s.Delete(p);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void IzmeniPark(ParkView park)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Park p = s.Get<Park>(park.Id);

                p.Povrsina = park.Povrsina;
                p.Naziv = park.Naziv;

                s.SaveOrUpdate(p);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void SacuvajPark(ParkView park)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Park p = new Park();

                p.Povrsina = park.Povrsina;
                p.Naziv = park.Naziv;
                p.ZonaUgrozenosti = park.ZonaUgrozenosti;
                p.TipPovrsine = park.TipPovrsine;
                p.Opstina = park.Opstina;

                s.Save(p);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static ParkView VratiPark(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Park p = s.Get<Park>(id);

                ParkView park = new ParkView(p);

                foreach (RadiU ru in p.Radnici)
                {
                    RadiUView ruv = new RadiUView(ru);
                    ruv.Park = null;
                    park.Radnici.Add(ruv);
                }

                foreach (JeSef js in p.Sefovi)
                {
                    JeSefView jsv = new JeSefView(js);
                    jsv.Park = null;
                    park.Sefovi.Add(jsv);
                }

                park.Objekti = p.Objekti.Select(x => new ObjekatView(x)).ToList();

                s.Close();

                return park;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static List<ParkView> VratiParkove()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Park> parkovi = s.QueryOver<Park>()
                                       .OrderBy(x => x.Id).Asc
                                       .List<Park>();

                List<ParkView> returnValue = new List<ParkView>();

                foreach (Park p in parkovi)
                {
                    ParkView park = new ParkView(p);

                    foreach(RadiU ru in p.Radnici)
                    {
                        RadiUView ruv = new RadiUView(ru);
                        ruv.Park = null;
                        park.Radnici.Add(ruv);
                    }

                    foreach (JeSef js in p.Sefovi)
                    {
                        JeSefView jsv = new JeSefView(js);
                        jsv.Park = null;
                        park.Sefovi.Add(jsv);
                    }

                    park.Objekti = p.Objekti.Select(x => new ObjekatView(x)).ToList();
                    returnValue.Add(park);
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
