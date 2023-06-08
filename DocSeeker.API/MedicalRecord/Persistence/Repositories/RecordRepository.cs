using DocSeeker.API.MedicalRecord.Domain.Models;
using DocSeeker.API.MedicalRecord.Domain.Repositories;
using DocSeeker.API.Shared.Persistence.Contexts;
using DocSeeker.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DocSeeker.API.MedicalRecord.Persistence.Repositories;

public class RecordRepository : BaseRepository, IRecordRepository
{
    public RecordRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Record>> ListAsync()
    {
        return await _context.Records.ToListAsync();
    }

    public async Task AddAsync(Record record)
    {
        await _context.Records.AddAsync(record);
    }

    public async Task<Record> FindByIdAsync(int id)
    {
        return await _context.Records.FindAsync(id);
    }

    public void Update(Record record)
    {
        _context.Records.Update(record);
    }

    public void Remove(Record record)
    {
        _context.Records.Remove(record);
    }
}