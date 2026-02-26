using Repository_Lab_Core.Models;

namespace Repository_Lab_Application.Interfaces.RepositoryInterfaces
{
    public interface IAuctionRepository
    {
        Task<IEnumerable<Auction>> GetActiveAuctions(CancellationToken cancellationToken);
    }
}
