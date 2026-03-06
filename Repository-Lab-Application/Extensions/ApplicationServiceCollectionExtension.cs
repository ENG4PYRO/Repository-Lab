using Microsoft.Extensions.DependencyInjection;
using Repository_Lab_Application.Interfaces.Service_Interfaces;
using Repository_Lab_Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Application.Extensions
{
    public static class ApplicationServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuctionService, AuctionService>();
            return services;
        }
    }
}
