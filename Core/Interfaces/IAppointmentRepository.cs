using SmartClinic.Core.Models;

namespace SmartClinic.Core.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> ListByDoctorAsync(Guid doctorId);
        Task<IEnumerable<Appointment>> ListByPatientAsync(Guid patientId);
    }
}