using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TNT.Core.Helpers.DI;

namespace TNT.Core.Http
{
    public static class PropertyInjectionExtensions
    {
        public static IServiceCollection AddPropertyInjection(this IServiceCollection services)
        {
            return services.AddScoped<PropertyInjection>();
        }
    }
}
