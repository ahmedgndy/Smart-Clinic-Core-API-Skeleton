using System.Text.Json.Serialization;
using SmartClinic.Core.Models;


public class PrescriptionItem
{
    [JsonIgnore]

    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PrescriptionId { get; set; }
    public Prescription Prescription { get; set; } = new Prescription();


    public Guid MedicationId { get; set; }
    public Medication Medication { get; set; } = new Medication();


    public string Dosage { get; set; }
    public string Instructions { get; set; } = " ";
}