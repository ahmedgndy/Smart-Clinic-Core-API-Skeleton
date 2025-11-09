
using Microsoft.EntityFrameworkCore;
using SmartClinic.Core.DTOs.Create;
using SmartClinic.Core.Enums;
using SmartClinic.Core.Interfaces;
using SmartClinic.Core.Models;


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
