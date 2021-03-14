using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundBids
{
    public class Bid
    {
        public double Amount { get; set; }

        public int ItemId { get; set; }

        public string Bidder { get; set; }
    }
}
