using DocSeeker.API.Appointments.Domain.Models;
using DocSeeker.API.Appointments.Domain.Repositories;
using DocSeeker.API.Shared.Persistence.Contexts;
using DocSeeker.API.Shared.Persistence.Repositories;

namespace DocSeeker.API.Appointments.Persistence.Repositories;

public class DoctorRepository : BaseRepository, IDoctorRepository
{
    public DoctorRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<Doctor>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    public void Update(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    public void Remove(Doctor doctor)
    {
        throw new NotImplementedException();
    }
}