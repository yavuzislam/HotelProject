﻿using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Mapping;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Reflection;


namespace HotelProject.WebUI
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
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
            services.AddHttpClient();
            services.AddControllersWithViews()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<CreateGuestValidator>();
    });

            services.AddFluentValidationAutoValidation()
                     .AddFluentValidationClientsideAdapters();
            //services.AddFluentValidationAutoValidation();
            //services.AddFluentValidationClientsideAdapters();
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddFluentValidationAutoValidation(cfg =>
            //{
            //    cfg.DisableDataAnnotationsValidation = true;
            //});
            //services.AddValidatorsFromAssemblyContaining<CreateGuestValidator>();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperConfig()));
            services.AddSingleton(mapperConfig.CreateMapper());
            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //    .RequireAuthenticatedUser()
            //    .Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //});
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

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}