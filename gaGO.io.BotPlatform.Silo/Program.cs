using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Hosting;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using Orleans.Configuration;
using gaGO.io.BotPlatform.Internals;

namespace gaGO.io.BotPlatform.Silo
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            Console.WriteLine("-");

            var host = new HostBuilder()
                .UseOrleans((context, siloBuilder) =>
                {
                    siloBuilder
                        .UseConsulClustering(SharedConnect.ConfigureConsul)
                        .Configure<ConnectionOptions>(SharedConnect.ConfigureProtocol)
                        .Configure<ClusterOptions>(SharedConnect.ConfigureCluster)
                        .Configure<GrainCollectionOptions>(SharedConnect.ConfigurePersistenceTimers)
                        .Configure<EndpointOptions>(SharedConnect.ConfigureServerEndpoint)
                        .AddMongoDBGrainStorage("Default", options => {
                            options.ConnectionString = "mongodb://orleans:EdcNYWE6U7l6tPWukNMfW@mongo:27017/Orleans?authSource=admin";
                            options.DatabaseName = "Orleans";
                        })
                        .UseDashboard()
                        .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(SystemInfoGrain).Assembly).WithReferences()
                        );
                })
                .ConfigureLogging(logging => logging.AddConsole())
                .Build();

            await host.RunAsync();

            return 0;
        }
    }
}