using Promoter.DataService.Global;
using Promoter.WebApi.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(PreStartConfig), "Configure")]
namespace Promoter.WebApi.Configurations
{
    public static class PreStartConfig
    {
        public static void Configure()
        {
            G.Configure();
        }
    }
}