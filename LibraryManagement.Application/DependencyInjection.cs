using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using LibraryManagement.Application.Common.Mappings;
namespace LibraryManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register MediatR services
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Register AutoMapper services
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
