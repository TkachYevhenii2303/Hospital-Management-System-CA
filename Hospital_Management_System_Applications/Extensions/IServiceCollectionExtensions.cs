using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapperConfigurations();
            services.AddMediatorConfigurations();
        }

        private static void AddAutoMapperConfigurations(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void AddMediatorConfigurations(this IServiceCollection services) 
        {
            services.AddMediatR(configuration => 
            configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
