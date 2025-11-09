using SmartClinic.Core.Interfaces;
using SmartClinic.Models;

namespace SmartClinic.Infrastructure.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repo;
        public DoctorService(IDoctorRepository repo) { _repo = repo; }

        public async Task<Doctor> CreateAsync(Doctor doctor)
        {
            doctor.Id = Guid.NewGuid();
            await _repo.AddAsync(doctor);
            return doctor;
        }

        public async Task DeleteAsync(Guid id) => await _repo.DeleteAsync(id);

        public async Task<Doctor> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);

        public async Task<IEnumerable<Doctor>> ListAsync() => await _repo.ListAsync();

        public async Task<Doctor> UpdateAsync(Guid id, Doctor doctor)
        {
            var existing = await _repo.GetByIdAsync(id) ?? throw new ArgumentException("Doctor not found");
            existing.FullName = doctor.FullName;
            existing.Email = doctor.Email;
            existing.Specialty = doctor.Specialty;
            await _repo.UpdateAsync(existing);
            return existing;
        }
    }
}