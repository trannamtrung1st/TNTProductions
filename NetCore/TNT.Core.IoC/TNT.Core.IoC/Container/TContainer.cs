using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TNT.Core.IoC.Wrapper;

namespace TNT.Core.IoC.Container
{

    public enum ResolveType
    {
        Default = 1,
        Simple = 2,
        Provided = 3,
        Injected = 4,
        Singleton = 5,
    }

    public interface ITContainer : IDisposable
    {
        void ManageResources(params IDisposable[] resources);
        void ClearResources(bool autoDispose);
        void ClearResources();

        Type Resolve<Type>(object[] arguments = null);
        object Resolve(Type type, object[] arguments = null);
        Type Resolve<Type>(Args[] args, int id = 0);
        object Resolve(Type type, Args[] args, int id = 0);
        Type Resolve<Type>(int id);
        object Resolve(Type type, int id);
        Type ResolveScopeInstance<Type>();
        object ResolveScopeInstance(Type type);

        Type Default<Type>();
        object Default(Type type);
        Type Simple<Type>(params object[] arguments);
        object Simple(Type type, params object[] arguments);
        Type Provided<Type>();
        object Provided(Type type);
        Type Injected<Type>(int id = 0);
        object Injected(Type type, int id = 0);
        Type Injected<Type>(Args[] args, int id = 0);
        object Injected(Type type, Args[] args, int id = 0);
        Type Singleton<Type>();
        object Singleton(Type type);

        ITContainer CreateScope();
        bool ResourcesControlModeOn { get; set; }

        void InjectTo(object obj, params object[] arguments);
    }

    public partial class TContainer : ITContainer
    {
        internal IDictionary<Type, BaseType> typeMappings;
        internal ISet<IDisposable> resources;
        internal IDictionary<Type, object> singletonObjs;
        internal IDictionary<Type, object> lifetimeScopeObjs;

        public TContainer()
        {
            typeMappings = new Dictionary<Type, BaseType>();
            resources = new HashSet<IDisposable>();
            singletonObjs = new Dictionary<Type, object>();
            lifetimeScopeObjs = new Dictionary<Type, object>();
        }

        internal TContainer(TContainer parent)
        {
            typeMappings = parent.typeMappings;
            resources = new HashSet<IDisposable>();
            singletonObjs = parent.singletonObjs;
            lifetimeScopeObjs = new Dictionary<Type, object>();
        }

        public bool ResourcesControlModeOn { get; set; } = true;
        internal static string ContextKey = typeof(TContainer).FullName;

        public void ClearResources(bool autoDispose)
        {
            List<Exception> notSuccess = new List<Exception>();
            if (autoDispose)
                foreach (var r in resources)
                {
                    try
                    {
                        r.Dispose();
                    }
                    catch (Exception e)
                    {
                        notSuccess.Add(e);
                    }
                }
            resources.Clear();
            if (notSuccess.Count > 0)
            {
                var ex = new Exception("Auto dispose fail, see Data[\"ITContainer.DisposeFail\"] for more informations");
                ex.Data["ITContainer.DisposeFail"] = notSuccess;
            }
        }

        public void ClearResources()
        {
            List<Exception> notSuccess = new List<Exception>();
            foreach (var r in resources)
            {
                try
                {
                    r.Dispose();
                }
                catch (Exception e)
                {
                    notSuccess.Add(e);
                }
            }
            resources.Clear();
            if (notSuccess.Count > 0)
            {
                var ex = new Exception("Auto dispose fail, see Data[\"ITContainer.DisposeFail\"] for more informations");
                ex.Data["ITContainer.DisposeFail"] = notSuccess;
            }
        }

        public ITContainer CreateScope()
        {
            return new TContainer(this);
        }

        internal void InjectTo(ImplementType implType, object instance, params object[] arguments)
        {
            if (implType.InjectableMethods != null)
                foreach (var m in implType.InjectableMethods)
                {
                    var len = m.ParamTypes.Length;
                    var args = new object[len];
                    var para = m.ParamTypes;
                    for (int i = 0; i < len; i++)
                        args[i] = Resolve(para[i], typeMappings[para[i]].ImplementType);
                    m.Method.Invoke(instance, args);
                }

            if (implType.InjectableProperties != null)
                foreach (var p in implType.InjectableProperties)
                    p.SetValue(instance, Resolve(p.PropertyType, typeMappings[p.PropertyType].ImplementType));

            if (implType.PostConstructs != null)
                foreach (var m in implType.PostConstructs)
                {
                    var pLen = m.ParamTypes.Length;
                    for (int i = 0; i < pLen; i++)
                        if (!arguments[i].GetType().Equals(m.ParamTypes[i]))
                            continue;
                    m.Method.Invoke(instance, arguments);
                }
        }

