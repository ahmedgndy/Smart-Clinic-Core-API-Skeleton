using SmartClinic.Core.Models;


public class PrescriptionItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PrescriptionId { get; set; }
    public Prescription Prescription { get; set; }


    public Guid MedicationId { get; set; }
    public Medication Medication { get; set; }


    public string Dosage { get; set; }
    public string Instructions { get; set; }
}