using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using SecureWebApi.Filters;

[assembly: OwinStartup(typeof(SecureWebApi.OwinStartup))]

namespace SecureWebApi
{
    public class OwinStartup
    {
        // Note: By default all requests go through this OWIN pipeline. Alternatively you can turn this off by adding an appSetting owin:AutomaticAppStartup with value “false”. 
        // With this turned off you can still have OWIN apps listening on specific routes by adding routes in global.asax file using MapOwinPath or MapOwinRoute extensions on RouteTable.Routes
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
