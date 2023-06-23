using AutoMapper;
using DocSeeker.API.MedicalAppointment.Domain.Models;
using DocSeeker.API.MedicalAppointment.Resources;

namespace DocSeeker.API.MedicalAppointment.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Appointment, AppointmentResource>();
    }
}