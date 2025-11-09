using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartClinic.Core.Models;

namespace SmartClinic.Infrastructure.Configurations
{
       public class PrescriptionItemConfiguration : IEntityTypeConfiguration<PrescriptionItem>
       {
              public void Configure(EntityTypeBuilder<PrescriptionItem> builder)
              {
                     builder.HasKey(i => i.Id);


                     builder.Property(i => i.Dosage)
                            .HasColumnType("nvarchar(50)")
                            .IsRequired();

                     builder.Property(i => i.Instructions)
                            .HasColumnType("nvarchar(200)")
                            .IsRequired();

              }
       }
}
