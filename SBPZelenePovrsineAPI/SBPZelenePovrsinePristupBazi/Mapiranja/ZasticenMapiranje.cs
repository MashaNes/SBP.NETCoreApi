using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBPZelenePovrsinePristupBazi.Entiteti;

namespace SBPZelenePovrsinePristupBazi.Mapiranja
{
    public class ZasticenMapiranje: ClassMap<Zasticen>
    {
        public ZasticenMapiranje()
        {
            Table("ZASTICEN");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Opis, "OPIS");
            Map(x => x.NovcanaNaknada, "NOVCANA_NAKNADA");
            Map(x => x.Institucija, "INSTITUCIJA");
            Map(x => x.DatumStavljanja, "DATUM_STAVLJANJA");
            HasOne(x => x.Objekat).PropertyRef(x => x.Zasticen);
        }
    }
}
