using DocSeeker.API.Prescriptions.Domain.Models;

namespace DocSeeker.API.Prescriptions.Domain.Repositories;

public interface IMedicineRepository
{
    Task<IEnumerable<Medicine>> ListAsync();
    Task<IEnumerable<Medicine>> FindByPrescriptionIdAsync(int prescriptionId);
    Task<Medicine> FindByIdAsync(int medicineId);
    Task AddAsync(Medicine medicine);
    void Update(Medicine medicine);
    void Remove(Medicine medicine);
}