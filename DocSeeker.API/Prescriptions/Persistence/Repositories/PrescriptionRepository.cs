using DocSeeker.API.Prescriptions.Domain.Models;
using DocSeeker.API.Prescriptions.Domain.Repositories;
using DocSeeker.API.Shared.Persistence.Contexts;
using DocSeeker.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DocSeeker.API.Prescriptions.Persistence.Repositories;

// Rider helps us create the functions, but we have to specify which functions
// are async.
public class PrescriptionRepository: BaseRepository, IPrescriptionRepository
{
    public PrescriptionRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Prescription>> ListAsync()
    {
        return await _context.Prescriptions.ToListAsync();
    }

    public async Task<IEnumerable<Prescription>> FindByDoctorIdAsync(int doctorId)
    {
        return await _context.Prescriptions
            .Where(p => p.DoctorId == doctorId)
            .ToListAsync();
    }

    public async Task AddAsync(Prescription prescription)
    {
        await _context.Prescriptions.AddAsync(prescription);
    }

    public void Update(Prescription prescription)
    {
        _context.Prescriptions.Update(prescription);
    }

    public void Remove(Prescription prescription)
    {
        _context.Prescriptions.Remove(prescription);
    }
}