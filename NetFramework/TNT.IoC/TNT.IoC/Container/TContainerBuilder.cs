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

    public partial class TContainerBuilder
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

        private void CheckInjectableCtor(ImplementType implType, Params[] ctorParams, int id = 0)
        {
            var wType = implType.WrappedType;
            var ctor = wType.GetConstructor(ctorParams.Select(p => p.ParameterType).ToArray());

            if (ctor == null)
                throw new Exception("Can not find suitable constructor");
            if (implType.InjectableConstructorParamTypesById == null)
                implType.InjectableConstructorParamTypesById = new Dictionary<int, Args[]>();
            implType.InjectableConstructorParamTypesById[id] = ctorParams.Select(p => new Args()
            {
                argsType = p.ParameterType,
                injectMode = p.ResolveType == ParamResolveType.Injectable,
                val = null
            }).ToArray();
        }

        public TContainerBuilder RegisterType(Type baseType, Type implType, BuilderOptions options)
        {
            if (options.ArgumentsProviders != null)
                RegisterType(baseType, implType, options.ArgumentsProviders);
            if (options.DefaultArguments != null)
                RegisterType(baseType, implType, options.DefaultArguments);
            if (!container.typeMappings.ContainsKey(baseType))
                RegisterType(baseType, implType);

            var typeMapping = container.typeMappings[baseType];
            var iType = typeMapping.ImplementType;
            if (options.InjectableConstructors != null)
            {
                foreach (var kvp in options.InjectableConstructors)
                    CheckInjectableCtor(iType, kvp.Value, kvp.Key);
            }
            if (options.PostConstructs != null)
            {
                if (iType.PostConstructs == null)
                    iType.PostConstructs = new List<MethodWrapper>();
                iType.PostConstructs.AddRange(options.PostConstructs.Select(p => new MethodWrapper
                {
                    Method = p,
                    ParamTypes = p.GetParameters().Select(para => para.ParameterType).ToArray()
                }));
            }

            if (options.InjectableMethods != null)
            {
                if (iType.InjectableMethods == null)
                    iType.InjectableMethods = new List<MethodWrapper>();
                iType.InjectableMethods.AddRange(options.InjectableMethods.Select(m => new MethodWrapper
                {
                    Method = m,
                    ParamTypes = m.GetParameters().Select(para => para.ParameterType).ToArray()
                }));
            }

            if (options.InjectableProperties != null)
            {
                if (iType.InjectableProperties == null)
                    iType.InjectableProperties = new List<PropertyInfo>();
                iType.InjectableProperties.AddRange(options.InjectableProperties);
            }

            if (options.DefaultResolveType != null)
                ResolveDefaultFor(baseType, options.DefaultResolveType.Value);
            if (options.AttachToLifetimeScope)
                AttachToLifetimeScope(baseType);
            return this;
        }

        public TContainerBuilder RegisterType(Type type, BuilderOptions options)
        {
            return RegisterType(type, type, options);
        }

        public TContainerBuilder RegisterType<BaseType, ImplType>(BuilderOptions options) where ImplType : BaseType
        {
            var bType = typeof(BaseType);
            var iType = typeof(ImplType);
            return RegisterType(bType, iType, options);
        }

        public TContainerBuilder RegisterType<Type>(BuilderOptions options)
        {
            var type = typeof(Type);
            return RegisterType(type, type, options);
        }

        public ITContainer Build()
        {
            foreach (var t in container.typeMappings)
            {
                CheckDefaultType(t.Value);
            }
            return container;
        }

        public TContainerBuilder RegisterRequestScopeHandlerModule()
        {
            THttpModule.GlobalContainer = container;
            HttpApplication.RegisterModule(typeof(THttpModule));
            return this;
        }

        private void MapSingleton(Type baseType, object singleTon)
        {
            if (!container.typeMappings.ContainsKey(baseType))
            {
                var implType = singleTon.GetType();
                var iType = new ImplementType()
                {
                    WrappedType = implType,
                    Constructors = implType.GetConstructors(),
                    ConstructorDefaultArguments = null,
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
            container.singletonObjs[baseType] = singleTon;
        }

        private void MapSingleton(Type baseType, Type implType, object[] args)
        {
            if (!container.typeMappings.ContainsKey(baseType))
            {
                var iType = new ImplementType()
                {
                    WrappedType = implType,
                    Constructors = implType.GetConstructors(),
                    ConstructorDefaultArguments = null,
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
            container.singletonObjs[baseType] = container.Resolve(baseType, args);
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
                    Constructors = implType.GetConstructors(),
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
                    Constructors = implType.GetConstructors(),
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

        public TContainerBuilder RegisterType(Type baseType, Type implType, params Expression<Func<ITContainer, object>>[] arguments)
        {
            Map(baseType, implType, arguments);
            return this;
        }

        public TContainerBuilder RegisterType(Type baseType, Type implType, object[] arguments)
        {
            Map(baseType, implType, arguments);
            return this;
        }

        public TContainerBuilder RegisterType(Type type, params Expression<Func<ITContainer, object>>[] arguments)
        {
            Map(type, type, arguments);
            return this;
        }

        public TContainerBuilder RegisterType(Type type, object[] arguments)
        {
            Map(type, type, arguments);
            return this;
        }

        public TContainerBuilder RegisterType<BaseType, ImplType>(params Expression<Func<ITContainer, object>>[] arguments) where ImplType : BaseType
        {
            var bType = typeof(BaseType);
            var iType = typeof(ImplType);
            Map(bType, iType, arguments);
            return this;
        }

        public TContainerBuilder RegisterType<BaseType, ImplType>(object[] arguments) where ImplType : BaseType
        {
            var bType = typeof(BaseType);
            var iType = typeof(ImplType);
            Map(bType, iType, arguments);
            return this;
        }

        public TContainerBuilder RegisterType<Type>(params Expression<Func<ITContainer, object>>[] arguments)
        {
            var type = typeof(Type);
            Map(type, type, arguments);
            return this;
        }

        public TContainerBuilder RegisterType<Type>(object[] arguments)
        {
            var type = typeof(Type);
            Map(type, type, arguments);
            return this;
        }

        public TContainerBuilder RegisterSingleton(Type type, object obj)
        {
            MapSingleton(type, obj);
            return this;
        }

        public TContainerBuilder RegisterSingleton<Type>(Type obj)
        {
            MapSingleton(typeof(Type), obj);
            return this;
        }

        public TContainerBuilder RegisterSingleton<BaseType, ImplType>(object[] arguments) where ImplType : BaseType
        {
            MapSingleton(typeof(BaseType), typeof(ImplType), arguments);
            return this;
        }

        public TContainerBuilder RegisterSingleton(Type baseType, Type implType, object[] arguments)
        {
            MapSingleton(baseType, implType, arguments);
            return this;
        }

        public TContainerBuilder RegisterType(Type baseType, Type implType)
        {
            Map(baseType, implType, new object[] { });
            return this;
        }

        public TContainerBuilder RegisterType<BaseType, ImplType>() where ImplType : BaseType
        {
            var bType = typeof(BaseType);
            var iType = typeof(ImplType);
            Map(bType, iType, new object[] { });
            return this;
        }

        public TContainerBuilder RegisterType<Type>()
        {
            var type = typeof(Type);
            Map(type, type, new object[] { });
            return this;
        }

        public TContainerBuilder RegisterType(Type type)
        {
            Map(type, type, new object[] { });
            return this;
        }

        public TContainerBuilder ResolveDefaultFor<Type>(ResolveType resolveType)
        {
            var bType = container.typeMappings[typeof(Type)];
            bType.ImplementType.DefaultResolveType = resolveType;
            return this;
        }

        public TContainerBuilder ResolveDefaultFor(Type type, ResolveType resolveType)
        {
            var bType = container.typeMappings[type];
            bType.ImplementType.DefaultResolveType = resolveType;
            return this;
        }

        public TContainerBuilder AttachAllRegisteredToLifetimeScope()
        {
            foreach (var t in container.typeMappings)
                t.Value.ImplementType.HasLifetimeScope = true;
            return this;
        }

        public TContainerBuilder AttachToLifetimeScope<Type>()
        {
            var bType = container.typeMappings[typeof(Type)];
            bType.ImplementType.HasLifetimeScope = true;
            return this;
        }

        public TContainerBuilder AttachToLifetimeScope(Type type)
        {
            var bType = container.typeMappings[type];
            bType.ImplementType.HasLifetimeScope = true;
            return this;
        }

        public TContainerBuilder Concatenate(TContainerBuilder anotherBuilder)
        {
            var anotherContainer = anotherBuilder.container;
            foreach (var tM in anotherContainer.typeMappings)
                this.container.typeMappings.Add(tM);
            foreach (var sgt in anotherContainer.singletonObjs)
                this.container.singletonObjs.Add(sgt);
            return this;
        }

    }

    public enum ParamResolveType
    {
        Injectable,
        Normal
    }

    public class Params
    {
        public ParamResolveType ResolveType { get; private set; }
        public Type ParameterType { get; private set; }
        internal Params() { }

        public static Params Injectable<Type>()
        {
            return new Params() { ResolveType = ParamResolveType.Injectable, ParameterType = typeof(Type) };
        }
        public static Params Injectable(Type type)
        {
            return new Params() { ResolveType = ParamResolveType.Injectable, ParameterType = type };
        }
        public static Params Normal<Type>()
        {
            return new Params() { ResolveType = ParamResolveType.Injectable, ParameterType = typeof(Type) };
        }
        public static Params Normal(Type type)
        {
            return new Params() { ResolveType = ParamResolveType.Injectable, ParameterType = type };
        }

    }

    public class BuilderOptions
    {
        public ResolveType? DefaultResolveType { get; set; }
        public IDictionary<int, Params[]> InjectableConstructors { get; set; }
        public object[] DefaultArguments { get; set; }
        public Expression<Func<ITContainer, object>>[] ArgumentsProviders { get; set; }
        public object SingletonObj { get; set; }

        public List<PropertyInfo> InjectableProperties { get; set; }
        public List<MethodInfo> InjectableMethods { get; set; }
        public List<MethodInfo> PostConstructs { get; set; }

        public bool AttachToLifetimeScope { get; set; }
    }

    public class THttpModule : HttpApplication
    {
        internal static ITContainer GlobalContainer { get; set; }
        public override void Init()
        {
            base.Init();
            BeginRequest += (a, b) => HttpContext.Current.Items[TContainer.ContextKey] = GlobalContainer.CreateScope();
            EventHandler dispose = (a, b) =>
            {
                var cont = HttpContext.Current.Items[TContainer.ContextKey];
                if (cont != null)
                    ((ITContainer)cont).Dispose();
            };
            EndRequest += dispose;
            Error += dispose;
        }
    }

}
