using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JobsAuctions.Models;
using Microsoft.AspNet.SignalR.Client;

namespace AuctionJobs
{
    public class Functions
    {
        internal static IHubProxy auctionHubClient;

        public static async Task NotifyOfExpiringAuctions(TextWriter log)
        {
            log.WriteLine("Checking for expired auctions.");

            //get auctions expiring in the next two days
            var targetTime = DateTime.Now.AddDays(2);
            
            var ctx = new AuctionDbContext();
            var query = from auc in ctx.Auctions
                        where auc.ClosingTime < targetTime && auc.ClosingTime > DateTime.Now
                        select auc;

            //for each item, notify the site through SignalR
            foreach (var item in query)
            {
                log.WriteLine($"Notifying of expired auction {item.Title}");
                try
                {
                    //call the signalr hub to notify clients
                    await auctionHubClient.Invoke("expiringAuction", item.Title, item.ClosingTime);
                }
                catch (Exception ex)
                {
                    log.WriteLine(ex.ToString());
                }
            }
        }
    }
}
