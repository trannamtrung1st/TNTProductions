using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCore.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TNT.Core.OAuth.Authorization;
using TNT.Core.OAuth;
using Microsoft.AspNetCore.Authentication;
using TestDataService.Global;
using TNT.Core.OAuth.Externals;
using System.Security.Claims;

namespace TestCore
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            #region Config OAuth
            OAuthOptions = AuthorizationServerOptions.Default;
            OAuthOptions.AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(30);
            OAuthOptions.AllowInsecureHttp = false;
            OAuthOptions.Provider = new AuthorizationServer(OAuthOptions);
            OAuthOptions.ExternalOAuthOptions = new ExternalOAuthOptions()
            {
                FacebookClient = new FacebookClient(
                    "523869358117226",
                    "14b9045c0222858c250ac81394778665"),
                GoogleClient = new GoogleClient(
                    "931960859587-hjibavglvimtv5d4rofuiul7sdqblht7.apps.googleusercontent.com",
                    "USs_I-dgw4l1Voj2hsyvi0kC"),
                FacebookAuthenticate = async (options, debug) =>
                {
                    var identity = new ClaimsIdentity(options.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, debug.Data.UserId));
                    identity.AddClaim(new Claim("Provider", "Facebook"));
                    var principal = new ClaimsPrincipal(identity);
                    return await Task.FromResult(new AuthenticationTicket(principal, options.AuthenticationScheme));
                },
                GoogleAuthenticate = async (options, debug) =>
                {
                    var identity = new ClaimsIdentity(options.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, debug.SubId));
                    identity.AddClaim(new Claim("Provider", "Google"));
                    var principal = new ClaimsPrincipal(identity);
                    return await Task.FromResult(new AuthenticationTicket(principal, options.AuthenticationScheme));
                },
            };
            #endregion
        }
        public AuthorizationServerOptions OAuthOptions { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services
                .AddBearerAuthorizationPolicy()
                .AddCookieAuthorizationPolicy()
                .AddBasicAuthorizationPolicy()
                .AddAuthentication()
                .AddBasicAuthentication<BasicAuthentication, AuthenticationSchemeOptions>()
                .AddBearerAuthentication(OAuthOptions)
                .AddCookieAuthentication(OAuthOptions);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddRazorPagesOptions(o =>
                {
                    o.Conventions.AuthorizePageWithPolicies("/Index", "Cookie", "Bearer", "Basic");
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseAuthorizationServer(OAuthOptions);

            app.UseMvc();
        }
    }



}
