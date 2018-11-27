using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace TNT.Helpers.WebApi.Owin
{
    public abstract class BasicAuthenticationMiddleware : AuthenticationMiddleware<BasicAuthenticationOptions>
    {
        public BasicAuthenticationMiddleware(OwinMiddleware next, BasicAuthenticationOptions options) : base(next, options)
        {
        }

    }

    public class BasicAuthenticationOptions : AuthenticationOptions
    {
        public BasicAuthenticationOptions() : base("Basic")
        {
        }
    }

    public abstract class BasicAuthenticationHandler : BaseAuthenticationHandler<BasicAuthenticationOptions>
    {
        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            //remember to change the state
            processed = true;
            //----------------------------

            var authHeader = GetAuthHeader();
            if (authHeader == null)
            {
                return null;
            }
            var authHeaderParam = Encoding.Default.GetString(Convert.FromBase64String(authHeader[1]));
            var credentials = authHeaderParam.Split(':');
            if (credentials.Length < 2)
            {
                return null;
            }
            var rawUsername = credentials[0];
            var rawPassword = credentials[1];
            return await AuthenticateAsync(rawUsername, rawPassword);
        }

        protected abstract Task<AuthenticationTicket> AuthenticateAsync(string rawUsername, string rawPassword);

    }

}
