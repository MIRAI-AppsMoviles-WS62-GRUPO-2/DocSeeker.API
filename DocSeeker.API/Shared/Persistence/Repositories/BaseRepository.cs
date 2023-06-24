using DocSeeker.API.Shared.Persistence.Contexts;

namespace DocSeeker.API.Shared.Persistence.Repositories;

// We crete a base repository class
public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}