using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TNT.Core.Helpers.DI
{

    public static class PropertyInjectionExtensions
    {
        public static IServiceCollection AddPropertyInjection(this IServiceCollection services)
        {
            return services.AddScoped<PropertyInjection>();
        }
    }
}
