using DocSeeker.API.Profile.Domain.Models;
using DocSeeker.API.Profile.Domain.Services.Communication;

namespace DocSeeker.API.Profile.Domain.Services;

public interface IDoctorService
{
    Task<IEnumerable<Doctor>> ListAsync();
    Task<DoctorResponse> SaveAsync(Doctor doctor);
    Task<DoctorResponse> UpdateAsync(int id, Doctor doctor);
    Task<DoctorResponse> DeleteAsync(int id);
}