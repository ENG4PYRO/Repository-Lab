using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Application.Interfaces.RepositoryInterfaces.Read
{
    public interface IReadRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}
