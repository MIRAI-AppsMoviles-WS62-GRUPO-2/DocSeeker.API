using AutoMapper;
using DocSeeker.API.Appointments.Domain.Models;
using DocSeeker.API.Appointments.Resources;

namespace DocSeeker.API.Appointments.Mapping;

public class ResourceToModelProfile : Profile
{
    protected ResourceToModelProfile()
    {
        CreateMap<SaveDoctorResource, Doctor>();
        CreateMap<SavePatientResource, Patient>();
        CreateMap<SaveAppointmentResource, Appointment>();
    }
}