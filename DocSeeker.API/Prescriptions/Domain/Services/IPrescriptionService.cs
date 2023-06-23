using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Prescriptions.Domain.Services.Communication;

namespace DocSeeker.API.Prescriptions.Domain.Services;

/*
 * This Service layer will interact with Persistence layer, that's why we use Tasks
 * Because we waited data from database.
 * We use Task beside Async because we use an interface not class.
 * Later we use Async when we use a class
 */
public interface IPrescriptionService
{
    /*
     * We use IEnumerable because we don't know if we get a list, array, etc.
     * We only know we will get an enumerable thing.
     */
    Task<IEnumerable<Prescription>> ListAsync();
    //Task<IEnumerable<Prescription>> ListByDoctorIdAsync(int doctorId);
    Task<PrescriptionResponse> SaveAsync(Prescription prescription);
    Task<PrescriptionResponse> UpdateAsync(int id, Prescription prescription);
    Task<PrescriptionResponse> DeleteAsync(int id);
}