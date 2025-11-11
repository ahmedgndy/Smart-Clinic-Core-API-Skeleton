

using System.Text.Json.Serialization;
using SmartClinic.Core.Models;

namespace SmartClinic.Core.Models
{
    public class Prescription
    {
        [JsonIgnore]

        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = new Appointment();

        public List<PrescriptionItem> Items { get; set; } = new();
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}