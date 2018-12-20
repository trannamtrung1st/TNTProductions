using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TNT.IoC.Attributes;
using TNT.IoC.Wrapper;

namespace TNT.IoC.Container
{

    public interface ITContainerBuilder
    {
        ITContainerBuilder RegisterType(Type baseType, Type implType);
        ITContainerBuilder RegisterType<BaseType, ImplType>() where ImplType : BaseType;
        ITContainerBuilder RegisterType(Type type);
        ITContainerBuilder RegisterType<Type>();
        ITContainerBuilder ResolveDefaultFor<Type>(ResolveType resolveType);
        ITContainerBuilder ResolveDefaultFor(Type type, ResolveType resolveType);

        ITContainerBuilder RegisterType(Type baseType, Type implType, params Expression<Func<ITContainer, object>>[] arguments);
        ITContainerBuilder RegisterType(Type baseType, Type implType, object[] arguments);
        ITContainerBuilder RegisterType(Type type, params Expression<Func<ITContainer, object>>[] arguments);
        ITContainerBuilder RegisterType(Type type, object[] arguments);
        ITContainerBuilder RegisterType<BaseType, ImplType>(params Expression<Func<ITContainer, object>>[] arguments) where ImplType : BaseType;
        ITContainerBuilder RegisterType<BaseType, ImplType>(object[] arguments) where ImplType : BaseType;
        ITContainerBuilder RegisterType<Type>(params Expression<Func<ITContainer, object>>[] arguments);
        ITContainerBuilder RegisterType<Type>(object[] arguments);

        ITContainerBuilder RegisterSingleton(Type type, object obj);
        ITContainerBuilder RegisterSingleton<Type>(Type obj);
        ITContainerBuilder RegisterSingleton<BaseType, ImplType>(object[] arguments) where ImplType : BaseType;
        ITContainerBuilder RegisterSingleton(Type baseType, Type implType, object[] arguments);

        ITContainerBuilder AttachToLifetimeScope<Type>();
        ITContainerBuilder AttachToLifetimeScope(Type type);

        ITContainerBuilder RegisterRequestScopeHandlerModule();

        ITContainer Build();
    }

    public partial class TContainerBuilder : ITContainerBuilder
    {
        private TContainer container;

        public TContainerBuilder()
        {
            container = new TContainer();
        }

        private void CheckDefaultType(BaseType type)
        {
            var implType = type.ImplementType;
            if (implType.DefaultResolveType == null)
            {
                if (container.singletonObjs.ContainsKey(type.WrappedType))
                    implType.DefaultResolveType = ResolveType.Singleton;
                else if (implType.InjectableConstructorParamTypesById != null)
                    implType.DefaultResolveType = ResolveType.Injected;
                else if (implType.ConstructorParamProviders != null)
                    implType.DefaultResolveType = ResolveType.Provided;
                else if (implType.ConstructorDefaultArguments != null)
                    implType.DefaultResolveType = ResolveType.Default;
                else implType.DefaultResolveType = ResolveType.Simple;
            }
        }

        public ITContainer Build()
        {
            foreach (var t in container.typeMappings)
            {
                CheckDefaultType(t.Value);
            }
            return container;
        }

        public ITContainerBuilder RegisterRequestScopeHandlerModule()
        {
            TContainerModule.GlobalContainer = container;
            HttpApplication.RegisterModule(typeof(TContainerModule));
            return this;
        }

        private void Map(Type baseType, Type implType, object[] args)
        {
            if (args.Length == 0)
                args = null;

            if (!container.typeMappings.ContainsKey(baseType))
            {
                var iType = new ImplementType()
                {
                    WrappedType = implType,
                    ConstructorDefaultArguments = args,
                    ConstructorParamProviders = null,
                };
                var bType = new BaseType()
                {
                    ImplementType = iType,
                    WrappedType = baseType
                };
                container.typeMappings.Add(baseType, bType);
                CheckInjectableCtor(iType);
                CheckInjectableMethod(iType);
                CheckInjectableProperties(iType);
                CheckPostConstructs(iType);
            }
            else
            {
                var bType = container.typeMappings[baseType];
                var iType = bType.ImplementType;
                iType.ConstructorDefaultArguments = args;
            }
        }

