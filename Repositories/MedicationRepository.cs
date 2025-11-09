


using SmartClinic.Interfaces;
using SmartClinic.Models;
namespace SmartClinic.Infrastructure.Repositories
{
    public class MedicationRepository : Repository<Medication>, IMedicationRepository
    {
        public MedicationRepository(ClinicDbContext db) : base(db) { }
    }

}