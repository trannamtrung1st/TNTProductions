using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TNT.Core.OAuth.Authorization
{
    public class OAuthGrantRefreshTokenContext : OAuthContext
    {
        public OAuthGrantRefreshTokenContext(OAuthContext context) : base(context)
        {
            this.RefreshToken = FormData["refresh_token"];
        }

        public OAuthGrantRefreshTokenContext(HttpContext httpContext, AuthorizationServerOptions options) : base(httpContext, options)
        {
            this.RefreshToken = FormData["refresh_token"];
        }

        public string RefreshToken { get; }
    }

    public partial class AuthorizationServerProvider : IOAuthAuthorizationServerProvider
    {

        public Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            if (Options.RefreshTokenProvider != null)
            {
                try
                {
                    var refreshReceiveContext = new AuthenticationTokenReceiveContext(context, Options.RefreshTokenFormat);
                    refreshReceiveContext.Token = context.RefreshToken;
                    Options.RefreshTokenProvider.ReceiveAsync(refreshReceiveContext);
                    var refreshTicket = refreshReceiveContext.Ticket;

                    if (refreshTicket.Properties.ExpiresUtc != null
                        && refreshTicket.Properties.ExpiresUtc < DateTime.UtcNow)
                        context.SetError(StatusCodes.Status401Unauthorized, Constants.InvalidTokenRequest, Constants.TokenExpired);
                    else context.Validate(refreshTicket);
                }
                catch (Exception e)
                {
                    context.SetError(StatusCodes.Status400BadRequest, Constants.InvalidTokenRequest, Constants.InvalidToken);
                }
            }
            return Task.CompletedTask;
        }
    }
}
