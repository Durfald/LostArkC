using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkManager.LOSTARK.Extensions
{
    public static class DatetimeExtensions
    {
        public static DateTime UnixTimeConvert(this ref DateTime date,int unixTimeStamp)
        {
            date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            date = date.AddSeconds(unixTimeStamp).ToUniversalTime();
            return date;
        }
    }
}
