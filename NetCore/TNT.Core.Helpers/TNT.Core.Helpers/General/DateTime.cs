using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.Helpers.General
{
    public static class DateTimeExtensions
    {

        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0,
                                                          DateTimeKind.Utc);

        public static int ToAge(this DateTime birthday)
        {
            var now = DateTime.Now;
            var timeSpan = now - birthday;
            return (int)timeSpan.TotalDays / 365;
        }

        public static DateTime ToUnixDateTime(this long milSec)
        {
            return UnixEpoch + TimeSpan.FromMilliseconds(milSec);
        }

        //format: yyyy-MM-dd'T'HH:mm:ss.fff'Z'
        public static DateTime? FromISOStrToLocalTime(this string dateStr)
        {
            DateTime date;
            if (DateTime.TryParse(dateStr, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out date))
                return date.ToLocalTime();
            return null;
        }

        //format: yyyy-MM-dd'T'HH:mm:ss.fff'Z'
        public static DateTime? FromISOStrToUTCTime(this string dateStr)
        {
            DateTime date;
            if (DateTime.TryParse(dateStr, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out date))
                return date;
            return null;
        }

        public static DateTime? ToLocalDateTime(this string dateStr, string format)
        {
            DateTime date;
            if (DateTime.TryParseExact(dateStr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            return null;
        }

        public static bool Is24HoursFormat(this TimeSpan time)
        {
            return time.TotalSeconds >= 0 && time.TotalSeconds < 86400;
        }

    }
}
