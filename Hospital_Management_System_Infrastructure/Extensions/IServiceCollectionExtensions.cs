using Hospital_Management_System_Domains.Common.Interfaces;
using Hospital_Management_System_Domains.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_Management_System_Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services) => services.AddServices();

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
        }
    }
}
