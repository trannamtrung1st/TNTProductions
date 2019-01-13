using SecureWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TNT.Helpers.WebApi.OAuth.Filters;

namespace SecureWebApi.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class BasicAuthenticate : BasicAuthenticationFilter
    {
        protected override IHttpActionResult InvalidCredential
        {
            get
            {
                return new UnauthorizedResult("Invalid credential");
            }
        }

        protected override IHttpActionResult MissingCredential
        {
            get
            {
                return new UnauthorizedResult("Missing credential");
            }
        }

        protected override Task AuthenticateAsync(string rawUsername, string rawPassword)
        {
            var user = User.Mappings.Values.Where(
                u => u.Username == rawUsername
                && u.Password == rawPassword).FirstOrDefault();
            if (user == null)
            {
                this.context.ErrorResult = new UnauthorizedResult("Invalid username or password");
                return null;
            }
            var userVM = new UserViewModel(user);
            userVM.AddClaim(new Claim(ClaimTypes.Authentication, "Application"));
            var principal = new UserPrincipal(userVM);
            this.SetPrincipal(principal);
            return Task.FromResult(0);
        }
    }
}