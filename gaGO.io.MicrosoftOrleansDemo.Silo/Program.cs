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
using gaGO.io.MicrosoftOrleansDemo.Internals;

namespace gaGO.io.MicrosoftOrleansDemo.Silo
{
    public class Program
    {        

        public static async Task<int> Main(string[] args)
        {
            Console.WriteLine("-");

            var host = new HostBuilder()
                 //.ConfigureWebHostDefaults(webBuilder =>
                 //{
                 //    // Configure ASP.NET Core
                 //    //webBuilder.UseStartup<Startup>();
                 //})
                .UseOrleans((context, siloBuilder) =>
                {
                    siloBuilder
                        .UseConsulClustering(SharedConnect.ConfigureConsul)
                        .Configure<ConnectionOptions>(SharedConnect.ConfigureProtocol)
                        .Configure<ClusterOptions>(SharedConnect.ConfigureCluster)
                        .Configure<GrainCollectionOptions>(SharedConnect.ConfigurePersistenceTimers)
                        .Configure<EndpointOptions>(SharedConnect.ConfigureServerEndpoint)
                        .AddMongoDBGrainStorage("Default", options => {
                            options.ConnectionString = Environment.GetEnvironmentVariable("MONGODB_CON") ?? throw new InvalidOperationException("MONGODB_CON is not set");
                            options.DatabaseName = Environment.GetEnvironmentVariable("MONGODB_DATABASE") ?? throw new InvalidOperationException("MONGODB_DATABASE is not set");
                        })
                        .UseDashboard()
                        .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(SystemInfoGrain).Assembly).WithReferences()
                        );
                })
                .ConfigureLogging(logging => logging.AddConsole())
                //.ConfigureServices(services =>
                //{
                //    /* Configure shared services */
                //})
                //.UseConsoleLifetime()
                .Build();

            await host.RunAsync();

            return 0;
        }
    }
}