using AutoMapper;
using Docseeker.API.MedicalAppointment.Domain.Models;
using Docseeker.API.MedicalAppointment.Resources;

namespace Docseeker.API.MedicalAppointment.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Appointment, AppointmentResource>();
    }
}