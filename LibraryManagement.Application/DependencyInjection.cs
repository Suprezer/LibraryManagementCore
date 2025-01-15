using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using LibraryManagement.Application.Common.Mappings;
namespace LibraryManagement.Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add application services to the IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to which the services will be added.</param>
        /// <returns>The IServiceCollection with the added services.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register MediatR services from the executing assembly
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Register AutoMapper services with the specified mapping profile
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
