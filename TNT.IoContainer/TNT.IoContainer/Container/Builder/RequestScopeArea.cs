using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TNT.IoContainer.Wrapper;

namespace TNT.IoContainer.Container
{
    public class TContainerModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            //context.BeginRequest += this.Application_BeginRequest;
            context.EndRequest += this.Application_EndRequest;
            context.Error += this.Application_Error;
        }

        //protected void Application_BeginRequest(object sender, EventArgs args)
        //{
        //}

        protected void Application_EndRequest(object sender, EventArgs args)
        {
            var container = HttpContext.Current.Items[typeof(ITContainer)];
            if (container != null)
                ((ITContainer)container).Dispose();
        }

        protected void Application_Error(object sender, EventArgs args)
        {
            var container = HttpContext.Current.Items[typeof(ITContainer)];
            if (container != null)
                ((ITContainer)container).Dispose();
        }

    }

    public partial class TContainerBuilder
    {

        public void RegisterRequestScopeHandlerModule()
        {
            HttpApplication.RegisterModule(typeof(TContainerModule));
        }

    }

}
