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

[assembly: OwinStartup(typeof(OwinOAuthWeb.Owin.OwinStartup))]

namespace OwinOAuthWeb.Owin
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.AttachOwinEnvironmentPerRequest();
            ConfigureAuthorizationServer(app);
            ConfigureAuthentication(app);
        }

        public void ConfigureAuthentication(IAppBuilder app)
        {
            app.UseProviderBasedAuthentication<ProviderAuthenticateMiddleware>(AuthenticationMode.Passive);
        }

        private void ConfigureAuthorizationServer(IAppBuilder app)
        {
            //app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            //{
            //    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(5),
            //    AuthorizationCodeExpireTimeSpan = TimeSpan.FromMinutes(5),
            //    Provider = new AuthorizationServer(),
            //    AccessTokenProvider = new AccessTokenProvider(),
            //    AuthorizationCodeProvider = new AuthenticationTokenProvider(),
            //    RefreshTokenProvider = new RefreshTokenProvider(),
            //    AccessTokenFormat = new AccessTokenFormat(),
            //    AllowInsecureHttp = true,
            //    ApplicationCanDisplayErrors = false,
            //    AuthenticationMode = AuthenticationMode.Active,
            //    AuthenticationType = "Application",
            //    AuthorizationCodeFormat = new AuthorizationCodeFormat(),
            //    AuthorizeEndpointPath = new PathString(),
            //    FormPostEndpoint = new PathString(),
            //    RefreshTokenFormat = new RefreshTokenFormat(),
            //    //SystemClock = //... default utc
            //    TokenEndpointPath = new PathString(),
            //});

        }
    }

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

    #region Auth server
    public class AuthorizationServer : OAuthAuthorizationServerProvider
    {
        public AuthorizationServer() : base()
        {
        }
    }

    public class AuthorizationCodeFormat : ISecureDataFormat<AuthenticationTicket>
    {
        public string Protect(AuthenticationTicket data)
        {
            throw new NotImplementedException();
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }

    public class RefreshTokenFormat : ISecureDataFormat<AuthenticationTicket>
    {
        public string Protect(AuthenticationTicket data)
        {
            throw new NotImplementedException();
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }

    public class AccessTokenFormat : ISecureDataFormat<AuthenticationTicket>
    {
        public string Protect(AuthenticationTicket data)
        {
            throw new NotImplementedException();
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }

    public class RefreshTokenProvider : AuthenticationTokenProvider
    {

    }

    public class AuthorizationTokenProvider : AuthenticationTokenProvider
    {

    }

    public class AccessTokenProvider : AuthenticationTokenProvider
    {

    }
    #endregion
}
