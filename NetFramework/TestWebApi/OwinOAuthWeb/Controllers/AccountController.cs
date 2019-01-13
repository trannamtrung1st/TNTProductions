using OwinOAuthWeb.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using TNT.Helpers.WebApi;

namespace OwinOAuthWeb.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {

        [Authorize]
        [Route("logout")]
        public HttpResponseMessage Logout()
        {
            var user = Users.ListUsers.Where(u => u.Username == User.Identity.Name).FirstOrDefault();
            user.RefreshToken = null;
            user.AccessToken = null;
            user.TokenExpireDate = null;
            user.TokenIssuedDate = null;
            user.RefreshTokenExpireDate = null;
            user.RefreshTokenIssuedDate = null;
            var mess = Http.Ok();
            Request.GetOwinContext().Response.Cookies.Append("TNT", "");
            return mess;
        }

    }
}
