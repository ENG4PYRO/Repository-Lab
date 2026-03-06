using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Application.Interfaces.RepositoryInterfaces.Write
{
    public interface IWriteRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        void Update(T entity);
        void Delete(T entity);
    }
}
