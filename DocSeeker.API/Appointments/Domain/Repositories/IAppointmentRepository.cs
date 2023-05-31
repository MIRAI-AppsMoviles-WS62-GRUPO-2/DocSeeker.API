using DocSeeker.API.Appointments.Domain.Models;

namespace DocSeeker.API.Appointments.Domain.Repositories;

public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> ListAsync();
    Task AddAsync(Appointment appointment);
    Task<Appointment> FindByIdAsync(int appointmentId);
    Task<Appointment> FindByDateAsync(DateTime date);
    Task<IEnumerable<Appointment>> FindByPatientIdAsync(int patientId);
    Task<IEnumerable<Appointment>> FindByDoctorIdAsync(int doctorId);
    void Update(Appointment appointment);
    void Remove(Appointment appointment);
}