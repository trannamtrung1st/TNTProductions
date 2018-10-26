using PromoterDataService.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(PromoterApi.Configurations.PreStartConfig), "Configure")]
namespace PromoterApi.Configurations
{
    public static class PreStartConfig
    {

        public static void Configure()
        {
            G.DefaultConfigure();
        }

    }
}