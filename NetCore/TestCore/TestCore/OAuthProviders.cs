using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TNT.Core.OAuth.Authentication;
using TNT.Core.OAuth.Authorization;

namespace TestCore
{

    public class BasicAuthentication : BasicAuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthentication(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> AuthenticateAsync(string rawUsername, string rawPassword)
        {
            if (rawUsername.Equals("tnt") && rawPassword.Equals("abc"))
            {
                var identity = new ClaimsIdentity(Scheme.Name);
                identity.AddClaim(new Claim(ClaimTypes.Name, rawUsername));
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                var principal = new ClaimsPrincipal(identity);
                var prop = new AuthenticationProperties();
                var ticket = new AuthenticationTicket(principal, prop, Scheme.Name);
                return Task.FromResult(AuthenticateResult.Success(ticket));
            }
            return Task.FromResult(AuthenticateResult.Fail("Invalid credentials"));
        }
    }

    public class AuthorizationServer : AuthorizationServerProvider
    {
        public AuthorizationServer(AuthorizationServerOptions options) : base(options)
        {
        }

        public override Task<AuthenticationTicket> AuthenticateAsync(string rawUsername, string rawPassword)
        {
            if (rawUsername.Equals("tnt") && rawPassword.Equals("abc"))
            {
                var identity = new ClaimsIdentity(Options.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, rawUsername));
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                var principal = new ClaimsPrincipal(identity);
                var prop = new AuthenticationProperties();
                var ticket = new AuthenticationTicket(principal, prop, Options.AuthenticationScheme);
                return Task.FromResult(ticket);
            }
            return Task.FromResult<AuthenticationTicket>(null);
        }
    }
}
