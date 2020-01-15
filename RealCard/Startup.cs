using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealCard.Authentication;
using RealCard.Core.BLL;
using RealCard.Core.DAL.Contexts;
using RealCard.Core.DAL.Contexts.Interfaces;
using RealCard.Core.DAL.Models;

namespace RealCard
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
            services.AddTransient<IUserStore<BaseAccount>, MSSQLUserContext>();
            services.AddTransient<IRoleStore<Role>, MSSQLRoleContext>();
            services.AddIdentity<BaseAccount, Role>().AddDefaultTokenProviders();

            services.AddTransient<IUserContext, MSSQLAccountContext>();
            services.AddTransient<ICardContext, MSSQLCardContext>();
            services.AddTransient<IFileContext, MSSQLFileContext>();
            services.AddTransient<IDeckContext, MSSQLDeckContext>();

            services.AddScoped<UserRepo>();
            services.AddScoped<CardRepo>();
            services.AddScoped<DeckRepo>();
            services.AddScoped<ImageFileRepo>();

            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "profile",
                    pattern: "profile/{id?}",
                    new {controller = "User", action = "Index"}
                );
            });
        }
    }
}
