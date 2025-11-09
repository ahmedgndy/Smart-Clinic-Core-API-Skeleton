namespace SmartClinic.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }


        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}