using DocSeeker.API.Profile.Domain.Models;

namespace DocSeeker.API.Profile.Domain.Repositories;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> ListAsync();
    Task AddAsync(Doctor doctor);
    void Update(Doctor doctor);
    void Remove(Doctor doctor);
}