using Smart_Clinic_Core_APi.Enums;
using Smart_Clinic_Core_APi.Models;

public class Appointment
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }


    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }


    public DateTime StartAt { get; set; }
    public int DurationMinutes { get; set; } = 30; // default
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;


    public Prescription Prescription { get; set; }
}