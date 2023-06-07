using Docseeker.API.Profiles.Domain.Models;
using Docseeker.API.Profiles.Domain.Repositories;
using DocSeeker.API.Shared.Persistence.Contexts;
using DocSeeker.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Docseeker.API.Profiles.Persistence.Repositories;

public class PatientRepository :  BaseRepository, IPatientRepository
{
    public PatientRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Patient>> ListAsync()
    {
        return await _context.Patients.ToListAsync(); // cambio sutil si tiene una dependencia en el model
    }

    public async Task AddAsync(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
    }

    public async Task<Patient> FindByIdAsync(int id)
    {
        return await _context.Patients.FindAsync(id);
    }

    public void Update(Patient patient)
    { 
        _context.Patients.Update(patient);   
    }

    public void Remove(Patient patient)
    {
        _context.Patients.Remove(patient);
    }
}