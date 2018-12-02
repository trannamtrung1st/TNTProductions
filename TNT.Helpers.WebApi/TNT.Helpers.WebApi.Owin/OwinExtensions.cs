using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TNT.Helpers.WebApi.Owin
{
    public static class OwinExtensions
    {
        public static void AttachOwinEnvironmentPerRequest(this IAppBuilder app)
        {
            app.Use((c, next) =>
            {
                var req = HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage;
                if (req != null)
                    req.SetOwinEnvironment(c.Environment);
                return next();
            });
        }

        public static void UseBasicAuthentication<Middleware>(this IAppBuilder app) where Middleware : BasicAuthenticationMiddleware
        {
            app.Use<Middleware>(new BasicAuthenticationOptions());
        }

        public static void UseBasicAuthentication<Middleware>(this IAppBuilder app, AuthenticationMode mode) where Middleware : BasicAuthenticationMiddleware
        {
            app.Use<Middleware>(new BasicAuthenticationOptions()
            {
                AuthenticationMode = mode
            });
        }

        public static void UseBearerAuthentication<Middleware>(this IAppBuilder app) where Middleware : BearerAuthenticationMiddleware
        {
            app.Use<Middleware>(new BearerAuthenticationOptions());
        }

        public static void UseBearerAuthentication<Middleware>(this IAppBuilder app, AuthenticationMode mode) where Middleware : BearerAuthenticationMiddleware
        {
            app.Use<Middleware>(new BearerAuthenticationOptions()
            {
                AuthenticationMode = mode
            });
        }

        public static void UseProviderBasedAuthentication<Middleware>(this IAppBuilder app) where Middleware : ProviderBasedAuthenticationMiddleware
        {
            app.Use<Middleware>(new ProviderBasedAuthenticationOptions());
        }

        public static void UseProviderBasedAuthentication<Middleware>(this IAppBuilder app, AuthenticationMode mode) where Middleware : ProviderBasedAuthenticationMiddleware
        {
            app.Use<Middleware>(new ProviderBasedAuthenticationOptions()
            {
                AuthenticationMode = mode
            });
        }

        public static void SetupOAuthAuthorizationServer(this IAppBuilder app, AuthorizationServerOptions options,
            bool useBearerAuthentication,
            bool useCookieAuthentication)
        {
            app.UseOAuthAuthorizationServer(options);

            if (useBearerAuthentication)
                app.Use<OAuthBasedBearerAuthenticationMiddleware>(
                    new OAuthBasedBearerAuthenticationOptions()
                    {
                        AuthServerOptions = options,
                    });

            if (useCookieAuthentication)
                app.Use<OAuthBasedCookieAuthenticationMiddleware>(
                    new OAuthBasedCookieAuthenticationOptions()
                    {
                        AuthServerOptions = options,
                    });
        }

        public static void DeleteCookie(this IOwinContext owin, string key)
        {
            owin.Response.Cookies.Append(key, "", new CookieOptions()
            {
                Expires = Constants.LongTimeAgo
            });
        }

        public static void DeleteCookie(this IOwinResponse resp, string key)
        {
            resp.Cookies.Append(key, "", new CookieOptions()
            {
                Expires = Constants.LongTimeAgo
            });
        }
    }
}
