using DocSeeker.API.Profiles.Domain.Models;

namespace DocSeeker.API.Profiles.Domain.Repositories;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> ListAsync();
    Task AddAsync(Doctor doctor);
    void Update(Doctor doctor);
    void Remove(Doctor doctor);
}