using ASystem.Context;
using ASystem.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SASystem.Context;
using System;

namespace ASystem
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
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IAirplaneContext, AirplaneContext>();
            services.AddScoped<IAirplaneManufacturerContext, AirplaneManufacturerContext>();
            services.AddScoped<IAirplaneModelContext, AirplaneModelContext>();
            services.AddScoped<IAirportContext, AirportContext>();
            services.AddScoped<IClassContext, ClassContext>();
            services.AddScoped<IEmployeeContext, EmployeeContext>();
            services.AddScoped<IFlightScheduleContext, FlightScheduleContext>();
            services.AddScoped<ICrewContext, CrewContext>();
            services.AddScoped<IJobContext, JobContext>();
            services.AddScoped<IPassengerContext, PassengerContext>();
            services.AddScoped<IPassportContext, PassportContext>();
            services.AddScoped<IPilotContext, PilotContext>();
            services.AddScoped<ISeatContext, SeatContext>();
            services.AddScoped<IScheduleCrewContext, ScheduleCrewContext>();
            services.AddScoped<ISchedulePassengerContext, SchedulePassengerContext>();
            services.AddScoped<ISchedulePilotContext, SchedulePilotContext>();
            services.AddScoped<ISchedulePriceContext, SchedulePriceContext>();
            services.AddScoped<IReportContext, ReportContext>();

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
        }
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

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Login}/{id?}");
                });
        }
    }
}
