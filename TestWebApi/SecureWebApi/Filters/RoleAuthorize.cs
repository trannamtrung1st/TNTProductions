using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using TNT.Helpers.WebApi;
using TNT.Helpers.WebApi.Filters;

namespace SecureWebApi.Filters
{
    public class RoleAuthorize : RoleAuthorizationFilter
    {
        public RoleAuthorize(params string[] roles) : base(roles)
        {
        }

        protected override HttpResponseMessage AnonymousNotAllowed
        {
            get
            {
                return Http.Unauthorized("Annonymouse not allowed");
            }
        }

        protected override HttpResponseMessage UnauthorizedRole
        {
            get
            {
                return Http.Unauthorized("Unauthorized role");
            }
        }
    }
}