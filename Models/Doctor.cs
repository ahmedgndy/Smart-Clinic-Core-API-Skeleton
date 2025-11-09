
namespace SmartClinic.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Specialty { get; set; }
        public string Email { get; set; }
        // Additional fields (phone, bio, etc.)


        public ICollection<Appointment> Appointments { get; set; }

    }
}