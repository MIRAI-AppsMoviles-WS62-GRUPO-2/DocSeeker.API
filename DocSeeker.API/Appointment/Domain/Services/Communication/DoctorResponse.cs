using DocSeeker.API.Appointment.Domain.Models;
using DocSeeker.API.Shared.Domain.Services.Communication;

namespace DocSeeker.API.Appointment.Domain.Services.Communication;

public class DoctorResponse : BaseResponse<Doctor>
{
    public DoctorResponse(string message) : base(message)
    {
    }

    public DoctorResponse(Doctor resource) : base(resource)
    {
    }
}