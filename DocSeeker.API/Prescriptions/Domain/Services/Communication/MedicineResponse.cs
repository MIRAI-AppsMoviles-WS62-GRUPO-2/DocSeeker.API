using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Shared.Domain.Services.Communication;

namespace DocSeeker.API.Prescriptions.Domain.Services.Communication;

public class MedicineResponse: BaseResponse<Medicine>
{
    public MedicineResponse(string message) : base(message)
    {
    }

    public MedicineResponse(Medicine resource) : base(resource)
    {
    }
}