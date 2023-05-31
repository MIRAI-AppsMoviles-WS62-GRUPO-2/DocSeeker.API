using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Prescriptions.Domain.Services.Communication;

namespace DocSeeker.API.Prescriptions.Domain.Services;

public interface IMedicineService
{
    Task<IEnumerable<Medicine>> ListAsync();
    Task<IEnumerable<Medicine>> ListByPrescriptionIdAsync(int prescriptionId);
    Task<MedicineResponse> SaveAsync(Medicine medicine);
    Task<MedicineResponse> UpdateAsync(int id, Medicine medicine);
    Task<MedicineResponse> DeleteAsync(int id);
}