using DataServiceTest.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApi.Configurations;

[assembly: PreApplicationStartMethod(typeof(ManualConfig), "Configure")]
namespace TestApi.Configurations
{
    public static class ManualConfig
    {

        public static void Configure()
        {
            G.DefaultConfigure();
        }

    }
}