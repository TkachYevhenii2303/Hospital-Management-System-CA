using Hospital_Management_System_DAL.Entities;
using Hospital_Management_System_Domains.Common;
using Hospital_Management_System_Domains.Common.Interfaces;
using Hospital_Management_System_Domains.Entities;
using Hospital_Management_System_Domains.Entities.Login;
using Hospital_Management_System_Persistence.Seeding;
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

        #region DbSets for each entity from the database
        
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
        public DbSet<CustomerAdministrator> CustomerAdministrators => Set<CustomerAdministrator>();
        public DbSet<UserModel> UserModels => Set<UserModel>();

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            SeedingConfigurations(modelBuilder);
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

        private void SeedingConfigurations(ModelBuilder modelBuilder)
        {
            var seeding = new SeedingWithBogus();

            modelBuilder.Entity<Employees>().HasData(seeding.Employees);
            modelBuilder.Entity<Positions>().HasData(seeding.Positions);
            modelBuilder.Entity<HasRoles>().HasData(seeding.HasRoles);
            modelBuilder.Entity<Hospitals>().HasData(seeding.Hospitals);
            modelBuilder.Entity<InDepartments>().HasData(seeding.InDepartments);
            modelBuilder.Entity<Departments>().HasData(seeding.Departments);
            modelBuilder.Entity<Shedules>().HasData(seeding.Shedules);
            modelBuilder.Entity<Patients>().HasData(seeding.Patients);
            modelBuilder.Entity<PatientsCases>().HasData(seeding.PatientsCases);
            modelBuilder.Entity<AppointmentsStatuses>().HasData(seeding.AppointmentsStatuses);
            modelBuilder.Entity<Appointments>().HasData(seeding.Appointments);
            modelBuilder.Entity<DocumentsTypes>().HasData(seeding.DocumentsTypes);
            modelBuilder.Entity<Documents>().HasData(seeding.Documents);
            modelBuilder.Entity<UserModel>().HasData(seeding.UserModels);
        }
    }
}
