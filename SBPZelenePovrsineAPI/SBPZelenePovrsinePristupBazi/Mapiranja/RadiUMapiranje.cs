using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBPZelenePovrsinePristupBazi.Entiteti;
using FluentNHibernate.Mapping;

namespace SBPZelenePovrsinePristupBazi.Mapiranja
{
    public class RadiUMapiranje : ClassMap<RadiU>
    {
        public RadiUMapiranje()
        {
            Table("RADI_U");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.DatumOd, "DATUM_OD");
            Map(x => x.DatumDo, "DATUM_DO");

            References(x => x.Radnik).Column("RADNIK_BR").LazyLoad();
            References(x => x.Park).Column("PARK_ID").LazyLoad();
        }
    }
}
