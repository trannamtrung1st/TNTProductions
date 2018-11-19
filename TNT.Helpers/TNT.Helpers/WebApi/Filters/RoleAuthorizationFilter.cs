using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TNT.Helpers.WebApi.Filters
{
    public abstract class RoleAuthorizationFilter : AuthorizationFilterAttribute
    {
        protected string[] Roles { get; }

        public RoleAuthorizationFilter(params string[] roles)
        {
            Roles = roles;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var principal = Thread.CurrentPrincipal as GenericPrincipal;

            if (principal == null)
            {
                actionContext.Response = AnonymousNotAllowed;
                return;
            }

            if (!AuthorizeRole(principal, actionContext))
                return;

            base.OnAuthorization(actionContext);
        }

        private bool AuthorizeRole(IPrincipal principal, HttpActionContext actionContext)
        {
            var valid = false;
            if (Roles.Length > 0)
            {
                foreach (var r in Roles)
                    if (principal.IsInRole(r))
                    {
                        valid = true;
                        break;
                    }
            }
            else valid = true;

            if (!valid)
            {
                actionContext.Response = UnauthorizedRole;
            }
            return valid;
        }

        protected abstract HttpResponseMessage UnauthorizedRole { get; }
        protected abstract HttpResponseMessage AnonymousNotAllowed { get; }

    }
}
