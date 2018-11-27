using SecureWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http;
using TNT.Helpers.WebApi.OAuth.Filters;

namespace SecureWebApi.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class BearerAuthenticate : BearerAuthenticationFilter
    {

        protected override IHttpActionResult MissingToken
        {
            get
            {
                return new UnauthorizedResult("Missing token");
            }
        }

        protected override Task AuthenticateAsync(string rawToken)
        {
            var user = User.Mappings.Values.Where(u => u.Token == rawToken).FirstOrDefault();
            if (user == null)
            {
                this.context.ErrorResult = new UnauthorizedResult("Invalid token");
                return Task.FromResult(0);
            }
            if (user.TokenExpiryTime < DateTime.Now)
            {
                this.context.ErrorResult = new UnauthorizedResult("Token expired");
                return Task.FromResult(0);
            }
            var timespan = user.TokenExpiryTime.Value.Subtract(DateTime.Now).TotalSeconds;
            if (timespan < (int)(0.5 * 60))
                user.TokenExpiryTime = user.TokenExpiryTime.Value.AddMinutes(1);
            var principal = new UserPrincipal(new UserViewModel(user));
            SetPrincipal(principal);
            return Task.FromResult(0);
        }

    }
}