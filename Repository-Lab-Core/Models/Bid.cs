using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Core.Models
{
    public class Bid
    {
        public int Id { get; set; }

        public User Buyer { get; set; }
        public int BuyerId { get; set; }

        public Auction Auction { get; set; }
        public int AuctionId { get; set; }
        public decimal Amount { get; set; }



    }
}
