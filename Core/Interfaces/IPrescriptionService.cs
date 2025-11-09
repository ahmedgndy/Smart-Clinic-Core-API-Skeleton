using SmartClinic.Core.DTOs.Create;
using SmartClinic.Core.Models;


namespace SmartClinic.Core.Interfaces
{
    public interface IPrescriptionService
    {
        Task<Prescription> CreateAsync(PrescriptionCreateDto dto);
        Task<Prescription> GetByIdAsync(Guid id);
        Task<IEnumerable<Prescription>> ListByPatientAsync(Guid patientId);
    }
}