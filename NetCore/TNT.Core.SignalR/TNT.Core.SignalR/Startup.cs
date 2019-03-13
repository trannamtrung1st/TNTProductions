using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TNT.Core.SignalR.Hubs;

namespace TNT.Core.SignalR
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

            //services.AddAuthentication(options =>
            //{
            //    // Identity made Cookie authentication the default.
            //    // However, we want JWT Bearer Auth to be the default.
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //  {
            //      // Configure JWT Bearer Auth to expect our security key
            //      options.TokenValidationParameters =
            //        new TokenValidationParameters
            //        {
            //            LifetimeValidator = (before, expires, token, param) =>
            //            {
            //                return expires > DateTime.UtcNow;
            //            },
            //            ValidateAudience = false,
            //            ValidateIssuer = false,
            //            ValidateActor = false,
            //            ValidateLifetime = true,
            //        };

            //      // We have to hook the OnMessageReceived event in order to
            //      // allow the JWT authentication handler to read the access
            //      // token from the query string when a WebSocket or 
            //      // Server-Sent Events request comes in.
            //      options.Events = new JwtBearerEvents
            //      {
            //          OnMessageReceived = context =>
            //          {
            //              var accessToken = context.Request.Query["access_token"];

            //              // If the request is for our hub...
            //              var path = context.HttpContext.Request.Path;
            //              if (!string.IsNullOrEmpty(accessToken) &&
            //                  (path.StartsWithSegments("/chatHub")))
            //              {
            //                  // Read the token out of the query string
            //                  context.Token = accessToken;
            //              }
            //              return Task.CompletedTask;
            //          }
            //      };
            //  });

            services.AddAuthentication("Basic")
            .AddScheme<BasicOptions, BasicHandler>("Basic", opt =>
            {
            });

            //services.AddAuthorization(opt =>
            //{
            //    opt.DefaultPolicy = new AuthorizationPolicyBuilder()
            //    .AddAuthenticationSchemes("Basic")
            //    .AddRequirements(new Requirement())
            //    .RequireAuthenticatedUser()
            //    .Build();
            //});

            //services.AddTransient<IAuthorizationHandler, AuthorizeHandler>();

            services.AddMvc()
                .AddNewtonsoftJson();

            services.AddSignalR();

            //services.AddSingleton<IUserIdProvider, NameUserIdProvider>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting(routes =>
            {
                routes.MapRazorPages();
            });
            app.UseAuthentication();
            app.UseCookiePolicy();
            app.UseAuthorization();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHubStrongTyped>("/chatHub", opt =>
                {
                });
            });
        }
    }
    public class NameUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Identity?.Name;
        }
    }
    public class BasicOptions : AuthenticationSchemeOptions
    {
    }

    public class Requirement : IAuthorizationRequirement
    {
        public Requirement()
        {
        }
    }

    //public class AuthorizePolicy : AuthorizationPolicy
    //{
    //    public AuthorizePolicy(IEnumerable<IAuthorizationRequirement> requirements, IEnumerable<string> authenticationSchemes) : base(requirements, authenticationSchemes)
    //    {
    //    }
    //}

    //public class AuthorizeHandler : AuthorizationHandler<Requirement>
    //{
    //    public AuthorizeHandler()
    //    {
    //    }

    //    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, Requirement requirement)
    //    {
    //        context.Succeed(requirement);
    //        return Task.CompletedTask;
    //    }
    //}
    public class BasicHandler : AuthenticationHandler<BasicOptions>
    {
        public static int TheOne { get; set; } = 0;
        public BasicHandler(IOptionsMonitor<BasicOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            TheOne++;
            if (TheOne > 5)
            {
                var iden = new ClaimsIdentity("Basic");
                iden.AddClaim(new Claim(ClaimTypes.Name, "TNT"));
                iden.AddClaim(new Claim(ClaimTypes.NameIdentifier, "TNT"));
                var user = new ClaimsPrincipal(iden);
                var ticket = new AuthenticationTicket(user, "Basic");
                return AuthenticateResult.Success(ticket);
            }
            var newIden = new ClaimsIdentity("Basic");
            newIden.AddClaim(new Claim(ClaimTypes.Name, "ABC"));
            newIden.AddClaim(new Claim(ClaimTypes.NameIdentifier, "ABC"));
            var newUser = new ClaimsPrincipal(newIden);
            var newTicket = new AuthenticationTicket(newUser, "Basic");
            return AuthenticateResult.Success(newTicket);
        }
    }

}
