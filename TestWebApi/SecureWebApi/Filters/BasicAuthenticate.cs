using SecureWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TNT.Helpers.WebApi.Filters;

namespace SecureWebApi.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class BasicAuthenticate : BasicAuthenticationFilter
    {
        protected override IHttpActionResult InvalidCredential
        {
            get
            {
                return new AuthResult("Invalid credential");
            }
        }

        protected override IHttpActionResult MissingCredential
        {
            get
            {
                return new AuthResult("Missing credential");
            }
        }

        protected override async Task<IPrincipal> AuthenticateAsync(string rawUsername, string rawPassword)
        {
            return await Task.Run(() =>
            {
                var user = User.Mappings.Values.Where(
                    u => u.Username == rawUsername
                    && u.Password == rawPassword).FirstOrDefault();
                if (user == null)
                {
                    this.context.ErrorResult = new AuthResult("Invalid username or password");
                    return null;
                }
                return new UserPrincipal(new UserViewModel(user));
            });
        }
    }
}