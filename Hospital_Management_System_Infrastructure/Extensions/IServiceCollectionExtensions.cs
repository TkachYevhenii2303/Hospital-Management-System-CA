using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_Management_System_Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services) => AddServices(services);

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMediator, Mediator>();
        }
    }
}
