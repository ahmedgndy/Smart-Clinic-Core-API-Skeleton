
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

        // fk to a user
        public Guid UserId { get; set; }
        public User? User { get; set; }

        [JsonIgnore]
        public ICollection<Appointment>? Appointments { get; set; }

    }
}