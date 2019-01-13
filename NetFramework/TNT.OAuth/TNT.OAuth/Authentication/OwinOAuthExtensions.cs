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

namespace TNT.OAuth.Authentication
{
    public static class OwinOAuthExtensions
    {
        
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

        public static void SetupOAuthAuthorizationServer(this IAppBuilder app, AuthorizationServerOptions options,
            bool useBearerAuthentication,
            bool useCookieAuthentication)
        {
            app.UseOAuthAuthorizationServer(options);

            if (useBearerAuthentication)
                app.Use<DefaultBearerAuthenticationMiddleware>(
                    new DefaultBearerAuthenticationOptions(options));

            if (useCookieAuthentication)
                app.Use<DefaultCookieAuthenticationMiddleware>(
                    new DefaultCookieAuthenticationOptions(options));
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
