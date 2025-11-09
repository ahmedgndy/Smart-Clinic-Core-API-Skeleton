using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Clinic_Core_APi.Models;

namespace Smart_Clinic_Core_APi.Infrastructure.Configurations
{
       public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
       {
              public void Configure(EntityTypeBuilder<Prescription> builder)
              {
                     builder.HasKey(p => p.Id);

                     builder.Property(p => p.Notes)
                            .HasColumnType("nvarchar(max)");

                     builder.Property(p => p.CreatedAt)
                                          .HasColumnType("datetime");


              }
       }
}
