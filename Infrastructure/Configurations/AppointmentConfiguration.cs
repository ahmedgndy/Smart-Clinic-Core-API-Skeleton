using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartClinic.Core.Models;

namespace SmartClinic.Infrastructure.Configurations
{
       public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
       {
              public void Configure(EntityTypeBuilder<Appointment> builder)
              {
                     builder.HasKey(a => a.Id);

                     builder.Property(a => a.StartAt)
                            .IsRequired()
                            .HasColumnType("datetime");

                     builder.Property(a => a.DurationMinutes)
                            .IsRequired()
                            .HasColumnType("float");


                     builder.Property(a => a.Status)
                            .IsRequired()
                      .HasColumnType("int");

                     builder.Property(a => a.RowVersion)
                      .IsRowVersion();

              }
       }
}
