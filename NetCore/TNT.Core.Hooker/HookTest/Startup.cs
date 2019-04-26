using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using TNT.Core.Hooker;

namespace HookTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpHooker(new HttpHookerOptions()
            {
                HookMethods = new List<string>() { "get" },
                HookResponse = true,
                HookRequest = false,
                Process = (user, req, resp) =>
                {
                    var text = JsonConvert.SerializeObject(new
                    {
                        user,
                        req,
                        resp
                    });
                    return Task.CompletedTask;
                }
            });

            app.UseHttpHooker(new HttpHookerOptions()
            {
                HookMethods = new List<string>() { "post" },
                HookRequest = true,
                Process = (user, req, resp) =>
                {
                    var text = JsonConvert.SerializeObject(new
                    {
                        user,
                        req,
                        resp
                    });
                    return Task.CompletedTask;
                }
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

}
