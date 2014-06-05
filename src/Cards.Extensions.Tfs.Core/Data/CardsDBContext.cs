using Cards.Extensions.Tfs.Core.Models;
using System.Data.Entity;

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

    }
}
