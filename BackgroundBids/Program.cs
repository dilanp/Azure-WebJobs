using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgroundBids
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder();

            builder.ConfigureWebJobs(bldr =>
            {
                bldr.AddAzureStorageCoreServices();
                bldr.AddAzureStorage();
            });

            builder.ConfigureLogging(logCfg =>
            {
                logCfg.AddConsole();
            });

            var host = builder.Build();

            using (host)
            {
                host.Run();
            }
        }
    }
}
