using System;
using System.Collections.Generic;
using System.Text;
using SBPZelenePovrsinePristupBazi.Entiteti;

namespace SBPZelenePovrsinePristupBazi.DTOs
{
    public class TravnjakView : ZelenaPovrsinaView
    {
        public String AdresaZgrade { get; set; }
        public float? Povrsina { get; set; }

        public TravnjakView()
        {

        }

        public TravnjakView(Travnjak t) : base(t)
        {
            AdresaZgrade = t.AdresaZgrade;
            Povrsina = t.Povrsina;
        }
    }
}
