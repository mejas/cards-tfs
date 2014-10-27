using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Extensions.Tfs.Tests
{
    public abstract class BaseTest
    {
        protected Dictionary<Type, object> Services;
        protected abstract Dictionary<Type, object> onInitializeServices();

        private void initializeServices()
        {
            Services = onInitializeServices();
        }

        public BaseTest()
        {
            initializeServices();
        }
    }
}
