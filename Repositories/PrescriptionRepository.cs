

using Microsoft.EntityFrameworkCore;

namespace SmartClinic.Infrastructure.Repositories
{
    public class PrescriptionRepository : Repository<Prescription>, IPrescriptionRepository
    {
        private readonly ClinicDbContext _context;
        public PrescriptionRepository(ClinicDbContext db) : base(db)
        {
            _context = db;
        }

        public override async Task<Prescription> GetByIdAsync(Guid id)
        {
            return await _context.Prescriptions
                .Include(p => p.Items)
                .ThenInclude(i => i.Medication)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Prescription>> ListByPatientAsync(Guid patientId)
        {
            return await _context.Prescriptions
                .Where(p => p.PatientId == patientId)
                .Include(p => p.Items).ThenInclude(i => i.Medication)
                .ToListAsync();
        }
    }


}
