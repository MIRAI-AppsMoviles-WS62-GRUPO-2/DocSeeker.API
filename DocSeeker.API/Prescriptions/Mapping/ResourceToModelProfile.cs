using AutoMapper;
using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Prescriptions.Resources;

namespace DocSeeker.API.Prescriptions.Mapping;

// In this file we are mapping DTOs to Models
public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePrescriptionResource, Prescription>();
        CreateMap<SaveMedicineResource, Medicine>();
    }
}