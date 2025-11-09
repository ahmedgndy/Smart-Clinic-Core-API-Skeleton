namespace SmartClinic.DTOs.create
{
    public class AppointmentCreateDto
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime StartAt { get; set; }
        public int DurationMinutes { get; set; } = 30;
    }
}