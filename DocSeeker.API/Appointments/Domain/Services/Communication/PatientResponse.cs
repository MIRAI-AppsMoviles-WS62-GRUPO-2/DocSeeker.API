using DocSeeker.API.Appointments.Domain.Models;
using DocSeeker.API.Shared.Domain.Services.Communication;

namespace DocSeeker.API.Appointments.Domain.Services.Communication;

public class PatientResponse : BaseResponse<Patient>
{
    public PatientResponse(string message) : base(message)
    {
    }
    public PatientResponse(Patient resource) : base(resource)
    {
    }
}