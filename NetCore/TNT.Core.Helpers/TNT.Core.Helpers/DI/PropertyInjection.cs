using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TNT.Core.Helpers.DI
{
    public class PropertyInjection
    {
        private static readonly IDictionary<Type, IEnumerable<PropertyInfo>> _mappings;
        static PropertyInjection()
        {
            _mappings = new Dictionary<Type, IEnumerable<PropertyInfo>>();
            var assembly = Assembly.GetEntryAssembly();
            var allTypes = assembly.DefinedTypes;
            foreach (var type in allTypes)
            {
                var listProps = new List<PropertyInfo>();
                var allProps = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (var p in allProps)
                {
                    var attr = p.GetCustomAttribute<InjectAttribute>(false);
                    if (attr != null)
                        listProps.Add(p);
                }
                if (listProps.Count > 0)
                    _mappings[type] = listProps;
            }
        }

        private readonly IServiceProvider _provider;
        public PropertyInjection(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void Inject(object obj)
        {
            var type = obj.GetType();
            if (_mappings.ContainsKey(type))
            {
                var listProps = _mappings[type];
                foreach (var p in listProps)
                {
                    p.SetValue(obj, _provider.GetRequiredService(p.PropertyType));
                }
            }
        }
    }

    public static class PropertyInjectionExtensions
    {
        public static IServiceCollection AddPropertyInjection(this IServiceCollection services)
        {
            return services.AddScoped<PropertyInjection>();
        }
    }
}
