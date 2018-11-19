﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;

namespace TNT.Helpers.WebApi.Filters
{
    public abstract class BearerAuthenticationFilter : AuthenticationFilter
    {
        protected override string AuthScheme
        {
            get
            {
                return "Bearer";
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
            var rawToken = authHeader.Parameter;
            if (rawToken == null)
            {
                context.ErrorResult = MissingToken;
                return;
            }

            await AuthenticateAsync(rawToken);
        }

        protected abstract Task AuthenticateAsync(string rawToken);

        protected abstract IHttpActionResult MissingToken { get; }
    }
}
