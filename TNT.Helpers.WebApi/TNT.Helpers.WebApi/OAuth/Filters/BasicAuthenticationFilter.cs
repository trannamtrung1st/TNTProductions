using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;

namespace TNT.Helpers.WebApi.OAuth.Filters
{
    public abstract class BasicAuthenticationFilter : AuthenticationFilter
    {
        protected override string AuthenticationType { get; set; } = "Basic";

        public override async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            this.context = context;
            var request = context.Request;
            var authHeader = request.Headers.Authorization;
            if (authHeader == null)
                return;
            if (!AuthenticationType.Contains(authHeader.Scheme))
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

            await AuthenticateAsync(rawUsername, rawPassword);
        }

        protected abstract Task AuthenticateAsync(string rawUsername, string rawPassword);

        protected abstract IHttpActionResult MissingCredential { get; }
        protected abstract IHttpActionResult InvalidCredential { get; }

    }
}
