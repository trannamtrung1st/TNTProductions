using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.Helpers.Data
{
    public static class DataExtension
    {
        #region Get properties of type
        private static IDictionary<Type, IDictionary<string, PropertyInfo>> ReflectionCaches;
        static DataExtension()
        {
            ReflectionCaches = new Dictionary<Type, IDictionary<string, PropertyInfo>>();
        }

        public static void CachePropertiesOfType(Type t)
        {
            var props = t.GetProperties();
            var mappings = new Dictionary<string, PropertyInfo>();
            foreach (var p in props)
            {
                mappings[p.Name] = p;
            }
            ReflectionCaches[t] = mappings;
        }

        private static IDictionary<string, PropertyInfo> GetPropMappings(Type type)
        {
            if (ReflectionCaches.ContainsKey(type))
                return ReflectionCaches[type];
            var mappings = new Dictionary<string, PropertyInfo>();
            var props = type.GetProperties();
            foreach (var p in props)
            {
                mappings[p.Name] = p;
            }
            return mappings;
        }
        #endregion

        #region Dynamic type 
        private static Type DynamicBuildType(
            ref int no, bool keepStructure,
            IDictionary<string, PropertyInfo> inpMappings, params string[] properties)
        {
            var builder = CreateTypeBuilder(
                "Dynamic" + no,
                "Dynamic" + no,
                "Dynamic" + no);
            if (!keepStructure)
            {
                var checkedList = new List<string>();
                foreach (var p in properties)
                {
                    var pStr = p;
                    if (pStr.Contains('.'))
                    {
                        var prName = pStr.Substring(0, pStr.IndexOf('.'));
                        if (!checkedList.Contains(prName))
                        {
                            var prType = inpMappings[prName].PropertyType;
                            var newMappings = GetPropMappings(prType);
                            var sames = properties.Where(pr => pr.StartsWith(prName + "."));
                            sames = sames.Select(pr => pr.Substring(pr.IndexOf('.') + 1));
                            ++no;
                            CreateAutoImplementedProperty(
                                builder, prName, DynamicBuildType(ref no, keepStructure, newMappings, sames.ToArray()));
                            checkedList.Add(prName);
                        }
                    }
                    else
                        CreateAutoImplementedProperty(builder, pStr, inpMappings[pStr].PropertyType);
                }
            }
            else
                foreach (var kvp in inpMappings)
                {
                    var sames = properties.Where(p => p.Contains(kvp.Key + "."))
                        .Select(p => p.Substring(p.IndexOf('.') + 1)).ToArray();
                    var newMappings = GetPropMappings(kvp.Value.PropertyType);
                    Type newType = null;
                    if (sames.Length > 0)
                    {
                        ++no;
                        newType = DynamicBuildType(ref no, keepStructure, newMappings, sames);
                    }
                    else
                        newType = kvp.Value.PropertyType;
                    CreateAutoImplementedProperty(builder, kvp.Key, newType);
                }
            return builder.CreateType();
        }

        public static TypeBuilder CreateTypeBuilder(
            string assemblyName, string moduleName, string typeName)
        {
            TypeBuilder typeBuilder = AssemblyBuilder
                .DefineDynamicAssembly(new AssemblyName(assemblyName),
                                       AssemblyBuilderAccess.Run)
                .DefineDynamicModule(moduleName)
                .DefineType(typeName, TypeAttributes.Public);
            typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
            return typeBuilder;
        }

        public static void CreateAutoImplementedProperty(
            TypeBuilder builder, string propertyName, Type propertyType)
        {
            const string PrivateFieldPrefix = "m_";
            const string GetterPrefix = "get_";
            const string SetterPrefix = "set_";

            // Generate the field.
            FieldBuilder fieldBuilder = builder.DefineField(
                string.Concat(PrivateFieldPrefix, propertyName),
                              propertyType, FieldAttributes.Private);

            // Generate the property
            PropertyBuilder propertyBuilder = builder.DefineProperty(
                propertyName, PropertyAttributes.HasDefault, propertyType, null);

            // Property getter and setter attributes.
            MethodAttributes propertyMethodAttributes =
                MethodAttributes.Public | MethodAttributes.SpecialName |
                MethodAttributes.HideBySig;

            // Define the getter method.
            MethodBuilder getterMethod = builder.DefineMethod(
                string.Concat(GetterPrefix, propertyName),
                propertyMethodAttributes, propertyType, Type.EmptyTypes);

            // Emit the IL code.
            // ldarg.0
            // ldfld,_field
            // ret
            ILGenerator getterILCode = getterMethod.GetILGenerator();
            getterILCode.Emit(OpCodes.Ldarg_0);
            getterILCode.Emit(OpCodes.Ldfld, fieldBuilder);
            getterILCode.Emit(OpCodes.Ret);

            // Define the setter method.
            MethodBuilder setterMethod = builder.DefineMethod(
                string.Concat(SetterPrefix, propertyName),
                propertyMethodAttributes, null, new Type[] { propertyType });

            // Emit the IL code.
            // ldarg.0
            // ldarg.1
            // stfld,_field
            // ret
            ILGenerator setterILCode = setterMethod.GetILGenerator();
            setterILCode.Emit(OpCodes.Ldarg_0);
            setterILCode.Emit(OpCodes.Ldarg_1);
            setterILCode.Emit(OpCodes.Stfld, fieldBuilder);
            setterILCode.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getterMethod);
            propertyBuilder.SetSetMethod(setterMethod);
        }
        #endregion

        #region Select only (self selection)
        private static MemberInitExpression CreateNew(
            ref int no, bool keepStructure, bool init,
            Type inpType, Type srcType,
            Expression src, params string[] properties)
        {
            int orgNo = no;
            var srcMappings = GetPropMappings(srcType);
            Type outType;
            if (init)
            {
                no++;
                outType = DynamicBuildType(ref no, keepStructure, GetPropMappings(inpType), properties);
            }
            else outType = inpType;
            var outMappings = GetPropMappings(outType);

            NewExpression newObj = Expression.New(outType);
            no = orgNo;
            var listAssignments = new List<MemberAssignment>();
            var checkedList = new List<string>();
            foreach (var p in properties)
            {
                var outStr = p.Replace(" ", "");
                var srcStr = outStr;

                if (outStr.Contains("."))
                {
                    var prName = outStr.Substring(0, outStr.IndexOf('.'));
                    if (!checkedList.Contains(prName))
                    {
                        var prInfo = outMappings[prName];
                        var prType = prInfo.PropertyType;
                        var sames = properties.Where(pr => pr.StartsWith(prName + "."));
                        sames = sames.Select(pr => pr.Substring(pr.IndexOf('.') + 1));
                        var newSrc = Expression.Property(src, srcMappings[prName]);
                        ++no;
                        var initPr = CreateNew(ref no, keepStructure, false,
                            prType, srcMappings[prName].PropertyType, newSrc, sames.ToArray());
                        listAssignments.Add(Expression.Bind(prInfo, initPr));
                        checkedList.Add(prName);
                    }
                }
                else
                {
                    var outProp = outMappings[outStr];
                    var srcProp = srcMappings[srcStr];
                    var srcMember = Expression.Property(src, srcProp);
                    listAssignments.Add(Expression.Bind(outProp, srcMember));
                }

            }

            var initObj = Expression.MemberInit(newObj, listAssignments);
            return initObj;
        }

        private static MemberInitExpression CreateNew(
            Type srcType,
            Expression src, params string[] properties)
        {
            var srcMappings = GetPropMappings(srcType);

            NewExpression newObj = Expression.New(srcType);
            var listAssignments = new List<MemberAssignment>();
            var checkedList = new List<string>();
            foreach (var p in properties)
            {
                var srcStr = p.Replace(" ", "");

                if (srcStr.Contains("."))
                {
                    var prName = srcStr.Substring(0, srcStr.IndexOf('.'));
                    if (!checkedList.Contains(prName))
                    {
                        var prInfo = srcMappings[prName];
                        var prType = prInfo.PropertyType;
                        var sames = properties.Where(pr => pr.StartsWith(prName + "."));
                        sames = sames.Select(pr => pr.Substring(pr.IndexOf('.') + 1));
                        var newSrc = Expression.Property(src, srcMappings[prName]);
                        var initPr = CreateNew(prType, newSrc, sames.ToArray());
                        listAssignments.Add(Expression.Bind(prInfo, initPr));
                        checkedList.Add(prName);
                    }
                }
                else
                {
                    var srcProp = srcMappings[srcStr];
                    var srcMember = Expression.Property(src, srcProp);
                    listAssignments.Add(Expression.Bind(srcProp, srcMember));
                }
            }
            var initObj = Expression.MemberInit(newObj, listAssignments);
            return initObj;
        }

        public static IQueryable<object> SelectOnly<In>(this IQueryable<In> query, bool keepStructure, params string[] properties)
        {
            var inpType = typeof(In);
            ParameterExpression inp = Expression.Parameter(typeof(In), "inp");
            var no = 0;
            var initObj = CreateNew(ref no, keepStructure, true, inpType, inpType, inp, properties);
            var lambda = Expression.Lambda<Func<In, object>>(initObj, inp);
            return query.Select(lambda);
        }

        public static IEnumerable<object> SelectOnly<In>(this IEnumerable<In> query, bool keepStructure, params string[] properties)
        {
            var inpType = typeof(In);
            ParameterExpression inp = Expression.Parameter(typeof(In), "inp");
            var no = 0;
            var initObj = CreateNew(ref no, keepStructure, true, inpType, inpType, inp, properties);
            var lambda = Expression.Lambda<Func<In, object>>(initObj, inp).Compile();
            return query.Select(lambda);
        }

        public static IQueryable<In> SelectOnly<In>(this IQueryable<In> query, params string[] properties)
        {
            var inpType = typeof(In);
            ParameterExpression inp = Expression.Parameter(typeof(In), "inp");
            var initObj = CreateNew(inpType, inp, properties);
            var lambda = Expression.Lambda<Func<In, In>>(initObj, inp);
            return query.Select(lambda);
        }

        public static IEnumerable<In> SelectOnly<In>(this IEnumerable<In> query, params string[] properties)
        {
            var inpType = typeof(In);
            ParameterExpression inp = Expression.Parameter(typeof(In), "inp");
            var initObj = CreateNew(inpType, inp, properties);
            var lambda = Expression.Lambda<Func<In, In>>(initObj, inp).Compile();
            return query.Select(lambda);
        }

        #endregion

        #region Select only (project from In to Out)
        private static MemberInitExpression CreateNew<Out>(
            Type outType, Type srcType,
            Expression src, params string[] propMappings)
        {
            var outMappings = GetPropMappings(outType);
            var srcMappings = GetPropMappings(srcType);

            NewExpression newObj = Expression.New(outType);
            var listAssignments = new List<MemberAssignment>();
            var checkedList = new List<string>();
            foreach (var p in propMappings)
            {
                var parts = p.Split('=');
                var outStr = parts[0].Replace(" ", "");
                var srcStr = parts[1].Replace(" ", "");

                if (outStr.Contains('.'))
                {
                    var prName = outStr.Substring(0, outStr.IndexOf('.'));
                    if (!checkedList.Contains(prName))
                    {
                        var prInfo = outMappings[prName];
                        var prType = prInfo.PropertyType;
                        var sames = propMappings.Where(pr => pr.Split('=')[0].StartsWith(prName + "."));
                        sames = sames.Select(pr => pr.Substring(pr.IndexOf('.') + 1));
                        var initPr = CreateNew<object>(prType, srcType, src, sames.ToArray());
                        listAssignments.Add(Expression.Bind(prInfo, initPr));
                        checkedList.Add(prName);
                    }
                }
                else
                {
                    var outProp = outMappings[outStr];
                    Expression newSrc;
                    Type newType = null;
                    if (srcStr.Contains('.'))
                    {
                        IDictionary<string, PropertyInfo> tmpMappings = srcMappings;
                        Expression tmpSrc = src;
                        var tmpStr = srcStr;
                        while (tmpStr.Contains('.'))
                        {
                            var srcPrName = tmpStr.Substring(0, tmpStr.IndexOf('.'));
                            var srcPrInfo = tmpMappings[srcPrName];
                            newType = srcPrInfo.PropertyType;
                            tmpSrc = Expression.Property(tmpSrc, srcPrInfo);
                            tmpStr = tmpStr.Substring(tmpStr.IndexOf('.') + 1);
                            tmpMappings = GetPropMappings(newType);
                        }
                        newSrc = Expression.Property(tmpSrc, tmpMappings[tmpStr]);
                    }
                    else
                    {
                        var srcPrInfo = srcMappings[srcStr];
                        newSrc = Expression.Property(src, srcPrInfo);
                        newType = srcPrInfo.PropertyType;
                    }
                    listAssignments.Add(Expression.Bind(outProp, newSrc));
                }

            }

            var initObj = Expression.MemberInit(newObj, listAssignments);
            return initObj;
        }

        public static IQueryable<Out> SelectOnly<In, Out>(this IQueryable<In> query, params string[] propMappings)
        {
            var inpType = typeof(In);
            var outType = typeof(Out);
            ParameterExpression inp = Expression.Parameter(typeof(In), "inp");
            var initObj = CreateNew<Out>(outType, inpType, inp, propMappings);
            var lambda = Expression.Lambda<Func<In, Out>>(initObj, inp);
            return query.Select(lambda);
        }

        public static IEnumerable<Out> SelectOnly<In, Out>(this IEnumerable<In> query, params string[] propMappings)
        {
            var inpType = typeof(In);
            var outType = typeof(Out);
            ParameterExpression inp = Expression.Parameter(typeof(In), "inp");
            var initObj = CreateNew<Out>(outType, inpType, inp, propMappings);
            var lambda = Expression.Lambda<Func<In, Out>>(initObj, inp).Compile();
            return query.Select(lambda);
        }

        #endregion

        #region Select only (specify output type by method param)
        public static IQueryable<object> SelectOnly<In>(this IQueryable<In> query, Type outType, params string[] propMappings)
        {
            var inpType = typeof(In);
            ParameterExpression inp = Expression.Parameter(typeof(In), "inp");
            var initObj = CreateNew<object>(outType, inpType, inp, propMappings);
            var lambda = Expression.Lambda<Func<In, object>>(initObj, inp);
            return query.Select(lambda);
        }

        public static IEnumerable<object> SelectOnly<In>(this IEnumerable<In> query, Type outType, params string[] propMappings)
        {
            var inpType = typeof(In);
            ParameterExpression inp = Expression.Parameter(typeof(In), "inp");
            var initObj = CreateNew<object>(outType, inpType, inp, propMappings);
            var lambda = Expression.Lambda<Func<In, object>>(initObj, inp).Compile();
            return query.Select(lambda);
        }

        #endregion

    }
}
