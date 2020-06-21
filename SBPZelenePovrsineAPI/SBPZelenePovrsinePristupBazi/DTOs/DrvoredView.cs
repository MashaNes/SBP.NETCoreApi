using SBPZelenePovrsinePristupBazi.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBPZelenePovrsinePristupBazi.DTOs
{
    public class DrvoredView : ZelenaPovrsinaView
    {
        public String Ulica { get; set; }
        public float? Duzina { get; set; }
        public int? BrojStabala { get; set; }
        public String VrstaDrveta { get; set; }

        public DrvoredView()
        {

        }

        public DrvoredView(Drvored d) : base(d)
        {
            Ulica = d.Ulica;
            Duzina = d.Duzina;
            BrojStabala = d.BrojStabala;
            VrstaDrveta = d.VrstaDrveta;
        }
    }
}
