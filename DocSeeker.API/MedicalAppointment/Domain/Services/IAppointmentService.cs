using DocSeeker.API.MedicalAppointment.Domain.Models;
using DocSeeker.API.MedicalAppointment.Domain.Services.Communication;

namespace DocSeeker.API.MedicalAppointment.Domain.Services;

public interface IAppointmentService
{
    Task<IEnumerable<Appointment>> ListAsync();
    Task<AppointmentResponse> SaveAsync(Appointment appointment);
    Task<AppointmentResponse> UpdateAsync(int id, Appointment appointment);
    Task<AppointmentResponse> DeleteAsync(int id);
}