using AutoMapper;
using DocSeeker.API.Profiles.Domain.Models;
using DocSeeker.API.Profiles.Resources;

namespace DocSeeker.API.Profiles.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Doctor, DoctorResource>();
    }
}