using Docseeker.API.MedicalAppointment.Domain.Models;
using DocSeeker.API.Shared.Domain.Services.Communication;

namespace Docseeker.API.MedicalAppointment.Domain.Services;

public class AppointmentResponse : BaseResponse<Appointment>
{
    public AppointmentResponse(string message) : base(message)
    {
    }

    public AppointmentResponse(Appointment resource) : base(resource)
    {
    }
}