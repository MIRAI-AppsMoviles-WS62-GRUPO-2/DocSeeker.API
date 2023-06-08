using AutoMapper;
using DocSeeker.API.MedicalAppointment.Domain.Models;
using DocSeeker.API.MedicalAppointment.Resources;

namespace DocSeeker.API.MedicalAppointment.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveAppointmentResource, Appointment>();
    }
}