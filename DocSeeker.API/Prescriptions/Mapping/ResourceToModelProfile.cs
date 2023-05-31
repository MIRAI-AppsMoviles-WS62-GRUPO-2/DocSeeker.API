using AutoMapper;
using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Prescriptions.Resources;

namespace DocSeeker.API.Prescriptions.Mapping;

public class ResourceToModelProfile: Profile
{
    protected ResourceToModelProfile()
    {
        CreateMap<SavePrescriptionResource, Prescription>();
        CreateMap<SaveMedicineResource, Medicine>();
        CreateMap<SaveDoctorResource, Doctor>();
    }
}