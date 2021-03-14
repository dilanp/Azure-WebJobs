using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AuctionCleanupJobs.Models
{
    public class AuctionDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.AddEnvironmentVariables();

            var config = builder.Build();

            optionsBuilder.UseSqlServer(
                config.GetConnectionString(
                    "AuctionDBContext"));

            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Auction> Auctions { get; set; }

        public DbSet<AuctionItem> AuctionItems { get; set; }

        public DbSet<Bid> Bids { get; set; }
    }
}