        private void Map(Type baseType, Type implType, params Expression<Func<ITContainer, object>>[] providers)
        {
            if (providers.Length == 0)
                providers = null;

            if (!container.typeMappings.ContainsKey(baseType))
            {
                var iType = new ImplementType()
                {
                    WrappedType = implType,
                    ConstructorDefaultArguments = null,
                    ConstructorParamProviders = providers.Select(e => e.Compile()).ToArray(),
                };
                var bType = new BaseType()
                {
                    ImplementType = iType,
                    WrappedType = baseType
                };
                container.typeMappings.Add(baseType, bType);
                CheckInjectableCtor(iType);
                CheckInjectableMethod(iType);
                CheckInjectableProperties(iType);
                CheckPostConstructs(iType);
            }
            else
            {
                var bType = container.typeMappings[baseType];
                var iType = bType.ImplementType;
                iType.ConstructorDefaultArguments = providers;
            }
        }

        private void CheckInjectableCtor(ImplementType implType)
        {
            var wType = implType.WrappedType;
            var ctors = wType.GetConstructors();

            var iAttr = typeof(InjectableAttribute);
            foreach (var c in ctors)
            {
                var para = c.GetParameters();
                if (c.IsDefined(iAttr, true))
                {
                    if (implType.InjectableConstructorParamTypesById == null)
                        implType.InjectableConstructorParamTypesById = new Dictionary<int, Args[]>();
                    if (!para.Any(p => p.IsDefined(iAttr, true)))
                    {
                        var attr = c.GetCustomAttributes(iAttr, true)[0] as InjectableAttribute;
                        implType.InjectableConstructorParamTypesById[attr.Id] = para
                            .Select(p => new Args()
                            {
                                injectMode = true,
                                argsType = p.ParameterType,
                                val = null
                            }).ToArray();
                    }
                    else
                    {
                        var args = new List<Args>();
                        foreach (var p in para)
                        {
                            if (p.IsDefined(iAttr, true))
                            {
                                args.Add(new Args()
                                {
                                    argsType = p.ParameterType,
                                    injectMode = true,
                                    val = null
                                });
                            }
                            else args.Add(null);
                        }
                        var attr = c.GetCustomAttributes(iAttr, true)[0] as InjectableAttribute;
                        implType.InjectableConstructorParamTypesById[attr.Id] = args.ToArray();
                    }
                }
            }

        }
        private void CheckInjectableMethod(ImplementType implType)
        {
            var wType = implType.WrappedType;
            var methods = wType.GetMethods();

            var iAttr = typeof(InjectableAttribute);
            foreach (var m in methods)
            {
                var para = m.GetParameters();
                if (!para.Any(p => p.IsDefined(iAttr, true)))
                {
                    if (m.IsDefined(iAttr, true))
                    {
                        if (implType.InjectableMethods == null)
                            implType.InjectableMethods = new List<MethodWrapper>();

                        var attr = m.GetCustomAttributes(iAttr, true)[0] as InjectableAttribute;
                        implType.InjectableMethods.Add(new MethodWrapper()
                        {
                            Method = m,
                            ParamTypes = para.Select(p => p.ParameterType).ToArray()
                        });
                    }
                }
                else
                    throw new Exception("Injectable method can not have non injectable parameters");
            }
        }
        private void CheckInjectableProperties(ImplementType implType)
        {
            var wType = implType.WrappedType;
            var props = wType.GetProperties();

            var iAttr = typeof(InjectableAttribute);
            foreach (var prop in props)
            {
                if (prop.IsDefined(iAttr, true))
                {
                    if (implType.InjectableProperties == null)
                        implType.InjectableProperties = new List<PropertyInfo>();
                    implType.InjectableProperties.Add(prop);
                }
            }
        }
        private void CheckPostConstructs(ImplementType implType)
        {
            var wType = implType.WrappedType;
            var methods = wType.GetMethods();

            var pAttr = typeof(PostConstruct);
            foreach (var m in methods)
            {
                if (m.IsDefined(pAttr, true))
                {
                    if (implType.PostConstructs == null)
                        implType.PostConstructs = new List<MethodWrapper>();

                    implType.PostConstructs.Add(new MethodWrapper()
                    {
                        Method = m,
                        ParamTypes = m.GetParameters().Select(p => p.ParameterType).ToArray()
                    });
                }
            }
        }

