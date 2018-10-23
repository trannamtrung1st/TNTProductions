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
    public interface ITContainer : IDisposable
    {
        //normal register
        void RegisterType(Type baseType, Type implType, Params constructor = null);
        void RegisterType<BaseType, ImplType>(Params constructor = null) where ImplType : BaseType;
        void RegisterType<Type>(Params constructor = null) where Type : class;
        void ManageResources(params IDisposable[] resources);

        //normal resolve
        Type Resolve<Type>(Params constructor = null);
        object Resolve(Type type, Params constructor = null);
        Type Resolve<Type>(params object[] parameters);
        object Resolve(Type type, params object[] parameters);

        //life time manager
        void ClearManagedResources(bool autoDispose);
        void ClearManagedResources();
        ITContainer CreateScope();
        bool ResourcesControlModeOn { get; set; }

        //singleton
        void RegisterSingleton<Type>(Type obj);
        void RegisterSingleton(Type baseType, object obj);
        void RegisterSingleton<BaseType, ImplType>(Params parameters = null);
        void RegisterSingleton(Type baseType, Type implType, Params parameters = null);

        Type ResolveSingleton<Type>();
        object ResolveSingleton(Type type);

        //pooling
        void RegisterToPool<Type>(int initSize, int maxPoolSize, Params parameters = null) where Type : IResource;
        void RegisterToPool<BaseType, ImplType>(int initSize,
            int maxPoolSize, Params parameters = null) where ImplType : BaseType where BaseType : IResource;
        void RegisterToPool(Type baseType, Type implType, int initSize,
            int maxPoolSize, Params parameters = null);
        Type ResolveFromPool<Type>(Params parameters = null) where Type : class, IResource;
        object ResolveFromPool(Type type, Params parameters = null);
        Type ResolveFromPool<Type>(params object[] parameters) where Type : class, IResource;
        object ResolveFromPool(Type type, params object[] parameters);

        //request scope
        void RegisterRequestScopeHandlerModule();
        ITContainer CreateRequestScope();
        ITContainer CreateScope(HttpContext context);
        Type ResolveRequestScope<Type>(Params parameters = null);
        Type ResolveRequestScope<Type>(params object[] parameters);
        object ResolveRequestScope(Type type, Params parameters = null);
        object ResolveRequestScope(Type type, params object[] parameters);
        ITContainer RequestScope { get; }
    }

    public partial class TContainer : ITContainer
    {
        /*
         * FIELDS
         */
        private Dictionary<Type, IBaseType> typeMapping;
        private HashSet<IDisposable> resolvedResources;
        public bool ResourcesControlModeOn { get; set; }
        private Dictionary<Type, object> singletonResources;
        private Dictionary<Type, ResourcePool> poolMapping;
        //INIT
        public TContainer()
        {
            typeMapping = new Dictionary<Type, IBaseType>();
            resolvedResources = new HashSet<IDisposable>();
            singletonResources = new Dictionary<Type, object>();
            poolMapping = new Dictionary<Type, ResourcePool>();
            ResourcesControlModeOn = true;
        }

    }
}
