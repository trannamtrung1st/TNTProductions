using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.IoContainer.Wrapper;

namespace TNT.IoContainer.Container
{
    public interface ITContainerBuilder
    {
        //normal register
        void RegisterType(Type baseType, Type implType, Params constructor = null);
        void RegisterType<BaseType, ImplType>(Params constructor = null) where ImplType : BaseType;
        void RegisterType<Type>(Params constructor = null) where Type : class;

        //singleton
        void RegisterSingleton<Type>(Type obj);
        void RegisterSingleton(Type baseType, object obj);
        void RegisterSingleton<BaseType, ImplType>(Params parameters = null);
        void RegisterSingleton(Type baseType, Type implType, Params parameters = null);

        //pooling
        void RegisterToPool<Type>(int initSize, int maxPoolSize, Params parameters = null) where Type : IResource;
        void RegisterToPool<BaseType, ImplType>(int initSize,
            int maxPoolSize, Params parameters = null) where ImplType : BaseType where BaseType : IResource;
        void RegisterToPool(Type baseType, Type implType, int initSize,
            int maxPoolSize, Params parameters = null);

        //request scope
        void RegisterRequestScopeHandlerModule();

        ITContainer Build();
    }

    public partial class TContainerBuilder : ITContainerBuilder
    {
        private TContainer container;

        public TContainerBuilder()
        {
            container = new TContainer();
        }

        public ITContainer Build()
        {
            return container;
        }

    }
}
