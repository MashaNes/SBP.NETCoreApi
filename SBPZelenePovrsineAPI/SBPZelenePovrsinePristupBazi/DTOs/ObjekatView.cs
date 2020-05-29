using System;
using System.Collections.Generic;
using System.Text;
using SBPZelenePovrsinePristupBazi.Entiteti;

namespace SBPZelenePovrsinePristupBazi.DTOs
{
    public class ObjekatView
    {
        public int Id { get; set; }
        public int RedniBroj { get; set; }

        public ParkView Park { get; set; }

        public String TipObjekta { get; protected set; }
        public virtual String Detalji { get; protected set; }

        public ObjekatView()
        {
            Detalji = "/";
        }

        public ObjekatView(Objekat o)
        {
            Id = o.Id;
            RedniBroj = o.RedniBroj;
        }
    }

    public class KlupaView : ObjekatView
    {
        public KlupaView()
        {
            TipObjekta = "Klupa";
        }

        public KlupaView(Klupa k) : base(k)
        {
            TipObjekta = "Klupa";
        }
    }

    public class FontanaView : ObjekatView
    {
        public FontanaView()
        {
            TipObjekta = "Fontana";
        }

        public FontanaView(Fontana f) : base(f)
        {
            TipObjekta = "Fontana";
        }
    }

    public class SvetiljkaView : ObjekatView
    {
        public SvetiljkaView()
        {
            TipObjekta = "Svetiljka";
        }

        public SvetiljkaView(Svetiljka s) : base(s)
        {
            TipObjekta = "Svetiljka";
        }
    }

    public class IgralisteView : ObjekatView
    {
        public int? BrojIgracaka { get; set; }
        public int StarostDeceOd { get; set; }
        public int StarostDeceDo { get; set; }
        public String Pesak { get; set; }

        public override string Detalji 
        { 
            get 
            {
                String rez = "Za decu od " + StarostDeceOd + " do " + StarostDeceDo + " godina. ";
                rez += (Pesak == "Da" ? "Ima pesak. " : "Nema pesak. ");
                rez += (BrojIgracaka == null ? "" : "Broj igračaka: " + BrojIgracaka);
                return rez;
            } 
            protected set => base.Detalji = value; 
        }

        public IgralisteView()
        {
            TipObjekta = "Igralište";
        }

        public IgralisteView(Igraliste i) : base(i)
        {
            TipObjekta = "Igralište";
            BrojIgracaka = i.BrojIgracaka;
            StarostDeceOd = i.StarostDeceOd;
            StarostDeceDo = i.StarostDeceDo;
            Pesak = i.Pesak;
        }
    }

    public class SpomenikView : ObjekatView
    {
        public ZasticenView Zasticen { get; set; }

        public SpomenikView()
        {
            TipObjekta = "Spomenik";
            Detalji = "Pod zaštitom države.";
        }

        public SpomenikView(Spomenik s) : base(s)
        {
            TipObjekta = "Spomenik";
            Detalji = "Pod zaštitom države.";
        }
    }

    public class SkulpturaView : ObjekatView
    {
        public ZasticenView Zasticen { get; set; }

        public SkulpturaView()
        {
            TipObjekta = "Skulptura";
            Detalji = "Pod zaštitom države.";
        }

        public SkulpturaView(Skulptura s) : base(s)
        {
            TipObjekta = "Skulptura";
            Detalji = "Pod zaštitom države.";
        }
    }

    public class DrvoView : ObjekatView
    {
        public String Vrsta { get; set; }
        public float? ObimDebla { get; set; }
        public DateTime? DatumSadnje { get; set; }
        public float? VisinaKrosnje { get; set; }
        public float? PovrsinaPokrivanja { get; set; }

        public ZasticenView Zasticen { get; set; }

        public override string Detalji
        {
            get
            {
                String rez = "Vrsta drveta: " + Vrsta + ". ";
                rez += (ObimDebla == null ? "" : "Obim debla: " + ObimDebla + "m. ");
                rez += (VisinaKrosnje == null ? "" : "Visina krošnje: " + VisinaKrosnje + "m. ");
                rez += (PovrsinaPokrivanja == null ? "" : "Površina pokrivanja: " + PovrsinaPokrivanja + "m^2. ");
                rez += (DatumSadnje == null ? "" : "Datum sadnje: " + DatumSadnje.Value.ToShortDateString() + ". ");
                rez += (Zasticen == null ? "Nije pod zaštitom države." : "Pod zaštitom države.");
                return rez;
            }
            protected set => base.Detalji = value; 
        }

        public DrvoView()
        {
            TipObjekta = "Drvo";
        }

        public DrvoView(Drvo d) : base(d)
        {
            TipObjekta = "Drvo";
            Vrsta = d.Vrsta;
            ObimDebla = d.ObimDebla;
            DatumSadnje = d.DatumSadnje;
            VisinaKrosnje = d.VisinaKrosnje;
            PovrsinaPokrivanja = d.PovrsinaPokrivanja;
        }
    }
}
