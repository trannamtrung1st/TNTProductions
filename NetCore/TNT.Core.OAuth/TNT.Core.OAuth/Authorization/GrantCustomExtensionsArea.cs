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
        public Task GrantCustomExtension(OAuthGrantCustomExtensionContext context)
        {
            context.SetError(StatusCodes.Status400BadRequest, Constants.UnsupportedGrantType);
            return Task.CompletedTask;
        }
    }


}
