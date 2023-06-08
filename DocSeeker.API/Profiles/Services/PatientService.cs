using Docseeker.API.Profiles.Domain.Models;
using Docseeker.API.Profiles.Domain.Repositories;
using Docseeker.API.Profiles.Domain.Services;
using Docseeker.API.Profiles.Domain.Services.Communication;
using DocSeeker.API.Shared.Domain.Repositories;


namespace Docseeker.API.Profiles.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;


    public PatientService(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
    {
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Patient>> ListAsync()
    {
        return await _patientRepository.ListAsync();
    }

    public async Task<PatientResponse> SaveAsync(Patient patient)
    {
        try
        {
            await _patientRepository.AddAsync(patient);
            await _unitOfWork.CompleteAsync();

            return new PatientResponse(patient);
        }
        catch (Exception e)
        {
            return new PatientResponse($"An error occurred when saving the patient: {e.Message}");
        }    
    }

    public async Task<PatientResponse> UpdateAsync(int id, Patient patient)
    {
        var existingPatient = await _patientRepository.FindByIdAsync(id);

        if (existingPatient == null)
            return new PatientResponse("Patient not found.");

        existingPatient.Name = patient.Name;

        try
        {
            _patientRepository.Update(existingPatient);
            await _unitOfWork.CompleteAsync();

            return new PatientResponse(existingPatient);
        }
        catch (Exception e)
        {
            return new PatientResponse($"An error occurred when updating the patient: {e.Message}");
        }
    }

    public async Task<PatientResponse> DeleteAsync(int id)
    {
        var existingPatient = await _patientRepository.FindByIdAsync(id);
        
        if (existingPatient == null)
            return new PatientResponse("Patient not found.");

        try
        {
            _patientRepository.Remove(existingPatient);
            await _unitOfWork.CompleteAsync();
            
            return new PatientResponse(existingPatient);
        }
        catch (Exception e)
        {
            return new PatientResponse($"An error occurred when deleting the patient: {e.Message}");
        }
    }
}