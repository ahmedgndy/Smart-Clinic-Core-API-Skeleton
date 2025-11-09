using SmartClinic.DTOs.create;
using SmartClinic.DTOs.Update;

namespace SmartClinic.Interfaces;

public interface IAppointmentService
{
    Task<Appointment> CreateAsync(AppointmentCreateDto dto);
    Task<Appointment> GetByIdAsync(Guid id);
    Task<IEnumerable<Appointment>> ListByDoctorAsync(Guid doctorId);
    Task<IEnumerable<Appointment>> ListByPatientAsync(Guid patientId);
    Task<Appointment> UpdateAsync(Guid id, AppointmentUpdateDto dto);
    Task CancelAsync(Guid id);
}