        public void InjectTo(object instance, params object[] arguments)
        {
            var implType = typeMappings[instance.GetType()].ImplementType;
            if (implType.InjectableMethods != null)
                foreach (var m in implType.InjectableMethods)
                {
                    var len = m.ParamTypes.Length;
                    var args = new object[len];
                    var para = m.ParamTypes;
                    for (int i = 0; i < len; i++)
                        args[i] = Resolve(para[i], typeMappings[para[i]].ImplementType);
                    m.Method.Invoke(instance, args);
                }

            if (implType.InjectableProperties != null)
                foreach (var p in implType.InjectableProperties)
                    p.SetValue(instance, Resolve(p.PropertyType, typeMappings[p.PropertyType].ImplementType));

            if (implType.PostConstructs != null)
                foreach (var m in implType.PostConstructs)
                {
                    var pLen = m.ParamTypes.Length;
                    for (int i = 0; i < pLen; i++)
                        if (!arguments[i].GetType().Equals(m.ParamTypes[i]))
                            continue;
                    m.Method.Invoke(instance, arguments);
                }
        }

        public void ManageResources(params IDisposable[] resources)
        {
            foreach (var r in resources)
                this.resources.Add(r);
        }

        public Type Injected<Type>(int id = 0)
        {
            var type = typeof(Type);
            return (Type)Injected(type, id);
        }

        public object Injected(Type type, int id = 0)
        {
            var implType = typeMappings[type].ImplementType;
            var injectableParams = implType.InjectableConstructorParamTypesById[id];
            var len = injectableParams.Length;
            var args = new object[len];
            for (int i = 0; i < len; i++)
                args[i] = Resolve(injectableParams[i].argsType, typeMappings[injectableParams[i].argsType].ImplementType);
            return FinalResolve(type, implType, args);
        }

        public Type Provided<Type>()
        {
            var type = typeof(Type);
            return (Type)Provided(type);
        }

        public object Provided(Type type)
        {
            var implType = typeMappings[type].ImplementType;
            var providers = implType.ConstructorParamProviders;
            var len = providers.Length;
            var args = new object[len];
            for (int i = 0; i < len; i++)
                args[i] = providers[i].Invoke(this);
            return FinalResolve(type, implType, args);
        }

        public Type Simple<Type>(params object[] arguments)
        {
            var type = typeof(Type);
            return (Type)FinalResolve(type, typeMappings[type].ImplementType, arguments);
        }

        public object Simple(Type type, params object[] arguments)
        {
            var implType = typeMappings[type].ImplementType;
            return FinalResolve(type, implType, arguments);
        }

        public Type Default<Type>()
        {
            var type = typeof(Type);
            var implType = typeMappings[type].ImplementType;
            return (Type)FinalResolve(type, implType, implType.ConstructorDefaultArguments);
        }

        public object Default(Type type)
        {
            var implType = typeMappings[type].ImplementType;
            return FinalResolve(type, implType, implType.ConstructorDefaultArguments);
        }

        public Type Injected<Type>(Args[] args, int id = 0)
        {
            var type = typeof(Type);
            return (Type)Injected(type, args, id);
        }

        public object Injected(Type type, Args[] arguments, int id = 0)
        {
            var implType = typeMappings[type].ImplementType;
            var injectableParams = implType.InjectableConstructorParamTypesById[id];
            var len = injectableParams.Length;
            for (int i = 0; i < len; i++)
                if (arguments[i].injectMode)
                    arguments[i].val = Resolve(injectableParams[i].argsType, typeMappings[injectableParams[i].argsType].ImplementType);
            return FinalResolve(type, implType, arguments);
        }

        internal object FinalResolve(Type bType, ImplementType implType, params object[] arguments)
        {
            object instance = null;
            foreach (var c in implType.Constructors)
            {
                if (c.IsSuitableForArgs(arguments))
                {
                    instance = c.Invoke(arguments);
                    break;
                }
            }
            if (instance == null)
                throw new Exception("Can not find suitable constructor");

            if (implType.HasLifetimeScope)
                lifetimeScopeObjs[bType] = instance;

            InjectTo(implType, instance, arguments);

            return instance;
        }

