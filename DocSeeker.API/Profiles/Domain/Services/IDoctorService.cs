using DocSeeker.API.Profiles.Domain.Models;
using DocSeeker.API.Profiles.Domain.Services.Communication;


namespace DocSeeker.API.Profiles.Domain.Services;

public interface IDoctorService
{
    Task<IEnumerable<Doctor>> ListAsync(); // IEnumerable is a collection of objects that can be individually accessed by index
    Task<DoctorResponse> SaveAsync(Doctor doctor); // Task represents an asynchronous operation that can return a value, SaveAsync is a method that saves a doctor
    Task<DoctorResponse> UpdateAsync(int id, Doctor doctor); // UpdateAsync is a method that updates a doctor
    Task<DoctorResponse> DeleteAsync(int id); // DeleteAsync is a method that deletes a doctor
}