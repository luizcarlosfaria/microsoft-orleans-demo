using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orleans.Configuration;

namespace gaGO.io.MicrosoftOrleansDemo
{
    public static class SharedConnect
    {
        private const string CONSUL_URI = "http://consul:8500";
        private const string CONSUL_KvRootFolder = "gaGO.io.MicrosoftOrleansDemo";

        private const int COLLECTION_AGE = 3;
        private const int COLLECTION_QUANTUM = 1;
        private const int DEACTIVATION_TIMEOUT = 3;

        private const string CLUSTER_ID = "production";
        private const string SERVICE_ID = "gaGO.io.MicrosoftOrleansDemo";

        public static void ConfigureConsul(ConsulClusteringSiloOptions options)
        {
            options.Address = new Uri(CONSUL_URI);
            options.KvRootFolder = CONSUL_KvRootFolder;
        }

        public static void ConfigureConsul(ConsulClusteringClientOptions options)
        {
            options.Address = new Uri(CONSUL_URI);
            options.KvRootFolder = CONSUL_KvRootFolder;
        }

        public static void ConfigurePersistenceTimers(GrainCollectionOptions options)
        {
            options.CollectionAge = TimeSpan.FromMinutes(COLLECTION_AGE);
            options.CollectionQuantum = TimeSpan.FromMinutes(COLLECTION_QUANTUM);
            options.DeactivationTimeout = TimeSpan.FromMinutes(DEACTIVATION_TIMEOUT);
        }
        public static void ConfigureServerEndpoint(EndpointOptions options)
        {
            try
            {
                var ip = System.Net.NetworkInformation.NetworkInterface
                    .GetAllNetworkInterfaces()
                    .Where(it => it.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
                    .SelectMany(it => it.GetIPProperties().UnicastAddresses)
                    .Select(it => it.Address)
                    .SingleOrDefault();

                options.AdvertisedIPAddress = ip;
            }
            catch (System.InvalidOperationException ex) when (ex.Message.Contains("more than one"))
            {
                throw new InvalidOperationException("Silo has many IP's. Host this silo in only one network.", ex);
            }
        }

        public static void ConfigureProtocol(ConnectionOptions options)
        {
            options.ProtocolVersion = Orleans.Runtime.Messaging.NetworkProtocolVersion.Version2;
        }

        public static void ConfigureCluster(ClusterOptions options)
        {
            options.ClusterId = CLUSTER_ID;
            options.ServiceId = SERVICE_ID;
        }
    }
}
