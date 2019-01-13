using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TNT.Helpers.WebApi.Owin
{
    public static class OwinExtensions
    {
        public static void AttachOwinEnvironmentPerRequest(this IAppBuilder app)
        {
            app.Use((c, next) =>
            {
                var req = HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage;
                if (req != null)
                    req.SetOwinEnvironment(c.Environment);
                return next();
            });
        }

    }
}
