using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helpers.WebApi.Owin
{
    public class Constants
    {
        public const string RefreshTokenExpiresKey = ".refresh_token_expires";
        public static readonly DateTime LongTimeAgo = new DateTime(1970, 1, 1);
    }
}
