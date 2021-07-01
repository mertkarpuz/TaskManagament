using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Navyki.Todo.Business.Concrete;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.Business.ValidationRules.FluentValidation;
using Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Navyki.Todo.DataAccess.Interfaces;
using Navyki.Todo.DTO.DTOs.AppUserDtos;
using Navyki.Todo.DTO.DTOs.ReportDtos;
using Navyki.Todo.DTO.DTOs.UrgencyDtos;
using Navyki.Todo.DTO.DTOs.WorkDtos;
using Navyki.Todo.Entities.Concrete;
using System;

namespace Navyki.ToDo.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IWorkService, WorkManager>();
            services.AddScoped<IUrgencyService, UrgencyManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IAppUserService,AppUserManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<IWorkDal, EfWorkRepository>();
            services.AddScoped<IUrgencyDal, EfUrgencyRepository>();
            services.AddScoped<IReportDal, EfReportRepostory>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<INotificationDal, EfNotificationRepository>();



            services.AddDbContext<TodoContext>();
            services.AddIdentity<AppUser,AppRole>(opt => {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<TodoContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "BusinessCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            }

            );

            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IValidator<UrgencyAddDto>,UrgencyAddValidator>();
            services.AddTransient<IValidator<UrgencyUpdateDto>, UrgencyUpdateValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();
            services.AddTransient<IValidator<WorkAddDto>, WorkAddValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateValidator>();
            services.AddTransient<IValidator<ReportAddDto>, ReportAddValidator>();
            services.AddTransient<IValidator<ReportUpdateDto>, ReportUpdateValidator>();






            services.AddControllersWithViews().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{Id?}"
                    );
            });
        }
    }
}
