using System;
using System.Collections.Generic;
using System.Text;
using SBPZelenePovrsinePristupBazi.Entiteti;

namespace SBPZelenePovrsinePristupBazi.DTOs
{
    public class RadnikView
    {
        public string BrRadneKnjizice { get; set; }
        public string MBr { get; set; }
        public string Ime { get; set; }
        public string ImeRoditelja { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string StrucnaSprema { get; set; }

        public IList<RadiUView> Parkovi { get; set; }
        public IList<JeSefView> SefParkova { get; set; }

        public RadnikView()
        {
            Parkovi = new List<RadiUView>();
            SefParkova = new List<JeSefView>();
        }

        public RadnikView(Radnik radnik)
        {
            BrRadneKnjizice = radnik.BrRadneKnjizice;
            MBr = radnik.MBr;
            Ime = radnik.Ime;
            ImeRoditelja = radnik.ImeRoditelja;
            Prezime = radnik.Prezime;
            Adresa = radnik.Adresa;
            DatumRodjenja = radnik.DatumRodjenja;
            StrucnaSprema = radnik.StrucnaSprema;
        }
    }

    public class RadnikOdrzavanjeZelenilaView: RadnikView
    {
        public RadnikOdrzavanjeZelenilaView() { }

        public RadnikOdrzavanjeZelenilaView(RadnikOdrzavanjeZelenila r): base(r) { }
    }

    public class RadnikOdrzavanjeHigijeneView: RadnikView
    {
        public RadnikOdrzavanjeHigijeneView() { }
        
        public RadnikOdrzavanjeHigijeneView(RadnikOdrzavanjeHigijene r): base(r) { }
    }

    public class RadnikOdrzavanjeObjekataUParkuView: RadnikView
    {
        public RadnikOdrzavanjeObjekataUParkuView() { }

        public RadnikOdrzavanjeObjekataUParkuView(RadnikOdrzavanjeObjekataUParku r): base(r) { }
    }

}
