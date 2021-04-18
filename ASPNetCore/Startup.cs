using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using React.AspNet;
using Microsoft.Extensions.Logging;
using BLL;

namespace ASPNetCore
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
            services.RegisterBllServices(Configuration);
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName).AddChakraCore();

            //var connection = Configuration.GetConnectionString("DefaultConnection");

            //services.AddIdentity<User, IdentityRole>()
                //.AddEntityFrameworkStores<MarketContext>();

            //services.AddDbContext<MarketContext>(options => options.UseSqlServer(connection));

            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = ".AspNetCore.Identity.Application";
                options.LoginPath = "/";
                options.AccessDeniedPath = "/";
                options.LogoutPath = "/";
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
                options.Events.OnRedirectToAccessDenied = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });


            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder
                    .WithOrigins("http://localhost:3000")
                    .WithMethods("PUT", "DELETE", "GET", "POST")
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            CreateUserRoles(services).Wait();

            app.UseDeveloperExceptionPage();

            app.UseReact(config => { });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            /*// подключаем CORS
            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
            */
            app.UseCors("AllowMyOrigin");

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            // Создание ролей администратора и пользователя
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }

            // Создание Администратора
            string adminEmail = "lizakurochkina";
            string adminPassword = "Liza2120_";
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

            // Создание Пользователя
            string userEmail = "billieBieberDu";
            string userPassword = "Billie18_"; 
            if (await userManager.FindByNameAsync(userEmail) == null)
            {
                User user = new User { Email = userEmail, UserName = userEmail };
                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                }
            }
        }
    }
}
