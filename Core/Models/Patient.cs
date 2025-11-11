namespace SmartClinic.Core.Models
{
    public class Patient
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = null!;

        // fk to a user
        public Guid UserId { get; set; } // pleasssse chhhhhage thiiiis shhhhit 
        public User? User { get; set; }

        public ICollection<Appointment>? Appointments { get; set; } = new List<Appointment>();
        public ICollection<Prescription>? Prescriptions { get; set; } = new List<Prescription>();
    }
}