using System;
using CustomSecureWeb.Areas.Identity.Data;
using CustomSecureWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CustomSecureWeb.Areas.Identity.IdentityHostingStartup))]
namespace CustomSecureWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DataContextConnection")));

                services.AddIdentity<AppUser, IdentityRole>()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<DataContext>();

            });
        }
    }
}