using Docseeker.API.Profiles.Domain.Models;

namespace Docseeker.API.Profiles.Domain.Repositories;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> ListAsync(); // IEnumerable is a collection of objects that can be individually accessed by index
    Task AddAsync(Doctor doctor); // Task represents an asynchronous operation that can return a value, AddAsync is a method that adds a doctor
    Task<Doctor> FindByIdAsync(int id); // FindByIdAsync is a method that finds a doctor by id
    void Update(Doctor doctor); // Update is a method that updates a doctor
    void Remove(Doctor doctor); // Remove is a method that removes a doctor
}