using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Cards.Extensions.Tfs.Core.Data
{
    public class CardsDBConfiguration : DbConfiguration
    {
        public CardsDBConfiguration()
        {
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
        }
    }
}
