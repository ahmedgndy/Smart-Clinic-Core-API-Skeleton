

using System.Text.Json.Serialization;
using SmartClinic.Core.Enums;

namespace SmartClinic.Core.Models
{
    public class Appointment
    {
        [JsonIgnore]

        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }


        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }


        public DateTime StartAt { get; set; }
        public int DurationMinutes { get; set; } = 30; // default
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public byte[]? RowVersion { get; set; } // concurrency token    
        public Prescription Prescription { get; set; }
    }
}