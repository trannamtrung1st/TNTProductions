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
    public abstract class ProviderBasedAuthenticationMiddleware : AuthenticationMiddleware<ProviderBasedAuthenticationOptions>
    {
        public ProviderBasedAuthenticationMiddleware(OwinMiddleware next, ProviderBasedAuthenticationOptions options) : base(next, options)
        {
        }

    }

    public class ProviderBasedAuthenticationOptions : AuthenticationOptions
    {
        public ProviderBasedAuthenticationOptions() : base("ProviderBased")
        {
        }
    }

    public abstract class ProviderBasedAuthenticationHandler : AuthorizationHeaderHandler<ProviderBasedAuthenticationOptions>
    {
        public abstract IEnumerable<string> AuthenticationTypes { get; set; }
        protected string[] authHeaders;

        protected IAuthenticationProvider<ProviderBasedAuthenticationHandler, ProviderBasedAuthenticationOptions> Provider { get; set; }
        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            //remember to change the state
            processed = true;
            //----------------------------
            Provider = GetProvider();
            if (Provider != null)
                return await Provider.AuthenticateAsync(this);
            return null;
        }

        protected override Task ApplyResponseChallengeAsync()
        {
            if (processed && Response.StatusCode == 401)
            {
                var wwwAuth = Response.Headers.GetCommaSeparatedValues("Www-Authenticate");
                foreach (var t in AuthenticationTypes)
                    if (wwwAuth == null || !wwwAuth.Contains(t))
                        Response.Headers.Append("Www-Authenticate", t);
            }
            return Task.FromResult(0);
        }

        public override string[] GetAuthHeader()
        {
            if (authHeaders == null)
            {
                if (string.IsNullOrEmpty(Request.Headers["Authorization"]))
                    return null;
                var authHeaderStr = Request.Headers["Authorization"];
                var headerParts = authHeaderStr.Split(' ');
                if (headerParts.Length != 2)
                    return null;
                authHeaders = headerParts;
            }
            return authHeaders;
        }

        protected abstract IAuthenticationProvider<ProviderBasedAuthenticationHandler, ProviderBasedAuthenticationOptions>
            GetProvider();

    }

    public interface IAuthenticationProvider<THandler, TOptions> : IDisposable
            where THandler : AuthenticationHandler<TOptions> where TOptions : AuthenticationOptions
    {
        string AuthenticationType { get; set; }
        Task<AuthenticationTicket> AuthenticateAsync(THandler handler);
    }

}
