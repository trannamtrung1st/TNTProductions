using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScaffoldIdentityWeb.Models;

[assembly: HostingStartup(typeof(ScaffoldIdentityWeb.Areas.Identity.IdentityHostingStartup))]
namespace ScaffoldIdentityWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DataContextConnection")));

                //services.AddDefaultIdentity<IdentityUser>()
                //    .AddEntityFrameworkStores<DataContext>();
            });
        }
    }
}