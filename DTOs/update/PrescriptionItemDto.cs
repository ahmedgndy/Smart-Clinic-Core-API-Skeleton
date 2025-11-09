
namespace SmartClinic.DTOs.Update;

public class PrescriptionItemDto
{
    public Guid MedicationId { get; set; }
    public string Dosage { get; set; }
    public string Instructions { get; set; }
}