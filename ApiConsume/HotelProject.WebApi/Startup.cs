using AutoMapper;
using FluentValidation.AspNetCore;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebApi.Mapping;
using HotelProject.WebApi.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace HotelProject.WebApi
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

            services.AddScoped<IRoomDal, EfRoomDal>();
            services.AddScoped<IRoomService, RoomManager>();

            services.AddScoped<IServiceDal, EfServiceDal>();
            services.AddScoped<IServiceService, ServiceManager>();

            services.AddScoped<IStaffDal, EfStaffDal>();
            services.AddScoped<IStaffService, StaffManager>();

            services.AddScoped<ISubscribeDal, EfSubscribeDal>();
            services.AddScoped<ISubscribeService, SubscribeManager>();

            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();

            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IBookingDal, EfBookingDal>();
            services.AddScoped<IBookingService, BookingManager>();

            services.AddScoped<ICustomerDal, EfCustomerDal>();
            services.AddScoped<ICustomerService, CustumerManager>();

            services.AddScoped<IGuestDal, EfGuestDal>();
            services.AddScoped<IGuestService, GuestManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<IMessageCategoryDal, EfMessageCategoryDal>();
            services.AddScoped<IMessageCategoryService, MessageCategoryManager>();

            services.AddScoped<ISendMessageDal, EfSendMessageDal>();
            services.AddScoped<ISendMessageService, SendMessageManager>();

            services.AddScoped<IAppUserDal, EfAppUserDal>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IWorkLocationDal, EfWorkLocationDal>();
            services.AddScoped<IWorkLocationService, WorkLocationManager>();

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperConfig()));
            services.AddSingleton(mapperConfig.CreateMapper());


            services.AddCors(opt =>
            {
                opt.AddPolicy("OtelApiCors", opts =>
                {
                    opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //services.AddControllers().AddNewtonsoftJson(options =>
            //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).
            //AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateGuestValidate>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelProject.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelProject.WebApi v1"));
            }
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors("OtelApiCors");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}