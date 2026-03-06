using Microsoft.EntityFrameworkCore;
using Repository_Lab_Application.Common;
using Repository_Lab_Application.Dtos;
using Repository_Lab_Application.Interfaces.RepositoryInterfaces.Read;
using Repository_Lab_Application.WorkOrderForm;
using Repository_Lab_Core.Enums;
using Repository_Lab_Core.Models;
using Repository_Lab_Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Infrastructure.Repositories.Read
{
    public class ReadAuctionRepository : ReadRepository<Auction>, IReadAuctionRepository
    {
        private readonly AppDbContext _context;

        private static readonly Func<AppDbContext, IAsyncEnumerable<AuctionSummaryDto>>
            _compiledActiveAuctions = EF.CompileAsyncQuery((AppDbContext context) =>
            context.Auctions.AsNoTracking()
                .Where(a => a.Status == AuctionStatus.Active &&
                            a.StartDate < DateTime.UtcNow &&
                            a.EndDate > DateTime.UtcNow).Select(a => new AuctionSummaryDto
                            {
                                Id = a.Id,
                                Title = a.Name,
                                CurrentPrice = a.CurrentPrice
                            }));


        public ReadAuctionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Auction>> GetActiveAuctions(CancellationToken cancellationToken)
        {
            return await _context.Auctions.AsNoTracking()
                .Where(a => a.Status == AuctionStatus.Active &&
                            a.StartDate < DateTime.UtcNow &&
                            a.EndDate > DateTime.UtcNow)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<AuctionSummaryDto>> GetActiveAuctionSummariesAsync(CancellationToken cancellationToken)
        {
            var result = new List<AuctionSummaryDto>();
            await foreach (var auction in _compiledActiveAuctions(_context)
                .WithCancellation(cancellationToken))
            {
                result.Add(auction);
            }

            return result;
        }

        public async Task<PagedResult<Auction>> SearchAuctions(AuctionSearchParameters searchParameters, CancellationToken cancellationToken)
        {
            IQueryable<Auction> query = _context.Auctions.AsNoTracking();

            if(!string.IsNullOrEmpty(searchParameters.SearchTerm))
            {
                query = query.Where(a => a.Name.Contains(searchParameters.SearchTerm) ||
                                         a.Description.Contains(searchParameters.SearchTerm));
            }
            if (searchParameters.MinPrice.HasValue)
            {
                query = query.Where(a => a.CurrentPrice >= searchParameters.MinPrice.Value);
            }

            if (searchParameters.MaxPrice.HasValue)
            {
                query = query.Where(a => a.CurrentPrice <= searchParameters.MaxPrice.Value);
            }

            PagedResult<Auction> result = new PagedResult<Auction>
            { 
                PageNumber = searchParameters.PageNumber,
                PageSize = searchParameters.PageSize,
                TotalItems = await query.CountAsync(cancellationToken),
            };

            result.Data = await query.Skip((searchParameters.PageNumber - 1) * searchParameters.PageSize)
                .Take(searchParameters.PageSize)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
