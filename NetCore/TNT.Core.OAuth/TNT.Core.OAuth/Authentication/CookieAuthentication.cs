using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

namespace TNT.Core.OAuth.Authentication
{
    #region Base Cookie Authentication
    public class AuthenticationCookieOptions : AuthenticationSchemeOptions
    {
        public string CookieKey { get; set; }
        public AuthenticationCookieOptions()
        {
        }
    }

    public abstract class CookieAuthenticationHandler : CookieAuthenticationHandler<AuthenticationCookieOptions>
    {
        protected CookieAuthenticationHandler(IOptionsMonitor<AuthenticationCookieOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }
    }

    public abstract class CookieAuthenticationHandler<TOptions> : AuthorizationHeaderHandler<TOptions>
        where TOptions : AuthenticationCookieOptions, new()
    {
        public const string HandlerSchemes = "Cookie";

        protected CookieAuthenticationHandler(IOptionsMonitor<TOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var cookie = Request.Cookies[Options.CookieKey];
            if (cookie == null)
                return AuthenticateResult.Fail(Constants.AuthenticationCookieMissing);
            return await AuthenticateAsync(cookie);
        }

        protected abstract Task<AuthenticateResult> AuthenticateAsync(string cookie);
    }

    #endregion
}
