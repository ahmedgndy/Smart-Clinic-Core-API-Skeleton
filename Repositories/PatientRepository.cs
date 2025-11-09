
using Microsoft.EntityFrameworkCore;
using SmartClinic.Models;

namespace SmartClinic.Infrastructure.Repositories
{

    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(ClinicDbContext db) : base(db) { }

        public override async Task<Patient> GetByIdAsync(Guid id)
        {
            return await _db.Set<Patient>().Include(p => p.Appointments).FirstOrDefaultAsync(p => p.Id == id);
        }
    }

}