using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Clinic_Core_APi.Models;

namespace Smart_Clinic_Core_APi.Infrastructure.Configurations
{
       public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
       {
              public void Configure(EntityTypeBuilder<Doctor> builder)
              {
                     builder.HasKey(d => d.Id);

                     builder.Property(d => d.FullName)
                            .IsRequired()
                            .HasColumnType("nvarchar(100)");

                     builder.Property(d => d.Specialty)
                            .IsRequired()
                            .HasColumnType("nvarchar(50)");

                     builder.Property(d => d.Email)
                            .IsRequired()
                            .HasColumnType("nvarchar(100)");

              }
       }
}
