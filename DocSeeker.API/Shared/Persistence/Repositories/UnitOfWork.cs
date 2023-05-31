using DocSeeker.API.Shared.Domain.Repositories;
using DocSeeker.API.Shared.Persistence.Contexts;

namespace DocSeeker.API.Shared.Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{
    // AppDbContext is a class created by us
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    // We generate a small abstraction layer so that the infrastructure isn't
    // directly related to the service layer. So that there is no coupling
    // between the Persistence and Services layer.
    public async Task CompleteAsync()
    {
        // Save all changes made in this context to the Database
        await _context.SaveChangesAsync();
    }
}