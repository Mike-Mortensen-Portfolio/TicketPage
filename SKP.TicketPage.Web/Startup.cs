using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SKP.TicketPage.Domain;
using SKP.TicketPage.Domain.Entities;
using SKP.TicketPage.Services;
using System;

namespace SKP.TicketPage.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TicketPageContext>();
            services.AddScoped<ITicketPageService, TicketPageService>();
            services.RegisterLogger();

            #region SSO
            services.AddIdentity<Employee, Role>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<TicketPageContext>();

            services.AddAuthentication()
            .AddWsFederation(options =>
            {
                options.Wtrealm = Configuration["wsfed:realm"];
                options.MetadataAddress = Configuration["wsfed:metadata"];
            });
            #endregion

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                //options.Cookie.Expiration;

                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
                //  options.ReturnUrlParameter = "";
            });


            services.AddRazorPages();
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
