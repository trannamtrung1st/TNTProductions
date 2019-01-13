using Microsoft.AspNetCore.Authentication;
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
    #region Base Bearer Authentication
    public abstract class BearerAuthenticationHandler : BearerAuthenticationHandler<AuthenticationSchemeOptions>
    {
        protected BearerAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }
    }

    public abstract class BearerAuthenticationHandler<TOptions> : AuthorizationHeaderHandler<TOptions>
        where TOptions : AuthenticationSchemeOptions, new()
    {
        public const string HandlerSchemes = "Bearer";

        protected BearerAuthenticationHandler(IOptionsMonitor<TOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authHeader = GetAuthHeader();
            if (authHeader == null || authHeader.Length == 0)
            {
                return AuthenticateResult.Fail(Constants.AuthorizationMissing);
            }
            var bearer = authHeader[1];
            return await AuthenticateAsync(bearer);
        }

        protected abstract Task<AuthenticateResult> AuthenticateAsync(string bearer);

    }

    #endregion

}
