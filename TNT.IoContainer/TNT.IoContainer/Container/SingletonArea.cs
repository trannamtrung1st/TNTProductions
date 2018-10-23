using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.IoContainer.Wrapper;

namespace TNT.IoContainer.Container
{
    public partial class TContainer
    {

        public void RegisterSingleton<Type>(Type obj)
        {
            singletonResources.Add(typeof(Type), obj);
        }

        public void RegisterSingleton(Type type, object obj)
        {
            singletonResources.Add(type, obj);
        }

        public void RegisterSingleton<BaseType, ImplType>(Params parameters = null)
        {
            RegisterSingleton(typeof(BaseType), typeof(ImplType), parameters);
        }

        public void RegisterSingleton(Type baseType, Type implType, Params parameters = null)
        {
            Map(baseType, implType, parameters);
            var singleton = Resolve(baseType, parameters);
            typeMapping.Remove(baseType);

            singletonResources.Add(baseType, singleton);
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
