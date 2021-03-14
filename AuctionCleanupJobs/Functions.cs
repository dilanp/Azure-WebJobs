using System;
using System.IO;
using System.Linq;

namespace AuctionCleanupJobs
{
    class Functions
    {
        public static void CleanupExpiredAuctions(TextWriter log)
        {
            bool itemsRemoved = false;

            log.WriteLine("Checking for auctions that can be deleted");

            var ctx = new Models.AuctionDbContext();
            var query = from auct in ctx.Auctions
                        where auct.ClosingTime < DateTime.Now
                        select auct;

            foreach (var item in query)
            {
                itemsRemoved = true;
                log.WriteLine($"Removing auction: {item.Title}");
                ctx.Auctions.Remove(item);
            }

            if (itemsRemoved)
            {
                ctx.SaveChanges();
            }
        }
    }
}
