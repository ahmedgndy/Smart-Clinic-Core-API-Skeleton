
using Microsoft.EntityFrameworkCore;
using SmartClinic.Core.Interfaces;
using SmartClinic.Models;

namespace SmartClinic.Infrastructure.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ClinicDbContext db) : base(db) { }

        public override async Task<Doctor> GetByIdAsync(Guid id)
        {
            return await _db.Set<Doctor>().Include(d => d.Appointments).FirstOrDefaultAsync(d => d.Id == id);
        }
    }

    public interface IDoctorRepository : IRepository<Doctor> { }

    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(ClinicDbContext db) : base(db) { }

        public override async Task<Patient> GetByIdAsync(Guid id)
        {
            return await _db.Set<Patient>().Include(p => p.Appointments).FirstOrDefaultAsync(p => p.Id == id);
        }
    }

    public interface IPatientRepository : IRepository<Patient> { }

    public class MedicationRepository : Repository<Medication>, IMedicationRepository
    {
        public MedicationRepository(ClinicDbContext db) : base(db) { }
    }

    public interface IMedicationRepository : IRepository<Medication> { }
}
