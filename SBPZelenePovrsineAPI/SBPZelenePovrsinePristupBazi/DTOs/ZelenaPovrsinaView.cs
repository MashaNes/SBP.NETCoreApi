using System;
using System.Collections.Generic;
using System.Text;
using SBPZelenePovrsinePristupBazi.Entiteti;

namespace SBPZelenePovrsinePristupBazi.DTOs
{
    public class ZelenaPovrsinaView
    {
        public int Id { get; set; }
        public String ZonaUgrozenosti { get; set; }
        public String Opstina { get; set; }
        public String TipPovrsine { get; set; }

        public ZelenaPovrsinaView()
        {

        }

        public ZelenaPovrsinaView(ZelenaPovrsina z)
        {
            Id = z.Id;
            ZonaUgrozenosti = z.ZonaUgrozenosti;
            Opstina = z.Opstina;
            TipPovrsine = z.TipPovrsine;
        }
    }
}
