using AutoMapper;
using DocSeeker.API.Profile.Domain.Models;
using DocSeeker.API.Profile.Resources;

namespace DocSeeker.API.Profile.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile // We have a file called Profile, that is a problem.
{
    public ModelToResourceProfile()
    {
        CreateMap<Doctor, DoctorResource>();
    }
}