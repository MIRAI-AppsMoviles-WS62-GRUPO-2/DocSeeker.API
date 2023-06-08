using AutoMapper;
using DocSeeker.API.MedicalRecord.Domain.Models;
using DocSeeker.API.MedicalRecord.Resources;

namespace DocSeeker.API.MedicalRecord.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveRecordResource, Record>();
    }
}
