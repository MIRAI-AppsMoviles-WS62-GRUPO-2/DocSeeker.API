using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Prescriptions.Domain.Repositories;
using DocSeeker.API.Prescriptions.Domain.Services;
using DocSeeker.API.Prescriptions.Domain.Services.Communication;
using DocSeeker.API.Shared.Domain.Repositories;

namespace DocSeeker.API.Prescriptions.Services;

public class MedicineService: IMedicineService
{
    private readonly IMedicineRepository _medicineRepository;
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MedicineService(IMedicineRepository medicineRepository, IPrescriptionRepository prescriptionRepository, IUnitOfWork unitOfWork)
    {
        _medicineRepository = medicineRepository;
        _prescriptionRepository = prescriptionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Medicine>> ListAsync()
    {
        return await _medicineRepository.ListAsync();
    }

    public async Task<IEnumerable<Medicine>> ListByPrescriptionIdAsync(int prescriptionId)
    {
        return await _medicineRepository.FindByPrescriptionIdAsync(prescriptionId);
    }

    public async Task<MedicineResponse> SaveAsync(Medicine medicine)
    {
        // Validate existence of assigned prescription
        
        var existingPrescription = await _prescriptionRepository.FindByIdAsync(medicine.PrescriptionId);

        if (existingPrescription == null)
            return new MedicineResponse("Invalid Prescription.");
        
        // Perform adding
        
        try
        {
            await _medicineRepository.AddAsync(medicine);
            await _unitOfWork.CompleteAsync();
            
            return new MedicineResponse(medicine);
        }
        catch (Exception e)
        {
            return new MedicineResponse($"An error occurred while updating the category: {e.Message}");
        }
    }

    public async Task<MedicineResponse> UpdateAsync(int id, Medicine medicine)
    {
        var existingMedicine = await _medicineRepository.FindByIdAsync(id);

        if (existingMedicine == null)
            return new MedicineResponse("Medicine not found.");

        var existingPrescription = await _prescriptionRepository.FindByIdAsync(medicine.PrescriptionId);

        if (existingPrescription == null)
            return new MedicineResponse("Invalid prescription.");
        
        existingMedicine.Name = medicine.Name;
        existingMedicine.Dose = medicine.Dose;
        existingMedicine.Period = medicine.Period;
        existingMedicine.RouteOfAdministration = medicine.RouteOfAdministration;
        existingMedicine.Duration = medicine.Duration;
        existingMedicine.SpecialInstructions = medicine.SpecialInstructions;

        try
        {
            _medicineRepository.Update(existingMedicine);
            await _unitOfWork.CompleteAsync();
            
            return new MedicineResponse(existingMedicine);
        }
        catch (Exception e)
        {
            return new MedicineResponse($"An error occurred while updating the category: {e.Message}");
        }
    }

    public async Task<MedicineResponse> DeleteAsync(int id)
    {
        var existingMedicine = await _medicineRepository.FindByIdAsync(id);

        if (existingMedicine == null)
            return new MedicineResponse("Medicine not found.");

        try
        {
            _medicineRepository.Remove(existingMedicine);
            await _unitOfWork.CompleteAsync();
            
            return new MedicineResponse(existingMedicine);
        }
        catch (Exception e)
        {
            return new MedicineResponse($"An error occurred while deleting the category: {e.Message}");
        }
    }
}