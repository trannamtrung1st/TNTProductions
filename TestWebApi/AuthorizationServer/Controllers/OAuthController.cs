using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace AuthorizationServer.Controllers
{
    public class OAuthController : ApiController
    {
        public HttpResponseMessage Authorize()
        {
            if (HttpContext.Current.Response.StatusCode != 200)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Unauthorized
                };
            }

            var authentication = HttpContext.Current.GetOwinContext().Authentication;
            var ticket = authentication.AuthenticateAsync("Bearer").Result;
            var identity = ticket != null ? ticket.Identity : null;
            if (identity == null)
            {
                authentication.Challenge("Application");
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Unauthorized
                };
            }

            var scopes = Request.GetQueryNameValuePairs().Where(kvp => kvp.Key == "scope")
                .FirstOrDefault().Value.Split(' ');

            identity = new ClaimsIdentity(identity.Claims, "Bearer", identity.NameClaimType, identity.RoleClaimType);
            foreach (var scope in scopes)
            {
                identity.AddClaim(new Claim("urn:oauth:scope", scope));
            }
            authentication.SignIn(identity);

            var curIdentity = Thread.CurrentPrincipal.Identity;
            if (curIdentity == null)
            {
                authentication.SignOut("Application");
                authentication.Challenge("Application");
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Unauthorized
                };
            }

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
