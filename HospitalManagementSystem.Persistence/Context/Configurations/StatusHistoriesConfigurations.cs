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
    internal class StatusHistoriesConfigurations : IEntityTypeConfiguration<StatusHistories>
    {
        public void Configure(EntityTypeBuilder<StatusHistories> builder)
        {
            builder
                .HasOne(x => x.AppointmentsStatus)
                .WithMany(x => x.StatusHistories)
                .HasForeignKey(fk => fk.AppointmentStatusId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
