using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Application.Interfaces.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
