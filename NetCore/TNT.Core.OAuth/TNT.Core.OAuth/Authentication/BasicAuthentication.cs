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
    public abstract class BasicAuthenticationHandler : BasicAuthenticationHandler<AuthenticationSchemeOptions>
    {
        protected BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }
    }

    public abstract class BasicAuthenticationHandler<TOptions> : AuthorizationHeaderHandler<TOptions>
        where TOptions : AuthenticationSchemeOptions, new()
    {
        public const string HandlerSchemes = "Basic";

        protected BasicAuthenticationHandler(IOptionsMonitor<TOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authHeader = GetAuthHeader();
            if (authHeader == null)
            {
                return AuthenticateResult.Fail(Constants.AuthorizationMissing);
            }
            var authHeaderParam = Encoding.Default.GetString(Convert.FromBase64String(authHeader[1]));
            var credentials = authHeaderParam.Split(':');
            if (credentials.Length < 2)
            {
                return AuthenticateResult.Fail(Constants.InvalidCredentials);
            }
            var rawUsername = credentials[0];
            var rawPassword = credentials[1];

            return await AuthenticateAsync(rawUsername, rawPassword);
        }

        protected abstract Task<AuthenticateResult> AuthenticateAsync(string rawUsername, string rawPassword);

    }

}
