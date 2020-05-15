using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBPZelenePovrsine.Entiteti
{
    public class Zasticen
    {
        public virtual int Id { get; protected set; }
        public virtual string Opis { get; set; }
        public virtual float NovcanaNaknada { get; set; }
        public virtual string Institucija { get; set; }
        public virtual DateTime DatumStavljanja { get; set; }
    }
}
