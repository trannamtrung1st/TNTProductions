using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.OAuth.Authorization
{
    public class OAuthGrantResourceOwnerCredentialsContext : OAuthContext
    {
        public OAuthGrantResourceOwnerCredentialsContext(OAuthContext context) : base(context)
        {
            Username = FormData["username"];
            Password = FormData["password"];
        }

        public OAuthGrantResourceOwnerCredentialsContext(HttpContext httpContext, AuthorizationServerOptions options) : base(httpContext, options)
        {
            Username = FormData["username"];
            Password = FormData["password"];
        }

        public string Username { get; }
        public string Password { get; }
    }

    public partial class AuthorizationServerProvider : IOAuthAuthorizationServerProvider
    {

        public abstract Task<AuthenticationTicket> AuthenticateAsync(string rawUsername, string rawPassword);
        public async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var ticket = await AuthenticateAsync(context.Username, context.Password);
            if (ticket == null)
            {
                context.SetError(StatusCodes.Status401Unauthorized, Constants.InvalidRequest, Constants.InvalidCredentials);
                return;
            }
            context.Validate(ticket);
        }
    }
}
