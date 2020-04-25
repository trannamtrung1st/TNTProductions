using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TNT.Core.Helpers.General
{
    public static class NumberExtension
    {
        public static string ToCommaGroup(this double number)
        {
            return number.ToString("#,#", CultureInfo.InvariantCulture);
        }
    }
}
