using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TNT.Core.OAuth.Authentication;
using TNT.Core.OAuth.Authorization;

namespace TNT.Core.OAuth
{
    public static class OAuthExtensions
    {
        public static IServiceCollection AddAuthorizationPolicy<Handler, TReq>(this IServiceCollection services,
            string policyName, IEnumerable<string> schemes,
            TReq requirement)
            where TReq : IAuthorizationRequirement where Handler : AuthorizationHandler<TReq>
        {
            services.AddAuthorization(o =>
            {
                var requirements = new List<IAuthorizationRequirement>();
                requirements.Add(requirement);
                var policy = new AuthorizationPolicy(requirements, schemes);
                o.AddPolicy(policyName, policy);
            });
            if (!services.Any(s => s.ServiceType == typeof(IAuthorizationHandler) &&
                s.ImplementationType == typeof(Handler) && s.Lifetime == ServiceLifetime.Singleton))
                services.AddSingleton<IAuthorizationHandler, Handler>();
            return services;
        }

        public static IServiceCollection AddBasicAuthorizationPolicy<Handler, TReq>(this IServiceCollection services, TReq requirement)
            where TReq : IAuthorizationRequirement where Handler : AuthorizationHandler<TReq>
        {
            return AddAuthorizationPolicy<Handler, TReq>(services, BasicAuthenticationHandler.HandlerSchemes,
                new List<string>() { BasicAuthenticationHandler.HandlerSchemes }, requirement);
        }

        public static IServiceCollection AddBearerAuthorizationPolicy<Handler, TReq>(this IServiceCollection services, TReq requirement)
            where TReq : IAuthorizationRequirement where Handler : AuthorizationHandler<TReq>
        {
            return AddAuthorizationPolicy<Handler, TReq>(services, BearerAuthenticationHandler.HandlerSchemes,
                new List<string>() { BearerAuthenticationHandler.HandlerSchemes }, requirement);
        }

        public static IServiceCollection AddCookieAuthorizationPolicy<Handler, TReq>(this IServiceCollection services, TReq requirement)
            where TReq : IAuthorizationRequirement where Handler : AuthorizationHandler<TReq>
        {
            return AddAuthorizationPolicy<Handler, TReq>(services, CookieAuthenticationHandler.HandlerSchemes,
                new List<string>() { CookieAuthenticationHandler.HandlerSchemes }, requirement);
        }

        public static AuthenticationBuilder AddBasicAuthentication<Handler>(this AuthenticationBuilder builder,
            Action<AuthenticationSchemeOptions> opt = null
        ) where Handler : BasicAuthenticationHandler
        {
            builder.AddScheme<AuthenticationSchemeOptions, Handler>(BasicAuthenticationHandler.HandlerSchemes, opt);
            return builder;
        }

        public static AuthenticationBuilder AddBearerAuthentication<Handler>(this AuthenticationBuilder builder,
            Action<AuthenticationSchemeOptions> opt = null
        ) where Handler : BearerAuthenticationHandler
        {
            builder.AddScheme<AuthenticationSchemeOptions, Handler>(BearerAuthenticationHandler.HandlerSchemes, opt);
            return builder;
        }

        public static AuthenticationBuilder AddBearerAuthentication(this AuthenticationBuilder builder,
            AuthorizationServerOptions options)
        {
            builder.AddScheme<DefaultBearerAuthenticationOptions, DefaultBearerAuthenticationHandler>
                (BearerAuthenticationHandler.HandlerSchemes, opt => opt.ServerOptions = options);
            return builder;
        }

        public static AuthenticationBuilder AddCookieAuthentication(this AuthenticationBuilder builder,
            AuthorizationServerOptions options)
        {
            builder.AddScheme<DefaultCookieAuthenticationOptions, DefaultCookieAuthenticationHandler>
                (CookieAuthenticationHandler.HandlerSchemes, opt =>
                {
                    opt.ServerOptions = options;
                    opt.CookieKey = options.AccessTokenCookieKey;
                });
            return builder;
        }

        public static AuthenticationBuilder AddCookieAuthentication<Handler>(this AuthenticationBuilder builder,
            Action<AuthenticationCookieOptions> opt = null
        ) where Handler : CookieAuthenticationHandler
        {
            builder.AddScheme<AuthenticationCookieOptions, Handler>(CookieAuthenticationHandler.HandlerSchemes, opt);
            return builder;
        }

        public static IApplicationBuilder UseAuthorizationServer(this IApplicationBuilder app, AuthorizationServerOptions options)
        {
            return app.UseMiddleware<AuthorizationServerMiddleware>(options);
        }

    }
}
