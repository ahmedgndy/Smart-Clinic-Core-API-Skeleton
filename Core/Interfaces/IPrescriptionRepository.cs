using SmartClinic.Core.Interfaces;
using SmartClinic.Core.Models;

namespace SmartClinic.Core.Interfaces
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        Task<IEnumerable<Prescription>> ListByPatientAsync(Guid patientId);
    }
}