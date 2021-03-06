using Orleans;
using Orleans.Runtime;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Orleans.Configuration;
using gaGO.io.MicrosoftOrleansDemo.Internals;
using Orleans.Hosting;

namespace gaGO.io.MicrosoftOrleansDemo.ClientConsole
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));
            Console.WriteLine("Inicializando");

            try
            {
                using var client = gaGO.io.MicrosoftOrleansDemo.ClientConnect.CreateClient()
                    .ConfigureLogging(logging => logging.AddConsole())
                    .Build();

                await client.Connect(CreateRetryFilter());
                Console.WriteLine("Client successfully connect to silo host");

                var grain = client.GetGrain<ISystemInfoGrain>(0);

                var grainWData = client.GetGrain<IGrainWithData>(1);

                await grainWData.SetName("luiz");

                for (var i = 0; i < 10; i++)
                {
                    var GetOSInfo = await grain.GetOSInfo();
                    var time = await grain.GetTime();
                    Console.WriteLine("");
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                }

                var name = await grainWData.GetName();

                //var date = await grain.ThrowException();

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 1;
            }
        }

        private static Func<Exception, Task<bool>> CreateRetryFilter(int maxAttempts = 5)
        {
            var attempt = 0;
            return RetryFilter;

            async Task<bool> RetryFilter(Exception exception)
            {
                attempt++;
                Console.WriteLine($"Cluster client attempt {attempt} of {maxAttempts} failed to connect to cluster.  Exception: {exception}");
                if (attempt > maxAttempts)
                {
                    return false;
                }

                await Task.Delay(TimeSpan.FromSeconds(4));
                return true;
            }
        }
    }
}