        internal object FinalResolve(Type bType, ImplementType implType, Args[] arguments)
        {
            object instance = null;
            var realArgs = arguments.Select(a => a.val).ToArray();
            foreach (var c in implType.Constructors)
            {
                if (c.IsSuitableForArgs(realArgs))
                {
                    instance = c.Invoke(realArgs);
                    break;
                }
            }
            if (instance == null)
                throw new Exception("Can not find suitable constructor");

            if (implType.HasLifetimeScope)
                lifetimeScopeObjs[bType] = instance;

            InjectTo(implType, instance, arguments);

            return instance;
        }

        internal object Resolve(Type bType, ImplementType implType)
        {
            if (implType.HasLifetimeScope)
                return ResolveScopeInstance(bType);
            switch (implType.DefaultResolveType)
            {
                case ResolveType.Default: return Default(bType);
                case ResolveType.Simple: return FinalResolve(bType, implType);
                case ResolveType.Provided: return Provided(bType);
                case ResolveType.Injected: return Injected(bType, 0);
                case ResolveType.Singleton: return Singleton(bType);
            }
            return FinalResolve(bType, implType);
        }

        public Type Singleton<Type>()
        {
            return (Type)singletonObjs[typeof(Type)];
        }

        public object Singleton(Type type)
        {
            return singletonObjs[type];
        }

        public Type Resolve<Type>(object[] arguments = null)
        {
            var type = typeof(Type);
            return (Type)Resolve(type, arguments);
        }

        public object Resolve(Type type, object[] arguments = null)
        {
            var implType = typeMappings[type].ImplementType;
            if (arguments != null)
                return FinalResolve(type, implType, arguments);
            if (implType.HasLifetimeScope)
                return ResolveScopeInstance(type);
            switch (implType.DefaultResolveType)
            {
                case ResolveType.Default: return Default(type);
                case ResolveType.Simple: return FinalResolve(type, implType);
                case ResolveType.Provided: return Provided(type);
                case ResolveType.Injected: return Injected(type, 0);
                case ResolveType.Singleton: return Singleton(type);
            }
            return FinalResolve(type, implType);
        }

        public Type Resolve<Type>(Args[] args, int id)
        {
            var type = typeof(Type);
            return (Type)Resolve(type, args, id);
        }

        public object Resolve(Type type, Args[] arguments, int id)
        {
            var implType = typeMappings[type].ImplementType;
            var injectableParams = implType.InjectableConstructorParamTypesById[id];
            var len = injectableParams.Length;
            for (int i = 0; i < len; i++)
                if (arguments[i].injectMode)
                    arguments[i].val = Resolve(type, typeMappings[injectableParams[i].argsType].ImplementType);
            return FinalResolve(type, implType, arguments);
        }

        public Type Resolve<Type>(int id)
        {
            var type = typeof(Type);
            return (Type)Resolve(type, id);
        }

        public object Resolve(Type type, int id)
        {
            var implType = typeMappings[type].ImplementType;
            var injectableParams = implType.InjectableConstructorParamTypesById[id];
            var len = injectableParams.Length;
            var args = new object[len];
            for (int i = 0; i < len; i++)
                args[i] = Resolve(injectableParams[i].argsType, typeMappings[injectableParams[i].argsType].ImplementType);
            return FinalResolve(type, implType, args);
        }

        internal object ResolveNewScopeInstance(Type type)
        {
            var implType = typeMappings[type].ImplementType;
            switch (implType.DefaultResolveType)
            {
                case ResolveType.Default: return Default(type);
                case ResolveType.Simple: return FinalResolve(type, implType);
                case ResolveType.Provided: return Provided(type);
                case ResolveType.Injected: return Injected(type, 0);
                case ResolveType.Singleton: return Singleton(type);
            }
            return FinalResolve(type, implType);
        }

        public Type ResolveScopeInstance<Type>()
        {
            var type = typeof(Type);
            if (!lifetimeScopeObjs.ContainsKey(type))
                lifetimeScopeObjs[type] = ResolveNewScopeInstance(type);
            return (Type)lifetimeScopeObjs[type];
        }

        public object ResolveScopeInstance(Type type)
        {
            if (!lifetimeScopeObjs.ContainsKey(type))
                lifetimeScopeObjs[type] = ResolveNewScopeInstance(type);
            return lifetimeScopeObjs[type];
        }

        #region IDisposable Support
        internal bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                ClearResources();

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~TContainer()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        #endregion

    }

    public static class Extensions
    {
        public static ITContainer GetIoC(this ControllerBase controller)
        {
            return controller.HttpContext.Items[TContainer.ContextKey] as ITContainer;
        }
    }

}
