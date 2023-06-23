using DocSeeker.API.Profiles.Interfaces.Internal;

namespace DocSeeker.API.Profiles.Services;

public class ProfileContextFacade : IProfileContextFacade
{
    private readonly DoctorService _doctorService;
    private readonly PatientService _patientService;
    
    public int TotalDoctors()
    {
        return _doctorService.ListAsync().Result.Count();
    }
    
    public int TotalPatients()
    {
        return _patientService.ListAsync().Result.Count();
    }
    
}