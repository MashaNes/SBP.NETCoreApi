using System;
using System.Collections.Generic;
using System.Text;
using SBPZelenePovrsinePristupBazi.Entiteti;

namespace SBPZelenePovrsinePristupBazi.DTOs
{
    public class JeSefView
    {
        public int Id { get; protected set; }
        public DateTime DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }

        public RadnikView Radnik { get; set; }
        public ParkView Park { get; set; }

        public JeSefView() { }

        public JeSefView(JeSef jeSef)
        {
            Id = jeSef.Id;
            DatumOd = jeSef.DatumOd;
            DatumDo = jeSef.DatumDo;
            Radnik = new RadnikView(jeSef.Radnik);
            Park = new ParkView(jeSef.Park);
        }
    }
}
