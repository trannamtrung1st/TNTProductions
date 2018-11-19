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
        void ManageResources(params IDisposable[] resources);

        //normal resolve
        Type Resolve<Type>(params object[] parameters);
        object Resolve(Type type, params object[] parameters);
        Type Resolve<Type>(Params parameters);
        object Resolve(Type type, Params parameters);

        //life time manager
        void ClearManagedResources(bool autoDispose);
        void ClearManagedResources();
        ITContainer CreateScope();
        bool ResourcesControlModeOn { get; set; }

        //singleton
        Type ResolveSingleton<Type>();
        object ResolveSingleton(Type type);

        //pooling
        Type ResolveFromPool<Type>(Params parameters) where Type : class, IResource;
        object ResolveFromPool(Type type, Params parameters);
        Type ResolveFromPool<Type>(params object[] parameters) where Type : class, IResource;
        object ResolveFromPool(Type type, params object[] parameters);

        //request scope
        ITContainer CreateRequestScope();
        ITContainer CreateScope(HttpContext context);
        Type ResolveRequestScope<Type>(Params parameters);
        Type ResolveRequestScope<Type>(params object[] parameters);
        object ResolveRequestScope(Type type, Params parameters);
        object ResolveRequestScope(Type type, params object[] parameters);
        ITContainer RequestScope { get; }
    }

    public partial class TContainer : ITContainer
    {
        public bool ResourcesControlModeOn { get; set; }

        internal Dictionary<Type, IBaseType> typeMapping;
        internal HashSet<IDisposable> resolvedResources;
        internal Dictionary<Type, object> singletonResources;
        internal Dictionary<Type, ResourcePool> poolMapping;

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
