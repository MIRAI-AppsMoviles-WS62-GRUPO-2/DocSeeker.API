using AutoMapper;
using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Prescriptions.Resources;

namespace DocSeeker.API.Prescriptions.Mapping;

public class ModelToResourceProfile: Profile
{
    protected ModelToResourceProfile()
    {
        CreateMap<Prescription, PrescriptionResource>();
        CreateMap<Medicine, MedicineResource>();
        CreateMap<Doctor, DoctorResource>();
    }
}