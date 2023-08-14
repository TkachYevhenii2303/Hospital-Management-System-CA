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
    internal class PatientsCasesConfigurations : IEntityTypeConfiguration<PatientsCases>
    {
        public void Configure(EntityTypeBuilder<PatientsCases> builder)
        {
            builder
               .HasMany(x => x.Documents)
               .WithOne(x => x.PatientsCases)
               .HasForeignKey(fk => fk.PatientCaseId)
               .IsRequired()
               .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasMany(x => x.Appointments)
                .WithOne(x => x.PatientsCases)
                .HasForeignKey(fk => fk.PatientCasesId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
