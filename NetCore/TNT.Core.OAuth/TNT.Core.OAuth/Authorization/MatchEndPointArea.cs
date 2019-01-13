using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.OAuth.Authorization
{
    public class OAuthMatchEndpointContext : OAuthContext
    {
        public OAuthMatchEndpointContext(OAuthContext context) : base(context)
        {
        }

        public OAuthMatchEndpointContext(HttpContext httpContext, AuthorizationServerOptions options) : base(httpContext, options)
        {
        }

        public bool IsTokenEndpoint { get; set; }
    }

    public partial class AuthorizationServerProvider : IOAuthAuthorizationServerProvider
    {
        public Task MatchEndpoint(OAuthMatchEndpointContext context)
        {
            context.IsTokenEndpoint = context.HttpContext.Request.Path.Value.ToLowerInvariant().Equals(
                    context.Options.TokenEndpointPath.Value.ToLowerInvariant());
            if (!context.IsTokenEndpoint)
                context.Rejected();
            else context.Validate();

            return Task.CompletedTask;
        }
    }
}
