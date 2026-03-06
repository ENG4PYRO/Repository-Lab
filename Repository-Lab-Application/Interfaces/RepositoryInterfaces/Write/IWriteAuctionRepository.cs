using Repository_Lab_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Application.Interfaces.RepositoryInterfaces.Write
{
    public interface IWriteAuctionRepository : IWriteRepository<Auction> 
    {
        Task<int> CompleteExpiredAuctionsAsync(CancellationToken cancellationToken);
    }
}
