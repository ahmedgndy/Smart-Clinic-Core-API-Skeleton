
using SmartClinic.DTOs.Update;

namespace SmartClinic.DTOs.Create;


public class PrescriptionCreateDto
{
    public Guid AppointmentId { get; set; }
    public IEnumerable<PrescriptionItemDto> Items { get; set; }
    public string Notes { get; set; }
}