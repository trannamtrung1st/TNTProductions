using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Http;

namespace AuthorizationServer.Controllers
{
    public class AccountController : ApiController
    {

        private string[] FetchResourceOwnerCredential()
        {
            var authHeader = HttpContext.Current.Request.Headers["Authorization"];
            if (authHeader == null)
                return null;
            if (!authHeader.StartsWith("Basic"))
                return null;
            var kvp = authHeader.Split(' ');
            if (kvp.Length == 1)
            {
                return null;
            }
            var authHeaderValue = Encoding.Default.GetString(Convert.FromBase64String(kvp[1]));
            var credentials = authHeaderValue.Split(':');
            return credentials;
        }

        //basic authentication
        public HttpResponseMessage Login()
        {
            var credentials = FetchResourceOwnerCredential();
            if (credentials == null)
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Unauthorized
                };
            var authentication = HttpContext.Current.GetOwinContext().Authentication;
            authentication.SignIn(
                new AuthenticationProperties { IsPersistent = true }, //session persisted
                new ClaimsIdentity(
                    new List<Claim>() { new Claim(ClaimTypes.Name, credentials[0]) },
                    "Application"));

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
        }

        public HttpResponseMessage Logout()
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
        }

        public HttpResponseMessage External()
        {
            var authentication = HttpContext.Current.GetOwinContext().Authentication;
            var identity = authentication.AuthenticateAsync("External").Result.Identity;
            if (identity != null)
            {
                authentication.SignOut("External");
                authentication.SignIn(
                    new AuthenticationProperties { IsPersistent = true },
                    new ClaimsIdentity(identity.Claims, "Application", identity.NameClaimType, identity.RoleClaimType));
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };
            }
            return new HttpResponseMessage()
            {
            };
        }
    }
}
