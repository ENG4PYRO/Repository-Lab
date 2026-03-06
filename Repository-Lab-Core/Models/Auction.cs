using Repository_Lab_Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Core.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AuctionStatus Status { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal CurrentPrice { get; set; }

        public User OwnerAuction { get; set; } 
        public int OwnerAuctionId { get; set; }

        public ICollection<Bid> Bids { get; set; } = new List<Bid>();

    }
}
