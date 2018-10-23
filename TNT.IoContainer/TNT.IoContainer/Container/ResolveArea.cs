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
         * CREATE INSTANCE
         */
        private object CreateInstance(Type type, params object[] initParams)
        {
            var instance = Activator.CreateInstance(type, initParams);
            CheckResource(instance);
            return instance;
        }

        /*
         * RESOLVE AREA
         */
        public Type Resolve<Type>(Params parameters = null)
        {
            var resolveType = typeof(Type);
            return (Type)Resolve(resolveType, parameters);
        }

        public Type Resolve<Type>(params object[] parameters)
        {
            var resolveType = typeof(Type);
            return (Type)Resolve(resolveType, parameters);
        }

        public object Resolve(Type type, Params parameters = null)
        {
            if (parameters != null)
                switch (parameters.Policy)
                {
                    case ParamsPolicy.Constructor:
                        return ResolveConstructor(type, parameters);
                    default:
                        return ResolveInjectableConstructor(type, parameters);
                }

            return ResolveConstructor(type);
        }

        public object Resolve(Type type, params object[] parameters)
        {
            return ResolveConstructor(type, parameters);
        }

        //final resolve for inject obj
        private object ResolveConstructor(Type type, Params parameters = null)
        {
            var baseObj = typeMapping[type];
            var implObj = baseObj.Implementer; //implement type

            if (baseObj.IsSimple && parameters == null)
                return CreateInstance(implObj.WrappedType);

            object[] initParams = null;
            if (parameters != null)
                initParams = parameters.Parameters;
            initParams = initParams ?? implObj.DefaultInitParams;
            object instance = null;
            try
            {
                instance = CreateInstance(implObj.WrappedType, initParams);//create instance
            }
            catch (Exception e)
            {
                var consBinding = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
                var constructors = implObj.WrappedType.GetConstructors(consBinding);
                bool called = false;
                foreach (var c in constructors)
                {
                    try
                    {
                        instance = c.Invoke(initParams);
                        called = true;
                        break;
                    }
                    catch (Exception e1)
                    {
                    }
                }
                if (!called)
                    return ResolveInjectableConstructor(type, Params.InjectAll(0));
                //try call default injectable params constructor
            }

            if (baseObj.IsSimple)
                return instance;

            //inject (create) instance of injectable properties
            foreach (var p in baseObj.InjectableProperties)
            {
                var val = ResolveConstructor(p.PropertyType);
                p.SetValue(instance, val);
            }

            //process injectable methods
            foreach (var m in baseObj.InjectableMethods)
            {
                var mParams = m.GetParameters();
                object[] resolvedParam = null;
                if (mParams != null && mParams.Length > 0)
                    resolvedParam = ResolveInjectableParams(mParams);
                m.Invoke(instance, resolvedParam);
            }

            //do post constructs (after all injection)
            foreach (var m in baseObj.PostConstructs)
            {
                try
                {
                    m.Invoke(instance, initParams);
                    break;
                }
                catch (Exception e) { }
            }

            return instance;
        }

        //final resolve for inject obj
        private object ResolveConstructor(Type type, params object[] initParams)
        {
            var baseObj = typeMapping[type];
            var implObj = baseObj.Implementer; //implement type

            if (baseObj.IsSimple && initParams == null)
                return CreateInstance(implObj.WrappedType);

            initParams = initParams ?? implObj.DefaultInitParams;
            object instance = null;
            try
            {
                instance = CreateInstance(implObj.WrappedType, initParams);//create instance
            }
            catch (Exception e)
            {
                var consBinding = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
                var constructors = implObj.WrappedType.GetConstructors(consBinding);
                bool called = false;
                foreach (var c in constructors)
                {
                    try
                    {
                        instance = c.Invoke(initParams);
                        called = true;
                        break;
                    }
                    catch (Exception e1)
                    {
                    }
                }
                if (!called)
                    return ResolveInjectableConstructor(type, Params.InjectAll(0));
                //try call default injectable params constructor
            }

            if (baseObj.IsSimple)
                return instance;

            //inject (create) instance of injectable properties
            foreach (var p in baseObj.InjectableProperties)
            {
                var val = ResolveConstructor(p.PropertyType);
                p.SetValue(instance, val);
            }

            //process injectable methods
            foreach (var m in baseObj.InjectableMethods)
            {
                var mParams = m.GetParameters();
                object[] resolvedParam = null;
                if (mParams != null && mParams.Length > 0)
                    resolvedParam = ResolveInjectableParams(mParams);
                m.Invoke(instance, resolvedParam);
            }

            //do post constructs (after all injection)
            foreach (var m in baseObj.PostConstructs)
            {
                try
                {
                    m.Invoke(instance, initParams);
                    break;
                }
                catch (Exception e) { }
            }

            return instance;
        }

        //for all injectable params
        private object[] ResolveInjectableParams(ParameterInfo[] realParams)
        {
            object[] result = new object[realParams.Length];

            //all injectable
            for (var i = 0; i < result.Length; i++)
                result[i] = ResolveConstructor(realParams[i].ParameterType);
            return result;
        }

        //for combination of params (Injectable and raw params)
        private object[] ResolveInjectableParams(ParameterInfo[] realParams, Params parameters)
        {
            object[] result = new object[realParams.Length];
            //combinations
            var virtualParams = parameters.Parameters;
            for (var i = 0; i < result.Length; i++)
            {
                if (virtualParams[i] is ParamsType)
                {
                    result[i] = ResolveConstructor(realParams[i].ParameterType);
                }
                else
                {
                    result[i] = virtualParams[i];
                }
            }
            return result;

        }

        //resolve injectable params before resolve obj
        private object ResolveInjectableConstructor(Type type, Params parameters)
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
                    return ResolveConstructor(type, Params.Constructor(resolvedParams));
                }
            }
            throw new Exception("Cannot find suitable injectable method/constructor with id " + id);
        }

    }
}
