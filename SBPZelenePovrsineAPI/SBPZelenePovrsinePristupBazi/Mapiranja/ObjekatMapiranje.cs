using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBPZelenePovrsinePristupBazi.Entiteti;

namespace SBPZelenePovrsinePristupBazi.Mapiranja
{
    public class ObjekatMapiranje : ClassMap<Objekat>
    {
        public ObjekatMapiranje()
        {
            Table("OBJEKAT");

            DiscriminateSubClassesOnColumn("TIP_OBJEKTA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.RedniBroj, "REDNI_BROJ");

            References(x => x.Park).Column("PARK_ID").LazyLoad();
            References(x => x.Zasticen).Column("ZASTITA_ID").Cascade.All().LazyLoad();
        }
    }

    public class KlupaMapiranje : SubclassMap<Klupa>
    {
        public KlupaMapiranje()
        {
            DiscriminatorValue("Klupa");
        }
    }

    public class FontanaMapiranje : SubclassMap<Fontana>
    {
        public FontanaMapiranje()
        {
            DiscriminatorValue("Fontana");
        }
    }

    public class SvetiljkaMapiranje : SubclassMap<Svetiljka>
    {
        public SvetiljkaMapiranje()
        {
            DiscriminatorValue("Svetiljka");
        }
    }

    public class IgralisteMapiranje : SubclassMap<Igraliste>
    {
        public IgralisteMapiranje()
        {
            DiscriminatorValue("Igralište");

            Map(x => x.BrojIgracaka, "BROJ_IGRACAKA");
            Map(x => x.StarostDeceOd, "STAROST_DECE_OD");
            Map(x => x.StarostDeceDo, "STAROST_DECE_DO");
            Map(x => x.Pesak, "PESAK");
        }
    }

    public class SpomenikMapiranje : SubclassMap<Spomenik>
    {
        public SpomenikMapiranje()
        {
            DiscriminatorValue("Spomenik");

            //References(x => x.Zasticen).Column("ZASTITA_ID").Cascade.All().LazyLoad();
        }
    }

    public class SkulpturaMapiranje : SubclassMap<Skulptura>
    {
        public SkulpturaMapiranje()
        {
            DiscriminatorValue("Skulptura");

            //References(x => x.Zasticen).Column("ZASTITA_ID").Cascade.All().LazyLoad();
        }
    }

    public class DrvoMapiranje : SubclassMap<Drvo>
    {
        public DrvoMapiranje()
        {
            DiscriminatorValue("Drvo");

            Map(x => x.Vrsta, "VRSTA");
            Map(x => x.ObimDebla, "OBIM_DEBLA");
            Map(x => x.DatumSadnje, "DATUM_SADNJE");
            Map(x => x.VisinaKrosnje, "VISINA_KROSNJE");
            Map(x => x.PovrsinaPokrivanja, "POVRSINA_POKRIVANJA");

            //References(x => x.Zasticen).Column("ZASTITA_ID").Cascade.All().LazyLoad();
        }
    }
}
