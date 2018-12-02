using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helpers.WebApi.Owin
{
    /* INDIVIDUAL USER AUTHORIZATION SERVER */

    /// <summary>
    /// Supported Grant Types:
    /// NOTE : [.] optional
    /// 
    /// 1/ Resource Owner Password Credentials Grant: The resource owner password credentials grant type is suitable in
    /// cases where the resource owner has a trust relationship with the
    /// client, such as the device operating system or a highly privileged
    /// application.The authorization server should take special care when
    /// enabling this grant type and only allow it when other flows are not viable.
    /// 
    /// * Request:
    ///     + Method: POST
    ///     + Format: application/x-www-form-urlencoded
    ///     + Parameters:
    ///         1/ Password grant type:
    ///             . grant_type = password
    ///             . username
    ///             . password
    ///             [.] scope (request scope -> get actual scope by auth server) (space seperated)
    ///         2/ Refresh token grant type:
    ///             . grant_type = refresh_token
    ///             . refresh_token
    ///             [.] scope (...)
    /// * Response:
    ///     + Format: Json
    ///     + Properties:
    ///         . access_token
    ///         . token_type: Bearer (or else)
    ///         . expires_in: 
    ///         [.] refresh_token: use for get a new token without password grant
    ///         [.] additional parameters (ticket properties)
    /// </summary>
    public abstract class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {

        protected bool setAccessTokenCookie;
        protected string accessTokenCookieKey;
        protected Func<DateTime, CookieOptions> getCookieOptions;

        public AuthorizationServerProvider(AuthorizationServerOptions options)
        {
            setAccessTokenCookie = options.SetAccessTokenCookie;
            accessTokenCookieKey = options.AccessTokenCookieKey;
            getCookieOptions = options.AccessTokenCookieOptions;
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

            if (setAccessTokenCookie)
            {
                var options = getCookieOptions(context.Properties.ExpiresUtc.Value.UtcDateTime);
                context.Response.Cookies.Append(accessTokenCookieKey, context.AccessToken, options);
            }

            return base.TokenEndpointResponse(context);
        }

    }

    public class AuthorizationServerOptions : OAuthAuthorizationServerOptions
    {
        public bool RegenerateRefreshToken { get; set; }
        public TimeSpan RefreshTokenExpireTimeSpan { get; set; }

        public bool SetAccessTokenCookie { get; set; }
        public string AccessTokenCookieKey { get; set; }

        //paramter 1: access token expire date
        public Func<DateTime, CookieOptions> AccessTokenCookieOptions { get; set; }

    }

    public class RefreshTokenProvider : AuthenticationTokenProvider
    {
        protected AuthorizationServerOptions authOptions;
        public RefreshTokenProvider(AuthorizationServerOptions options)
        {
            authOptions = options;
        }

        //public override void Create(AuthenticationTokenCreateContext context)
        //{
        //    object inputs;
        //    context.OwinContext.Environment.TryGetValue("Microsoft.Owin.Form#collection", out inputs);
        //    var grantType = ((FormCollection)inputs)?.GetValues("grant_type");
        //    var grant = grantType.FirstOrDefault();
        //    if (grant == null || (!RegenerateRefreshToken && grant.Equals("refresh_token"))) return;
        //    var refreshToken = context.SerializeTicket();
        //    context.SetToken(refreshToken);
        //}

        public override Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            object inputs;
            context.OwinContext.Environment.TryGetValue("Microsoft.Owin.Form#collection", out inputs);
            var grantType = ((FormCollection)inputs)?.GetValues("grant_type");
            var grant = grantType.FirstOrDefault();
            if (grant == null || (!authOptions.RegenerateRefreshToken && grant.Equals("refresh_token")))
                return Task.FromResult(0);

            var accessTicket = context.Ticket;
            var refreshProps = new AuthenticationProperties();
            var refreshTicket = new AuthenticationTicket(accessTicket.Identity, refreshProps);
            refreshTicket.Properties.IssuedUtc = accessTicket.Properties.IssuedUtc.Value;

            var expire = refreshTicket.Properties.IssuedUtc.Value.Add(authOptions.RefreshTokenExpireTimeSpan);
            refreshTicket.Properties.ExpiresUtc = expire;
            accessTicket.Properties.Dictionary[Constants.RefreshTokenExpiresKey] =
                expire.ToString("ddd, dd MMM yyy HH':'mm':'ss 'GMT'");

            var refreshToken = authOptions.RefreshTokenFormat.Protect(refreshTicket);
            context.SetToken(refreshToken);
            return Task.FromResult(0);
        }

        //public override void Receive(AuthenticationTokenReceiveContext context)
        //{
        //    context.DeserializeTicket(context.Token);
        //}

        public override Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
            return Task.FromResult(0);
        }
    }

    #region OAuth Based Bearer Authentication
    public class OAuthBasedBearerAuthenticationMiddleware : BearerAuthenticationMiddleware<OAuthBasedBearerAuthenticationOptions>
    {
        public OAuthBasedBearerAuthenticationMiddleware(OwinMiddleware next, OAuthBasedBearerAuthenticationOptions options) : base(next, options)
        {
        }

        protected override AuthenticationHandler<OAuthBasedBearerAuthenticationOptions> CreateHandler()
        {
            return new OAuthBasedBearerAuthenticationHandler();
        }
    }

    public class OAuthBasedBearerAuthenticationOptions : BearerAuthenticationOptions
    {
        public AuthorizationServerOptions AuthServerOptions { get; set; }

    }

    public class OAuthBasedBearerAuthenticationHandler : BearerAuthenticationHandler<OAuthBasedBearerAuthenticationOptions>
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
    public class OAuthBasedCookieAuthenticationMiddleware : CookieAuthenticationMiddleware<OAuthBasedCookieAuthenticationOptions>
    {
        public OAuthBasedCookieAuthenticationMiddleware(OwinMiddleware next, OAuthBasedCookieAuthenticationOptions options) : base(next, options)
        {
        }

        protected override AuthenticationHandler<OAuthBasedCookieAuthenticationOptions> CreateHandler()
        {
            return new OAuthBasedCookieAuthenticationHandler();
        }
    }

    public class OAuthBasedCookieAuthenticationOptions : CookieAuthenticationOptions
    {
        public AuthorizationServerOptions AuthServerOptions { get; set; }
    }

    public class OAuthBasedCookieAuthenticationHandler : CookieAuthenticationHandler<OAuthBasedCookieAuthenticationOptions>
    {
        protected override string AuthenticationCookieKey
        {
            get
            {
                return Options.AuthServerOptions.AccessTokenCookieKey;
            }
        }

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
                Response.DeleteCookie(AuthenticationCookieKey);
            return ticket;
        }

    }
    #endregion

}
