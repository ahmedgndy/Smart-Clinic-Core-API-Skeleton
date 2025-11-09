using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Clinic_Core_APi.Models;

namespace Smart_Clinic_Core_APi.Infrastructure.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FullName)
                   .IsRequired()
                   .HasColumnType("varchar(100)");



            builder.Property(p => p.DateOfBirth)
                   .IsRequired()
                   .HasColumnType("datetime");

            builder.Property(p => p.Email)
                   .IsRequired()
                   .HasColumnType("varchar(100)");


        }
    }
}
