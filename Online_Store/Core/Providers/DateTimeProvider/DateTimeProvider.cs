using System;

namespace Online_Store.Core.Providers.DateTimeProvider
{
    public abstract class DateTimeProvider
    {
        public static DateTime Now
        {
            get
            {
                return new DateTime(2017, 1, 16, 0, 0, 0);
            }
        }
    }
}