using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using repos.Servises;
using repos.Domeins.Repository.Abstract;
using repos.Domeins.Repository.EntityFramework;
using repos.Domeins;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using repos.Domeins.Entities;

namespace repos
{
    public class Startup

    { public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            //подключаем конфиг из appsetings.json и связываем его с файлом -оберткой Сonfig
            Configuration.Bind("Project", new Config());
           
            //подключаем нужный функционал-связываеи интерфейс и его реализацию(можно поменять)
            services.AddTransient<ITextFieldRepository, EFTextFieldRepository>();
            services.AddTransient<IServiceItemRepository, EFServiceItemRepository>();
            services.AddTransient<DataManager>();
            //подключаем контекст БД
            services.AddDbContext<ApDbContext>(x => x.UseSqlServer(Config.ConnectionString));
            //настраеваем Identity cистему
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
             {
                 opts.User.RequireUniqueEmail = true;
                 opts.Password.RequiredLength = 6;
                 opts.Password.RequireNonAlphanumeric = false;
                 opts.Password.RequireLowercase = false;
                 opts.Password.RequireUppercase = false;
                 opts.Password.RequireDigit = false;

             }).AddEntityFrameworkStores<ApDbContext>().AddDefaultTokenProviders();

            //настраеваем куки аунтентификацию
            services.ConfigureApplicationCookie(options=>
               {
                   options.Cookie.Name = "kuki";
                   options.Cookie.HttpOnly = true;
                   options.LoginPath = "/account/login";
                   options.AccessDeniedPath = "/account/accessdenled";
                   options.SlidingExpiration = true;
                });
            //настраеваем политику авторизации для Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });
            //контролеры и представления мvc
            services.AddControllersWithViews(x=>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            //аутентификация и авторизация
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                
            });
        }
    }
}
