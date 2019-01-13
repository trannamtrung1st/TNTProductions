using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.OAuth.Authentication;

namespace TNT.OAuth
{
    public abstract class AuthorizationServer : OAuthAuthorizationServerProvider
    {
        protected AuthorizationServerOptions options;

        public AuthorizationServer(AuthorizationServerOptions options)
        {
            this.options = options;
        }

        public override Task MatchEndpoint(OAuthMatchEndpointContext context)
        {
            //base checked
            return base.MatchEndpoint(context);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //individual user must not have client Id
            if (context.ClientId == null)
            {
                return Task.FromResult(context.Validated());
            }
            context.SetError("invalid_client", "Individual user must not have client id");
            context.Rejected();
            return Task.FromResult(0);
        }

        public override Task ValidateTokenRequest(OAuthValidateTokenRequestContext context)
        {
            //grant type must be password or refresh_token (base checked)
            return base.ValidateTokenRequest(context);
        }

        public abstract Task<AuthenticationTicket> AuthenticateAsync(string rawUsername, string rawPassword);
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var ticket = await AuthenticateAsync(context.UserName, context.Password);
            if (ticket == null)
            {
                context.SetError("Invalid password grant", "Invalid username or password");
                context.Rejected();
                return;
            }
            context.Validated(ticket);
        }

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            if (context.Ticket.Properties.ExpiresUtc <= DateTime.UtcNow)
                return;
            await base.GrantRefreshToken(context);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var p in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters[p.Key] = p.Value;
            }
            return base.TokenEndpoint(context);
        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            if (context.Properties.Dictionary.ContainsKey(Constants.RefreshTokenExpiresKey))
                context.AdditionalResponseParameters[Constants.RefreshTokenExpiresKey] =
                    context.Properties.Dictionary[Constants.RefreshTokenExpiresKey];

            if (options.SetAccessTokenCookie)
            {
                var cookieOptions = options.AccessTokenCookieOptions(context.Properties.ExpiresUtc.Value.UtcDateTime);
                context.Response.Cookies.Append(options.AccessTokenCookieKey, context.AccessToken, cookieOptions);
            }

            return base.TokenEndpointResponse(context);
        }
    }

    public class AuthorizationServerOptions : OAuthAuthorizationServerOptions
    {
        public TimeSpan RefreshTokenExpireTimeSpan { get; set; }

        public bool SetAccessTokenCookie { get; set; }
        public string AccessTokenCookieKey { get; set; }

        //paramter 1: access token expire date
        public Func<DateTime, CookieOptions> AccessTokenCookieOptions { get; set; }

        public AuthorizationServerOptions()
        {
        }
    }

    public class RefreshTokenProvider : AuthenticationTokenProvider
    {
        protected AuthorizationServerOptions options;
        public RefreshTokenProvider(AuthorizationServerOptions options)
        {
            this.options = options;
        }

        public override Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            object inputs;
            context.OwinContext.Environment.TryGetValue("Microsoft.Owin.Form#collection", out inputs);
            var grantType = ((FormCollection)inputs)?.GetValues("grant_type");
            var grant = grantType.FirstOrDefault();
            if (grant == null || grant.Equals("refresh_token"))
                return Task.FromResult(0);

            var accessTicket = context.Ticket;
            var refreshProps = new AuthenticationProperties();
            var refreshTicket = new AuthenticationTicket(accessTicket.Identity, refreshProps);
            refreshTicket.Properties.IssuedUtc = accessTicket.Properties.IssuedUtc.Value;

            var expire = refreshTicket.Properties.IssuedUtc.Value.Add(options.RefreshTokenExpireTimeSpan);
            refreshTicket.Properties.ExpiresUtc = expire;
            accessTicket.Properties.Dictionary[Constants.RefreshTokenExpiresKey] =
                expire.ToString("ddd, dd MMM yyy HH':'mm':'ss 'GMT'");

            var refreshToken = options.RefreshTokenFormat.Protect(refreshTicket);
            context.SetToken(refreshToken);
            return Task.FromResult(0);
        }

        public override Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
            return Task.FromResult(0);
        }
    }

    #region OAuth Based Bearer Authentication
    public class DefaultBearerAuthenticationMiddleware : BearerAuthenticationMiddleware<DefaultBearerAuthenticationOptions>
    {
        public DefaultBearerAuthenticationMiddleware(OwinMiddleware next, DefaultBearerAuthenticationOptions options) : base(next, options)
        {
        }

        protected override AuthenticationHandler<DefaultBearerAuthenticationOptions> CreateHandler()
        {
            return new DefaultBearerAuthenticationHandler();
        }
    }

    public class DefaultBearerAuthenticationOptions : BearerAuthenticationOptions
    {
        public AuthorizationServerOptions AuthServerOptions { get; set; }

        public DefaultBearerAuthenticationOptions(AuthorizationServerOptions options)
        {
            AuthServerOptions = options;
        }

    }

    public class DefaultBearerAuthenticationHandler : BearerAuthenticationHandler<DefaultBearerAuthenticationOptions>
    {
        protected virtual Task<AuthenticationTicket> AuthenticateUnprotectedTicket(AuthenticationTicket ticket)
        {
            if (ticket.Properties.ExpiresUtc <= DateTime.UtcNow)
                ticket = null;
            return Task.FromResult(ticket);
        }

        protected override async Task<AuthenticationTicket> AuthenticateAsync(string bearer)
        {
            var ticket = Options.AuthServerOptions.AccessTokenFormat.Unprotect(bearer);
            if (ticket != null)
                ticket = await AuthenticateUnprotectedTicket(ticket);
            return ticket;
        }

    }
    #endregion

    #region Server Cookie Authentication
    public class DefaultCookieAuthenticationMiddleware : CookieAuthenticationMiddleware<DefaultCookieAuthenticationOptions>
    {
        public DefaultCookieAuthenticationMiddleware(OwinMiddleware next, DefaultCookieAuthenticationOptions options) : base(next, options)
        {
        }

        protected override AuthenticationHandler<DefaultCookieAuthenticationOptions> CreateHandler()
        {
            return new DefaultCookieAuthenticationHandler();
        }
    }

    public class DefaultCookieAuthenticationOptions : CookieAuthenticationOptions
    {
        public AuthorizationServerOptions AuthServerOptions { get; set; }

        public DefaultCookieAuthenticationOptions(AuthorizationServerOptions options)
        {
            AuthServerOptions = options;
            AuthenticationCookieKey = options.AccessTokenCookieKey;
        }
    }

    public class DefaultCookieAuthenticationHandler : CookieAuthenticationHandler<DefaultCookieAuthenticationOptions>
    {
        protected virtual Task<AuthenticationTicket> AuthenticateUnprotectedTicket(AuthenticationTicket ticket)
        {
            if (ticket.Properties.ExpiresUtc <= DateTime.UtcNow)
                ticket = null;
            return Task.FromResult(ticket);
        }

        protected override async Task<AuthenticationTicket> AuthenticateAsync(string cookie)
        {
            var ticket = Options.AuthServerOptions.AccessTokenFormat.Unprotect(cookie);
            if (ticket != null)
                ticket = await AuthenticateUnprotectedTicket(ticket);
            if (ticket == null)
                Response.DeleteCookie(Options.AuthServerOptions.AccessTokenCookieKey);
            return ticket;
        }

    }
    #endregion
}
