using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Prescriptions.Domain.Services.Communication;

namespace DocSeeker.API.Prescriptions.Domain.Services;

public interface IDoctorService
{
    Task<IEnumerable<Doctor>> ListAsync();
    Task<DoctorResponse> SaveAsync(Doctor doctor);
    Task<DoctorResponse> UpdateAsync(int id, Doctor doctor);
    Task<DoctorResponse> DeleteAsync(int id);
}