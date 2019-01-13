using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TNT.OAuth.Authentication
{
    #region Base Cookie Authentication
    public abstract class CookieAuthenticationMiddleware<TOptions> : AuthenticationMiddleware<TOptions> where TOptions : AuthenticationOptions
    {
        public CookieAuthenticationMiddleware(OwinMiddleware next, TOptions options) : base(next, options)
        {
        }

    }

    public abstract class CookieAuthenticationMiddleware : CookieAuthenticationMiddleware<CookieAuthenticationOptions>
    {
        public CookieAuthenticationMiddleware(OwinMiddleware next, CookieAuthenticationOptions options) : base(next, options)
        {
        }
    }

    public class CookieAuthenticationOptions : AuthenticationOptions
    {
        public string AuthenticationCookieKey { get; set; }

        public CookieAuthenticationOptions() : base("Cookie")
        {
        }
    }

    public abstract class CookieAuthenticationHandler<TOptions> : BaseAuthenticationHandler<TOptions> where TOptions : CookieAuthenticationOptions
    {
        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            //remember to change the state
            processed = true;
            //----------------------------
            var cookie = Request.Cookies[Options.AuthenticationCookieKey];
            if (cookie != null)
                return await AuthenticateAsync(cookie);
            return null;
        }

        protected abstract Task<AuthenticationTicket> AuthenticateAsync(string cookie);
    }

    public abstract class CookieAuthenticationHandler : CookieAuthenticationHandler<CookieAuthenticationOptions>
    {
    }
    #endregion
}
