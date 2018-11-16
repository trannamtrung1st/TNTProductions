using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.IoContainer.Wrapper;

namespace TNT.IoContainer.Container
{
    public partial class TContainerBuilder
    {

        public void RegisterSingleton<Type>(Type obj)
        {
            container.singletonResources.Add(typeof(Type), obj);
        }

        public void RegisterSingleton(Type type, object obj)
        {
            container.singletonResources.Add(type, obj);
        }

        public void RegisterSingleton<BaseType, ImplType>(Params parameters = null)
        {
            RegisterSingleton(typeof(BaseType), typeof(ImplType), parameters);
        }

        public void RegisterSingleton(Type baseType, Type implType, Params parameters = null)
        {
            Map(baseType, implType, parameters);
            var singleton = container.Resolve(baseType, parameters);
            container.typeMapping.Remove(baseType);

            container.singletonResources.Add(baseType, singleton);
        }

    }
}
