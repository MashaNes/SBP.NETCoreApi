using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBPZelenePovrsine.Entiteti;
using FluentNHibernate.Mapping;

namespace SBPZelenePovrsine.Mapiranja
{
    public class ZelenaPovrsinaMapiranje : ClassMap<ZelenaPovrsina>
    {
        public ZelenaPovrsinaMapiranje()
        {
            Table("ZELENA_POVRSINA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.ZonaUgrozenosti, "ZONA_UGROZENOSTI");
            Map(x => x.Opstina, "OPSTINA");
            Map(x => x.TipPovrsine, "TIP_POVRSINE");
        }
    }
}
