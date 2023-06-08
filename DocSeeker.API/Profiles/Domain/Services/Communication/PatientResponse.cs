using DocSeeker.API.Profiles.Domain.Models;
using DocSeeker.API.Shared.Domain.Services.Communication;

namespace DocSeeker.API.Profiles.Domain.Services.Communication;

public class PatientResponse : BaseResponse<Patient>
{
    public PatientResponse(string message) : base(message)
    {
    }

    public PatientResponse(Patient resource) : base(resource)
    {
    }
}