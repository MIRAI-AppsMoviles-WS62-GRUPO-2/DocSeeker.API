using Docseeker.API.Profiles.Domain.Models;
using Docseeker.API.Profiles.Domain.Services.Communication;

namespace Docseeker.API.Profiles.Domain.Services;

public interface IPatientService
{
    Task<IEnumerable<Patient>> ListAsync(); // IEnumerable is a collection of objects that can be individually accessed by index
    Task<PatientResponse> SaveAsync(Patient patient); // Task represents an asynchronous operation that can return a value, SaveAsync is a method that saves a patient
    Task<PatientResponse> UpdateAsync(int id, Patient patient); // UpdateAsync is a method that updates a patient
    Task<PatientResponse> DeleteAsync(int id); // DeleteAsync is a method that deletes a patient
}