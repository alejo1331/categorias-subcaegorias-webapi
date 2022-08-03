using System;
using System.Linq;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Categorias.Api.Utils
{
    public static class ServiceDiscoveryExtensions
    {
        static private string IPAddress = "127.0.0.1";
        static private string Port = "7000";
        static private string ServiceName = "categorias-subcategorias-WebApi";

        public static IServiceCollection AddConsulConfig(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<string>("Consul:Host") == null)
            {
                Console.WriteLine($"Error: 'Consul:Host' is not found in the application settings (appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json)");
                return services;
            }

            if (configuration.GetValue<string>("Consul:ServiceName") == null)
            {
                Console.WriteLine($"Error: 'Consul:ServiceName' is not found in the application settings (appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json)");
                return services;
            }

            if (Environment.GetEnvironmentVariable("IP_EXTERNA") == null)
            {
                Console.WriteLine("Error: Environment variable 'IP_EXTERNA' not found");
                return services;
            }

            if (Environment.GetEnvironmentVariable("PORT_EXTERNO") == null)
            {
                Console.WriteLine("Error: Environment variable 'PORT_EXTERNO' not found");
                return services;
            }

            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                var hostConsul = configuration.GetValue<string>("Consul:Host");
                consulConfig.Address = new Uri(hostConsul);

                IPAddress = Environment.GetEnvironmentVariable("IP_EXTERNA") ?? IPAddress;
                Port = Environment.GetEnvironmentVariable("PORT_EXTERNO") ?? Port;

                ServiceDiscoveryExtensions.ServiceName = configuration.GetValue<string>("Consul:ServiceName");

                Console.WriteLine($"Info: Consul:Host {hostConsul}");
                Console.WriteLine($"Info: Consul:ServiceName {configuration.GetValue<string>("Consul:ServiceName")}");
                Console.WriteLine($"Info: Environment variable IP_EXTERNA {IPAddress}");
                Console.WriteLine($"Info: Environment variable PORT_EXTERNO {Port}");
            }));
            return services;
        }

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app)
        {
            try
            {
                var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
                var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("AppExtensions");
                var lifetime = app.ApplicationServices.GetRequiredService<Microsoft.Extensions.Hosting.IHostApplicationLifetime>();

                var registration = new AgentServiceRegistration()
                {
                    ID = $"{ServiceDiscoveryExtensions.ServiceName}-{IPAddress}-{Port}",
                    Name = ServiceDiscoveryExtensions.ServiceName,
                    Address = IPAddress,
                    Port = Convert.ToInt32(Port)
                };

                Console.WriteLine("Info: Registering with Consul");
                consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
                consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

                lifetime.ApplicationStopping.Register(() =>
                {
                    Console.WriteLine("Info: Unregistering from Consul");
                    consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
                });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
            }
            return app;
        }
    }
}