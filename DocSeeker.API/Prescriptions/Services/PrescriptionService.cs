using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Prescriptions.Domain.Repositories;
using DocSeeker.API.Prescriptions.Domain.Services;
using DocSeeker.API.Prescriptions.Domain.Services.Communication;
using DocSeeker.API.Shared.Domain.Repositories;

namespace DocSeeker.API.Prescriptions.Services;

public class PrescriptionService: IPrescriptionService
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository, IUnitOfWork unitOfWork)
    {
        _prescriptionRepository = prescriptionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Prescription>> ListAsync()
    {
        return await _prescriptionRepository.ListAsync();
    }

    public async Task<IEnumerable<Prescription>> ListByDoctorIdAsync(int doctorId)
    {
        return await _prescriptionRepository.FindByDoctorIdAsync(doctorId);
    }

    public async Task<PrescriptionResponse> SaveAsync(Prescription prescription)
    {
        // I'm not sure if call IDoctorRepository to validate that doctorId is right.
        
        try
        {
            await _prescriptionRepository.AddAsync(prescription); // connection
            await _unitOfWork.CompleteAsync();

            return new PrescriptionResponse(prescription);
        }
        catch (Exception e)
        {
            return new PrescriptionResponse($"An error occurred while saving the category: {e.Message}");
        }
    }

    public async Task<PrescriptionResponse> UpdateAsync(int id, Prescription prescription)
    {
        var existingPrescription = await _prescriptionRepository.FindByIdAsync(id);

        if (existingPrescription == null)
            return new PrescriptionResponse("Prescription not found.");

        existingPrescription.State = prescription.State;
        existingPrescription.Recommendation = prescription.Recommendation;
        existingPrescription.Medicines = prescription.Medicines;// I'm not sure of this

        try
        {
            _prescriptionRepository.Update(existingPrescription);
            await _unitOfWork.CompleteAsync();

            return new PrescriptionResponse(existingPrescription);
        }
        catch (Exception e)
        {
            return new PrescriptionResponse($"An error occurred while updating the category: {e.Message}");
        }
    }

    public async Task<PrescriptionResponse> DeleteAsync(int id)
    {
        var existingPrescription = await _prescriptionRepository.FindByIdAsync(id);

        if (existingPrescription == null)
            return new PrescriptionResponse("Prescription not found.");

        try
        {
            _prescriptionRepository.Remove(existingPrescription);
            await _unitOfWork.CompleteAsync();

            return new PrescriptionResponse(existingPrescription);
        }
        catch (Exception e)
        {
            return new PrescriptionResponse($"An error occurred while deleting the category: {e.Message}");
        }
    }
}