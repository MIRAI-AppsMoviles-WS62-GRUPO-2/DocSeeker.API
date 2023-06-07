using Docseeker.API.Profiles.Domain.Models;

namespace Docseeker.API.Profiles.Domain.Repositories;

public interface IPatientRepository
{
    Task<IEnumerable<Patient>> ListAsync(); // IEnumerable is a collection of objects that can be individually accessed by index
    Task AddAsync(Patient patient); // Task represents an asynchronous operation that can return a value, AddAsync is a method that adds a patient
    Task<Patient> FindByIdAsync(int id); // FindByIdAsync is a method that finds a patient by id
    void Update(Patient patient); // Update is a method that updates a patient
    void Remove(Patient patient); // Remove is a method that removes a patient
}