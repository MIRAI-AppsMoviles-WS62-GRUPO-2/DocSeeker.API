using DocSeeker.API.MedicalAppointment.Domain.Models;
using DocSeeker.API.Shared.Domain.Services.Communication;

namespace DocSeeker.API.MedicalAppointment.Domain.Services.Communication;

public class AppointmentResponse : BaseResponse<Appointment>
{
    public AppointmentResponse(string message) : base(message)
    {
    }

    public AppointmentResponse(Appointment resource) : base(resource)
    {
    }
}