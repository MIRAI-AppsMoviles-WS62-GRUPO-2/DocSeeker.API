using DocSeeker.API.MedicalRecord.Domain.Models;
using DocSeeker.API.Shared.Domain.Services.Communication;

namespace DocSeeker.API.MedicalRecord.Domain.Services.Communication;

public class RecordResponse : BaseResponse<Record>
{
    public RecordResponse(string message) : base(message)
    {
    }

    public RecordResponse(Record resource) : base(resource)
    {
    }
}