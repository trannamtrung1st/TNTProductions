using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TNT.Core.Helpers.DI
{

    public static class ServiceInjectionExtensions
    {
        public static IServiceCollection AddServiceInjection(this IServiceCollection services)
        {
            return services.AddScoped<ServiceInjection>();
        }
    }
}
