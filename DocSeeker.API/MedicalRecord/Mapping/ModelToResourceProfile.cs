using AutoMapper;
using Docseeker.API.MedicalRecord.Domain.Models;
using Docseeker.API.MedicalRecord.Resources;

namespace DocSeeker.API.MedicalRecord.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Record, RecordResource>();
    }
}

