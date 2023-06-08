using AutoMapper; 
using DocSeeker.API.Profiles.Domain.Models;
using DocSeeker.API.Profiles.Resources;

namespace DocSeeker.API.Profiles.Mapping;

public class ResourceToModelProfile : Profile // This is the mapping from Resource to Model
{
    public ResourceToModelProfile() 
    {
        CreateMap<SaveDoctorResource, Doctor>(); // This is the mapping from SaveDoctorResource to Doctor
        CreateMap<SavePatientResource, Patient>(); // This is the mapping from SavePatientResource to Patient
    }
}