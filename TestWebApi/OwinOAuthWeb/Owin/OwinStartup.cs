using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security;
using TNT.Helpers.WebApi.Owin;
using System.Security.Claims;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using TNT.Helpers.WebApi.Owin.Externals;
using TNT.Helpers.WebApi.Externals;
using System.Linq;
using TNT.Helpers.Cryptography;
using Newtonsoft.Json;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(OwinOAuthWeb.Owin.OwinStartup))]

namespace OwinOAuthWeb.Owin
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.AttachOwinEnvironmentPerRequest();
            ConfigureAuthorizationServer(app);
            //ConfigureAuthentication(app);
        }

        private void ConfigureAuthentication(IAppBuilder app)
        {
            app.UseProviderBasedAuthentication<ProviderAuthenticateMiddleware>(AuthenticationMode.Passive);
        }

        private void ConfigureAuthorizationServer(IAppBuilder app)
        {
            app.SetupOAuthAuthorizationServer(new AppAuthServerOptions(), true, true);
        }
    }

    #region Authentication middleware
    public class ProviderAuthenticateMiddleware : ProviderBasedAuthenticationMiddleware
    {
        public ProviderAuthenticateMiddleware(OwinMiddleware next, ProviderBasedAuthenticationOptions options) : base(next, options)
        {
        }

        protected override AuthenticationHandler<ProviderBasedAuthenticationOptions> CreateHandler()
        {
            return new ProviderAuthenticateHandler();
        }
    }

    public class ProviderAuthenticateHandler : ProviderBasedAuthenticationHandler
    {
        static string fbAppId = "523869358117226";
        static string fbAppSec = "14b9045c0222858c250ac81394778665";
        static string ggClientId = "931960859587-hjibavglvimtv5d4rofuiul7sdqblht7.apps.googleusercontent.com";
        static string ggClientSec = "USs_I-dgw4l1Voj2hsyvi0kC";
        private static IDictionary<string, IAuthenticationProvider<ProviderBasedAuthenticationHandler, ProviderBasedAuthenticationOptions>>
            providerByScheme;

        static ProviderAuthenticateHandler()
        {
            providerByScheme = new Dictionary<string, IAuthenticationProvider<ProviderBasedAuthenticationHandler, ProviderBasedAuthenticationOptions>>();
            providerByScheme["facebook"] = new FacebookAuthProvider(fbAppId, fbAppSec);
            providerByScheme["google"] = new GoogleAuthProvider(ggClientId, ggClientSec);
            providerByScheme["bearer"] = new BearerAuthProvider();
        }

        public override IEnumerable<string> AuthenticationTypes
        {
            get
            {
                return providerByScheme.Values.Select(v => v.AuthenticationType);
            }
            set { }
        }

        protected override IAuthenticationProvider<ProviderBasedAuthenticationHandler, ProviderBasedAuthenticationOptions> GetProvider()
        {
            GetAuthHeader();
            if (authHeaders != null && providerByScheme.ContainsKey(authHeaders[0].ToLower()))
                Provider = providerByScheme[authHeaders[0].ToLower()];
            return Provider;
        }
    }

    public class FacebookAuthProvider : FacebookProvider
    {
        public FacebookAuthProvider(string appId, string appSecret) : base(appId, appSecret)
        {
        }

        public override async Task<AuthenticationTicket> AuthenticateAsync(string token)
        {
            var debugResult = await Provider.DebugToken(token);
            if (debugResult != null && debugResult.IsValid)
            {
                var identity = new ClaimsIdentity(this.AuthenticationType);
                var ticket = new AuthenticationTicket(identity, null);
                return ticket;
            }
            return null;
        }
    }

    public class GoogleAuthProvider : GoogleProvider
    {
        public GoogleAuthProvider(string clientId, string clientSecret) : base(clientId, clientSecret)
        {
        }

        public override async Task<AuthenticationTicket> AuthenticateAsync(string token)
        {
            var debugResult = await Provider.DebugToken(token);
            if (debugResult != null && debugResult.IsValid)
            {
                var identity = new ClaimsIdentity(this.AuthenticationType);
                var ticket = new AuthenticationTicket(identity, null);
                return ticket;
            }
            return null;
        }
    }

    public class BearerAuthProvider : IAuthenticationProvider<ProviderBasedAuthenticationHandler, ProviderBasedAuthenticationOptions>
    {
        public string AuthenticationType { get; set; } = "Bearer";

        public Task<AuthenticationTicket> AuthenticateAsync(ProviderBasedAuthenticationHandler handler)
        {
            var authHeader = handler.GetAuthHeader();
            //get user by token
            var identity = new ClaimsIdentity(AuthenticationType);
            return Task.FromResult(new AuthenticationTicket(identity, null));
        }

        public void Dispose()
        {
        }

    }
    #endregion

    #region Authorization server
    public class AppAuthServerOptions : AuthorizationServerOptions
    {
        public AppAuthServerOptions()
        {
            this.AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(2);
            this.RegenerateRefreshToken = false;
            this.RefreshTokenExpireTimeSpan = TimeSpan.FromMinutes(1);
            this.AllowInsecureHttp = true;
            this.ApplicationCanDisplayErrors = false;
            this.AuthenticationMode = AuthenticationMode.Active;
            this.AuthenticationType = "Application";
            this.AccessTokenFormat = new ServerAccessTokenFormat();
            this.RefreshTokenFormat = new ServerRefreshTokenFormat();
            this.AccessTokenCookieKey = "TNT";
            this.SetAccessTokenCookie = true;
            this.AccessTokenCookieOptions = tokenExpire =>
            {
                return new CookieOptions()
                {
                    Domain = "localhost",
                    Expires = tokenExpire,
                    HttpOnly = false,
                    Path = "/",
                    Secure = false
                };
            };
            this.TokenEndpointPath = new PathString("/token");
            this.Provider = new AuthorizationServer(this);
            this.RefreshTokenProvider = new RefreshTokenProvider(this);
        }
    }

    public class AuthorizationServer : AuthorizationServerProvider
    {
        public AuthorizationServer(AuthorizationServerOptions options) : base(options)
        {
        }

        public override Task<AuthenticationTicket> AuthenticateAsync(string rawUsername, string rawPassword)
        {
            var user = Users.ListUsers.Where(u => u.Username == rawUsername && u.Password == rawPassword).FirstOrDefault();
            if (user == null)
                return Task.FromResult<AuthenticationTicket>(null);
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            var identity = new ClaimsIdentity(claims, "Application");
            var props = new AuthenticationProperties();
            props.Dictionary["additional"] = user.Username;
            var ticket = new AuthenticationTicket(identity, props);
            return Task.FromResult(ticket);
        }

    }

    public class ServerRefreshTokenFormat : ISecureDataFormat<AuthenticationTicket>
    {
        protected TokenGenerator tokenGen = new TokenGenerator(128);
        public string Protect(AuthenticationTicket data)
        {
            var user = Users.ListUsers.Where(u => u.Username == data.Identity.Name).FirstOrDefault();
            if (user == null)
                return null;
            user.RefreshToken = tokenGen.Generate();
            user.RefreshTokenIssuedDate = data.Properties.IssuedUtc.Value.UtcDateTime;
            user.RefreshTokenExpireDate = data.Properties.ExpiresUtc.Value.UtcDateTime;
            return user.RefreshToken;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            var user = Users.ListUsers.Where(u => u.RefreshToken == protectedText).FirstOrDefault();
            if (user == null)
                return null;
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            var identity = new ClaimsIdentity(claims, "Application");
            var props = new AuthenticationProperties();
            props.Dictionary["additional"] = user.Username;
            props.IssuedUtc = user.RefreshTokenIssuedDate;
            props.ExpiresUtc = user.RefreshTokenExpireDate;
            var ticket = new AuthenticationTicket(identity, props);
            return ticket;
        }
    }

    public class ServerAccessTokenFormat : ISecureDataFormat<AuthenticationTicket>
    {
        protected TokenGenerator tokenGen = new TokenGenerator(128);
        public string Protect(AuthenticationTicket data)
        {
            var user = Users.ListUsers.Where(u => u.Username == data.Identity.Name).FirstOrDefault();
            if (user == null)
                return null;
            user.AccessToken = tokenGen.Generate();
            user.TokenIssuedDate = data.Properties.IssuedUtc.Value.UtcDateTime;
            user.TokenExpireDate = data.Properties.ExpiresUtc.Value.UtcDateTime;
            return user.AccessToken;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            var user = Users.ListUsers.Where(u => u.AccessToken == protectedText).FirstOrDefault();
            if (user == null)
                return null;
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            var identity = new ClaimsIdentity(claims, "Application");
            var props = new AuthenticationProperties();
            props.Dictionary["additional"] = user.Username;
            props.IssuedUtc = user.TokenIssuedDate;
            props.ExpiresUtc = user.TokenExpireDate;
            var ticket = new AuthenticationTicket(identity, props);
            return ticket;
        }
    }
    #endregion

    #region User
    public class Users
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? TokenIssuedDate { get; set; }
        public DateTime? TokenExpireDate { get; set; }
        public DateTime? RefreshTokenIssuedDate { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }

        public static List<Users> ListUsers = new List<Users>()
        {
            new Users()
            {
                Username = "tnt",
                Password = "123",
            },
            new Users()
            {
                Username = "abc",
                Password = "456",
            },
            new Users()
            {
                Username = "def",
                Password = "789",
            },
        };



    }
    #endregion
}
