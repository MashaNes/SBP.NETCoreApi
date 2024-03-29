﻿using NHibernate;
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
                throw;
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

                    park.Radnici = vratiListuRadiU(p);
                    park.Sefovi = vratiListuJeSef(p);
                    park.Objekti = vratiListuObjekat(p);

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

                park.Radnici = vratiListuRadiU(p);
                park.Sefovi = vratiListuJeSef(p);
                park.Objekti = vratiListuObjekat(p);

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
                    
                    park.Radnici = vratiListuRadiU(p);
                    park.Sefovi = vratiListuJeSef(p);
                    park.Objekti = vratiListuObjekat(p);
                    
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

        private static IList<RadiUView> vratiListuRadiU(Park p)
        {
            IList<RadiUView> radiULista = new List<RadiUView>();
            foreach (RadiU ru in p.Radnici)
            {
                RadiUView ruv = new RadiUView(ru);
                ruv.Park = null;
                radiULista.Add(ruv);
            }

            return radiULista;
        }

        private static IList<JeSefView> vratiListuJeSef(Park p)
        {
            IList<JeSefView> jeSefLista = new List<JeSefView>();
            foreach (JeSef js in p.Sefovi)
            {
                JeSefView jsv = new JeSefView(js);
                jsv.Park = null;
                jeSefLista.Add(jsv);
            }

            return jeSefLista;
        }

        private static IList<ObjekatView> vratiListuObjekat(Park p)
        {
            IList<ObjekatView> objekatLista = new List<ObjekatView>();

            foreach (Objekat o in p.Objekti)
            {
                if (o.GetType() == typeof(Spomenik))
                {
                    Spomenik sp = o as Spomenik;
                    SpomenikView spv = new SpomenikView(sp);
                    if (sp.Zasticen != null)
                        spv.Zasticen = new ZasticenView(sp.Zasticen);
                    objekatLista.Add(spv);
                }
                else if (o.GetType() == typeof(Skulptura))
                {
                    Skulptura sk = o as Skulptura;
                    SkulpturaView skv = new SkulpturaView(sk);
                    if (sk.Zasticen != null)
                        skv.Zasticen = new ZasticenView(sk.Zasticen);
                    objekatLista.Add(skv);
                }
                else if (o.GetType() == typeof(Fontana))
                {
                    Fontana f = o as Fontana;
                    objekatLista.Add(new FontanaView(f));
                }
                else if (o.GetType() == typeof(Klupa))
                {
                    Klupa k = o as Klupa;
                    objekatLista.Add(new KlupaView(k));
                }
                else if (o.GetType() == typeof(Svetiljka))
                {
                    Svetiljka sv = o as Svetiljka;
                    objekatLista.Add(new SvetiljkaView(sv));
                }
                else if (o.GetType() == typeof(Igraliste))
                {
                    Igraliste i = (Igraliste)o;
                    objekatLista.Add(new IgralisteView(i));
                }
                else
                {
                    Drvo d = o as Drvo;
                    DrvoView dv = new DrvoView(d);
                    if (d.Zasticen != null)
                        dv.Zasticen = new ZasticenView(d.Zasticen);
                    objekatLista.Add(dv);
                }
            }

            return objekatLista;
        }
        #endregion
        #endregion

        #region Objekti

        public static List<ObjekatView> VratiObjekte()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Objekat> objekti = s.QueryOver<Objekat>()
                                          .OrderBy(x => x.Id)
                                          .Asc.List<Objekat>();

                List<ObjekatView> returnValue = new List<ObjekatView>();

                foreach (Objekat o in objekti)
                {
                    if (o.GetType() == typeof(Spomenik))
                    {
                        Spomenik sp = o as Spomenik;
                        SpomenikView spv = new SpomenikView(sp);
                        if (sp.Zasticen != null)
                            spv.Zasticen = new ZasticenView(sp.Zasticen);
                        spv.Park = new ParkView(o.Park);
                        returnValue.Add(spv);
                    }
                    else if (o.GetType() == typeof(Skulptura))
                    {
                        Skulptura sk = o as Skulptura;
                        SkulpturaView skv = new SkulpturaView(sk);
                        if (sk.Zasticen != null)
                            skv.Zasticen = new ZasticenView(sk.Zasticen);
                        skv.Park = new ParkView(o.Park);
                        returnValue.Add(skv);
                    }
                    else if (o.GetType() == typeof(Fontana))
                    {
                        Fontana f = o as Fontana;
                        FontanaView fv = new FontanaView(f);
                        fv.Park = new ParkView(o.Park);
                        returnValue.Add(fv);
                    }
                    else if (o.GetType() == typeof(Klupa))
                    {
                        Klupa k = o as Klupa;
                        KlupaView kv = new KlupaView(k);
                        kv.Park = new ParkView(o.Park);
                        returnValue.Add(kv);
                    }
                    else if (o.GetType() == typeof(Svetiljka))
                    {
                        Svetiljka sv = o as Svetiljka;
                        SvetiljkaView svv = new SvetiljkaView(sv);
                        svv.Park = new ParkView(o.Park);
                        returnValue.Add(svv);
                    }
                    else if (o.GetType() == typeof(Igraliste))
                    {
                        Igraliste i = o as Igraliste;
                        IgralisteView iv = new IgralisteView(i);
                        iv.Park = new ParkView(o.Park);
                        returnValue.Add(iv);
                    }
                    else
                    {
                        Drvo d = o as Drvo;
                        DrvoView dv = new DrvoView(d);
                        if (d.Zasticen != null)
                            dv.Zasticen = new ZasticenView(d.Zasticen);
                        dv.Park = new ParkView(o.Park);
                        returnValue.Add(dv);
                    }
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

        public static IList<ObjekatView> VratiObjekteIzParka(int parkID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Park p = s.Get<Park>(parkID);

                IList<ObjekatView> lista = vratiListuObjekat(p);

                s.Close();

                return lista;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static ObjekatView VratiObjekat(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Objekat o = s.Get<Objekat>(id);

                if (o.GetType() == typeof(Spomenik))
                {
                    Spomenik sp = o as Spomenik;
                    SpomenikView spv = new SpomenikView(sp);
                    if (sp.Zasticen != null)
                        spv.Zasticen = new ZasticenView(sp.Zasticen);
                    s.Close();
                    return spv;
                }
                else if (o.GetType() == typeof(Skulptura))
                {
                    Skulptura sk = o as Skulptura;
                    SkulpturaView skv = new SkulpturaView(sk);
                    if (sk.Zasticen != null)
                        skv.Zasticen = new ZasticenView(sk.Zasticen);
                    s.Close();
                    return skv;
                }
                else if (o.GetType() == typeof(Fontana))
                {
                    Fontana f = o as Fontana;
                    s.Close();
                    return new FontanaView(f);
                }
                else if (o.GetType() == typeof(Klupa))
                {
                    Klupa k = o as Klupa;
                    s.Close();
                    return new KlupaView(k);
                }
                else if (o.GetType() == typeof(Svetiljka))
                {
                    Svetiljka sv = o as Svetiljka;
                    s.Close();
                    return new SvetiljkaView(sv);
                }
                else if (o.GetType() == typeof(Igraliste))
                {
                    Igraliste i = (Igraliste)o;
                    s.Close();
                    return new IgralisteView(i);
                }
                else
                {
                    Drvo d = o as Drvo;
                    DrvoView dv = new DrvoView(d);
                    if (d.Zasticen != null)
                        dv.Zasticen = new ZasticenView(d.Zasticen);
                    s.Close();
                    return dv;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void ObrisiObjekat(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Objekat o = s.Get<Objekat>(id);

                s.Delete(o);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        #region Klupe

        public static void ObrisiKlupu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Klupa k = s.Get<Klupa>(id);

                s.Delete(k);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void DodajKlupuUPark(KlupaView k, int parkID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Klupa klupa = new Klupa();
                klupa.RedniBroj = k.RedniBroj;

                Park p = s.Get<Park>(parkID);
                klupa.Park = p;
                p.Objekti.Add(klupa);

                s.Update(p);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void IzmeniKlupu(KlupaView klupa)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Klupa k = s.Get<Klupa>(klupa.Id);

                k.RedniBroj = klupa.RedniBroj;

                s.SaveOrUpdate(k);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static KlupaView VratiKlupu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Klupa k = s.Get<Klupa>(id);

                KlupaView klupa = new KlupaView(k);
                klupa.Park = new ParkView(k.Park);

                s.Close();

                return klupa;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static List<KlupaView> VratiKlupe()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Klupa> klupe = s.QueryOver<Klupa>()
                                      .OrderBy(x => x.Id).Asc
                                      .List<Klupa>();

                List<KlupaView> returnValue = new List<KlupaView>();

                foreach (Klupa k in klupe)
                {
                    KlupaView klupa = new KlupaView(k);
                    klupa.Park = new ParkView(k.Park);
                    returnValue.Add(klupa);
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

        public static List<KlupaView> VratiKlupeIzParka(int parkID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Klupa> klupe = s.QueryOver<Klupa>()
                                      .Where(x => x.Park.Id == parkID)
                                      .OrderBy(x => x.RedniBroj).Asc
                                      .List<Klupa>();

                List<KlupaView> returnValue = new List<KlupaView>();

                foreach (Klupa k in klupe)
                {
                    KlupaView klupa = new KlupaView(k);
                    returnValue.Add(klupa);
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

        #region Fontane

        public static void ObrisiFontanu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Fontana f = s.Get<Fontana>(id);

                s.Delete(f);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void DodajFontanuUPark(FontanaView k, int parkID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Fontana fontana = new Fontana();
                fontana.RedniBroj = k.RedniBroj;

                Park p = s.Get<Park>(parkID);
                fontana.Park = p;
                p.Objekti.Add(fontana);

                s.Update(p);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void IzmeniFontanu(FontanaView fontana)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Fontana f = s.Get<Fontana>(fontana.Id);

                f.RedniBroj = fontana.RedniBroj;

                s.SaveOrUpdate(f);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static FontanaView VratiFontanu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Fontana f = s.Get<Fontana>(id);

                FontanaView fontana = new FontanaView(f);
                fontana.Park = new ParkView(f.Park);

                s.Close();

                return fontana;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static List<FontanaView> VratiFontane()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Fontana> fontane = s.QueryOver<Fontana>()
                                          .OrderBy(x => x.Id).Asc
                                          .List<Fontana>();

                List<FontanaView> returnValue = new List<FontanaView>();

                foreach (Fontana f in fontane)
                {
                    FontanaView fontana = new FontanaView(f);
                    fontana.Park = new ParkView(f.Park);
                    returnValue.Add(fontana);
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

        public static List<FontanaView> VratiFontaneIzParka(int parkID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Fontana> fontane = s.QueryOver<Fontana>()
                                          .Where(x => x.Park.Id == parkID)
                                          .OrderBy(x => x.RedniBroj).Asc
                                          .List<Fontana>();

                List<FontanaView> returnValue = new List<FontanaView>();

                foreach (Fontana f in fontane)
                {
                    FontanaView fontana = new FontanaView(f);
                    returnValue.Add(fontana);
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

        #region Svetiljke

        public static void ObrisiSvetiljku(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Svetiljka sv = s.Get<Svetiljka>(id);

                s.Delete(sv);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void DodajSvetiljkuUPark(SvetiljkaView sv, int parkID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Svetiljka svetiljka = new Svetiljka();
                svetiljka.RedniBroj = sv.RedniBroj;

                Park p = s.Get<Park>(parkID);
                svetiljka.Park = p;
                p.Objekti.Add(svetiljka);

                s.Update(p);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void IzmeniSvetiljku(SvetiljkaView svetiljka)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Svetiljka sv = s.Get<Svetiljka>(svetiljka.Id);

                sv.RedniBroj = svetiljka.RedniBroj;

                s.SaveOrUpdate(sv);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static SvetiljkaView VratiSvetiljku(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Svetiljka sv = s.Get<Svetiljka>(id);

                SvetiljkaView svetiljka = new SvetiljkaView(sv);
                svetiljka.Park = new ParkView(sv.Park);

                s.Close();

                return svetiljka;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static List<SvetiljkaView> VratiSvetiljke()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Svetiljka> svetiljke = s.QueryOver<Svetiljka>()
                                              .OrderBy(x => x.Id).Asc
                                              .List<Svetiljka>();

                List<SvetiljkaView> returnValue = new List<SvetiljkaView>();

                foreach (Svetiljka sv in svetiljke)
                {
                    SvetiljkaView svetiljka = new SvetiljkaView(sv);
                    svetiljka.Park = new ParkView(sv.Park);
                    returnValue.Add(svetiljka);
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

        public static List<SvetiljkaView> VratiSvetiljkeIzParka(int parkID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Svetiljka> svetiljke = s.QueryOver<Svetiljka>()
                                              .Where(x => x.Park.Id == parkID)
                                              .OrderBy(x => x.RedniBroj).Asc
                                              .List<Svetiljka>();

                List<SvetiljkaView> returnValue = new List<SvetiljkaView>();

                foreach (Svetiljka sv in svetiljke)
                {
                    SvetiljkaView svetiljka = new SvetiljkaView(sv);
                    returnValue.Add(svetiljka);
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

        #region Igralista

        public static void ObrisiIgraliste(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Igraliste i = s.Get<Igraliste>(id);

                s.Delete(i);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void DodajIgraliste(IgralisteView i, int parkID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                
                Igraliste igraliste = new Igraliste();
                
                igraliste.StarostDeceOd = i.StarostDeceOd;
                igraliste.StarostDeceDo = i.StarostDeceDo;
                igraliste.Pesak = i.Pesak;
                igraliste.BrojIgracaka = i.BrojIgracaka;
                igraliste.RedniBroj = i.RedniBroj;

                Park p = s.Get<Park>(parkID);
                igraliste.Park = p;
                p.Objekti.Add(igraliste);

                s.Update(p);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void IzmeniIgraliste(IgralisteView igraliste)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Igraliste i = s.Get<Igraliste>(igraliste.Id);

                i.StarostDeceOd = igraliste.StarostDeceOd;
                i.StarostDeceDo = igraliste.StarostDeceDo;
                i.Pesak = igraliste.Pesak;
                i.BrojIgracaka = igraliste.BrojIgracaka;
                i.RedniBroj = igraliste.RedniBroj;

                s.SaveOrUpdate(i);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static IgralisteView VratiIgraliste(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Igraliste i = s.Get<Igraliste>(id);

                IgralisteView svetiljka = new IgralisteView(i);
                svetiljka.Park = new ParkView(i.Park);

                s.Close();

                return svetiljka;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static List<IgralisteView> VratiIgralista()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Igraliste> igralista = s.QueryOver<Igraliste>()
                                              .OrderBy(x => x.Id).Asc
                                              .List<Igraliste>();

                List<IgralisteView> returnValue = new List<IgralisteView>();

                foreach (Igraliste i in igralista)
                {
                    IgralisteView igraliste = new IgralisteView(i);
                    igraliste.Park = new ParkView(i.Park);
                    returnValue.Add(igraliste);
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

        public static List<IgralisteView> VratiIgralistaIzParka(int parkID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Igraliste> igralista = s.QueryOver<Igraliste>()
                                              .Where(x => x.Park.Id == parkID)
                                              .OrderBy(x => x.RedniBroj).Asc
                                              .List<Igraliste>();

                List<IgralisteView> returnValue = new List<IgralisteView>();

                foreach (Igraliste i in igralista)
                {
                    IgralisteView igraliste = new IgralisteView(i);
                    returnValue.Add(igraliste);
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

        #region Spomenici

        public static void ObrisiSpomenik(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Spomenik sp = s.Get<Spomenik>(id);

                s.Delete(sp);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void DodajSpomenik(SpomenikView sp, int parkID)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Spomenik spomenik = new Spomenik();

                spomenik.RedniBroj = sp.RedniBroj;
                spomenik.Zasticen = new Zasticen();
                spomenik.Zasticen.DatumStavljanja = sp.Zasticen.DatumStavljanja;
                spomenik.Zasticen.Institucija = sp.Zasticen.Institucija;
                spomenik.Zasticen.NovcanaNaknada = sp.Zasticen.NovcanaNaknada;
                spomenik.Zasticen.Opis = sp.Zasticen.Opis;

                Park p = s.Get<Park>(parkID);
                spomenik.Park = p;
                p.Objekti.Add(spomenik);

                s.Update(p);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void IzmeniSpomenik(SpomenikView spomenik)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Spomenik sp = s.Get<Spomenik>(spomenik.Id);

                sp.RedniBroj = spomenik.RedniBroj;

                s.SaveOrUpdate(sp);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static SpomenikView VratiSpomenik(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Spomenik sp = s.Get<Spomenik>(id);

                SpomenikView spomenik = new SpomenikView(sp);
                spomenik.Park = new ParkView(sp.Park);
                spomenik.Zasticen = new ZasticenView(sp.Zasticen);

                s.Close();

                return spomenik;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static List<SpomenikView> VratiSpomenike()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Spomenik> spomenici = s.QueryOver<Spomenik>()
                                             .OrderBy(x => x.Id).Asc
                                             .List<Spomenik>();

                List<SpomenikView> returnValue = new List<SpomenikView>();

                foreach (Spomenik sp in spomenici)
                {
                    SpomenikView spomenik = new SpomenikView(sp);
                    spomenik.Park = new ParkView(sp.Park);
                    spomenik.Zasticen = new ZasticenView(sp.Zasticen);
                    returnValue.Add(spomenik);
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

        public static List<SpomenikView> VratiSpomenikeIzParka(int parkID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Spomenik> spomenici = s.QueryOver<Spomenik>()
                                             .Where(x => x.Park.Id == parkID)
                                             .OrderBy(x => x.RedniBroj).Asc
                                             .List<Spomenik>();

                List<SpomenikView> returnValue = new List<SpomenikView>();

                foreach (Spomenik sp in spomenici)
                {
                    SpomenikView spomenik = new SpomenikView(sp);
                    spomenik.Zasticen = new ZasticenView(sp.Zasticen);
                    returnValue.Add(spomenik);
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

        #region Skulpture

        public static void ObrisiSkulpturu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Skulptura sp = s.Get<Skulptura>(id);

                s.Delete(sp);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void DodajSkulpturu(SkulpturaView sk, int parkID)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Skulptura skulptura = new Skulptura();

                skulptura.RedniBroj = sk.RedniBroj;
                skulptura.Zasticen = new Zasticen();
                skulptura.Zasticen.DatumStavljanja = sk.Zasticen.DatumStavljanja;
                skulptura.Zasticen.Institucija = sk.Zasticen.Institucija;
                skulptura.Zasticen.NovcanaNaknada = sk.Zasticen.NovcanaNaknada;
                skulptura.Zasticen.Opis = sk.Zasticen.Opis;

                Park p = s.Get<Park>(parkID);
                skulptura.Park = p;
                p.Objekti.Add(skulptura);

                s.Update(p);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void IzmeniSkulpturu(SkulpturaView skulptura)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Skulptura sk = s.Get<Skulptura>(skulptura.Id);

                sk.RedniBroj = skulptura.RedniBroj;

                s.SaveOrUpdate(sk);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static SkulpturaView VratiSkulpturu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Skulptura sk = s.Get<Skulptura>(id);

                SkulpturaView skulptura = new SkulpturaView(sk);
                skulptura.Park = new ParkView(sk.Park);
                skulptura.Zasticen = new ZasticenView(sk.Zasticen);

                s.Close();

                return skulptura;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static List<SkulpturaView> VratiSkulpture()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Skulptura> skulpture = s.QueryOver<Skulptura>()
                                              .OrderBy(x => x.Id).Asc
                                              .List<Skulptura>();

                List<SkulpturaView> returnValue = new List<SkulpturaView>();

                foreach (Skulptura sk in skulpture)
                {
                    SkulpturaView skulptura = new SkulpturaView(sk);
                    skulptura.Park = new ParkView(sk.Park);
                    skulptura.Zasticen = new ZasticenView(sk.Zasticen);
                    returnValue.Add(skulptura);
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

        public static List<SkulpturaView> VratiSkulptureIzParka(int parkID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Skulptura> skulpture = s.QueryOver<Skulptura>()
                                              .Where(x => x.Park.Id == parkID)
                                              .OrderBy(x => x.RedniBroj).Asc
                                              .List<Skulptura>();

                List<SkulpturaView> returnValue = new List<SkulpturaView>();

                foreach (Skulptura sk in skulpture)
                {
                    SkulpturaView skulptura = new SkulpturaView(sk);
                    skulptura.Zasticen = new ZasticenView(sk.Zasticen);
                    returnValue.Add(skulptura);
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

        #region Drvece

        public static void ObrisiDrvo(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Drvo d = s.Get<Drvo>(id);

                s.Delete(d);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void DodajDrvo(DrvoView d, int parkID)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Drvo drvo = new Drvo();

                drvo.RedniBroj = d.RedniBroj;
                drvo.Vrsta = d.Vrsta;
                drvo.ObimDebla = d.ObimDebla;
                drvo.DatumSadnje = d.DatumSadnje;
                drvo.VisinaKrosnje = d.VisinaKrosnje;
                drvo.PovrsinaPokrivanja = d.PovrsinaPokrivanja;

                if (d.Zasticen != null)
                {
                    drvo.Zasticen = new Zasticen();
                    drvo.Zasticen.DatumStavljanja = d.Zasticen.DatumStavljanja;
                    drvo.Zasticen.Institucija = d.Zasticen.Institucija;
                    drvo.Zasticen.NovcanaNaknada = d.Zasticen.NovcanaNaknada;
                    drvo.Zasticen.Opis = d.Zasticen.Opis;
                }

                Park p = s.Get<Park>(parkID);
                drvo.Park = p;
                p.Objekti.Add(drvo);

                s.Update(p);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static void IzmeniDrvo(DrvoView d)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Drvo drvo = s.Get<Drvo>(d.Id);

                drvo.RedniBroj = d.RedniBroj;
                drvo.Vrsta = d.Vrsta;
                drvo.ObimDebla = d.ObimDebla;
                drvo.DatumSadnje = d.DatumSadnje;
                drvo.VisinaKrosnje = d.VisinaKrosnje;
                drvo.PovrsinaPokrivanja = d.PovrsinaPokrivanja;

                s.SaveOrUpdate(drvo);
                s.Flush();

                s.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static DrvoView VratiDrvo(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Drvo d = s.Get<Drvo>(id);

                DrvoView drvo = new DrvoView(d);
                drvo.Park = new ParkView(d.Park);
                if(d.Zasticen != null)
                    drvo.Zasticen = new ZasticenView(d.Zasticen);

                s.Close();

                return drvo;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static List<DrvoView> VratiDrvece()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Drvo> drvece = s.QueryOver<Drvo>()
                                      .OrderBy(x => x.Id).Asc
                                      .List<Drvo>();

                List<DrvoView> returnValue = new List<DrvoView>();

                foreach (Drvo d in drvece)
                {
                    DrvoView drvo = new DrvoView(d);
                    drvo.Park = new ParkView(d.Park);
                    if(d.Zasticen != null)
                        drvo.Zasticen = new ZasticenView(d.Zasticen);
                    returnValue.Add(drvo);
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

        public static List<DrvoView> VratiDrveceIzParka(int parkID)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Drvo> drvece = s.QueryOver<Drvo>()
                                      .Where(x => x.Park.Id == parkID)
                                      .OrderBy(x => x.RedniBroj).Asc
                                      .List<Drvo>();

                List<DrvoView> returnValue = new List<DrvoView>();

                foreach (Drvo d in drvece)
                {
                    DrvoView drvo = new DrvoView(d);
                    if(d.Zasticen != null)
                        drvo.Zasticen = new ZasticenView(d.Zasticen);
                    returnValue.Add(drvo);
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
                    rv.Parkovi = VratiRadnikoveParkove(r);
                    rv.SefParkova = VratiRadnikovaSefovanja(r);
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
                radnikView.Parkovi = VratiRadnikoveParkove(radnik);
                radnikView.SefParkova = VratiRadnikovaSefovanja(radnik);

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

        public static IList<RadiUView> VratiRadnikoveParkove(Radnik r)
        {
            IList<RadiUView> returnValue = new List<RadiUView>();
            foreach(RadiU ru in r.Parkovi)
            {
                RadiUView ruv = new RadiUView(ru);
                ruv.Radnik = null;
                returnValue.Add(ruv);
            }
            return returnValue;
        }

        public static IList<JeSefView> VratiRadnikovaSefovanja(Radnik r)
        {
            IList<JeSefView> returnValue = new List<JeSefView>();
            foreach (JeSef js in r.SefParkova)
            {
                JeSefView jsv = new JeSefView(js);
                jsv.Radnik = null;
                returnValue.Add(jsv);
            }
            return returnValue;
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
                    rv.Parkovi = VratiRadnikoveParkove(r);
                    rv.SefParkova = VratiRadnikovaSefovanja(r);
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
                radnikView.Parkovi = VratiRadnikoveParkove(radnik);
                radnikView.SefParkova = VratiRadnikovaSefovanja(radnik);

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

        public static void ObrisiRadnikaOdrzavanjeZelenila(string brKnjizice)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadnikOdrzavanjeZelenila radnik = s.Get<RadnikOdrzavanjeZelenila>(brKnjizice);
                s.Delete(radnik);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }



        #endregion

        #region RadniciOdrzavanjeHigijene

        public static List<RadnikOdrzavanjeHigijeneView> VratiRadnikeOdrzavanjeHigijene()
        {
            List<RadnikOdrzavanjeHigijeneView> returnValue = new List<RadnikOdrzavanjeHigijeneView>();

            try
            {
                ISession s = DataLayer.GetSession();
                IList<RadnikOdrzavanjeHigijene> radnici = s.Query<RadnikOdrzavanjeHigijene>().ToList();

                foreach (RadnikOdrzavanjeHigijene r in radnici)
                {
                    RadnikOdrzavanjeHigijeneView rv = new RadnikOdrzavanjeHigijeneView(r);
                    rv.Parkovi = VratiRadnikoveParkove(r);
                    rv.SefParkova = VratiRadnikovaSefovanja(r);
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

        public static RadnikOdrzavanjeHigijeneView VratiOdredjenogRadnikaOdrzavanjeHigijene(string brKnjizice)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                ISQLQuery sqlQuery = s.CreateSQLQuery("SELECT * FROM RADNIK WHERE BR_RADNE_KNJIZICE = ? AND TIP_ANGAZOVANJA = ?");
                sqlQuery.SetParameter(0, brKnjizice);
                sqlQuery.SetParameter(1, "Održavanje higijene");
                sqlQuery.AddEntity(typeof(RadnikOdrzavanjeHigijene));

                RadnikOdrzavanjeHigijene radnik = sqlQuery.UniqueResult<RadnikOdrzavanjeHigijene>();

                RadnikOdrzavanjeHigijeneView radnikView = new RadnikOdrzavanjeHigijeneView(radnik);
                radnikView.Parkovi = VratiRadnikoveParkove(radnik);
                radnikView.SefParkova = VratiRadnikovaSefovanja(radnik);

                s.Close();

                return radnikView;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void SacuvajRadnikaOdrzavanjeHigijene(RadnikOdrzavanjeHigijeneView radnikView)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadnikOdrzavanjeHigijene radnik = new RadnikOdrzavanjeHigijene();
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void IzmeniRadnikaOdrzavanjeHigijene(RadnikOdrzavanjeHigijeneView radnikView)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadnikOdrzavanjeHigijene radnik = s.Load<RadnikOdrzavanjeHigijene>(radnikView.BrRadneKnjizice);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void ObrisiRadnikaOdrzavanjeHigijene(string brKnjizice)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadnikOdrzavanjeHigijene radnik = s.Get<RadnikOdrzavanjeHigijene>(brKnjizice);
                s.Delete(radnik);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion

        #region RadniciOdrzavanjeObjekata

        public static List<RadnikOdrzavanjeObjekataUParkuView> VratiRadnikeOdrzavanjeObjekata()
        {
            List<RadnikOdrzavanjeObjekataUParkuView> returnValue = new List<RadnikOdrzavanjeObjekataUParkuView>();

            try
            {
                ISession s = DataLayer.GetSession();
                IList<RadnikOdrzavanjeObjekataUParku> radnici = s.Query<RadnikOdrzavanjeObjekataUParku>().ToList();

                foreach (RadnikOdrzavanjeObjekataUParku r in radnici)
                {
                    RadnikOdrzavanjeObjekataUParkuView rv = new RadnikOdrzavanjeObjekataUParkuView(r);
                    rv.Parkovi = VratiRadnikoveParkove(r);
                    rv.SefParkova = VratiRadnikovaSefovanja(r);
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

        public static RadnikOdrzavanjeObjekataUParkuView VratiOdredjenogRadnikaOdrzavanjeObjekata(string brKnjizice)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                ISQLQuery sqlQuery = s.CreateSQLQuery("SELECT * FROM RADNIK WHERE BR_RADNE_KNJIZICE = ? AND TIP_ANGAZOVANJA = ?");
                sqlQuery.SetParameter(0, brKnjizice);
                sqlQuery.SetParameter(1, "Održavanje objekata u parku");
                sqlQuery.AddEntity(typeof(RadnikOdrzavanjeObjekataUParku));

                RadnikOdrzavanjeObjekataUParku radnik = sqlQuery.UniqueResult<RadnikOdrzavanjeObjekataUParku>();

                RadnikOdrzavanjeObjekataUParkuView radnikView = new RadnikOdrzavanjeObjekataUParkuView(radnik);
                radnikView.Parkovi = VratiRadnikoveParkove(radnik);
                radnikView.SefParkova = VratiRadnikovaSefovanja(radnik);

                s.Close();

                return radnikView;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void IzmeniRadnikaOdrzavanjeObjekata(RadnikOdrzavanjeObjekataUParkuView radnikView)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadnikOdrzavanjeObjekataUParku radnik = s.Load<RadnikOdrzavanjeObjekataUParku>(radnikView.BrRadneKnjizice);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void ObrisiRadnikaOdrzavanjeObjekata(string brKnjizice)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadnikOdrzavanjeObjekataUParku radnik = s.Get<RadnikOdrzavanjeObjekataUParku>(brKnjizice);
                s.Delete(radnik);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void DodajRadnikaOdrzavanjeObjekata(RadiUView radiUView)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                RadnikOdrzavanjeObjekataUParku radnik = new RadnikOdrzavanjeObjekataUParku();
                radnik.BrRadneKnjizice = radiUView.Radnik.BrRadneKnjizice;
                radnik.MBr = radiUView.Radnik.MBr;
                radnik.Ime = radiUView.Radnik.Ime;
                radnik.ImeRoditelja = radiUView.Radnik.ImeRoditelja;
                radnik.Prezime = radiUView.Radnik.Prezime;
                radnik.Adresa = radiUView.Radnik.Adresa;
                radnik.DatumRodjenja = radiUView.Radnik.DatumRodjenja;
                radnik.StrucnaSprema = radiUView.Radnik.StrucnaSprema;

                s.Save(radnik);
                s.Flush();

                Park park = s.Load<Park>(radiUView.Park.Id);

                RadiU radniOdnos = new RadiU();
                radniOdnos.DatumOd = radiUView.DatumOd;
                radniOdnos.DatumDo = radiUView.DatumDo;
                radniOdnos.Park = park;
                radniOdnos.Radnik = radnik;

                s.Save(radniOdnos);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        #endregion

        #region RadiU

        public static void DodajRadniOdnos(RadiUView radiUView, string brKnjizice, int idParka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadiU radiU = new RadiU();
                radiU.DatumOd = radiUView.DatumOd;
                radiU.DatumDo = radiUView.DatumDo;
                radiU.Park = s.Load<Park>(idParka);
                radiU.Radnik = s.Load<Radnik>(brKnjizice);

                s.Save(radiU);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static List<RadiUView> VratiRadneOdnose()
        {
            List<RadiUView> retValue = new List<RadiUView>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<RadiU> radniOdnosi = s.Query<RadiU>().ToList();

                foreach (RadiU radniOdnos in radniOdnosi)
                {
                    RadiUView radiUView = new RadiUView(radniOdnos);
                    retValue.Add(radiUView);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return retValue;
        }

        public static RadiUView VratiRadniOdnos(int radiUId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadiU radniOdnos = s.Get<RadiU>(radiUId);
                RadiUView retVal = new RadiUView(radniOdnos);

                s.Close();

                return retVal;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static List<RadiUView> VratiRadneOdnoseRadnika(string brKnjizice)
        {
            List<RadiUView> retValue = new List<RadiUView>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<RadiU> radniOdnosi = s.Query<RadiU>()
                                           .Where(r => r.Radnik.BrRadneKnjizice == brKnjizice)
                                           .ToList();

                foreach (RadiU radniOdnos in radniOdnosi)
                {
                    RadiUView radiUView = new RadiUView(radniOdnos);
                    retValue.Add(radiUView);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return retValue;
        }

        public static List<RadiUView> VratiRadneOdnoseIzParka(int idParka)
        {
            List<RadiUView> retValue = new List<RadiUView>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<RadiU> radniOdnosi = s.Query<RadiU>()
                                           .Where(r => r.Park.Id == idParka)
                                           .ToList();

                foreach (RadiU radniOdnos in radniOdnosi)
                {
                    RadiUView radiUView = new RadiUView(radniOdnos);
                    retValue.Add(radiUView);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return retValue;
        }

        public static void IzmeniRadniOdnos(RadiUView radiUView)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadiU radniOdnos = s.Get<RadiU>(radiUView.Id);
                radniOdnos.DatumOd = radiUView.DatumOd;
                radniOdnos.DatumDo = radiUView.DatumDo;

                s.SaveOrUpdate(radniOdnos);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void IzbrisiRadniOdnos(int radiUId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadiU radniOdnos = s.Get<RadiU>(radiUId);

                s.Delete(radniOdnos);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion

        #region JeSef

        public static void DodajSefovanje(JeSefView jeSefView, string brKnjizice, int idParka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                JeSef jeSef = new JeSef();
                jeSef.DatumOd = jeSefView.DatumOd;
                jeSef.DatumDo = jeSefView.DatumDo;
                jeSef.Park = s.Load<Park>(idParka);
                jeSef.Radnik = s.Load<Radnik>(brKnjizice);

                s.Save(jeSef);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static List<JeSefView> VratiSefovanja()
        {
            List<JeSefView> retValue = new List<JeSefView>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<JeSef> sefovanja = s.Query<JeSef>().ToList();

                foreach (JeSef jeSef in sefovanja)
                {
                    JeSefView jeSefView = new JeSefView(jeSef);
                    retValue.Add(jeSefView);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return retValue;
        }

        public static JeSefView VratiSefovanje(int jeSefId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                JeSef jeSef = s.Get<JeSef>(jeSefId);

                JeSefView retVal = new JeSefView(jeSef);

                s.Close();

                return retVal;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static List<JeSefView> VratiSefovanjaRadnika(string brKnjizice)
        {
            List<JeSefView> retValue = new List<JeSefView>();

            try
            {
                ISession s = DataLayer.GetSession();

                List<JeSef> sefovanja = s.Query<JeSef>()
                                           .Where(js => js.Radnik.BrRadneKnjizice == brKnjizice)
                                           .ToList();

                foreach (JeSef sefovanje in sefovanja)
                {
                    JeSefView jeSefView = new JeSefView(sefovanje);
                    retValue.Add(jeSefView);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return retValue;
        }

        public static List<JeSefView> VratiSefovanjaIzParka(int idParka)
        {
            List<JeSefView> retValue = new List<JeSefView>();

            try
            {

                ISession s = DataLayer.GetSession();

                List<JeSef> sefovanja = s.Query<JeSef>()
                                           .Where(js => js.Park.Id == idParka)
                                           .ToList();

                foreach (JeSef sefovanje in sefovanja)
                {
                    JeSefView jeSefView = new JeSefView(sefovanje);
                    retValue.Add(jeSefView);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return retValue;
        }

        public static void IzmeniSefovanje(JeSefView jeSefView)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                JeSef sefovanje = s.Get<JeSef>(jeSefView.Id);
                sefovanje.DatumOd = jeSefView.DatumOd;
                sefovanje.DatumDo = jeSefView.DatumDo;

                s.SaveOrUpdate(sefovanje);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void IzbrisiSefovanje(int jeSefId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                JeSef sefovanje = s.Get<JeSef>(jeSefId);

                s.Delete(sefovanje);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion

        #endregion

        #region Zasticen

        public static List<ZasticenView> VratiZasticeneObjekte()
        {
            List<ZasticenView> returnValue = new List<ZasticenView>();

            try
            {
                ISession s = DataLayer.GetSession();
                IList<Zasticen> zasticeni = s.QueryOver<Zasticen>().List<Zasticen>();

                foreach (Zasticen z in zasticeni)
                {
                    ZasticenView zv = new ZasticenView(z);
                    if(z.Objekat.GetType() == typeof(Spomenik))
                    {
                        Spomenik spomenik = z.Objekat as Spomenik;
                        zv.Objekat = new SpomenikView(spomenik);
                        
                    }
                    else if(z.Objekat.GetType() == typeof(Skulptura))
                    {
                        Skulptura skulptura = z.Objekat as Skulptura;
                        zv.Objekat = new SkulpturaView(skulptura);
                    }
                    else if (z.Objekat.GetType() == typeof(Drvo))
                    {
                        Drvo drvo = z.Objekat as Drvo;
                        DrvoView dv = new DrvoView(drvo);
                        dv.Zasticen = zv;
                        zv.Objekat = dv;
                    }
                    zv.Objekat.Park = new ParkView(z.Objekat.Park);
                    returnValue.Add(zv);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return returnValue;
        }

        public static List<ZasticenView> VratiZasticeneObjekteIzParka(int idParka)
        {
            List<ZasticenView> returnValue = new List<ZasticenView>();

            try
            {
                ISession s = DataLayer.GetSession();
                IList<Zasticen> zasticeni = s.Query<Zasticen>()
                                             .Where(z => z.Objekat.Park.Id == idParka)
                                             .ToList<Zasticen>();

                foreach (Zasticen z in zasticeni)
                {
                    ZasticenView zv = new ZasticenView(z);
                    if (z.Objekat.GetType() == typeof(Spomenik))
                    {
                        Spomenik spomenik = z.Objekat as Spomenik;
                        zv.Objekat = new SpomenikView(spomenik);
                    }
                    else if (z.Objekat.GetType() == typeof(Skulptura))
                    {
                        Skulptura skulptura = z.Objekat as Skulptura;
                        zv.Objekat = new SkulpturaView(skulptura);
                    }
                    else if (z.Objekat.GetType() == typeof(Drvo))
                    {
                        Drvo drvo = z.Objekat as Drvo;
                        DrvoView dv = new DrvoView(drvo);
                        dv.Zasticen = zv;
                        zv.Objekat = dv;
                    }
                    zv.Objekat.Park = new ParkView(z.Objekat.Park);
                    returnValue.Add(zv);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return returnValue;
        }

        public static ZasticenView VratiZasticenObjekat(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zasticen zasticen = s.Get<Zasticen>(id);
                ZasticenView zasticenView = new ZasticenView(zasticen);
                if (zasticen.Objekat.GetType() == typeof(Spomenik))
                {
                    Spomenik spomenik = zasticen.Objekat as Spomenik;
                    zasticenView.Objekat = new SpomenikView(spomenik);
                }
                else if (zasticen.Objekat.GetType() == typeof(Skulptura))
                {
                    Skulptura skulptura = zasticen.Objekat as Skulptura;
                    zasticenView.Objekat = new SkulpturaView(skulptura);
                }
                else if (zasticen.Objekat.GetType() == typeof(Drvo))
                {
                    Drvo drvo = zasticen.Objekat as Drvo;
                    zasticenView.Objekat = new DrvoView(drvo);
                }
                zasticenView.Objekat.Park = new ParkView(zasticen.Objekat.Park);

                s.Close();

                return zasticenView;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void ObrisiZastitu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zasticen zasticen = s.Get<Zasticen>(id);
                Objekat objekat = s.Query<Objekat>().Where(o => o.Zasticen.Id == id).Single();

                objekat.Zasticen = null;
                s.SaveOrUpdate(objekat);
                s.Flush();

                s.Delete(zasticen);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void DodajZastituObjektu(ZasticenView zasticenView, int idObjekta)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zasticen zasticen = new Zasticen();
                zasticen.Institucija = zasticenView.Institucija;
                zasticen.NovcanaNaknada = zasticenView.NovcanaNaknada;
                zasticen.Opis = zasticenView.Opis;
                zasticen.DatumStavljanja = zasticenView.DatumStavljanja;

                Objekat objekat = s.Load<Objekat>(idObjekta);
                objekat.Zasticen = zasticen;

                s.Update(objekat);
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void IzmeniZastitu(ZasticenView zasticenView)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zasticen zasticen = s.Load<Zasticen>(zasticenView.Id);
                zasticen.Institucija = zasticenView.Institucija;
                zasticen.NovcanaNaknada = zasticenView.NovcanaNaknada;
                zasticen.Opis = zasticenView.Opis;
                zasticen.DatumStavljanja = zasticenView.DatumStavljanja;

                s.SaveOrUpdate(zasticen);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion
    }
}
