using System.Text.Json.Serialization;

namespace SmartClinic.Core.Models;


public class Medication
{
    [JsonIgnore]

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}
