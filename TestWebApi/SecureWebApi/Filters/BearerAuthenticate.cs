using SecureWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TNT.Helpers.WebApi;
using TNT.Helpers.WebApi.Filters;

namespace SecureWebApi.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class BearerAuthenticate : BearerAuthenticationFilter
    {

        protected override IHttpActionResult MissingToken
        {
            get
            {
                return new AuthResult("Missing token");
            }
        }

        protected override async Task AuthenticateAsync(string rawToken)
        {
            await Task.Run(() =>
            {
                var user = User.Mappings.Values.Where(u => u.Token == rawToken).FirstOrDefault();
                if (user == null)
                {
                    this.context.ErrorResult = new AuthResult("Invalid token");
                    return;
                }
                if (user.TokenExpiryTime < DateTime.Now)
                {
                    this.context.ErrorResult = new AuthResult("Token expired");
                    return;
                }
                var timespan = user.TokenExpiryTime.Value.Subtract(DateTime.Now).TotalSeconds;
                if (timespan < (int)(0.5 * 60))
                    user.TokenExpiryTime = user.TokenExpiryTime.Value.AddMinutes(1);
                SetPrincipal(new UserPrincipal(user.ToViewModel()), context);
            });
        }

    }
}