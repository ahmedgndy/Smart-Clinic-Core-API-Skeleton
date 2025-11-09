

using SmartClinic.Models;

namespace SmartClinic.Core.Interfaces
{
    public interface IMedicationService
    {
        Task<Medication> CreateAsync(Medication medication);
        Task<Medication> GetByIdAsync(Guid id);
        Task<IEnumerable<Medication>> ListAsync();
        Task<Medication> UpdateAsync(Guid id, Medication medication);
        Task DeleteAsync(Guid id);
    }
}
