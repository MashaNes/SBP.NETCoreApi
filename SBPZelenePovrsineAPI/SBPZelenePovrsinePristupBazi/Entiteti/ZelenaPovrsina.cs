using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBPZelenePovrsinePristupBazi.Entiteti
{
    public class ZelenaPovrsina
    {
        public virtual int Id { get; protected set; }
        public virtual String ZonaUgrozenosti { get; set; }
        public virtual String Opstina { get; set; }
        public virtual String TipPovrsine { get; set; }
    }
}
