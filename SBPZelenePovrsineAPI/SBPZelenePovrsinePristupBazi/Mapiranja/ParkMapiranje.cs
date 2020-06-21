using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBPZelenePovrsinePristupBazi.Entiteti;
using FluentNHibernate.Mapping;

namespace SBPZelenePovrsinePristupBazi.Mapiranja
{
    public class ParkMapiranje : SubclassMap<Park>
    {
        public ParkMapiranje()
        {
            Table("PARK");
            KeyColumn("ID");

            Map(x => x.Povrsina, "POVRSINA");
            Map(x => x.Naziv, "NAZIV");

            HasMany(x => x.Radnici).KeyColumn("PARK_ID").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Sefovi).KeyColumn("PARK_ID").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Objekti).KeyColumn("PARK_ID").LazyLoad().Cascade.All().Inverse();
        }
    }
}
