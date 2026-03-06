using Microsoft.EntityFrameworkCore;
using Repository_Lab_Application.Interfaces.RepositoryInterfaces.Write;
using Repository_Lab_Core.Enums;
using Repository_Lab_Core.Models;
using Repository_Lab_Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Infrastructure.Repositories.Write
{
    public class WriteAuctionRepository : WriteRepository<Auction>, IWriteAuctionRepository
    {
        private readonly AppDbContext _dbContext;
        public WriteAuctionRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CompleteExpiredAuctionsAsync(CancellationToken cancellationToken)
        {
            var result = await _dbContext.Auctions.Where(x => x.Status == AuctionStatus.Active && x.EndDate < DateTime.UtcNow)
                .ExecuteUpdateAsync(setters => setters.SetProperty(
                    x => x.Status , x => AuctionStatus.Completed),cancellationToken);

            return result;
        }
    }
}
