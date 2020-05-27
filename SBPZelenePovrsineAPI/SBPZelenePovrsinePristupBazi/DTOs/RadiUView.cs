using System;
using System.Collections.Generic;
using System.Text;
using SBPZelenePovrsinePristupBazi.Entiteti;

namespace SBPZelenePovrsinePristupBazi.DTOs
{
    public class RadiUView
    {
        public int Id { get; protected set; }
        public DateTime DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }

        public RadnikView Radnik { get; set; }
        public ParkView Park { get; set; }

        public RadiUView() { }

        public RadiUView(RadiU radiU)
        {
            Id = radiU.Id;
            DatumOd = radiU.DatumOd;
            DatumDo = radiU.DatumDo;
            Radnik = new RadnikView(radiU.Radnik);
            Park = new ParkView(radiU.Park);
        }
    }
}
