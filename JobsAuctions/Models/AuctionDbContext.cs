using System.Data.Entity;

namespace JobsAuctions.Models
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext()
        {
            Database.SetInitializer(new AuctionDbInitializer());
        }
        public DbSet<Auction> Auctions { get; set; }

        public DbSet<AuctionItem> AuctionItems { get; set; }

        public DbSet<Bid> Bids { get; set; }


    }
}