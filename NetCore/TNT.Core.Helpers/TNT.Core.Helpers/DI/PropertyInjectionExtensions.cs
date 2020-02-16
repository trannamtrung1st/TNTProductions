using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TNT.Core.Helpers.DI
{

    public static class PropertyInjectionExtensions
    {
        public static IServiceCollection AddPropertyInjection(this IServiceCollection services,
            IEnumerable<Type> assTypes)
        {
            PropertyInjection.Init(assTypes);
            return services.AddScoped<PropertyInjection>();
        }
    }
}
