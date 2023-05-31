using AutoMapper;
using DocSeeker.API.Appointments.Domain.Models;
using DocSeeker.API.Appointments.Domain.Services.Communication;

namespace DocSeeker.API.Appointments.Mapping;

public class ModelToResourceProfile : Profile
{
    protected ModelToResourceProfile()
    {
        CreateMap<Doctor, DoctorResponse>();
        CreateMap<Patient, PatientResponse>();
        CreateMap<Appointment, AppointmentResponse>();
    }
}