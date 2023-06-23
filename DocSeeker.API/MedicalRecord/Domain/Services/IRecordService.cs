using DocSeeker.API.MedicalRecord.Domain.Models;
using DocSeeker.API.MedicalRecord.Domain.Services.Communication;

namespace DocSeeker.API.MedicalRecord.Domain.Services;

public interface IRecordService
{
    Task<IEnumerable<Record>> ListAsync();
    Task<RecordResponse> SaveAsync(Record record);
    Task<RecordResponse> UpdateAsync(int id, Record record);
    Task<RecordResponse> DeleteAsync(int id);
}