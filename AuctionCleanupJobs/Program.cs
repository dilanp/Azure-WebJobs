using System;

namespace AuctionCleanupJobs
{
    class Program
    {
        static void Main(string[] args)
        {
            Functions.CleanupExpiredAuctions(Console.Out);
        }
    }
}
