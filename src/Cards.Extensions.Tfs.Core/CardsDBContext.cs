using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Extensions.Tfs.Core
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
