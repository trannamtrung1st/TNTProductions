using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.OAuth.Authorization
{
    public partial class AuthorizationServerProvider : IOAuthAuthorizationServerProvider
    {
        public Task ValidateTokenRequest(OAuthValidateTokenRequestContext context)
        {
            if (!context.HttpContext.Request.Method.ToLowerInvariant().Equals("post"))
            {
                context.SetError(StatusCodes.Status400BadRequest, Constants.InvalidRequest, Constants.UnsupportedMethod);
                return Task.CompletedTask;
            }

            switch (context.GrantType)
            {
                case "password":
                    if (!context.FormData.ContainsKey("username") || !context.FormData.ContainsKey("password"))
                        context.SetError(StatusCodes.Status400BadRequest, Constants.InvalidTokenRequest);
                    break;
                case "refresh_token":
                    if (!context.FormData.ContainsKey("refresh_token"))
                        context.SetError(StatusCodes.Status400BadRequest, Constants.InvalidTokenRequest);
                    break;
                case null:
                    context.SetError(StatusCodes.Status400BadRequest, Constants.InvalidTokenRequest);
                    break;
            }
            if (!context.HasError)
                context.Validate();
            return Task.CompletedTask;
        }
    }

    public class OAuthValidateTokenRequestContext : OAuthContext
    {
        public OAuthValidateTokenRequestContext(OAuthContext context) : base(context)
        {
            GrantType = FormData?["grant_type"];
        }

        public OAuthValidateTokenRequestContext(HttpContext httpContext, AuthorizationServerOptions options) : base(httpContext, options)
        {
            GrantType = FormData?["grant_type"];
        }

        public string GrantType { get; }
    }

}
