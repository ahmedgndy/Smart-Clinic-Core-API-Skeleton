using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Clinic_Core_APi.Models;

namespace Smart_Clinic_Core_APi.Infrastructure.Configurations
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
