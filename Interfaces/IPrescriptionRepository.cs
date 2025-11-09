using SmartClinic.Interfaces;

public interface IPrescriptionRepository : IRepository<Prescription>
{
    Task<IEnumerable<Prescription>> ListByPatientAsync(Guid patientId);
}