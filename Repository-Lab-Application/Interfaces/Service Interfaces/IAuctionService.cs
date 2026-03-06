using Repository_Lab_Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Application.Interfaces.Service_Interfaces
{
    public interface IAuctionService
    {
        Task PliceBidAsync(int auctionId, decimal amount, CancellationToken cancellationToken);
    }
}
