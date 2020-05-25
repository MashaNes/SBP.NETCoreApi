using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBPZelenePovrsinePristupBazi.Entiteti
{
    public class JeSef
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime DatumOd { get; set; }
        public virtual DateTime? DatumDo { get; set; }

        public virtual Radnik Radnik { get; set; }
        public virtual Park Park { get; set; }
    }
}
