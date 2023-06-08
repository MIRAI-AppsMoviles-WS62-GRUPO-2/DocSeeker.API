using DocSeeker.API.MedicalRecord.Domain.Models;

namespace DocSeeker.API.MedicalRecord.Domain.Repositories;

public interface IRecordRepository
{
    Task<IEnumerable<Record>> ListAsync();
    Task AddAsync(Record record);
    Task<Record> FindByIdAsync(int id);
    void Update(Record record);
    void Remove(Record record);
}