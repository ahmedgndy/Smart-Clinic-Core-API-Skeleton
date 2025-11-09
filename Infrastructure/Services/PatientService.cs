using SmartClinic.Interfaces;
using SmartClinic.Models;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _repo;
    public PatientService(IPatientRepository repo) { _repo = repo; }

    public async Task<Patient> CreateAsync(Patient patient)
    {
        patient.Id = Guid.NewGuid();
        await _repo.AddAsync(patient);
        return patient;
    }

    public async Task DeleteAsync(Guid id) => await _repo.DeleteAsync(id);

    public async Task<Patient> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);

    public async Task<IEnumerable<Patient>> ListAsync() => await _repo.ListAsync();

    public async Task<Patient> UpdateAsync(Guid id, Patient patient)
    {
        var existing = await _repo.GetByIdAsync(id) ?? throw new ArgumentException("Patient not found");
        existing.FullName = patient.FullName;
        existing.Email = patient.Email;
        existing.DateOfBirth = patient.DateOfBirth;
        await _repo.UpdateAsync(existing);
        return existing;
    }
}