        public ITContainerBuilder RegisterType(Type baseType, Type implType, params Expression<Func<ITContainer, object>>[] arguments)
        {
            Map(baseType, implType, arguments);
            return this;
        }

        public ITContainerBuilder RegisterType(Type baseType, Type implType, object[] arguments)
        {
            Map(baseType, implType, arguments);
            return this;
        }

        public ITContainerBuilder RegisterType(Type type, params Expression<Func<ITContainer, object>>[] arguments)
        {
            Map(type, type, arguments);
            return this;
        }

        public ITContainerBuilder RegisterType(Type type, object[] arguments)
        {
            Map(type, type, arguments);
            return this;
        }

        public ITContainerBuilder RegisterType<BaseType, ImplType>(params Expression<Func<ITContainer, object>>[] arguments) where ImplType : BaseType
        {
            var bType = typeof(BaseType);
            var iType = typeof(ImplType);
            Map(bType, iType, arguments);
            return this;
        }

        public ITContainerBuilder RegisterType<BaseType, ImplType>(object[] arguments) where ImplType : BaseType
        {
            var bType = typeof(BaseType);
            var iType = typeof(ImplType);
            Map(bType, iType, arguments);
            return this;
        }

        public ITContainerBuilder RegisterType<Type>(Expression<Func<ITContainer, object>>[] arguments)
        {
            var type = typeof(Type);
            Map(type, type, arguments);
            return this;
        }

        public ITContainerBuilder RegisterType<Type>(object[] arguments)
        {
            var type = typeof(Type);
            Map(type, type, arguments);
            return this;
        }

        public ITContainerBuilder RegisterSingleton(Type type, object obj)
        {
            container.singletonObjs[type] = obj;
            return this;
        }

        public ITContainerBuilder RegisterSingleton<Type>(Type obj)
        {
            container.singletonObjs[typeof(Type)] = obj;
            return this;
        }

        public ITContainerBuilder RegisterSingleton<BaseType, ImplType>(object[] arguments) where ImplType : BaseType
        {
            container.singletonObjs[typeof(BaseType)] = Activator.CreateInstance(typeof(ImplType), arguments);
            return this;
        }

        public ITContainerBuilder RegisterSingleton(Type baseType, Type implType, object[] arguments)
        {
            container.singletonObjs[baseType] = Activator.CreateInstance(implType, arguments);
            return this;
        }

        public ITContainerBuilder RegisterType(Type baseType, Type implType)
        {
            Map(baseType, implType, new object[] { });
            return this;
        }

        public ITContainerBuilder RegisterType<BaseType, ImplType>() where ImplType : BaseType
        {
            var bType = typeof(BaseType);
            var iType = typeof(ImplType);
            Map(bType, iType, new object[] { });
            return this;
        }

        public ITContainerBuilder RegisterType<Type>()
        {
            var type = typeof(Type);
            Map(type, type, new object[] { });
            return this;
        }

        public ITContainerBuilder RegisterType(Type type)
        {
            Map(type, type, new object[] { });
            return this;
        }

        public ITContainerBuilder ResolveDefaultFor<Type>(ResolveType resolveType)
        {
            var bType = container.typeMappings[typeof(Type)];
            bType.ImplementType.DefaultResolveType = resolveType;
            return this;
        }

        public ITContainerBuilder ResolveDefaultFor(Type type, ResolveType resolveType)
        {
            var bType = container.typeMappings[type];
            bType.ImplementType.DefaultResolveType = resolveType;
            return this;
        }

        public ITContainerBuilder AttachToLifetimeScope<Type>()
        {
            var bType = container.typeMappings[typeof(Type)];
            bType.ImplementType.HasLifetimeScope = true;
            return this;
        }

        public ITContainerBuilder AttachToLifetimeScope(Type type)
        {
            var bType = container.typeMappings[type];
            bType.ImplementType.HasLifetimeScope = true;
            return this;
        }
    }

    public class TContainerModule : IHttpModule
    {
        public static ITContainer GlobalContainer { get; set; }

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += this.Application_BeginRequest;
            context.EndRequest += this.Application_EndRequest;
            context.Error += this.Application_Error;
        }

        protected void Application_BeginRequest(object sender, EventArgs args)
        {
            HttpContext.Current.Items[typeof(ITContainer)] = GlobalContainer.CreateScope();
        }

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

}
