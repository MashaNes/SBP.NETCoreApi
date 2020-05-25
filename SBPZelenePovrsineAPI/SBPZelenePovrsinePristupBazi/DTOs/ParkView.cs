using System;
using System.Collections.Generic;
using System.Text;
using SBPZelenePovrsinePristupBazi.Entiteti;

namespace SBPZelenePovrsinePristupBazi.DTOs
{
    public class ParkView : ZelenaPovrsinaView
    {
        public float? Povrsina { get; set; }
        public String Naziv { get; set; }

        public virtual IList<RadiUView> Radnici { get; set; }
        public virtual IList<JeSefView> Sefovi { get; set; }
        public virtual IList<ObjekatView> Objekti { get; set; }

        public ParkView()
        {
            Radnici = new List<RadiUView>();
            Sefovi = new List<JeSefView>();
            Objekti = new List<ObjekatView>();
        }

        public ParkView(Park p) : base(p)
        {
            Povrsina = p.Povrsina;
            Naziv = p.Naziv;
        }
    }
}
