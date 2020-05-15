using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBPZelenePovrsine.Entiteti;
using FluentNHibernate.Mapping;

namespace SBPZelenePovrsine.Mapiranja
{
    public class DrvoredMapiranje : SubclassMap<Drvored>
    {
        public DrvoredMapiranje()
        {
            Table("DRVORED");
            KeyColumn("ID");

            Map(x => x.Ulica, "ULICA");
            Map(x => x.Duzina, "DUZINA");
            Map(x => x.BrojStabala, "BROJ_STABALA");
            Map(x => x.VrstaDrveta, "VRSTA_DRVETA");
        }
    }
}
