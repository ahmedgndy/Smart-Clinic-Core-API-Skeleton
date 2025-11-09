

using SmartClinic.Models;

public class Prescription
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid AppointmentId { get; set; }
    public Appointment Appointment { get; set; }


    // Simple representation of medications inside prescriptions
    public ICollection<PrescriptionItem> Items { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}