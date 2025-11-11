using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartClinic.Core.Models;

namespace SmartClinic.Infrastructure.Configurations
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

                     builder
                          .HasMany(p => p.Items)
                          .WithOne(i => i.Prescription)
                          .HasForeignKey(i => i.PrescriptionId)
                          .OnDelete(DeleteBehavior.Cascade);
              }
       }
}
