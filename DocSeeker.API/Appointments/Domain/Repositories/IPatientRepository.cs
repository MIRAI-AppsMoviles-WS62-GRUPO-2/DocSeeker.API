using DocSeeker.API.Appointments.Domain.Models;

namespace DocSeeker.API.Appointments.Domain.Repositories;

public interface IPatientRepository
{
    Task<IEnumerable<Patient>> ListAsync();
    Task AddAsync(Patient patient);
    Task<Patient> FindByIdAsync(int id);
    void Update(Patient patient);
    void Remove(Patient patient);
}