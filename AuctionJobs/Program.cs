using Microsoft.AspNet.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace AuctionJobs
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            Task.Run(async () => await SetupSignalRClient()).Wait();

            Task.Run(async () =>
            {
                await Functions.NotifyOfExpiringAuctions(Console.Out);
            }).Wait();
        }

        private static async Task SetupSignalRClient()
        {
            try
            {
                string hostName = Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME");
                var connection = new HubConnection($"https://{hostName}");
                Functions.auctionHubClient = connection.CreateHubProxy("auctionHub");

                await connection.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
