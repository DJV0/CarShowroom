using CarShowroom.Client.Infrastructure.HttpClients;
using CarShowroom.Client.Infrastructure.HttpClients.Interfaces;
using CarShowroom.Client.Services;
using CarShowroom.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<ICarClient, CarClient>(client => 
                                                            client.BaseAddress = new Uri("https://localhost:44362/api/"));
            builder.Services.AddHttpClient<IClientClient, ClientClient>(client =>
                                                            client.BaseAddress = new Uri("https://localhost:44362/api/"));
            builder.Services.AddHttpClient<IPartClient, PartClient>(client =>
                                                            client.BaseAddress = new Uri("https://localhost:44362/api/"));
            builder.Services.AddHttpClient<IOrderClient, OrderClient>(client =>
                                                            client.BaseAddress = new Uri("https://localhost:44362/api/"));
            builder.Services.AddHttpClient<IEmployeeClient, EmployeeClient>(client =>
                                                            client.BaseAddress = new Uri("https://localhost:44362/api/"));

            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IPartService, PartService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            await builder.Build().RunAsync();
        }
    }
}
