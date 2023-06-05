using DocSeeker.API.Profiles.Domain.Models;
using DocSeeker.API.Profiles.Domain.Services.Communication;

namespace DocSeeker.API.Profiles.Domain.Services;

public interface IDoctorService
{
    Task<IEnumerable<Doctor>> ListAsync();
    Task<DoctorResponse> SaveAsync(Doctor doctor);
    Task<DoctorResponse> UpdateAsync(int id, Doctor doctor);
    Task<DoctorResponse> DeleteAsync(int id);
}