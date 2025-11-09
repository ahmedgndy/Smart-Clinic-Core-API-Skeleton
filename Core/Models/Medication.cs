namespace SmartClinic.Core.Models;


public class Medication
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
}
