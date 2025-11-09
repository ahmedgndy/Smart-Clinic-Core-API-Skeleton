using SmartClinic.DTOs.Create;

namespace SmartClinic.Interfaces
{
    public interface IPrescriptionService
    {
        Task<Prescription> CreateAsync(PrescriptionCreateDto dto);
        Task<Prescription> GetByIdAsync(Guid id);
        Task<IEnumerable<Prescription>> ListByPatientAsync(Guid patientId);
    }
}