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

namespace Api.Utils
{
    public static class ServiceDiscoveryExtensions
    {
        static public string ServiceName;
        static public string IPAddress;
        static public string Port;

        public static IServiceCollection AddConsulConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                var address = configuration.GetValue<string>("Consul:Host");
                IPAddress = Environment.GetEnvironmentVariable("IP_EXTERNA");
                Port = Environment.GetEnvironmentVariable("PORT_EXTERNO");

                Console.WriteLine("IP: " + IPAddress);
                Console.WriteLine("Port: " + Port);

                consulConfig.Address = new Uri(address);

                ServiceDiscoveryExtensions.ServiceName = configuration.GetValue<string>("Consul:ServiceName");
            }));
            return services;
        }

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("AppExtensions");
            var lifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();

            if (!(app.Properties["server.Features"] is FeatureCollection features)) return app;

            // var addresses = features.Get<IServerAddressesFeature> ();
            // var address = addresses.Addresses.First ();

            // Console.WriteLine ($"address={address}");

            // var uri = new Uri (address);

            var registration = new AgentServiceRegistration()
            {
                ID = $"{ServiceDiscoveryExtensions.ServiceName}-{IPAddress}-{Port}",
                Name = ServiceDiscoveryExtensions.ServiceName,
                Address = IPAddress,
                Port = Convert.ToInt32(Port)
            };

            logger.LogInformation("Registering with Consul");
            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

            lifetime.ApplicationStopping.Register(() =>
            {
                logger.LogInformation("Unregistering from Consul");
                consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            });

            return app;
        }
    }
}