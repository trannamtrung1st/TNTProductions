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

    public partial class TContainer
    {
        /*
         * REGISTER AREA
         */

        //General mapping
        private void Map(Type baseType, Type implType, Params constructor = null)
        {
            object[] defaultInitParams = null;
            if (constructor != null)
                defaultInitParams = constructor.Parameters;

            IImplementType implObj = new ImplementType()
            {
                WrappedType = implType,
                DefaultInitParams = defaultInitParams
            };

            IBaseType baseObj = new Wrapper.BaseType()
            {
                WrappedType = baseType,
                Implementer = implObj
            };

            //check and add to injectable properties list
            CheckInjectableProperties(baseObj);
            //check post constructs
            CheckPostConstructsAndInjectableMethods(baseObj);

            if (defaultInitParams == null
                && baseObj.InjectableMethods.Count == 0
                && baseObj.InjectableProperties.Count == 0
                && baseObj.PostConstructs.Count == 0)
                baseObj.IsSimple = true;

            typeMapping.Add(baseType, baseObj);
        }
        //Direct instance
        public void RegisterType<Type>(Params constructor = null) where Type : class
        {
            Map(typeof(Type), typeof(Type), constructor);
        }
        //Abstract or base instance
        public void RegisterType(Type baseType, Type implType, Params constructor = null)
        {
            Map(baseType, implType, constructor);
        }
        //Abstract or base instance
        public void RegisterType<BaseType, ImplType>(Params constructor = null) where ImplType : BaseType
        {
            Map(typeof(BaseType), typeof(ImplType), constructor);
        }

        private void CheckInjectableProperties(IBaseType baseObj)
        {
            var props = baseObj.Implementer.WrappedType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var p in props)
            {
                if (p.IsDefined(typeof(Injectable), true))
                {
                    baseObj.InjectableProperties.Add(p);
                }
            }
        }

        private void CheckPostConstructsAndInjectableMethods(IBaseType baseObj)
        {
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            var methods = baseObj.Implementer.WrappedType.GetMethods(bindingFlags);
            foreach (var m in methods)
            {
                if (m.IsDefined(typeof(PostConstruct), true))
                {
                    baseObj.PostConstructs.Add(m);
                }
                else if (m.IsDefined(typeof(InjectableParams)))
                {
                    baseObj.InjectableMethods.Add(m);
                }
            }
        }

    }

}
