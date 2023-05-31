using DocSeeker.API.Appointments.Domain.Models;
using DocSeeker.API.Appointments.Domain.Services.Communication;

namespace DocSeeker.API.Appointments.Domain.Services;

public interface IPatientService
{
    Task<IEnumerable<Patient>> ListAsync();
    Task<PatientResponse> SaveAsync(Patient doctor);
    Task<PatientResponse> UpdateAsync(int id, Patient doctor);
    Task<PatientResponse> DeleteAsync(int id);
}