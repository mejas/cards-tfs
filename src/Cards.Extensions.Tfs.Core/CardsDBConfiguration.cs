using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Extensions.Tfs.Core
{
    public class CardsDBConfiguration : DbConfiguration
    {

        public CardsDBConfiguration()
        {
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
        }

    }
}
