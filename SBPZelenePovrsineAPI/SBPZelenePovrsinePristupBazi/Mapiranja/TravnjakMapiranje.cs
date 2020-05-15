using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBPZelenePovrsine.Entiteti;
using FluentNHibernate.Mapping;

namespace SBPZelenePovrsine.Mapiranja
{
    public class TravnjakMapiranje : SubclassMap<Travnjak>
    {
        public TravnjakMapiranje()
        {
            Table("TRAVNJAK");
            KeyColumn("ID");

            Map(x => x.AdresaZgrade, "ADRESA_ZGRADE");
            Map(x => x.Povrsina, "POVRSINA");
        }
    }
}
