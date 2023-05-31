using DocSeeker.API.Appointments.Domain.Models;
using DocSeeker.API.Shared.Domain.Services.Communication;

namespace DocSeeker.API.Appointments.Domain.Services.Communication;

public class AppointmentResponse : BaseResponse<Appointment>
{
    public AppointmentResponse(string message) : base(message)
    {
    }
    public AppointmentResponse(Models.Appointment resource) : base(resource)
    {
    }
}