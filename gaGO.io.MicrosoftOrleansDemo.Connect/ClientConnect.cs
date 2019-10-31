using System;
using System.Collections.Generic;
using System.Text;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

namespace gaGO.io.MicrosoftOrleansDemo
{
    public static class ClientConnect
    {
        public static IClientBuilder CreateClient()
        {
            var clientBuilder = new ClientBuilder()
                        .UseConsulClustering(SharedConnect.ConfigureConsul)
                        .Configure<ConnectionOptions>(SharedConnect.ConfigureProtocol)
                        .Configure<ClusterOptions>(SharedConnect.ConfigureCluster);

            return clientBuilder;
        }
    }
}
