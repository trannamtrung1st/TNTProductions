using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TNT.Helpers.WebApi.Filters
{
    public abstract class UserAuthorizationFilter : AuthorizationFilterAttribute
    {
        public UserAuthorizationFilter()
        {
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var principal = Thread.CurrentPrincipal as GenericPrincipal;

            if (principal == null)
            {
                actionContext.Response = AnonymousNotAllowed;
                return;
            }

            base.OnAuthorization(actionContext);
        }

        protected abstract HttpResponseMessage AnonymousNotAllowed { get; }
    }
}
