using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TNT.IoContainer.Attributes;
using TNT.IoContainer.Wrapper;

namespace TNT.IoContainer.Container
{
    public partial class TContainer
    {
        /*
         * CREATE INSTANCE
         */
        private object CreateInstance(Type type, params object[] initParams)
        {
            var instance = Activator.CreateInstance(type, initParams);
            CheckResource(instance);
            return instance;
        }

        /*
         * RESOLVE AREA
         */
        public Type Resolve<Type>(params object[] parameters)
        {
            var resolveType = typeof(Type);
            return (Type)ResolveConstructor(resolveType, parameters);
        }

        public Type Resolve<Type>(Params parameters)
        {
            var resolveType = typeof(Type);
            return (Type)Resolve(resolveType, parameters);
        }

        public object Resolve(Type type, params object[] parameters)
        {
            return ResolveConstructor(type, parameters);
        }

        public object Resolve(Type type, Params parameters)
        {
            if (parameters != null)
                switch (parameters.Policy)
                {
                    case ParamsPolicy.Constructor:
                        return ResolveConstructor(type, parameters.Parameters);
                    default:
                        return ResolveInjectableConstructor(type, parameters);
                }

            return ResolveConstructor(type);
        }

        //final resolve for inject obj
        private object ResolveConstructor(Type type, params object[] initParams)
        {
            var baseObj = typeMapping[type];

            var instance = CreateInstance(baseObj.ImplType, initParams);//create instance
            if (baseObj.IsSimple)
                return instance;

            //inject (create) instance of injectable properties
            foreach (var p in baseObj.InjectableProperties)
            {
                var val = ResolveConstructor(p.PropertyType);
                p.SetValue(instance, val);
            }

            //process injectable methods
            foreach (var m in baseObj.InjectableMethods)
            {
                var mParams = m.GetParameters();
                object[] resolvedParam = null;
                if (mParams != null && mParams.Length > 0)
                    resolvedParam = ResolveInjectableParams(mParams);
                m.Invoke(instance, resolvedParam);
            }

            //do post constructs (after all injection)
            foreach (var m in baseObj.PostConstructs)
            {
                try
                {
                    m.Invoke(instance, initParams);
                    break;
                }
                catch (Exception e) { }
            }

            return instance;
        }

        //for all injectable params
        private object[] ResolveInjectableParams(ParameterInfo[] realParams)
        {
            object[] result = new object[realParams.Length];

            //all injectable
            for (var i = 0; i < result.Length; i++)
                result[i] = ResolveConstructor(realParams[i].ParameterType);
            return result;
        }

        //for combination of params (Injectable and raw params)
        private object[] ResolveInjectableParams(ParameterInfo[] realParams, Params parameters)
        {
            object[] result = new object[realParams.Length];
            //combinations
            var virtualParams = parameters.Parameters;
            for (var i = 0; i < result.Length; i++)
            {
                if (virtualParams[i] is ParamsType)
                {
                    result[i] = ResolveConstructor(realParams[i].ParameterType);
                }
                else
                {
                    result[i] = virtualParams[i];
                }
            }
            return result;

        }

        //resolve injectable params before resolve obj
        private object ResolveInjectableConstructor(Type type, Params parameters)
        {
            var id = parameters.Id;
            var consBinding = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            var constructors = typeMapping[type].ImplType.GetConstructors(consBinding);
            foreach (var c in constructors)
            {
                var attr = c.GetCustomAttribute<InjectableParams>(true);
                if (attr != null && attr.Id == id)
                {
                    var resolvedParams = parameters.Policy == ParamsPolicy.AllInjectables ?
                        ResolveInjectableParams(c.GetParameters()) :
                        ResolveInjectableParams(c.GetParameters(), parameters);
                    return ResolveConstructor(type, Params.Constructor(resolvedParams));
                }
            }
            throw new Exception("Cannot find suitable injectable method/constructor with id " + id);
        }

        public Type ResolveRequestScope<Type>(params object[] parameters)
        {
            var resolveType = typeof(Type);
            return (Type)ResolveRequestScope(resolveType, parameters);
        }

        public Type ResolveRequestScope<Type>(Params parameters)
        {
            var resolveType = typeof(Type);
            return (Type)ResolveRequestScope(resolveType, parameters);
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

        public object ResolveRequestScope(Type type, Params parameters)
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

        private object[] GetResolvedParams(Type type, Params parameters)
        {
            var id = parameters.Id;
            var consBinding = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            var constructors = typeMapping[type].ImplType.GetConstructors(consBinding);
            foreach (var c in constructors)
            {
                var attr = c.GetCustomAttribute<InjectableParams>(true);
                if (attr != null && attr.Id == id)
                {
                    var resolvedParams = parameters.Policy == ParamsPolicy.AllInjectables ?
                        ResolveInjectableParams(c.GetParameters()) :
                        ResolveInjectableParams(c.GetParameters(), parameters);
                    return resolvedParams;
                }
            }
            return null;
        }

        private object[] GetParameters(Type type, Params parameters)
        {
            if (parameters != null)
            {
                switch (parameters.Policy)
                {
                    case ParamsPolicy.Constructor:
                        return parameters.Parameters;
                    default:
                        return GetResolvedParams(type, parameters);
                }
            }
            return null;
        }

        public Type ResolveFromPool<Type>(Params parameters) where Type : class, IResource
        {
            var type = typeof(Type);
            return (Type)ResolveFromPool(type, parameters);
        }

        public object ResolveFromPool(Type type, Params parameters)
        {
            var pool = poolMapping[type];

            lock (pool)
            {
                var res = pool.GetResource();
                if (res != null)
                {
                    object[] initParams = null;
                    if (parameters != null)
                    {
                        initParams = GetParameters(type, parameters);
                    }
                    res.ReInit(initParams);
                }
                else
                {
                    var resourceType = pool.resourceType;
                    parameters = parameters ?? pool.defaultInitParams;
                    var resource = (Resource)Resolve(type, parameters);
                    resource.pool = pool;
                    pool.EnqueueResource(resource);
                    res = resource;
                }
                if (ResourcesControlModeOn)
                    ManageResources(res);
                return res;
            }
        }

        public Type ResolveFromPool<Type>(params object[] parameters) where Type : class, IResource
        {
            var type = typeof(Type);
            return (Type)ResolveFromPool(type, parameters);
        }

        public object ResolveFromPool(Type type, params object[] parameters)
        {
            var pool = poolMapping[type];

            lock (pool)
            {
                var res = pool.GetResource();
                if (res != null)
                {
                    res.ReInit(parameters);
                }
                else
                {
                    var resourceType = pool.resourceType;
                    var resource = (Resource)Resolve(type, parameters);
                    resource.pool = pool;
                    pool.currentSize++;
                    pool.EnqueueResource(resource);
                    res = resource;
                }
                if (ResourcesControlModeOn)
                    ManageResources(res);
                return res;
            }
        }

        public Type ResolveSingleton<Type>()
        {
            return (Type)singletonResources[typeof(Type)];
        }

        public object ResolveSingleton(Type type)
        {
            return singletonResources[type];
        }

    }
}
