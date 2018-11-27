using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helpers.WebApi.Owin
{
    public abstract class BearerAuthenticationMiddleware : AuthenticationMiddleware<BearerAuthenticationOptions>
    {
        public BearerAuthenticationMiddleware(OwinMiddleware next, BearerAuthenticationOptions options) : base(next, options)
        {
        }

    }

    public class BearerAuthenticationOptions : AuthenticationOptions
    {
        public BearerAuthenticationOptions() : base("Bearer")
        {
        }
    }

    public abstract class BearerAuthenticationHandler : BaseAuthenticationHandler<BearerAuthenticationOptions>
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
            var bearer = authHeader[1];
            return await AuthenticateAsync(bearer);
        }

        protected abstract Task<AuthenticationTicket> AuthenticateAsync(string bearer);

    }
}
