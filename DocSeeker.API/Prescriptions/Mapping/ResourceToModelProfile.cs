using AutoMapper;
using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Prescriptions.Resources;

namespace DocSeeker.API.Prescriptions.Mapping;

// In this file we are mapping DTOs to Models
public class ResourceToModelProfile: AutoMapper.Profile // We have a file called Profile, that is a problem.
{
    protected ResourceToModelProfile()
    {
        CreateMap<SavePrescriptionResource, Prescription>();
        CreateMap<SaveMedicineResource, Medicine>();
    }
}