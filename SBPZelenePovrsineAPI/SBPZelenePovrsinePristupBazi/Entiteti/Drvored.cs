using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBPZelenePovrsinePristupBazi.Entiteti
{
    public class Drvored : ZelenaPovrsina
    {
        public virtual String Ulica { get; set; }
        public virtual float? Duzina { get; set; }
        public virtual int? BrojStabala { get; set; }
        public virtual String VrstaDrveta { get; set; }
    }
}
