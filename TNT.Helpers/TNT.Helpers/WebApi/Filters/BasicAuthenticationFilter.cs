using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;

namespace TNT.Helpers.WebApi.Filters
{
    public abstract class BasicAuthenticationFilter : AuthenticationFilter
    {
        protected override string AuthScheme
        {
            get
            {
                return "Basic";
            }
        }

        public override async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            this.context = context;
            var request = context.Request;
            var authHeader = request.Headers.Authorization;
            if (authHeader == null)
                return;
            if (!authHeader.Scheme.Equals(AuthScheme))
                return;
            if (authHeader.Parameter == null)
            {
                context.ErrorResult = MissingCredential;
                return;
            }
            var authHeaderValue = Encoding.Default.GetString(Convert.FromBase64String(authHeader.Parameter));
            var credentials = authHeaderValue.Split(':');
            if (authHeaderValue.Length < 2)
            {
                context.ErrorResult = InvalidCredential;
                return;
            }

            var rawUsername = credentials[0];
            var rawPassword = credentials[1];

            var principal = await AuthenticateAsync(rawUsername, rawPassword);
            if (principal != null)
                SetPrincipal(principal);
        }

        protected abstract Task<IPrincipal> AuthenticateAsync(string rawUsername, string rawPassword);

        protected abstract IHttpActionResult MissingCredential { get; }
        protected abstract IHttpActionResult InvalidCredential { get; }

    }
}
