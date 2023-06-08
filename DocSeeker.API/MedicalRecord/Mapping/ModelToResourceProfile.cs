using AutoMapper;
using DocSeeker.API.MedicalRecord.Domain.Models;
using DocSeeker.API.MedicalRecord.Resources;

namespace DocSeeker.API.MedicalRecord.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Record, RecordResource>();
    }
}

