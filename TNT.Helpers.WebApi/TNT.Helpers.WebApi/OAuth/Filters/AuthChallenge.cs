using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace TNT.Helpers.WebApi.OAuth.Filters
{
    public class AuthChallenge : IHttpActionResult
    {
        public AuthChallenge(IEnumerable<AuthenticationHeaderValue> challenges, IHttpActionResult innerResult)
        {
            Challenges = challenges;
            InnerResult = innerResult;
        }

        public AuthChallenge(AuthenticationHeaderValue challenge, IHttpActionResult innerResult)
        {
            Challenges = new List<AuthenticationHeaderValue>() { challenge };
            InnerResult = innerResult;
        }

        public IEnumerable<AuthenticationHeaderValue> Challenges { get; private set; }

        public IHttpActionResult InnerResult { get; private set; }

        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await InnerResult.ExecuteAsync(cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                foreach (var c in Challenges)
                {
                    // Only add one challenge per authentication scheme.
                    if (!response.Headers.WwwAuthenticate.Any(h => h.Scheme == c.Scheme))
                    {
                        response.Headers.WwwAuthenticate.Add(c);
                    }
                }
            }
            return response;
        }
    }
}