using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TNT.IoC.Container;

namespace TNT.IoC.Wrapper
{
    internal class ImplementType
    {
        public ResolveType? DefaultResolveType { get; set; }
        public Type WrappedType { get; set; }
        public ConstructorInfo[] Constructors { get; set; }

        public object[] ConstructorDefaultArguments { get; set; }
        public Func<ITContainer, object>[] ConstructorParamProviders { get; set; }
        public IDictionary<int, Args[]> InjectableConstructorParamTypesById { get; set; }
        public bool HasLifetimeScope { get; set; }

        public List<MethodWrapper> InjectableMethods { get; set; }
        public List<MethodWrapper> PostConstructs { get; set; }
        public List<PropertyInfo> InjectableProperties { get; set; }
    }

    internal class MethodWrapper
    {
        public MethodInfo Method { get; set; }
        public Type[] ParamTypes { get; set; }
    }
}
