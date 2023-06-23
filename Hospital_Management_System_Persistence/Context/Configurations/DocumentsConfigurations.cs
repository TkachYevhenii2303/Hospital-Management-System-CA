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
    internal class DocumentsConfigurations : IEntityTypeConfiguration<Documents>
    {
        public void Configure(EntityTypeBuilder<Documents> builder)
        {
            builder
                .HasOne(x => x.DocumentsTypes)
                .WithMany(x => x.Documents)
                .HasForeignKey(fk => fk.DocumentsTypesId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
