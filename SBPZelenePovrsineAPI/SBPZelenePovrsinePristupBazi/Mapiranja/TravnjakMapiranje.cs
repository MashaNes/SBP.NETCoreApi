using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBPZelenePovrsinePristupBazi.Entiteti;
using FluentNHibernate.Mapping;

namespace SBPZelenePovrsinePristupBazi.Mapiranja
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
