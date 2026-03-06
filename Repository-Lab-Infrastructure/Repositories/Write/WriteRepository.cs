using Microsoft.EntityFrameworkCore;
using Repository_Lab_Application.Interfaces.RepositoryInterfaces.Write;
using Repository_Lab_Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Infrastructure.Repositories.Write
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        public WriteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(entity, cancellationToken);
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id, cancellationToken);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }
    }
}
