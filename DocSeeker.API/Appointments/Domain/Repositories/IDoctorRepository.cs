using DocSeeker.API.Appointments.Domain.Models;

namespace DocSeeker.API.Appointments.Domain.Repositories;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> ListAsync();
    Task AddAsync(Doctor doctor);
    Task<Doctor> FindByIdAsync(int id);
    void Update(Doctor doctor);
    void Remove(Doctor doctor);
}