using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace TNT.Core.OAuth.Authentication
{
    public abstract class BaseAuthenticationHandler<TOptions>
       : AuthenticationHandler<TOptions> where TOptions : AuthenticationSchemeOptions, new()
    {
        protected BaseAuthenticationHandler(IOptionsMonitor<TOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected async override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            var wwwAuth = Response.Headers.GetCommaSeparatedValues("Www-Authenticate");
            if (wwwAuth == null || !wwwAuth.Contains(Scheme.Name))
                Response.Headers.Append("Www-Authenticate", Scheme.Name);
            await base.HandleChallengeAsync(properties);
        }
    }

    public abstract class AuthorizationHeaderHandler<TOptions>
        : BaseAuthenticationHandler<TOptions> where TOptions : AuthenticationSchemeOptions, new()
    {
        protected AuthorizationHeaderHandler(IOptionsMonitor<TOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected virtual string[] GetAuthHeader()
        {
            var authHeaderStr = Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrEmpty(authHeaderStr))
                return null;
            var headerParts = authHeaderStr.Split(' ');
            if (headerParts.Length != 2)
                return null;
            if (!headerParts[0].ToLower().Equals(Scheme.Name.ToLower()))
                return null;
            return headerParts;
        }

    }

}
