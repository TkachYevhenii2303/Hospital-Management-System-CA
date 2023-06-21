using Hospital_Management_System_DAL.Entities;
using Hospital_Management_System_Domains.Common;
using Hospital_Management_System_Domains.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Persistence.Context
{
    public class HospitalManagementContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public HospitalManagementContext(DbContextOptions<HospitalManagementContext> options, 
            IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<Employees> Employees => Set<Employees>();
        public DbSet<Positions> Positions => Set<Positions>();
        public DbSet<HasRoles> HasRoles => Set<HasRoles>();
        public DbSet<Hospitals> Hospitals => Set<Hospitals>();
        public DbSet<InDepartments> InDepartments => Set<InDepartments>();
        public DbSet<Departments> Departments => Set<Departments>();
        public DbSet<Shedules> Shedules => Set<Shedules>();
        public DbSet<Patients> Patients => Set<Patients>();
        public DbSet<PatientsCases> PatientsCases => Set<PatientsCases>();
        public DbSet<AppointmentsStatuses> AppointmentsStatuses => Set<AppointmentsStatuses>();
        public DbSet<Appointments> Appointments => Set<Appointments>();
        public DbSet<StatusHistories> StatusHistories => Set<StatusHistories>();
        public DbSet<DocumentsTypes> DocumentsTypes => Set<DocumentsTypes>();
        public DbSet<Documents> Documents => Set<Documents>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if (_dispatcher is null) { return result; }

            var entitiesWithEvent = ChangeTracker.Entries<BaseEntity>()
                .Select(ent => ent.Entity)
                .Where(ent => ent.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEventsAsync(entitiesWithEvent);

            return result;
        }
    }
}
