using System.Data.Entity;
using Cards.Extensions.Tfs.Core.Models;

namespace Cards.Extensions.Tfs.Core.Data
{

    [DbConfigurationType(typeof(CardsDBConfiguration))]
    public class CardsDBContext : DbContext
    {

        public CardsDBContext()
            : base("CardsDB")
        {
            
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardActivity> CardActivities { get; set; }

    }
}
