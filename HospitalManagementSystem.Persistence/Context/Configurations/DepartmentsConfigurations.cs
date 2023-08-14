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
    internal class DepartmentsConfigurations : IEntityTypeConfiguration<Departments>
    {
        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            builder
                .HasMany(x => x.InDepartments)
                .WithOne(x => x.Departments)
                .HasForeignKey(fk => fk.DepartmentsId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
