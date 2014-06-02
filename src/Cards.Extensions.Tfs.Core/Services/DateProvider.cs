using Cards.Extensions.Tfs.Core.Interfaces;
using System;

namespace Cards.Extensions.Tfs.Core.Services
{
    public class DateProvider : IDateProvider
    {
        public DateTime Now()
        {
            return DateTime.UtcNow;
        }
    }
}
