using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helpers.WebApi.Owin
{
    #region Base Bearer Authentication
    public abstract class BearerAuthenticationMiddleware<TOptions> : AuthenticationMiddleware<TOptions> where TOptions : AuthenticationOptions
    {
        public BearerAuthenticationMiddleware(OwinMiddleware next, TOptions options) : base(next, options)
        {
        }

    }

    public abstract class BearerAuthenticationMiddleware : BearerAuthenticationMiddleware<BearerAuthenticationOptions>
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

    public abstract class BearerAuthenticationHandler<TOptions> : AuthorizationHeaderHandler<TOptions> where TOptions : AuthenticationOptions
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

    public abstract class BearerAuthenticationHandler : BearerAuthenticationHandler<BearerAuthenticationOptions>
    {
    }
    #endregion

}
