using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using Onion.AppCore.Services;
using Onion.Infrastructure.Data;
using Onion.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Onion.WebApp
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

            // установка конфигурации подключения
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options => //CookieAuthenticationOptions
            //    {
            //        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            //    });
            services.AddTransient<IGenericRepository<Employee>, SQLRepository<Employee>>();
            services.AddTransient<IEmployee, EmployeeService>();
            services.AddTransient<IGenericRepository<Project>, SQLRepository<Project>>();
            services.AddTransient<IProject, ProjectService>();
            services.AddTransient<IGenericRepository<Team>, SQLRepository<Team>>();
            services.AddTransient<ITeam, TeamService>();
            services.AddTransient<IGenericRepository<Department>, SQLRepository<Department>>();
            services.AddTransient<IDepartment, DepartmentService>();
            services.AddTransient<IGenericRepository<DepartmentType>, SQLRepository<DepartmentType>>();
            services.AddTransient<IDepartmentType, DepartmentTypeService>();


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            // обработка ошибок HTTP
            app.UseStatusCodePages();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Project}/{action=Show}/{id?}");
            });
        }
    }
}
