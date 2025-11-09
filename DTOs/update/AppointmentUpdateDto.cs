
namespace SmartClinic.DTOs.Update;

public class AppointmentUpdateDto
{
public DateTime StartAt { get; set; }
public int DurationMinutes { get; set; } = 30;
public string Status { get; set; }
}
