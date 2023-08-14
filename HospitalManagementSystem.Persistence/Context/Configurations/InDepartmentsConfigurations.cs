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
    internal class InDepartmentsConfigurations : IEntityTypeConfiguration<InDepartments>
    {
        public void Configure(EntityTypeBuilder<InDepartments> builder)
        {
            builder
                .HasMany(x => x.Documents)
                .WithOne(x => x.InDepartment)
                .HasForeignKey(fk => fk.InDepartmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Appointments)
                .WithOne(x => x.InDepartment)
                .HasForeignKey(fk => fk.InDepartmentsId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Shedules)
                .WithOne(x => x.InDepartment)
                .HasForeignKey(fk => fk.InDepartmentsId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
