

using SmartClinic.Models;

public class Prescription
{
    public Guid Id { get; set; }
    public Guid AppointmentId { get; set; }
    public Appointment Appointment { get; set; }


    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }

    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    // Simple representation of medications inside prescriptions
    public ICollection<PrescriptionItem> Items { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}