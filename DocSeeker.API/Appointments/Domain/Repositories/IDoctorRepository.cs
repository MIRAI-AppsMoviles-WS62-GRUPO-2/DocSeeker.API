using DocSeeker.API.Appointments.Domain.Models;

namespace DocSeeker.API.Appointments.Domain.Repositories;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> ListAsync();
    Task AddAsync(Doctor doctor);
    void Update(Doctor doctor);
    void Remove(Doctor doctor);
}