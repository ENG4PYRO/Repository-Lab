using Repository_Lab_Application.Common;
using Repository_Lab_Application.Dtos;
using Repository_Lab_Application.WorkOrderForm;
using Repository_Lab_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repository_Lab_Application.Interfaces.RepositoryInterfaces.Read
{
    public interface IReadAuctionRepository : IReadRepository<Auction>
    {
        Task<IEnumerable<Auction>> GetActiveAuctions(CancellationToken cancellationToken);
        Task<PagedResult<Auction>> SearchAuctions(AuctionSearchParameters searchParameters, CancellationToken cancellationToken);
        Task<IEnumerable<AuctionSummaryDto>> GetActiveAuctionSummariesAsync(CancellationToken cancellationToken);
    }
}
