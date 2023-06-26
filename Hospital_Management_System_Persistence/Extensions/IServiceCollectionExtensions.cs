using Hospital_Management_System_Applications.Interfaces.Patterns;
using Hospital_Management_System_Applications.Interfaces.Repositories;
using Hospital_Management_System_Persistence.Context;
using Hospital_Management_System_Persistence.Repositories;
using Hospital_Management_System_Persistence.Repositories.Patterns;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextConfiguration(configuration);
            services.AddRepositoriesConfiguration();
        }

        private static void AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<HospitalManagementContext>(options =>
            {
                options.UseSqlServer(connectionString,
                    builder => builder.MigrationsAssembly("Hospital_Management_System_Migrations"));
            });
        }

        private static void AddRepositoriesConfiguration(this IServiceCollection services)
        {
            services
               .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
               .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
               .AddTransient<IEmployeeRepository, EmployeeRepository>()
               .AddTransient<IAppointmentsRepository, AppointmentsRepository>();
        }
    }
}
