using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cards.Extensions.Tfs.Core
{
    public interface IDateProvider
    {
        DateTime Now();
    }
}
