using DocSeeker.API.News.Domain.Models;
using DocSeeker.API.News.Domain.Repositories;
using DocSeeker.API.Shared.Persistence.Contexts;
using DocSeeker.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DocSeeker.API.News.Persistence.Repositories;

public class NewRepository : BaseRepository, INewRepository
{
    public NewRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<New>> ListAsync()
    {
        return await _context.News.ToListAsync();
    }

    public async Task AddAsync(New news)
    {
        await _context.News.AddAsync(news);
    }

    public async Task<New> FindByIdAsync(int id)
    {
        return await _context.News.FindAsync(id);
    }

    public void Update(New news)
    {
        _context.News.Update(news);
    }

    public void Remove(New news)
    {
        _context.News.Remove(news);
    }
}