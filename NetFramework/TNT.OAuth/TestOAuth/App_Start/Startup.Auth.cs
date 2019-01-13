using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using TestOAuth.Models;
using TNT.OAuth;
using TNT.OAuth.Authentication;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Security.Claims;

namespace TestOAuth
{
    public partial class Startup
    {

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            var options = new AuthorizationServerOptions()
            {
                AccessTokenCookieKey = "TNT",
                AccessTokenCookieOptions = tokenExpireDate =>
                {
                    return new CookieOptions()
                    {
                        Domain = "localhost",
                        Expires = tokenExpireDate,
                        HttpOnly = false,
                        Path = "/",
                        Secure = false,
                    };
                },
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(2),
                AllowInsecureHttp = true,
                ApplicationCanDisplayErrors = false,
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                AuthenticationType = "Application",
                TokenEndpointPath = new PathString("/token"),
                RefreshTokenExpireTimeSpan = TimeSpan.FromMinutes(5),
                SetAccessTokenCookie = true,
            };
            options.RefreshTokenProvider = new RefreshTokenProvider(options);
            options.Provider = new AppAuthorizationServer(options);
            app.SetupOAuthAuthorizationServer(options, true, true);

        }
    }

    public class AppAuthorizationServer : AuthorizationServer
    {
        public AppAuthorizationServer(AuthorizationServerOptions options) : base(options)
        {
        }

        public override Task<AuthenticationTicket> AuthenticateAsync(string rawUsername, string rawPassword)
        {
            var identity = new ClaimsIdentity(options.AuthenticationType);
            return Task.FromResult(new AuthenticationTicket(identity, null));
        }
    }
}
