
using DocSeeker.API.Appointments.Domain.Models;
using DocSeeker.API.Shared.Domain.Services.Communication;

namespace DocSeeker.API.Appointments.Domain.Services.Communication;

public class DoctorResponse : BaseResponse<Doctor>
{
    public DoctorResponse(string message) : base(message)
    {
    }

    public DoctorResponse(Doctor resource) : base(resource)
    {
    }
}