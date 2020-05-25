using System;
using System.Collections.Generic;
using System.Text;
using SBPZelenePovrsinePristupBazi.Entiteti;

namespace SBPZelenePovrsinePristupBazi.DTOs
{
    public class ObjekatView
    {
        public int Id { get; protected set; }
        public int RedniBroj { get; set; }

        public ParkView Park { get; set; }

        public ObjekatView()
        {

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

        }

        public KlupaView(Klupa k) : base(k)
        {

        }
    }

    public class FontanaView : ObjekatView
    {
        public FontanaView()
        {

        }

        public FontanaView(Fontana f) : base(f)
        {

        }
    }

    public class SvetiljkaView : ObjekatView
    {
        public SvetiljkaView()
        {

        }

        public SvetiljkaView(Svetiljka s) : base(s)
        {

        }
    }

    public class IgralisteView : ObjekatView
    {
        public int? BrojIgracaka { get; set; }
        public int StarostDeceOd { get; set; }
        public int StarostDeceDo { get; set; }
        public String Pesak { get; set; }

        public IgralisteView()
        {

        }

        public IgralisteView(Igraliste i) : base(i)
        {
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

        }

        public SpomenikView(Spomenik s) : base(s)
        {

        }
    }

    public class SkulpturaView : ObjekatView
    {
        public ZasticenView Zasticen { get; set; }

        public SkulpturaView()
        {

        }

        public SkulpturaView(Skulptura s) : base(s)
        {

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

        public DrvoView()
        {

        }

        public DrvoView(Drvo d) : base(d)
        {
            Vrsta = d.Vrsta;
            ObimDebla = d.ObimDebla;
            DatumSadnje = d.DatumSadnje;
            VisinaKrosnje = d.VisinaKrosnje;
            PovrsinaPokrivanja = d.PovrsinaPokrivanja;
        }
    }
}
