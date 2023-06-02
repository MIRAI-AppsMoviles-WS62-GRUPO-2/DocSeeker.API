using AutoMapper; 
using DocSeeker.API.Profile.Domain.Models;
using DocSeeker.API.Profile.Resources;

namespace DocSeeker.API.Profile.Mapping;

public class ResourceToModelProfile: AutoMapper.Profile // We have a file called Profile, that is a problem.
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveDoctorResource, Doctor>();
    }
}