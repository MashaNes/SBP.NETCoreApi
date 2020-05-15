using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBPZelenePovrsine.Entiteti
{
    public class Travnjak : ZelenaPovrsina
    {
        public virtual String AdresaZgrade { get; set; }
        public virtual float? Povrsina { get; set; }
    }
}
