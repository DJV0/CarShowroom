using Carshowroom.DAL;
using CarShowroom.BLL.Interfaces;
using CarShowroom.BLL.Services;
using CarShowroom.Models;
using CarShowroom.WebAPI.Infrastructure.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CarShowroom.WebAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarShowroom.WebAPI", Version = "v1" });
            });
            services.AddHttpClient();
            services.AddDbContext<CarShowroomDbContext>(options => 
                                                    options.UseSqlServer(Configuration["ConnectionStrings:CarShowroomdb"]));
            services.AddAutoMapper(typeof(ClientProfile), typeof(CarProfile), typeof(EmployeeProfile),
                typeof(PartProfile), typeof(OrderProfile));
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPartService, PartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddScoped<IHttpClientServiceImplementation, HttpClientFactoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarShowroom.WebAPI v1"));
            }

            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Error: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error"
                        }.ToString());
                    }
                });
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
