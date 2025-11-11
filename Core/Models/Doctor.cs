
using System.Text.Json.Serialization;

namespace SmartClinic.Core.Models
{
    public class Doctor
    {
        [JsonIgnore]

        public Guid Id { get; set; } = Guid.NewGuid();

        public string FullName { get; set; }
        public string Specialty { get; set; }
        public string Email { get; set; }
        // Additional fields (phone, bio, etc.)

        [JsonIgnore]
        public ICollection<Appointment>? Appointments { get; set; }

    }
}