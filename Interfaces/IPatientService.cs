namespace SmartClinic.Core.Interfaces
{
    public interface IPatientService
    {
        Task<Patient> CreateAsync(Patient patient);
        Task<Patient> GetByIdAsync(Guid id);
        Task<IEnumerable<Patient>> ListAsync();
        Task<Patient> UpdateAsync(Guid id, Patient patient);
        Task DeleteAsync(Guid id);
    }
}