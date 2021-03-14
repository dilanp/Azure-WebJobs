using System;
using System.Collections.Generic;

namespace AuctionCleanupJobs.Models
{
    public class Auction
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime OpeningTime { get; set; }

        public DateTime ClosingTime { get; set; }

        public ICollection<AuctionItem> Items { get; set; }
    }
}