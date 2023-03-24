using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concrete;
using DataAccessLayer.Abstract.Repositories;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard_Sima_Maniyeva_
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
            services.AddControllersWithViews();
            services.AddScoped<IMemberDal, EFMemberRepository>();
            services.AddScoped<IDepartmentDal,EFDepartmentRepository>();
            services.AddScoped<ISpecialityDal,EFSpecialityRepository>();
            services.AddScoped<IAdminDal,EFAdminRepository>();
            services.AddScoped<IUniversityDal,EFUniversityRepository>();
            
            services.AddScoped<IMemberService,MemberManager>();
            services.AddScoped<IDepartmentService,DepartmentManager>();
            services.AddScoped<ISpecialityService,SpecialityManager>();
            services.AddScoped<IUniversityService,UniversityManager>();
            services.AddScoped<IAdminService,AdminManager>();

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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Admin}/{action=SignIn}/{id?}");
            });
        }
    }
}
