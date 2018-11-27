using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helpers.General
{
    public static class DateTimeExtensions
    {

        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0,
                                                          DateTimeKind.Utc);

        public static DateTime ToUnixDateTime(this long milSec)
        {
            return UnixEpoch + TimeSpan.FromMilliseconds(milSec);
        }

    }
}
