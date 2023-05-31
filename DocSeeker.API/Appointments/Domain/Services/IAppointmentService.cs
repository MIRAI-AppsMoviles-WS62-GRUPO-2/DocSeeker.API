using DocSeeker.API.Appointments.Domain.Models;
using DocSeeker.API.Appointments.Domain.Services.Communication;

namespace DocSeeker.API.Appointments.Domain.Services;


public interface IAppointmentService
{
    Task<IEnumerable<Appointment>> ListAsync();
    Task<IEnumerable<Appointment>> ListByPatientIdAsync(int patientId);
    Task<IEnumerable<Appointment>> ListByDoctorIdAsync(int doctorId);
    Task<AppointmentResponse> SaveAsync(Appointment appointment);
    Task<AppointmentResponse> UpdateAsync(int id, Appointment appointment);
    Task<AppointmentResponse> DeleteAsync(int id);
}