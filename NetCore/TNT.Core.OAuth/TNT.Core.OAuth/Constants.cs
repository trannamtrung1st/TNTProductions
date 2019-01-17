using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.OAuth
{
    public class Constants
    {
        public const string RefreshTokenExpiresKey = ".refresh_token_expires";
        public static readonly DateTime LongTimeAgo = new DateTime(1970, 1, 1);
        public const string HttpsOnly = "Only https connection allowed";
        public const string InvalidEndpoint = "Invalid endpoint";
        public const string TokenExpired = "Token expired";
        public const string InvalidTokenRequest = "Invalid token request";
        public const string AuthorizationMissing = "Authorization header missing";
        public const string InvalidCredentials = "Invalid credentials";
        public const string AuthenticationCookieMissing = "Authentication cookie missing";
        public const string UnsupportedGrantType = "Unsupported grant type";
        public const string InvalidCookieAccessToken = "Invalid cookie access token";
        public const string InvalidBearerAccessToken = "Invalid bearer access token";
        public const string InvalidRequest = "invalid_request";
        public const string UnsupportedMethod = "Unsupported method";
        public const string InvalidToken = "Invalid token";
    }
}
