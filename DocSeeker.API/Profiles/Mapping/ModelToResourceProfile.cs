using AutoMapper;
using DocSeeker.API.Profiles.Domain.Models;
using DocSeeker.API.Profiles.Resources;

namespace DocSeeker.API.Profiles.Mapping;

public class ModelToResourceProfile : Profile // This is the mapping from Model to Resource
{
    public ModelToResourceProfile()
    {
        CreateMap<Doctor, DoctorResource>(); // This is the mapping from Doctor to DoctorResource
        CreateMap<Patient, PatientResource>(); // This is the mapping from Patient to PatientResource
    }
}