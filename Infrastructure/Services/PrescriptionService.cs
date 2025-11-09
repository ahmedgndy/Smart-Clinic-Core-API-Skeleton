
using Microsoft.EntityFrameworkCore;
using SmartClinic.DTOs.Create;
using SmartClinic.Enums;
using SmartClinic.Interfaces;

namespace SmartClinic.Infrastructure.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _repo;
        private readonly ClinicDbContext _db;

        public PrescriptionService(IPrescriptionRepository repo, ClinicDbContext db)
        {
            _repo = repo;
            _db = db;
        }

        public async Task<Prescription> CreateAsync(PrescriptionCreateDto dto)
        {
            var ap = await _db.Appointments.Include(a => a.Patient).FirstOrDefaultAsync(a => a.Id == dto.AppointmentId)
                ?? throw new ArgumentException("Appointment not found.");

            if (ap.Status != AppointmentStatus.Completed && ap.Status != AppointmentStatus.Approved)
                throw new InvalidOperationException("Prescription can only be created after a completed or approved appointment.");

            var prescription = new Prescription
            {
                Id = Guid.NewGuid(),
                AppointmentId = ap.Id,
                DoctorId = ap.DoctorId,
                PatientId = ap.PatientId,
                Notes = dto.Notes,
                CreatedAt = DateTime.UtcNow,
                Items = dto.Items?.Select(i => new PrescriptionItem
                {
                    Id = Guid.NewGuid(),
                    MedicationId = i.MedicationId,
                    Dosage = i.Dosage,
                    Instructions = i.Instructions
                }).ToList()
            };

            await _repo.AddAsync(prescription);
            return prescription;
        }

        public async Task<Prescription> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);

        public async Task<IEnumerable<Prescription>> ListByPatientAsync(Guid patientId) => await _repo.ListByPatientAsync(patientId);
    }
}
