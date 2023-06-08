using DocSeeker.API.MedicalAppointment.Domain.Models;

namespace DocSeeker.API.MedicalAppointment.Domain.Repositories;

public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> ListAsync();
    Task AddAsync(Appointment appointment);
    Task<Appointment> FindByIdAsync(int id);
    void Update(Appointment appointment);
    void Remove(Appointment appointment);
}