using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace TNT.Helpers.WebApi.Owin
{
    public abstract class BaseAuthenticationHandler<TOptions> : AuthenticationHandler<TOptions> where TOptions : AuthenticationOptions
    {
        protected bool processed;

        protected override Task ApplyResponseChallengeAsync()
        {
            if (processed && Response.StatusCode == 401)
            {
                var wwwAuth = Response.Headers.GetCommaSeparatedValues("Www-Authenticate");
                if (wwwAuth == null || !wwwAuth.Contains(Options.AuthenticationType))
                    Response.Headers.Append("Www-Authenticate", Options.AuthenticationType);
            }
            return Task.FromResult(0);
        }
    }

    public abstract class AuthorizationHeaderHandler<TOptions> : BaseAuthenticationHandler<TOptions> where TOptions : AuthenticationOptions
    {

        public virtual string[] GetAuthHeader()
        {
            if (string.IsNullOrEmpty(Request.Headers["Authorization"]))
                return null;
            var authHeaderStr = Request.Headers["Authorization"];
            var headerParts = authHeaderStr.Split(' ');
            if (headerParts.Length != 2)
                return null;
            if (!headerParts[0].ToLower().Equals(Options.AuthenticationType.ToLower()))
                return null;
            return headerParts;
        }

    }

}
