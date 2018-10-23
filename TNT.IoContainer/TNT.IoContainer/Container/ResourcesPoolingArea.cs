using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TNT.IoContainer.Attributes;
using TNT.IoContainer.Wrapper;

namespace TNT.IoContainer.Container
{
    public interface IReusable
    {
        //ReInit fields, properties before called from Pool
        void ReInit(params object[] initParams);
    }

    //Dispose method should release resource
    public interface IResource : IDisposable, IReusable
    {
        void Release();
    }

    public abstract class Resource : IResource
    {
        internal ResourcePool pool;

        public virtual void ReInit(params object[] initParams)
        {
            disposedValue = false;
        }

        public virtual void Release()
        {
            if (pool != null)
                pool.EnqueueResource(this);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }
                Release();
                disposedValue = true;
            }
        }

        //TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~Resource()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public virtual void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    internal class ResourcePool
    {
        private Queue<IResource> freeResource;
        internal int currentSize;
        internal int maxSize;
        internal Type resourceType;
        internal Params defaultInitParams;

        public ResourcePool(int maxSize, Type rType, Params initParams = null)
        {
            freeResource = new Queue<IResource>();
            this.maxSize = maxSize;
            resourceType = rType;
            defaultInitParams = initParams;
        }

        internal IResource GetResource()
        {
            if (freeResource.Count == 0)
                return null;
            var s = freeResource.Dequeue();
            return s;
        }

        internal void EnqueueResource(IResource s)
        {
            if (currentSize <= maxSize)
            {
                freeResource.Enqueue(s);
            }
            else
            {
                throw new Exception("Pool size overflow");
            }
        }

    }

    public partial class TContainer
    {

        //POOLING
        public void RegisterToPool<Type>(int initSize,
            int maxPoolSize, Params parameters = null) where Type : IResource
        {
            var type = typeof(Type);
            RegisterToPool(type, type, initSize, maxPoolSize, parameters);
        }

        public void RegisterToPool<BaseType, ImplType>(int initSize,
            int maxPoolSize, Params parameters = null) where ImplType : BaseType where BaseType : IResource
        {
            var baseType = typeof(BaseType);
            var implType = typeof(ImplType);
            RegisterToPool(baseType, implType, initSize, maxPoolSize, parameters);
        }

        public void RegisterToPool(Type baseType, Type implType, int initSize,
            int maxPoolSize, Params parameters = null)
        {
            //check
            if (!(typeof(IResource).IsAssignableFrom(baseType))
                || !(baseType.IsAssignableFrom(implType))
                || !(typeof(Resource).IsAssignableFrom(implType)))
                throw new Exception("Base type must implement IResource and Impl type must impl BaseType, Resource");
            if (initSize <= 0 || maxPoolSize < initSize)
                throw new Exception("Invalid init size");
            //---------
            Map(baseType, implType, parameters);

            var pool = new ResourcePool(maxPoolSize, baseType, parameters);
            for (var i = 0; i < initSize; i++)
            {
                var resource = (Resource)Resolve(baseType, parameters);
                resource.pool = pool;
                pool.EnqueueResource(resource);
            }
            pool.currentSize = initSize;

            poolMapping.Add(baseType, pool);
        }

        private object[] GetResolvedParams(Type type, Params parameters = null)
        {
            var id = parameters.Id;
            var consBinding = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            var constructors = typeMapping[type].Implementer.WrappedType.GetConstructors(consBinding);
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

        private object[] GetParameters(Type type, Params parameters = null)
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

        public Type ResolveFromPool<Type>(Params parameters = null) where Type : class, IResource
        {
            var type = typeof(Type);
            return (Type)ResolveFromPool(type, parameters);
        }

        public object ResolveFromPool(Type type, Params parameters = null)
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

    }

}
