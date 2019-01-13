using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TNT.Core.Helpers.Cryptography;
using TNT.Core.OAuth.Authentication;

namespace TNT.Core.OAuth.Authorization
{
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        private int statusCode;

        internal ErrorResponse(int status, string error, string description)
        {
            Error = error;
            ErrorDescription = description;
            statusCode = status;
        }

        public int StatusCode()
        {
            return statusCode;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

    public class AuthorizationServerMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationServerMiddleware(RequestDelegate next, AuthorizationServerOptions options)
        {
            this._next = next;
            Options = options;
            Provider = options.Provider;
        }

        public AuthorizationServerOptions Options { get; set; }
        public IOAuthAuthorizationServerProvider Provider { get; set; }

        public async Task Invoke(HttpContext http)
        {
            #region Match endpoint
            var matchEndpointContext = new OAuthMatchEndpointContext(http, Options);
            await Provider.MatchEndpoint(matchEndpointContext);
            var valid = await CheckIfValid(matchEndpointContext, http, _next);
            if (!valid)
                return;
            #endregion

            OAuthTokenEndpointResponseContext responseContext = null;

            #region Validate token endpoint request
            if (matchEndpointContext.IsTokenEndpoint)
            {
                var validateTokenContext = new OAuthValidateTokenRequestContext(matchEndpointContext);
                await Provider.ValidateTokenRequest(validateTokenContext);
                valid = await CheckIfValid(validateTokenContext, http, _next);
                if (!valid)
                    return;

                switch (validateTokenContext.GrantType)
                {
                    case "password":
                        var resourceOwnerContext = new OAuthGrantResourceOwnerCredentialsContext(validateTokenContext);
                        await Provider.GrantResourceOwnerCredentials(resourceOwnerContext);
                        valid = await CheckIfValid(resourceOwnerContext, http, _next);
                        if (!valid)
                            return;
                        responseContext = new OAuthTokenEndpointResponseContext(
                            resourceOwnerContext.Ticket, resourceOwnerContext);
                        break;
                    case "refresh_token":
                        var refreshTokenContext = new OAuthGrantRefreshTokenContext(validateTokenContext);
                        await Provider.GrantRefreshToken(refreshTokenContext);
                        valid = await CheckIfValid(refreshTokenContext, http, _next);
                        if (!valid)
                            return;
                        var refreshTicket = refreshTokenContext.Ticket;
                        var newTicket = new AuthenticationTicket(refreshTicket.Principal,
                            new AuthenticationProperties(), refreshTicket.AuthenticationScheme);
                        responseContext = new OAuthTokenEndpointResponseContext(
                            newTicket, refreshTokenContext);
                        break;
                    default:
                        var customContext = new OAuthGrantCustomExtensionContext(validateTokenContext);
                        await Provider.GrantCustomExtension(customContext);
                        valid = await CheckIfValid(customContext, http, _next);
                        if (!valid)
                            return;
                        responseContext = new OAuthTokenEndpointResponseContext(
                            customContext.Ticket, customContext);
                        break;
                }
            }
            #endregion

            #region Token endpoint response
            await Provider.TokenEndpointResponse(responseContext);
            valid = await CheckIfValid(responseContext, http, _next);
            if (!valid)
                return;
            await http.Response.WriteAsync(JsonConvert.SerializeObject(responseContext.ResponseParameters));
            #endregion

        }

        private static async Task<bool> CheckIfValid(OAuthContext context, HttpContext http, RequestDelegate next)
        {
            if (!context.IsValidated && !context.HasError)
            {
                await next(http);
                return false;
            }
            if (context.HasError)
            {
                http.Response.StatusCode = context.Error.StatusCode();
                await http.Response.WriteAsync(context.Error.ToString());
                return false;
            }
            return true;
        }
    }

    public interface IOAuthAuthorizationServerProvider
    {
        AuthorizationServerOptions Options { get; set; }

        Task MatchEndpoint(OAuthMatchEndpointContext context);

        Task ValidateTokenRequest(OAuthValidateTokenRequestContext context);

