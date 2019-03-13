using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TNT.Core.OAuth;
using TNT.Core.OAuth.Authentication;
using TNT.Core.SignalR.Hubs;

namespace TNT.Core.SignalR2._2
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(opt => opt.DefaultScheme = "Basic")
                .AddBasicAuthentication<BasicHandler, BasicOptions>();

            services.AddMvc()
                .AddRazorPagesOptions(opt =>
                {
                    opt.Conventions.AuthorizePage("/Index");
                });

            services.AddSignalR();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHubStrongTyped>("/chatHub");
            });

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc();
        }
    }

    public class BasicHandler : BasicAuthenticationHandler<BasicOptions>
    {
        public BasicHandler(IOptionsMonitor<BasicOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> AuthenticateAsync(string rawUsername, string rawPassword)
        {
            var identity = new ClaimsIdentity("Basic");
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, rawUsername));
            identity.AddClaim(new Claim(ClaimTypes.Name, rawUsername));
            var user = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(user, BasicAuthenticationHandler.HandlerSchemes);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }

    public class BasicOptions : AuthenticationSchemeOptions
    {
        public BasicOptions()
        {
        }
    }

}
