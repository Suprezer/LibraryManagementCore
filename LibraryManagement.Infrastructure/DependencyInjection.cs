using LibraryManagement.Application.IService;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure services to the IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to which the services will be added.</param>
        /// <param name="configuration">The IConfiguration instance for accessing configuration settings.</param>
        /// <returns>The IServiceCollection with the added services.</returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure the DbContext with the connection string from the configuration
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

            // Register third-party services here
            services.AddScoped<IOpenLibraryBookService, OpenLibraryBookService>();
            services.AddScoped<IOpenLibraryEditionService, OpenLibraryEditionService>();

            return services;
        }
    }
}

