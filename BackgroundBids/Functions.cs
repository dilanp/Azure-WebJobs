using Microsoft.Azure.WebJobs;
using System.IO;

namespace BackgroundBids
{
    public class Functions
    {
        public static void ProcessBid(
           [QueueTrigger("bids")] Bid msg, //Binding (input)
           [Blob("bids/log.txt", FileAccess.Write)] TextWriter blob, //Binding (output)
           TextWriter log)
        {
            blob.WriteLine(
                $"Item: {msg.ItemId}, had bid of {msg.Amount} made by {msg.Bidder}");
        }
    }
}
