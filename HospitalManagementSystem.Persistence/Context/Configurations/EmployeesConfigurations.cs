using Hospital_Management_System_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_DAL.Configurations
{
    internal class EmployeesConfigurations : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder
                .HasMany(x => x.HasRoles)
                .WithOne(x => x.Employees)
                .HasForeignKey(fk => fk.EmployeesId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.InDepartments)
                .WithOne(x => x.Employees)
                .HasForeignKey(fk => fk.EmployeesId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
