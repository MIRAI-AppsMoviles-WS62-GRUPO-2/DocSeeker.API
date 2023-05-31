using DocSeeker.API.Prescriptions.Domain.Models;

namespace DocSeeker.API.Prescriptions.Domain.Repositories;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> ListAsync();
    Task AddAsync(Doctor doctor);
    void Update(Doctor doctor);
    void Remove(Doctor doctor);
}