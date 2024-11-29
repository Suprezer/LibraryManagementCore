﻿using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                // If the connection string is null, throw an exception
                if (connectionString == null)
                {
                    throw new ArgumentNullException("Connection string is null");
                }
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}