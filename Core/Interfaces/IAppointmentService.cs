

using SmartClinic.Core.DTOs.create;
using SmartClinic.Core.DTOs.Update;
using SmartClinic.Core.Models;

namespace SmartClinic.Core.Interfaces{

public interface IAppointmentService
{
    Task<Appointment> CreateAsync(AppointmentCreateDto dto);
    Task<Appointment> GetByIdAsync(Guid id);
    Task<IEnumerable<Appointment>> ListByDoctorAsync(Guid doctorId);
    Task<IEnumerable<Appointment>> ListByPatientAsync(Guid patientId);
    Task<Appointment> UpdateAsync(Guid id, AppointmentUpdateDto dto);
    Task CancelAsync(Guid id);
    Task ApproveAsync(Guid id);
    Task RejectAsync(Guid id);

}
}