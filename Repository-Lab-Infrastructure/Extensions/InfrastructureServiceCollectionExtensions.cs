using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Repository_Lab_Application.Interfaces.RepositoryInterfaces;
using Repository_Lab_Application.Interfaces.RepositoryInterfaces.Read;
using Repository_Lab_Application.Interfaces.RepositoryInterfaces.Write;
using Repository_Lab_Infrastructure.Caches;
using Repository_Lab_Infrastructure.Data;
using Repository_Lab_Infrastructure.Repositories;
using Repository_Lab_Infrastructure.Repositories.Read;
using Repository_Lab_Infrastructure.Repositories.Write;

namespace Repository_Lab_Infrastructure.Extensions
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDb"));
            services.AddMemoryCache();

            services.AddScoped<IWriteAuctionRepository, WriteAuctionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ReadAuctionRepository>();
            services.AddScoped<IReadAuctionRepository>(serviceProvider =>
            {
                var inner = serviceProvider.GetRequiredService<ReadAuctionRepository>();
                var cache = serviceProvider.GetRequiredService<IMemoryCache>();
                return new CachedReadAuctionRepository(inner, cache);
            });

            return services;
        }
    }
}



    
