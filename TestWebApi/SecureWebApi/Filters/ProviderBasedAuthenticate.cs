using SecureWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using TNT.Helpers.WebApi;
using System.Security.Claims;
using TNT.Helpers.WebApi.OAuth.Filters;
using TNT.Helpers.WebApi.OAuth.Providers;

namespace SecureWebApi.Filters
{
    public class ProviderBasedAuthenticate : ProviderBasedAuthenticationFilter
    {
        static ProviderBasedAuthenticate()
        {
            ProviderByScheme["Facebook"] = new FacebookOAuth(
                "523869358117226", 
                "14b9045c0222858c250ac81394778665");
            ProviderByScheme["Google"] = new GoogleOAuth(
                "931960859587-hjibavglvimtv5d4rofuiul7sdqblht7.apps.googleusercontent.com", 
                "USs_I-dgw4l1Voj2hsyvi0kC");
        }

        protected override IHttpActionResult MissingAuthorizationParameter
        {
            get
            {
                return new UnauthorizedResult("Missing authorization parameter");
            }
        }

        protected override Task AuthenticateAsync(ClaimsIdentity identity)
        {
            identity.AddClaim(new Claim(ClaimTypes.Authentication, "External"));
            SetPrincipal(new ClaimsPrincipal(identity));
            return Task.FromResult(0);
        }

    }

    public class FacebookOAuth : FacebookProvider
    {
        public FacebookOAuth(string appId, string appSecret) : base(appId, appSecret)
        {
        }

        public override async Task<ClaimsIdentity> AuthenticateAsync(string scheme, string token, HttpAuthenticationContext context)
        {
            var debug = await DebugToken(token);
            if (debug == null)
            {
                context.ErrorResult = new UnauthorizedResult("Invalid or expired token");
                return null;
            }

            var user = User.Mappings.Values.Where(u => u.UserId == debug.Data.UserId).FirstOrDefault();
            if (user == null)
            {
                context.ErrorResult = new UnauthorizedResult("User hasn't registered");
                return null;
            }
            var userVM = new UserViewModel(user);
            userVM.Token = token;
            return userVM;
        }
    }

    public class GoogleOAuth : GoogleProvider
    {
        public GoogleOAuth(string clientId, string clientSecret) : base(clientId, clientSecret)
        {
        }

        public override async Task<ClaimsIdentity> AuthenticateAsync(string scheme, string token, HttpAuthenticationContext context)
        {
            var debug = await DebugToken(token);
            if (debug == null)
            {
                context.ErrorResult = new UnauthorizedResult("Invalid or expired token");
                return null;
            }

            var user = User.Mappings.Values.Where(u => u.UserId == debug.SubId).FirstOrDefault();
            if (user == null)
            {
                context.ErrorResult = new UnauthorizedResult("User hasn't registered");
                return null;
            }
            var userVM = new UserViewModel(user);
            userVM.Token = token;
            return userVM;
        }
    }

}