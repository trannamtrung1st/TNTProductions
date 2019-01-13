using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.OAuth.Authorization
{
    public class OAuthTokenEndpointResponseContext : OAuthContext
    {
        public OAuthTokenEndpointResponseContext(AuthenticationTicket finalTicket, OAuthContext context) : base(context)
        {
            Ticket = finalTicket;
            Properties = Ticket.Properties;
            ResponseParameters = new Dictionary<string, string>();
        }

        public OAuthTokenEndpointResponseContext(AuthenticationTicket finalTicket,
            HttpContext httpContext, AuthorizationServerOptions options) : base(httpContext, options)
        {
            Ticket = finalTicket;
            Properties = Ticket.Properties;
            ResponseParameters = new Dictionary<string, string>();
        }

        public AuthenticationProperties Properties { get; }
        public string AccessToken { get; set; }
        public IDictionary<string, string> ResponseParameters { get; }
    }

    public partial class AuthorizationServerProvider : IOAuthAuthorizationServerProvider
    {
        public Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            if (Options.AccessTokenProvider != null)
            {
                var tokenContext = new AuthenticationTokenCreateContext(context, Options.AccessTokenFormat);
                tokenContext.Ticket = context.Ticket;

                context.Properties.IssuedUtc = DateTime.UtcNow;
                context.Properties.ExpiresUtc = context.Properties.IssuedUtc.Value.Add(Options.AccessTokenExpireTimeSpan);
                Options.AccessTokenProvider.CreateAsync(tokenContext);
                context.AccessToken = tokenContext.Token;
                context.ResponseParameters["access_token"] = tokenContext.Token;
                context.ResponseParameters[".expires"] = context.Properties.ExpiresUtc?
                    .ToString("ddd, dd MMM yyy HH':'mm':'ss 'GMT'");
                context.ResponseParameters[".issued"] = context.Properties.IssuedUtc?
                    .ToString("ddd, dd MMM yyy HH':'mm':'ss 'GMT'");
                context.ResponseParameters["token_type"] = "Bearer";
                context.ResponseParameters["expires_in"] = ((long)Options.AccessTokenExpireTimeSpan.TotalSeconds).ToString();

            }

            if (Options.RefreshTokenProvider != null)
            {
                var refreshContext = new AuthenticationTokenCreateContext(context, Options.RefreshTokenFormat);
                refreshContext.Ticket = context.Ticket;
                Options.RefreshTokenProvider.CreateAsync(refreshContext);

                if (refreshContext.Token != null)
                {
                    context.ResponseParameters["refresh_token"] = refreshContext.Token;
                    if (refreshContext.Ticket.Properties.ExpiresUtc != null)
                        context.ResponseParameters[Constants.RefreshTokenExpiresKey] =
                            refreshContext.Ticket.Properties.ExpiresUtc?.ToString("ddd, dd MMM yyy HH':'mm':'ss 'GMT'");
                }
            }

            if (Options.AccessTokenCookieKey != null)
            {
                var cookieOptions = Options.AccessTokenCookieOptions(context.Properties.ExpiresUtc.Value.UtcDateTime);
                cookieOptions.Domain = Options.Domain;
                context.HttpContext.Response.Cookies.Append(Options.AccessTokenCookieKey, context.AccessToken, cookieOptions);
            }
            context.Validate();
            return Task.CompletedTask;
        }
    }
}
