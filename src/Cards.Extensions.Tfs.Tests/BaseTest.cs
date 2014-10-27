using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Cards.Extensions.Tfs.Tests
{
    public abstract class BaseTest<T>
    {
        protected T Subject;
        private Dictionary<Type, Mock> _services;
        protected abstract Dictionary<Type, Mock> OnInitializeServices();
        
        protected abstract void Setup();

        protected S GetService<S>() where S : class
        {
            return _services[typeof(S)].Object as S;
        }

        private void initializeServices()
        {
            _services = OnInitializeServices();
        }

        public BaseTest()
        {
            initializeServices();
        }
    }
}
