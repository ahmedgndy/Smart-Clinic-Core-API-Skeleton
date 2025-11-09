
using Microsoft.EntityFrameworkCore;
using SmartClinic.Models;


namespace SmartClinic.Infrastructure;


public class ClinicDbContext : DbContext
{
    public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
        : base(options)
    {
    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionItem> PrescriptionItems { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicDbContext).Assembly);

        modelBuilder.Entity<Doctor>()
        .HasMany(d => d.Appointments)
        .WithOne(a => a.Doctor)
        .HasForeignKey(a => a.DoctorId)
        .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Patient>()
        .HasMany(p => p.Appointments)
        .WithOne(a => a.Patient)
        .HasForeignKey(a => a.PatientId)
        .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Prescription>()
        .HasMany(p => p.Items)
        .WithOne(i => i.Prescription)
        .HasForeignKey(i => i.PrescriptionId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}

