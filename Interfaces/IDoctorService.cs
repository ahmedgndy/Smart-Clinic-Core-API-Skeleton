using SmartClinic.Models;

namespace SmartClinic.Core.Interfaces
{
    public interface IDoctorService
    {
        Task<Doctor> CreateAsync(Doctor doctor);
        Task<Doctor> GetByIdAsync(Guid id);
        Task<IEnumerable<Doctor>> ListAsync();
        Task<Doctor> UpdateAsync(Guid id, Doctor doctor);
        Task DeleteAsync(Guid id);
    }
}