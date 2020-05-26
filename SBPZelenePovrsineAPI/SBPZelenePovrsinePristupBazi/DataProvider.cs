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
        #endregion
    }
}
