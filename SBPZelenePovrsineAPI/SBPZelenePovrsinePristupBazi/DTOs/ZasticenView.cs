using System;
using System.Collections.Generic;
using System.Text;
using SBPZelenePovrsinePristupBazi.Entiteti;

namespace SBPZelenePovrsinePristupBazi.DTOs
{
    public class ZasticenView
    {
        public int Id { get; protected set; }
        public string Opis { get; set; }
        public float NovcanaNaknada { get; set; }
        public string Institucija { get; set; }
        public DateTime DatumStavljanja { get; set; }

        public ZasticenView() { }

        public ZasticenView(Zasticen zasticen)
        {
            Id = zasticen.Id;
            Opis = zasticen.Opis;
            NovcanaNaknada = zasticen.NovcanaNaknada;
            Institucija = zasticen.Institucija;
            DatumStavljanja = zasticen.DatumStavljanja;
        }
    }
}
