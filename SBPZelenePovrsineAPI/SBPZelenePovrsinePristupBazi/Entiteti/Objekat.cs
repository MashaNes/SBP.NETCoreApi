using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBPZelenePovrsine.Entiteti
{
    public abstract class Objekat
    {
        public virtual int Id { get; protected set; }
        public virtual int RedniBroj { get; set; }

        public virtual Park Park { get; set; }
    }

    public class Klupa : Objekat
    {

    }

    public class Fontana : Objekat
    {

    }

    public class Svetiljka : Objekat
    {

    }

    public class Igraliste : Objekat
    {
        public virtual int? BrojIgracaka { get; set; }
        public virtual int StarostDeceOd { get; set; }
        public virtual int StarostDeceDo { get; set; }
        public virtual String Pesak { get; set; }
    }

    public class Spomenik : Objekat
    {
        public virtual Zasticen Zasticen { get; set; }
    }

    public class Skulptura : Objekat
    {
        public virtual Zasticen Zasticen { get; set; }
    }

    public class Drvo : Objekat
    {
        public virtual String Vrsta { get; set; }
        public virtual float? ObimDebla { get; set; }
        public virtual DateTime? DatumSadnje { get; set; }
        public virtual float? VisinaKrosnje { get; set; }
        public virtual float? PovrsinaPokrivanja { get; set; }

        public virtual Zasticen Zasticen { get; set; }
    }
}
