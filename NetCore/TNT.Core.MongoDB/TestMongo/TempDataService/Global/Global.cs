using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TempDataService.Models.Configs;

namespace TempDataService.Global
{
    public static partial class G
    {
        public static void Configure(IServiceCollection services, IMongoDbSettings settings)
        {
            G.ConfigureAutomapper();
            G.ConfigureIoC(services, settings);
        }
    }
}
