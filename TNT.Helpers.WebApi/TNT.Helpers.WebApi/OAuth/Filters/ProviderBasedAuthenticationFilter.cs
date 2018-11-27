using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using TNT.Helpers.WebApi.OAuth;

namespace TNT.Helpers.WebApi.OAuth.Filters
{
    public abstract class ProviderBasedAuthenticationFilter : AuthenticationFilter
    {
        protected override string AuthenticationType { get; set; } = "ProviderBased";
        public abstract IEnumerable<string> ProviderAuthenticationTypes { get; set; }

        public IAuthenticationProvider<ProviderBasedAuthenticationFilter> Provider { get; set; }

        public override async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            this.context = context;
            var request = context.Request;
            var authHeader = request.Headers.Authorization;
            if (authHeader == null)
                return;
            Provider = GetProvider();
            if (Provider == null)
                return;

            var authPara = authHeader.Parameter;
            if (authPara == null)
            {
                context.ErrorResult = MissingAuthorizationParameter;
                return;
            }

            await Provider.AuthenticateAsync(this);
        }

        public override Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            List<AuthenticationHeaderValue> authHeaders = new List<AuthenticationHeaderValue>();
            foreach (var t in ProviderAuthenticationTypes)
            {
                authHeaders.Add(new AuthenticationHeaderValue(t));
            }
            context.Result = new AuthChallenge(authHeaders, context.Result);
            return Task.FromResult(0);
        }

        protected abstract IAuthenticationProvider<ProviderBasedAuthenticationFilter> GetProvider();

        protected abstract IHttpActionResult MissingAuthorizationParameter { get; }

    }
}
