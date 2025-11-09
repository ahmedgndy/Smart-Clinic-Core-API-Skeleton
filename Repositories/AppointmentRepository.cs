

using Microsoft.EntityFrameworkCore;



namespace SmartClinic.Infrastructure.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly ClinicDbContext _context;
        public AppointmentRepository(ClinicDbContext db) : base(db)
        {
            _context = db;
        }

        public async Task<IEnumerable<Appointment>> ListByDoctorAsync(Guid doctorId)
        {
            return await _context.Appointments
                .Where(a => a.DoctorId == doctorId)
                .Include(a => a.Patient)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> ListByPatientAsync(Guid patientId)
        {
            return await _context.Appointments
                .Where(a => a.PatientId == patientId)
                .Include(a => a.Doctor)
                .ToListAsync();
        }

        public override async Task<Appointment> GetByIdAsync(Guid id)
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescription).ThenInclude(p => p.Items)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

    }


}
