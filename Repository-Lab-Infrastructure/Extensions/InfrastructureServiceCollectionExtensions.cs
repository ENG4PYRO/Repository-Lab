using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository_Lab_Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Infrastructure.Extensions
{
    public static class InfrastructureServiceCollectionExtensions
    {
            public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
            {

                services.AddDbContext<AppDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryDb")); 
                                                                
                return services;
        }
    }
}
