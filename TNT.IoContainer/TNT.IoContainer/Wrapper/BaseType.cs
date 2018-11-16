using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TNT.IoContainer.Wrapper
{

    internal interface IBaseType
    {
        Type WrappedType { get; set; }
        HashSet<PropertyInfo> InjectableProperties { get; set; }
        HashSet<MethodInfo> InjectableMethods { get; set; }
        HashSet<MethodInfo> PostConstructs { get; set; }
        //IImplementType ImplType { get; set; }
        Type ImplType { get; set; }
        bool IsSimple { get; set; }
    }

    internal class BaseType : IBaseType
    {
        public Type WrappedType { get; set; }
        //public IImplementType ImplType { get; set; }
        public Type ImplType { get; set; }
        public HashSet<PropertyInfo> InjectableProperties { get; set; }
        public HashSet<MethodInfo> InjectableMethods { get; set; }
        public HashSet<MethodInfo> PostConstructs { get; set; }
        public bool IsSimple { get; set; }

        public BaseType()
        {
            InjectableProperties = new HashSet<PropertyInfo>();
            PostConstructs = new HashSet<MethodInfo>();
            InjectableMethods = new HashSet<MethodInfo>();
        }
    }
}