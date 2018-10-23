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

    public partial class TContainer
    {

        public void RegisterRequestScopeHandlerModule()
        {
            HttpApplication.RegisterModule(typeof(TContainerModule));
        }

        public ITContainer CreateRequestScope()
        {
            var container = CreateScope();
            HttpContext.Current.Items[typeof(ITContainer)] = container;
            return container;
        }

        public ITContainer CreateScope(HttpContext context)
        {
            var container = CreateScope();
            context.Items[typeof(ITContainer)] = container;
            return container;
        }

        public Type ResolveRequestScope<Type>(Params parameters = null)
        {
            var resolveType = typeof(Type);
            return (Type)ResolveRequestScope(resolveType, parameters);
        }

        public Type ResolveRequestScope<Type>(params object[] parameters)
        {
            var resolveType = typeof(Type);
            return (Type)ResolveRequestScope(resolveType, parameters);
        }

        public object ResolveRequestScope(Type type, Params parameters = null)
        {
            var items = HttpContext.Current.Items;
            var obj = items[type];
            if (obj == null)
            {
                var reqScopeContainer = items[typeof(ITContainer)];
                if (reqScopeContainer == null)
                {
                    reqScopeContainer = CreateRequestScope();
                }
                obj = ((ITContainer)reqScopeContainer).Resolve(type, parameters);
            }
            return obj;
        }

        public object ResolveRequestScope(Type type, params object[] parameters)
        {
            var items = HttpContext.Current.Items;
            var obj = items[type];
            if (obj == null)
            {
                var reqScopeContainer = items[typeof(ITContainer)];
                if (reqScopeContainer == null)
                {
                    reqScopeContainer = CreateRequestScope();
                }
                obj = ((ITContainer)reqScopeContainer).Resolve(type, parameters);
            }
            return obj;
        }

        public ITContainer RequestScope
        {
            get
            {
                return (ITContainer)HttpContext.Current.Items[typeof(ITContainer)];
            }
        }

    }

}
