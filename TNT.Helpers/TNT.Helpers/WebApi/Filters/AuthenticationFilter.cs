using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace TNT.Helpers.WebApi.Filters
{
    public abstract class AuthenticationFilter : Attribute, IAuthenticationFilter
    {
        protected abstract string AuthScheme { get; }
        protected HttpAuthenticationContext context;

        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            context.Result = new AuthChallenge(new AuthenticationHeaderValue(AuthScheme), context.Result);
            return Task.FromResult(0);
        }

        protected void SetPrincipal(IPrincipal principal, HttpAuthenticationContext authContext = null)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
            if (authContext != null)
            {
                authContext.Principal = principal;
            }
        }

        public abstract Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken);
    }

}