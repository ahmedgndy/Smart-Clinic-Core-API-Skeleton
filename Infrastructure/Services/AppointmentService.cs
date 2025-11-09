

using Microsoft.EntityFrameworkCore;
using SmartClinic.DTOs.create;
using SmartClinic.DTOs.Update;
using SmartClinic.Enums;
using SmartClinic.Interfaces;

namespace SmartClinic.Infrastructure.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repo;
        private readonly ClinicDbContext _db;

        public AppointmentService(IAppointmentRepository repo, ClinicDbContext db)
        {
            _repo = repo;
            _db = db;
        }

        public async Task<Appointment> CreateAsync(AppointmentCreateDto dto)
        {
            if (dto.StartAt <= DateTime.UtcNow)
                throw new ArgumentException("Appointment time must be in the future.");

            var doctor = await _db.Doctors.FindAsync(dto.DoctorId)
                ?? throw new ArgumentException("Doctor not found.");

            var patient = await _db.Patients.FindAsync(dto.PatientId)
                ?? throw new ArgumentException("Patient not found.");

            var endAt = dto.StartAt.AddMinutes(dto.DurationMinutes);

            bool overlap = await _db.Appointments
                .Where(a => a.DoctorId == dto.DoctorId && a.Id != Guid.Empty)
                .Where(a => a.Status != AppointmentStatus.Cancelled && a.Status != AppointmentStatus.Rejected)
                .AnyAsync(a => (dto.StartAt < a.StartAt.AddMinutes(a.DurationMinutes)) && (endAt > a.StartAt));

            if (overlap) throw new InvalidOperationException("Doctor has another appointment in that time range.");

            var appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
                StartAt = dto.StartAt,
                DurationMinutes = dto.DurationMinutes,
                Status = AppointmentStatus.Pending
            };

            await _repo.AddAsync(appointment);
            return appointment;
        }

        public async Task<Appointment> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);

        public async Task<IEnumerable<Appointment>> ListByDoctorAsync(Guid doctorId) => await _repo.ListByDoctorAsync(doctorId);

        public async Task<IEnumerable<Appointment>> ListByPatientAsync(Guid patientId) => await _repo.ListByPatientAsync(patientId);

        public async Task<Appointment> UpdateAsync(Guid id, AppointmentUpdateDto dto)
        {
            var ap = await _db.Appointments.FindAsync(id) ?? throw new ArgumentException("Appointment not found.");

            if (dto.StartAt != ap.StartAt)
            {
                if (dto.StartAt <= DateTime.UtcNow) throw new ArgumentException("Appointment time must be in the future.");

                var duration = dto.DurationMinutes;

                var endAt = dto.StartAt.AddMinutes(duration);

                bool overlap = await _db.Appointments
                    .Where(a => a.DoctorId == ap.DoctorId && a.Id != id)
                    .Where(a => a.Status != AppointmentStatus.Cancelled && a.Status != AppointmentStatus.Rejected)
                    .AnyAsync(a => (dto.StartAt < a.StartAt.AddMinutes(a.DurationMinutes)) && (endAt > a.StartAt));

                if (overlap) throw new InvalidOperationException("Doctor has another appointment in that time range.");

                ap.StartAt = dto.StartAt;
                ap.DurationMinutes = duration;
            }

            if (!string.IsNullOrEmpty(dto.Status) && Enum.TryParse<AppointmentStatus>(dto.Status, true, out var st))
                ap.Status = st;

            await _repo.UpdateAsync(ap);
            return ap;
        }

        public async Task CancelAsync(Guid id)
        {
            var ap = await _db.Appointments.FindAsync(id) ?? throw new ArgumentException("Appointment not found.");
            ap.Status = AppointmentStatus.Cancelled;
            await _repo.UpdateAsync(ap);
        }

        public async Task ApproveAsync(Guid id)
        {
            var ap = await _db.Appointments.FindAsync(id) ?? throw new ArgumentException("Appointment not found.");
            ap.Status = AppointmentStatus.Approved;
            await _repo.UpdateAsync(ap);
        }

        public async Task RejectAsync(Guid id)
        {
            var ap = await _db.Appointments.FindAsync(id) ?? throw new ArgumentException("Appointment not found.");
            ap.Status = AppointmentStatus.Rejected;
            await _repo.UpdateAsync(ap);
        }


    }
}
