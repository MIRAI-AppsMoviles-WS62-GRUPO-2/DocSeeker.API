using AutoMapper;
using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Prescriptions.Resources;

namespace DocSeeker.API.Prescriptions.Mapping;

// In this file we are mapping Models to DTOs
public class ModelToResourceProfile: AutoMapper.Profile // We have a file called Profile, that is a problem.
{
    public ModelToResourceProfile()
    {
        CreateMap<Prescription, PrescriptionResource>();
        CreateMap<Medicine, MedicineResource>();
    }
}