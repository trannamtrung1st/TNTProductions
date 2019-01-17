using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.OAuth.Authorization
{
    public class OAuthGrantCustomExtensionContext : OAuthContext
    {
        public OAuthGrantCustomExtensionContext(OAuthContext context) : base(context)
        {
            ClientId = FormData["client_id"];
            GrantType = FormData["grant_type"];
        }

        public OAuthGrantCustomExtensionContext(HttpContext httpContext, AuthorizationServerOptions options) : base(httpContext, options)
        {
            ClientId = FormData["client_id"];
            GrantType = FormData["grant_type"];
        }

        public string ClientId { get; }
        public string GrantType { get; }
    }

    public partial class AuthorizationServerProvider : IOAuthAuthorizationServerProvider
    {
        public async Task GrantCustomExtension(OAuthGrantCustomExtensionContext context)
        {
            var exOptions = Options.ExternalOAuthOptions;
            AuthenticationTicket ticket = null;
            if (exOptions != null)
            {
                var fbClient = exOptions.FacebookClient;
                var ggClient = exOptions.GoogleClient;
                string accessToken = context.FormData["access_token"];
                if (fbClient != null && context.GrantType.Equals("fb_access_token"))
                {
                    var debug = await fbClient.DebugToken(accessToken);
                    if (debug != null && debug.IsValid)
                        ticket = exOptions.FacebookAuthenticate != null ?
                           await exOptions.FacebookAuthenticate.Invoke(Options, debug) : null;
                }
                else if (ggClient != null && context.GrantType.Equals("gg_access_token"))
                {
                    var debug = await ggClient.DebugToken(accessToken);
                    if (debug != null && debug.IsValid)
                        ticket = exOptions.GoogleAuthenticate != null ?
                            await exOptions.GoogleAuthenticate.Invoke(Options, debug) : null;
                }
                else
                {
                    context.SetError(StatusCodes.Status400BadRequest, Constants.InvalidRequest, Constants.UnsupportedGrantType);
                    return;
                }
            }
            else
            {
                context.SetError(StatusCodes.Status400BadRequest, Constants.InvalidRequest, Constants.UnsupportedGrantType);
                return;
            }
            if (ticket == null)
            {
                context.SetError(StatusCodes.Status401Unauthorized, Constants.InvalidRequest, Constants.InvalidToken);
                return;
            }
            context.Validate(ticket);
        }
    }


}
