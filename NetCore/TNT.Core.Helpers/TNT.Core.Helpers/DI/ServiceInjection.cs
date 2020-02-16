using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TNT.Core.Helpers.DI
{
    internal class InjectedTypeInfo
    {
        public List<PropertyInfo> Properties { get; set; } = new List<PropertyInfo>();
        public List<FieldInfo> Fields { get; set; } = new List<FieldInfo>();
    }

    public class ServiceInjection
    {
        private static IDictionary<Type, InjectedTypeInfo> _mappings;
        static ServiceInjection()
        {
            _mappings = new Dictionary<Type, InjectedTypeInfo>();
        }

        public static void Register(IEnumerable<Type> assemblyRepresentTypes)
        {
            foreach (var t in assemblyRepresentTypes)
            {
                var assembly = Assembly.GetAssembly(t);
                var allTypes = assembly.DefinedTypes;
                foreach (var type in allTypes)
                {
                    var allProps = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    var allFields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    var info = new InjectedTypeInfo();
                    foreach (var p in allProps)
                    {
                        var attr = p.GetCustomAttribute<InjectAttribute>(false);
                        if (attr != null)
                            info.Properties.Add(p);
                    }
                    foreach (var f in allFields)
                    {
                        var attr = f.GetCustomAttribute<InjectAttribute>(false);
                        if (attr != null)
                            info.Fields.Add(f);
                    }
                    if (info.Fields.Count > 0 || info.Properties.Count > 0)
                        _mappings[type] = info;
                }
            }
        }

        private readonly IServiceProvider _provider;
        public ServiceInjection(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void Inject(object obj)
        {
            var type = obj.GetType();
            if (_mappings.ContainsKey(type))
            {
                var info = _mappings[type];
                foreach (var p in info.Properties)
                {
                    p.SetValue(obj, _provider.GetRequiredService(p.PropertyType));
                }
                foreach (var f in info.Fields)
                {
                    f.SetValue(obj, _provider.GetRequiredService(f.FieldType));
                }
            }
        }
    }

}
