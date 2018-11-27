using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace TNT.Helpers.WebApi.OAuth.Filters
{
    public abstract class AuthenticationFilter : Attribute, IAuthenticationFilter
    {
        protected abstract string AuthenticationType { get; set; }
        protected HttpAuthenticationContext context;

        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        public virtual Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            context.Result = new AuthChallenge(new AuthenticationHeaderValue(AuthenticationType), context.Result);
            return Task.FromResult(0);
        }

        protected void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        protected IPrincipal GetPrincipal()
        {
            var principal = Thread.CurrentPrincipal;
            return principal;
        }

        public abstract Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken);
    }

}