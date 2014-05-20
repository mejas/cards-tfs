using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cards.Extensions.Tfs.Core
{
    public class DateProvider : IDateProvider
    {
        public DateTime Now()
        {
            return DateTime.UtcNow;
        }
    }
}
