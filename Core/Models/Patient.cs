namespace SmartClinic.Core.Models
{
    public class Patient
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }


        public ICollection<Appointment>? Appointments { get; set; } = new List<Appointment>();
        public ICollection<Prescription>? Prescriptions { get; set; } = new List<Prescription>();
    }
}