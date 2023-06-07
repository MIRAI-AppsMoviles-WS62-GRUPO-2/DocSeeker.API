using AutoMapper; 
using Docseeker.API.Profiles.Domain.Models;
using Docseeker.API.Profiles.Resources;

namespace Docseeker.API.Profiles.Mapping;

public class ResourceToModelProfile : Profile // This is the mapping from Resource to Model
{
    public ResourceToModelProfile() 
    {
        CreateMap<SaveDoctorResource, Doctor>(); // This is the mapping from SaveDoctorResource to Doctor
        CreateMap<SavePatientResource, Patient>(); // This is the mapping from SavePatientResource to Patient
    }
}