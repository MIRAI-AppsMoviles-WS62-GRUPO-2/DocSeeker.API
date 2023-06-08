using DocSeeker.API.Prescriptions.Domain.Models;

namespace DocSeeker.API.Prescriptions.Domain.Repositories;

public interface IPrescriptionRepository
{
    Task<IEnumerable<Prescription>> ListAsync();
    Task<IEnumerable<Prescription>> FindByDoctorIdAsync(int doctorId);
    Task<Prescription> FindByIdAsync(int prescriptionId);
    Task AddAsync(Prescription prescription);
    void Update(Prescription prescription);
    void Remove(Prescription prescription);
}