        Task GrantCustomExtension(OAuthGrantCustomExtensionContext context);
        Task GrantRefreshToken(OAuthGrantRefreshTokenContext context);
        Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context);

        Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context);
    }

    public class AuthorizationServerOptions
    {
        public TimeSpan RefreshTokenExpireTimeSpan { get; set; } = TimeSpan.FromDays(1);
        public TimeSpan AccessTokenExpireTimeSpan { get; set; } = TimeSpan.FromHours(1);

        public string Domain { get; set; } = "localhost";
        public string AuthenticationScheme { get; set; } = "Application";
        public string AccessTokenCookieKey { get; set; } = "Application";
        //parameter 1: access token expire date
        public Func<DateTime, CookieOptions> AccessTokenCookieOptions { get; set; }
            = exp =>
            {
                return new CookieOptions()
                {
                    Expires = exp,
                    HttpOnly = false,
                    Secure = false
                };
            };

        public PathString TokenEndpointPath { get; set; } = new PathString("/token");
        public IOAuthAuthorizationServerProvider Provider { get; set; }
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; set; } = new DefaultTokenFormat();
        public ISecureDataFormat<AuthenticationTicket> RefreshTokenFormat { get; set; } = new DefaultTokenFormat();
        public IAuthenticationTokenProvider AccessTokenProvider { get; set; }
        public IAuthenticationTokenProvider RefreshTokenProvider { get; set; }
        public bool AllowInsecureHttp { get; set; } = false;
    }

    public abstract partial class AuthorizationServerProvider : IOAuthAuthorizationServerProvider
    {
        public AuthorizationServerOptions Options { get; set; }
        public AuthorizationServerProvider()
        {
        }
        public AuthorizationServerProvider(AuthorizationServerOptions options)
        {
            this.Options = options;
            options.AccessTokenProvider = new AccessTokenProvider(options);
            options.RefreshTokenProvider = new RefreshTokenProvider(options);
        }
    }

    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        protected AuthorizationServerOptions options;
        public RefreshTokenProvider(AuthorizationServerOptions options)
        {
            this.options = options;
        }

        public Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var grantType = context.OAuthContext.FormData["grant_type"];
            if (grantType.Equals("refresh_token"))
                return Task.CompletedTask;

            var accessTicket = context.Ticket;
            var refreshProps = new AuthenticationProperties();
            var refreshTicket = new AuthenticationTicket(accessTicket.Principal, refreshProps, options.AuthenticationScheme);
            refreshTicket.Properties.IssuedUtc = accessTicket.Properties.IssuedUtc.Value;

            var expire = refreshTicket.Properties.IssuedUtc.Value.Add(options.RefreshTokenExpireTimeSpan);
            refreshTicket.Properties.ExpiresUtc = expire;
            context.Ticket = refreshTicket;
            context.SerializeTicket();
            return Task.CompletedTask;
        }

        public Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket();
            return Task.CompletedTask;
        }
    }

    public class AccessTokenProvider : IAuthenticationTokenProvider
    {
        protected AuthorizationServerOptions options;
        public AccessTokenProvider(AuthorizationServerOptions options)
        {
            this.options = options;
        }

        public Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            context.SerializeTicket();
            return Task.CompletedTask;
        }

        public Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket();
            return Task.CompletedTask;
        }
    }

    public class DefaultTokenFormat : ISecureDataFormat<AuthenticationTicket>
    {
        protected TicketSerializer serializer;
        protected AesCryptor cryptor;
        protected Random random;

        public DefaultTokenFormat()
        {
            serializer = new TicketSerializer();
            cryptor = CryptoFactory.GetDefaultAesCryptor();
            random = new Random();
        }

        public string Protect(AuthenticationTicket data)
        {
            var bytes = serializer.Serialize(data);
            return cryptor.EncryptToBase64(DateTime.UtcNow.Ticks + "_" + Encoding.UTF8.GetString(bytes));
        }

        public string Protect(AuthenticationTicket data, string purpose)
        {
            return Protect(data);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            var data = cryptor.DecryptFromBase64(protectedText);
            data = data.Substring(data.IndexOf('_') + 1);
            var ticket = serializer.Deserialize(
                Encoding.UTF8.GetBytes(data));
            return ticket;
        }

        public AuthenticationTicket Unprotect(string protectedText, string purpose)
        {
            return Unprotect(protectedText);
        }
    }

    #region OAuth Based Bearer Authentication
    public class DefaultBearerAuthenticationHandler : BearerAuthenticationHandler<DefaultBearerAuthenticationOptions>
    {
        public DefaultBearerAuthenticationHandler(IOptionsMonitor<DefaultBearerAuthenticationOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected virtual Task<AuthenticationTicket> AuthenticateUnprotectedTicket(AuthenticationTicket ticket)
        {
            if (ticket.Properties.ExpiresUtc <= DateTime.UtcNow)
                ticket = null;
            return Task.FromResult(ticket);
        }

        protected override async Task<AuthenticateResult> AuthenticateAsync(string bearer)
        {
            AuthenticationTicket ticket = null;
            try
            {
                ticket = Options.ServerOptions.AccessTokenFormat.Unprotect(bearer);
            }
            catch (Exception) { }
            if (ticket != null)
                ticket = await AuthenticateUnprotectedTicket(ticket);
            if (ticket == null)
            {
                return AuthenticateResult.Fail(Constants.InvalidBearerAccessToken);
            }
            return AuthenticateResult.Success(ticket);
        }
    }

    public class DefaultBearerAuthenticationOptions : AuthenticationSchemeOptions
    {
        public AuthorizationServerOptions ServerOptions { get; set; }

        public DefaultBearerAuthenticationOptions()
        {
        }

        public DefaultBearerAuthenticationOptions(AuthorizationServerOptions options)
        {
            ServerOptions = options;
        }
    }
    #endregion

    #region Server Cookie Authentication
    public class DefaultCookieAuthenticationOptions : AuthenticationCookieOptions
    {
        public AuthorizationServerOptions ServerOptions { get; set; }

        public DefaultCookieAuthenticationOptions()
        {
        }

        public DefaultCookieAuthenticationOptions(AuthorizationServerOptions options)
        {
            ServerOptions = options;
            CookieKey = options.AccessTokenCookieKey;
        }
    }

    public class DefaultCookieAuthenticationHandler : CookieAuthenticationHandler<DefaultCookieAuthenticationOptions>
    {
        public DefaultCookieAuthenticationHandler(IOptionsMonitor<DefaultCookieAuthenticationOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected virtual Task<AuthenticationTicket> AuthenticateUnprotectedTicket(AuthenticationTicket ticket)
        {
            if (ticket.Properties.ExpiresUtc <= DateTime.UtcNow)
                ticket = null;
            return Task.FromResult(ticket);
        }

        protected override async Task<AuthenticateResult> AuthenticateAsync(string cookie)
        {
            var ticket = Options.ServerOptions.AccessTokenFormat.Unprotect(cookie);
            if (ticket != null)
                ticket = await AuthenticateUnprotectedTicket(ticket);
            if (ticket == null)
            {
                Response.Cookies.Delete(Options.CookieKey);
                return AuthenticateResult.Fail(Constants.InvalidCookieAccessToken);
            }
            return AuthenticateResult.Success(ticket);
        }

    }
    #endregion

    public abstract class AuthenticationTokenContext
    {
        public string Token { get; set; }
        public AuthenticationTicket Ticket { get; set; }
        public ISecureDataFormat<AuthenticationTicket> Format { get; set; }
        public OAuthContext OAuthContext { get; set; }
        public AuthenticationTokenContext(OAuthContext context, ISecureDataFormat<AuthenticationTicket> format)
        {
            OAuthContext = context;
            Format = format;
        }
    }

    public class AuthenticationTokenCreateContext : AuthenticationTokenContext
    {
        public AuthenticationTokenCreateContext(OAuthContext context, ISecureDataFormat<AuthenticationTicket> format) : base(context, format)
        {
        }

        public void SerializeTicket()
        {
            Token = Format.Protect(Ticket);
        }
    }

    public class AuthenticationTokenReceiveContext : AuthenticationTokenContext
    {
        public AuthenticationTokenReceiveContext(OAuthContext context, ISecureDataFormat<AuthenticationTicket> format) : base(context, format)
        {
        }

        public void DeserializeTicket()
        {
            Ticket = Format.Unprotect(Token);
        }
    }

    public interface IAuthenticationTokenProvider
    {
        Task CreateAsync(AuthenticationTokenCreateContext context);
        Task ReceiveAsync(AuthenticationTokenReceiveContext context);
    }
}
