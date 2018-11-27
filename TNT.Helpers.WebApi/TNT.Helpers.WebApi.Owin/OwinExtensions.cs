using Microsoft.Owin;
using Microsoft.Owin.Security;
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

    }
}
