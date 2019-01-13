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
using TNT.Helpers.Cryptography;
using TNT.Helpers.WebApi;

namespace SecureWebApi.Controllers.Apis
{
    [Authorize]
    [BearerAuthenticate]
    [RoutePrefix("api/security")]
    public class SecurityController : ApiController
    {
        [OverrideAuthentication]
        [ProviderBasedAuthenticate]
        [BasicAuthenticate]
        [Route("token")]
        [HttpGet]
        public HttpResponseMessage GetToken()
        {
            var userVM = (Thread.CurrentPrincipal.Identity as UserViewModel);
            var user = userVM.ToEntity();
            if (userVM.HasClaim(ClaimTypes.Authentication, "Application"))
            {
                user.Token = GetAuthToken();
            }
            else
                user.Token = userVM.Token;
            var now = DateTime.Now;
            user.TokenGenTime = now;
            user.TokenExpiryTime = now.AddMinutes(1);
            return Http.OkBase(user.ToViewModel(), "Success");
        }

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

        [Route("user")]
        [HttpGet]
        public HttpResponseMessage GetUser()
        {
            var user = (Thread.CurrentPrincipal.Identity as UserViewModel);
            return Http.OkBase(user, "Success");
        }

        [Route("create-resource")]
        [HttpGet]
        public HttpResponseMessage CreateResource()
        {
            return Http.OkBase(null, "OK");
        }

        private static TokenGenerator tokenGen = new TokenGenerator(256);
        private string GetAuthToken()
        {
            //test;
            return tokenGen.Generate();
        }

    }
}
