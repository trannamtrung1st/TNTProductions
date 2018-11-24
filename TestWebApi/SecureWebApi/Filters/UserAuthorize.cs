using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using TNT.Helpers.WebApi;
using TNT.Helpers.WebApi.Filters;

namespace SecureWebApi.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class UserAuthorize : UserAuthorizationFilter
    {
        protected override HttpResponseMessage AnonymousNotAllowed
        {
            get
            {
                return Http.Unauthorized("Anonymous not allowed", "Anonymous not allowed");
            }
        }
    }
}