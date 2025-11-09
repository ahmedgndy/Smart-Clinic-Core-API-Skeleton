
using Microsoft.EntityFrameworkCore;
using SmartClinic.Core.Interfaces;
using SmartClinic.Core.Models;

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

}
