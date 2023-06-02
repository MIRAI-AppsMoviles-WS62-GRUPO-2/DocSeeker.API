using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Prescriptions.Domain.Repositories;
using DocSeeker.API.Shared.Persistence.Contexts;
using DocSeeker.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DocSeeker.API.Prescriptions.Persistence.Repositories;

// Rider helps us create the functions, but we have to specify which functions
// are async.
public class MedicineRepository: BaseRepository, IMedicineRepository
{
    public MedicineRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Medicine>> ListAsync()
    {
        // We can use .Include() to get information of an object related
        // with out current object
        return await _context.Medicines.ToListAsync();
    }

    public async Task<IEnumerable<Medicine>> FindByPrescriptionIdAsync(int prescriptionId)
    {
        return await _context.Medicines
            .Where(m => m.PrescriptionId == prescriptionId)
            .ToListAsync();
    }

    public async Task AddAsync(Medicine medicine)
    {
        await _context.Medicines.AddAsync(medicine);
    }

    public void Update(Medicine medicine)
    {
        _context.Medicines.Update(medicine);
    }

    public void Remove(Medicine medicine)
    {
        _context.Medicines.Remove(medicine);
    }
}