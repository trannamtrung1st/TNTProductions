using SecureWebApi.Filters;
using SecureWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Filters;
using TNT.Helpers.WebApi;

namespace SecureWebApi.Controllers.Apis
{
    [RoutePrefix("api/security")]
    public class SecurityController : ApiController
    {

        //[BasicAuthenticate]
        //[UserAuthorize]
        [Route("token")]
        [HttpGet]
        public HttpResponseMessage GetToken()
        {
            var user = (Thread.CurrentPrincipal.Identity as UserViewModel).ToEntity();
            var now = DateTime.Now;
            user.Token = GetAuthToken();
            user.TokenGenTime = now;
            user.TokenExpiryTime = now.AddMinutes(1);
            return Http.OkBase(user.ToViewModel(), "Success");
        }

        //[BearerAuthenticate]
        //[UserAuthorize]
        [Route("logout")]
        [HttpGet]
        public HttpResponseMessage LogOut()
        {
            var user = (Thread.CurrentPrincipal.Identity as UserViewModel).ToEntity();
            user.Token = null;
            user.TokenGenTime = null;
            user.TokenExpiryTime = null;

            return Http.OkBase(null, "Log out successfully");
        }

        //[BearerAuthenticate]
        //[UserAuthorize]
        [Route("user")]
        [HttpGet]
        public HttpResponseMessage GetUser()
        {
            var user = (Thread.CurrentPrincipal.Identity as UserViewModel);
            return Http.OkBase(user, "Success");
        }

        //[BearerAuthenticate]
        //[RoleAuthorize("Administrator", "Manager")]
        [Route("create-resource")]
        [HttpGet]
        public HttpResponseMessage CreateResource()
        {
            return Http.OkBase(null, "OK");
        }

        private string GetAuthToken()
        {
            //test;
            return Guid.NewGuid().ToString();
        }

    }
}
