using Microsoft.Extensions.Caching.Memory;
using Repository_Lab_Application.Common;
using Repository_Lab_Application.Dtos;
using Repository_Lab_Application.Interfaces.RepositoryInterfaces.Read;
using Repository_Lab_Application.WorkOrderForm;
using Repository_Lab_Core.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Repository_Lab_Infrastructure.Caches
{
    public class CachedReadAuctionRepository : IReadAuctionRepository
    {
        private readonly IReadAuctionRepository _decorated;
        private readonly IMemoryCache _cache;
        public CachedReadAuctionRepository(IReadAuctionRepository decorated, IMemoryCache cache)
        {
            _decorated = decorated;
            _cache = cache;
        }

        public async Task<IEnumerable<Auction>> GetActiveAuctions(CancellationToken cancellationToken)
        {   
            var result = await _cache.GetOrCreateAsync("homepage_active_auctions", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return await _decorated.GetActiveAuctions(cancellationToken);
            });
            return result ?? Enumerable.Empty<Auction>();
        }

        public async Task<IEnumerable<AuctionSummaryDto>> GetActiveAuctionSummariesAsync(CancellationToken cancellationToken)
        {
            var result = await _cache.GetOrCreateAsync("homepage_active_auctions_summary", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return await _decorated.GetActiveAuctionSummariesAsync(cancellationToken);
            });
            return result ?? Enumerable.Empty<AuctionSummaryDto>();
        }

        public async Task<IEnumerable<Auction>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _cache.GetOrCreateAsync("all_auctions", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                return await _decorated.GetAllAsync(cancellationToken);
            });
            return result ?? Enumerable.Empty<Auction>();
        }

        public async Task<Auction?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _decorated.GetByIdAsync(id, cancellationToken);
        }

        public async Task<PagedResult<Auction>> SearchAuctions(AuctionSearchParameters searchParameters, CancellationToken cancellationToken)
        {
            return await _decorated.SearchAuctions(searchParameters, cancellationToken); 
        }
    }
}
