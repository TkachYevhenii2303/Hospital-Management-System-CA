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
    internal class HospitalConfigurations : IEntityTypeConfiguration<Hospitals>
    {
        public void Configure(EntityTypeBuilder<Hospitals> builder)
        {
            builder
                .HasMany(x => x.Departments)
                .WithOne(x => x.Hospital)
                .HasForeignKey(fk => fk.HospitalId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
