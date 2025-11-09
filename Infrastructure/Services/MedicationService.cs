using SmartClinic.Core.Interfaces;
using SmartClinic.Core.Models;



namespace SmartClinic.Infrastructure.Services
{

    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository _repo;
        public MedicationService(IMedicationRepository repo) { _repo = repo; }

        public async Task<Medication> CreateAsync(Medication medication)
        {
            medication.Id = Guid.NewGuid();
            await _repo.AddAsync(medication);
            return medication;
        }

        public async Task DeleteAsync(Guid id) => await _repo.DeleteAsync(id);

        public async Task<Medication> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);

        public async Task<IEnumerable<Medication>> ListAsync() => await _repo.ListAsync();

        public async Task<Medication> UpdateAsync(Guid id, Medication medication)
        {
            var existing = await _repo.GetByIdAsync(id) ?? throw new ArgumentException("Medication not found");
            existing.Name = medication.Name;
            existing.Description = medication.Description;
            await _repo.UpdateAsync(existing);
            return existing;
        }
    }

}