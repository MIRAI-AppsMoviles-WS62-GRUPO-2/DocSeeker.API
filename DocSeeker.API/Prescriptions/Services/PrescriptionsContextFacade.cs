using DocSeeker.API.Prescriptions.Interfaces.Internal;

namespace DocSeeker.API.Prescriptions.Services;

public class PrescriptionsContextFacade: IPrescriptionsContextFacade
{
    private readonly PrescriptionService _prescriptionService;
    private readonly MedicineService _medicineService;
    
    public int TotalPrescriptions()
    {
        return _prescriptionService.ListAsync().Result.Count();
    }

    public int TotalMedicines()
    {
        return _medicineService.ListAsync().Result.Count();
    }
}